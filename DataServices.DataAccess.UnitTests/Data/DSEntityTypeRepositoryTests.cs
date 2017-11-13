// <copyright file="EntityTypeRepositoryTests.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.UnitTests.Data
{
    using Caching;
    using DataAccess.Data;
    using DataServices.UnitTests.Common.Data;
    using DataServices.UnitTests.Common.EntityTypes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests around the EntityTypeRepository.
    /// </summary>
    [TestClass]
    public class EntityTypeRepositoryTests
    {
        /// <summary>
        /// Caching implementation.
        /// </summary>
        private static IBaseCaching _cache;

        /// <summary>
        /// List of entity definitions known to the system.
        /// </summary>
        private static IDSEntityTypeRepository _entityTypeRepository;

        /// <summary>
        /// List of entity definitions known to the system.
        /// </summary>
        private static IDSEntityTypeResolver _entityTypeResolver;

        /// <summary>
        /// Initializes the class for the test run.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _entityTypeResolver = new SampleEntityTypeResolver();
            _cache = new MemoryCache();
            _entityTypeRepository = new DSEntityTypeRepository(_cache, _entityTypeResolver);
        }

        /// <summary>
        /// Tests that the EntityTypeRepository Get function successfully loads each item into cache.
        /// </summary>
        [TestMethod]
        public void TestGet()
        {
            foreach (var entityTypeName in _entityTypeResolver.Types)
            {
                Assert.IsFalse(_cache.Contains(GetKey(entityTypeName)), string.Format("Should not exist in cache yet: {0}.", entityTypeName));
            }

            foreach (var entityTypeName in _entityTypeResolver.Types)
            {
                var entityType = _entityTypeRepository.Get(entityTypeName);
                Assert.IsTrue(_cache.Contains(GetKey(entityTypeName)), string.Format("Should have been loaded to cache: {0}.", entityTypeName));
            }
        }

        /// <summary>
        /// Tests that the EntityTypeRepository GetElement function works and loads into cache.
        /// </summary>
        [TestMethod]
        public void TestGetElement()
        {
            var entityType = _entityTypeRepository.Get(TestObjectB.ClassName);
            var elementPath = "ObjectA.Foo";

            string cacheKey = string.Format("{0}.{1}", entityType.Name, elementPath);
            Assert.IsFalse(_cache.Contains(GetKey(cacheKey)), string.Format("Should not exist in cache yet: {0}.", cacheKey));

            var element = _entityTypeRepository.GetElement(entityType, elementPath);

            Assert.IsNotNull(element, "Should have found Foo.");
            Assert.AreEqual("Foo", element.Name, "Should have retrieved Foo.");

            Assert.IsTrue(_cache.Contains(GetKey(cacheKey)), string.Format("Should have been loaded to cache: {0}.", cacheKey));

            // Ensure single item paths work
            element = _entityTypeRepository.GetElement(entityType, "ObjectA");
            Assert.IsNotNull(element, "Should have found ObjectA.");
            Assert.AreEqual("ObjectA", element.Name, "Should have retrieved ObjectA.");

            // Ensure that bad paths return NULL
            element = _entityTypeRepository.GetElement(entityType, "Nothing");
            Assert.IsNull(element, "Should not have found Nothing.");

            element = _entityTypeRepository.GetElement(entityType, "ObjectA.Nothing");
            Assert.IsNull(element, "Should not have found ObjectA.Nothing.");

            element = _entityTypeRepository.GetElement(entityType, "ObjectA.Foo.Nothing");
            Assert.IsNull(element, "Should not have found ObjectA.Foo.Nothing.");
        }

        /// <summary>
        /// Tests that the EntityTypeRepository Preload function successfully loads things to cache.
        /// </summary>
        [TestMethod]
        public void TestPreload()
        {
            foreach (var entityTypeName in _entityTypeResolver.Types)
            {
                Assert.IsFalse(_cache.Contains(GetKey(entityTypeName)), string.Format("Should not exist in cache yet: {0}.", entityTypeName));
            }

            _entityTypeRepository.Preload();

            foreach (var entityTypeName in _entityTypeResolver.Types)
            {
                Assert.IsTrue(_cache.Contains(GetKey(entityTypeName)), string.Format("Should have been loaded to cache: {0}.", entityTypeName));
            }
        }

        /// <summary>
        /// Gets the cache key being used.
        /// </summary>
        /// <param name="entityTypeName">Name of the entity type.</param>
        /// <returns>The formatted cache key.</returns>
        private string GetKey(string entityTypeName)
        {
            return string.Format("EntityType_{0}", entityTypeName);
        }
    }
}
