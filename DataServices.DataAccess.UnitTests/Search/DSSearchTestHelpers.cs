// <copyright file="DSSearchTestHelpers.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.UnitTests.Search
{
    using DataAccess.Data;
    using DataAccess.Search;
    using SDK.Search;

    /// <summary>
    /// Helper functions to set up common data structures for running tests.
    /// </summary>
    public static class DSSearchTestHelpers
    {
        /// <summary>
        /// Generate a Search Builder instance based on the supplied information.
        /// </summary>
        /// <param name="entityTypeRepository">List of entity definitions known to the system.</param>
        /// <param name="search">Search instance to build.</param>
        /// <param name="parameterize">When true, will parameterize the search, otherwise will not.</param>
        /// <returns>Search Builder instance run against supplied Search.</returns>
        public static IDSSearchBuilder CreateSearchBuilder(IDSEntityTypeRepository entityTypeRepository, DSSearch search, bool parameterize = false)
        {
            DSSearchParser searchParser;
            return CreateSearchBuilder(entityTypeRepository, search, out searchParser, parameterize);
        }

        /// <summary>
        /// Generate a Search Builder instance based on the supplied information.
        /// </summary>
        /// <param name="entityTypeRepository">List of entity definitions known to the system.</param>
        /// <param name="search">Search instance to build.</param>
        /// <param name="searchParser">Output parameter to return the initialized Search Parser.</param>
        /// <param name="parameterize">When true, will parameterize the search, otherwise will not.</param>
        /// <returns>Search Builder instance run against supplied Search.</returns>
        public static IDSSearchBuilder CreateSearchBuilder(IDSEntityTypeRepository entityTypeRepository, DSSearch search, out DSSearchParser searchParser, bool parameterize = false)
        {
            var queryBuilder = new DSSQLSearchBuilder(parameterize);
            searchParser = new DSSearchParser(entityTypeRepository, queryBuilder);
            searchParser.BuildSearch(search);

            return queryBuilder;
        }

        /// <summary>
        /// Given an expected query result, append the supplied order clause, formatted appropriately.
        /// </summary>
        /// <param name="query">The query to format.</param>
        /// <param name="orderClause">The "ORDER BY" clause to append.</param>
        /// <returns>Formatted query result.</returns>
        public static string AddDefaultQueryOrder(string query, string orderClause)
        {
            return string.Format("{0} ORDER BY {1} OFFSET 0 ROWS FETCH NEXT 25 ROWS ONLY", query, orderClause);
        }
    }
}
