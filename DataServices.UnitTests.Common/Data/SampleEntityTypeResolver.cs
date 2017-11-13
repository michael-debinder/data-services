// <copyright file="SampleEntityTypeResolver.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.UnitTests.Common.Data
{
    using System.Collections.Generic;
    using DataAccess.Data;
    using EntityTypes;

    /// <summary>
    /// This is a manual set of items that would normally be built by Metadata.
    /// </summary>
    public class SampleEntityTypeResolver : IDSEntityTypeResolver
    {
        /// <summary>Storage for some one-off entity types for certain tests.</summary>
        private Dictionary<string, DSEntityType> tempItems;

        /// <summary>
        /// Storage for the list of all available types.
        /// </summary>
        private List<string> _types = new List<string>
        {
            "TestObjectA",
            "TestObjectB",
            "TestObjectC"
        };

        /// <summary>
        /// Gets the list of all available types.
        /// </summary>
        /// <returns>The list of all available types.</returns>
        public List<string> Types
        {
            get
            {
                return _types;
            }
        }

        /// <summary>
        /// Add a temporary Entity Type for testing.
        /// </summary>
        /// <param name="name">Name of the Entity Type</param>
        /// <param name="entityType">The Entity Type definition.</param>
        public void AddTemp(string name, DSEntityType entityType)
        {
            if (tempItems == null)
            {
                tempItems = new Dictionary<string, DSEntityType>();
            }

            tempItems[name] = entityType;
        }

        /// <summary>
        /// Gets the entity definition for the supplied name.
        /// </summary>
        /// <param name="name">Name of the entity definition to return.</param>
        /// <returns>Entity definition for the supplied name.</returns>
        /// <exception cref="CacheNotInitializedException">Throws when cache provider is not initialized through constructor.</exception>
        public DSEntityType Get(string name)
        {
            // First check the Temp Items
            if (tempItems != null && tempItems.ContainsKey(name))
            {
                return tempItems[name];
            }

            switch (name)
            {
                case "TestObjectA":
                    return new TestObjectA();

                case "TestObjectB":
                    return new TestObjectB();

                case "TestObjectC":
                    return new TestObjectC();

                default:
                    return null;
            }
        }
    }
}
