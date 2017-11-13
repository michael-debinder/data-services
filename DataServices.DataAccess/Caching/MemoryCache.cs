// <copyright file="MemoryCache.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Caching
{
    using System.Collections.Generic;
    using Exceptions;

    /// <summary>
    /// Simple memory cache implementation. Not recommended for production use, but good for Unit Testing.
    /// </summary>
    public class MemoryCache : IBaseCaching
    {
        /// <summary>
        /// Dictionary to store cache.
        /// </summary>
        private Dictionary<string, object> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCache"/> class.
        /// </summary>
        public MemoryCache()
        {
            _cache = new Dictionary<string, object>();
        }

        /// <summary>
        /// Determine if cache currently contains supplied key.
        /// </summary>
        /// <param name="key">Key to look for in cache.</param>
        /// <returns>True if key found, otherwise false.</returns>
        public bool Contains(string key)
        {
            return _cache.ContainsKey(key);
        }

        /// <summary>
        /// Retrieve value from cache for supplied key.
        /// </summary>
        /// <param name="key">Key to look for in cache.</param>
        /// <returns>Value found for supplied key.</returns>
        /// <exception cref="MissingFromCacheException">Throws when key not found in cache.</exception>
        public object Get(string key)
        {
            if (!_cache.ContainsKey(key))
            {
                throw new MissingFromCacheException(string.Format("'{0}' not found in memory cache.", key));
            }

            return _cache[key];
        }

        /// <summary>
        /// Add value to cache for supplied key.
        /// </summary>
        /// <param name="key">Key to add to cache.</param>
        /// <param name="value">Value to cache for supplied key.</param>
        public void Set(string key, object value)
        {
            _cache[key] = value;
        }
    }
}
