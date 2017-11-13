// <copyright file="EntityTypeRepository.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Data
{
    using System;
    using Caching;
    using EntityTypes;
    using Exceptions;
    using SDK.Data;

    /// <summary>
    /// Repository for accessing all of the available Entity Types defined in the system.
    /// </summary>
    public class DSEntityTypeRepository : IDSEntityTypeRepository
    {
        /// <summary>
        /// Template for generating a unique cache key.
        /// </summary>
        private const string CacheKeyTemplate = "EntityType_{0}";

        /// <summary>
        /// Internal cache provider.
        /// </summary>
        private IBaseCaching _cache;

        /// <summary>
        /// Internal cache provider.
        /// </summary>
        private IDSEntityTypeResolver _resolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="DSEntityTypeRepository"/> class.
        /// </summary>
        /// <param name="cacheProvider">Link to a cache provider for the repository.</param>
        /// <param name="resolver">Link to a resolver for retrieving the entity types.</param>
        public DSEntityTypeRepository(IBaseCaching cacheProvider, IDSEntityTypeResolver resolver)
        {
            _cache = cacheProvider;
            _resolver = resolver;
        }

        /// <summary>
        /// Gets the entity definition for the supplied name.
        /// </summary>
        /// <param name="name">Name of the entity definition to return.</param>
        /// <returns>Entity definition for the supplied name.</returns>
        /// <exception cref="CacheNotInitializedException">Throws when cache provider is not initialized through constructor.</exception>
        public DSEntityType Get(string name)
        {
            if (_cache == null)
            {
                throw new CacheNotInitializedException("Cache provider is not set.");
            }

            var cacheKey = Key(name);
            if (!_cache.Contains(cacheKey))
            {
                var newEntityType = _resolver.Get(name);
                _cache.Set(cacheKey, newEntityType);
                return newEntityType;
            }

            var entityType = _cache.Get(cacheKey) as DSEntityType;

            return entityType;
        }

        /// <summary>
        /// Gets the element referenced by the supplied path.
        /// </summary>
        /// <param name="entityType">Entity Type where the supplied path starts.</param>
        /// <param name="path">Path to the element.</param>
        /// <returns>The element referenced by the supplied path, or 'null' if not found.</returns>
        public DSEntityTypeElement GetElement(DSEntityType entityType, string path)
        {
            if (_cache == null)
            {
                throw new CacheNotInitializedException("Cache provider is not set.");
            }

            string cacheKey = Key(string.Format("{0}.{1}", entityType.Name, path));
            if (_cache.Contains(cacheKey))
            {
                return (DSEntityTypeElement)_cache.Get(cacheKey);
            }

            DSEntityTypeElement element = null;
            var currentEntity = entityType;
            var pathParts = path.Split('.');

            for (var i = 0; i < pathParts.Length; i++)
            {
                if (!currentEntity.Elements.ContainsKey(pathParts[i]))
                {
                    return null;
                }

                element = currentEntity.Elements[pathParts[i]];
                if (i < pathParts.Length - 1 && element.DataType != DSElementTypeEnum.Reference)
                {
                    // We are not at the end of the path but cannot traverse to a Reference
                    return null;
                }

                // Traverse to the next Entity
                if (element.DataType == DSElementTypeEnum.Reference)
                {
                    currentEntity = Get(element.ReferenceTypeName);
                }
            }
            
            _cache.Set(cacheKey, element);
            return element;
        }

        /// <summary>
        /// Automatically load all of the available entity types into cache.
        /// </summary>
        public void Preload()
        {
            foreach (var entityType in _resolver.Types)
            {
                Get(entityType);
            }
        }

        /// <summary>
        /// Generates a unique cache key based on the supplied name.
        /// </summary>
        /// <param name="name">Name of the entity definition.</param>
        /// <returns>A unique cache key based on the supplied name.</returns>
        private string Key(string name)
        {
            return string.Format(CacheKeyTemplate, name);
        }
    }
}
