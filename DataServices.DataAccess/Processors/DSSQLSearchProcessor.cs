// <copyright file="DSSQLSearchProcessor.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Processors
{
    using System.Data;
    using System.Data.SqlClient;
    using Caching;
    using Context;
    using Data;
    using SDK.API;
    using SDK.Data;
    using SDK.Search;
    using Search;

    /// <summary>
    /// Implementation used to execute a DSSearch against a SQL Database Query.
    /// </summary>
    public class DSSQLSearchProcessor : IDSSearchProcessor
    {
        /// <summary>
        /// Internal cache provider.
        /// </summary>
        private IBaseCaching _cache;

        /// <summary>
        /// List of entity definitions known to the system.
        /// </summary>
        private IDSEntityTypeRepository _entityTypeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DSSQLSearchProcessor"/> class.
        /// </summary>
        /// <param name="cacheProvider">Link to a cache provider for the repository.</param>
        /// <param name="entityTypeRepository">Definitions of all available entities in system.</param>
        public DSSQLSearchProcessor(IBaseCaching cacheProvider, IDSEntityTypeRepository entityTypeRepository)
        {
            _cache = cacheProvider;
            _entityTypeRepository = entityTypeRepository;
        }

        /// <summary>
        /// Executes a supplied DSSearch against a SQL Server database.
        /// </summary>
        /// <param name="search">The Search to execute.</param>
        /// <param name="ctx">The current data context.</param>
        /// <returns>Results from the search or any erorr messages generated.</returns>
        public DSSearchResponse ExecuteSearch(DSSearch search, DSDataContext ctx)
        {
            var queryBuilder = new DSSQLSearchBuilder(); // TODO - should this be injected? possible to use different one with different Filter Builder for ex.
            var searchParser = new DSSearchParser(_entityTypeRepository, queryBuilder);
            searchParser.BuildSearch(search);

            // TODO - Implement the Parameterize capability
            var sql = queryBuilder.ToString();

            var connString = ctx.GetConnectionString();
            var results = new DataTable();
            using (var da = new SqlDataAdapter(sql, connString))
            {
                da.Fill(results);
            }

            int totalRecords = results.Rows.Count;
            if (totalRecords == search.PageSize)
            {
                // We need to see if there are more than just this page
                var countResults = new DataTable();
                using (var da = new SqlDataAdapter(queryBuilder.ToStringForCount(), connString))
                {
                    da.Fill(countResults);
                }

                totalRecords = (int)countResults.Rows[0][0];
            }
            else
            {
                totalRecords += (search.Page - 1) * search.PageSize;
            }

            return new DSSearchResponse
            {
                Errors = null,
                TotalRecords = totalRecords,
                Results = results.ToEntityList<DSEntity>()
            };
        }
    }
}
