// <copyright file="SearchSampleData.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.UnitTests.Common.Data
{
    using SDK.Search;

    /// <summary>
    /// Helper class for some commonly used DSSearch instances.
    /// </summary>
    public static class SearchSampleData
    {
        /// <summary>
        /// Gets a DSSearch instance on TestObjectA with the "Foo" element.
        /// </summary>
        public static DSSearch SimpleTestObjectASearch
        {
            get
            {
                var simpleSearch = new DSSearch();
                simpleSearch.Type = "TestObjectA";
                simpleSearch.AddSelect("Foo");

                return simpleSearch;
            }
        }

        /// <summary>
        /// Gets a DSSearch instance on TestObjectB with the "Foo" element.
        /// </summary>
        public static DSSearch SimpleTestObjectBSearch
        {
            get
            {
                var simpleSearch = new DSSearch();
                simpleSearch.Type = "TestObjectB";
                simpleSearch.AddSelect("Foo");

                return simpleSearch;
            }
        }

        /// <summary>
        /// Gets a DSSearch instance on TestObjectB with the "Bar" element.
        /// </summary>
        public static DSSearch SimpleTestObjectB2Search
        {
            get
            {
                var simpleSearch = new DSSearch();
                simpleSearch.Type = "TestObjectB";
                simpleSearch.AddSelect("Bar");

                return simpleSearch;
            }
        }

        /// <summary>
        /// Gets a DSSearch instance on TestObjectB with the "Foo" element.
        /// </summary>
        public static DSSearch SimpleTestObjectCSearch
        {
            get
            {
                var simpleSearch = new DSSearch();
                simpleSearch.Type = "TestObjectC";
                simpleSearch.AddSelect("A");

                return simpleSearch;
            }

        }
    }
}
