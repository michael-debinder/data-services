// <copyright file="DataAccessController.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess
{
    using Caching;
    using Context;
    using Data;
    using Processors;
    using SDK.API;
    using Search;

    /// <summary>
    /// Main class to run Search Requests.
    /// </summary>
    public class DataAccessController
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
        /// Processor instance to run the searches.
        /// </summary>
        private IDSSearchProcessor _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessController"/> class.
        /// </summary>
        /// <param name="cacheProvider">Link to a cache provider for the repository.</param>
        /// <param name="entityTypeRepository">Definitions of all available entities in system.</param>
        /// <param name="processor">The Search Processor to utilize.</param>
        public DataAccessController(IBaseCaching cacheProvider, IDSEntityTypeRepository entityTypeRepository, IDSSearchProcessor processor)
        {
            _cache = cacheProvider;
            _entityTypeRepository = entityTypeRepository;
            _processor = processor;
        }

        /// <summary>
        /// Executes a supplied DSSearch against a SQL Server database.
        /// </summary>
        /// <param name="searchRequest">Search definition and context.</param>
        /// <returns>Results from the search or any erorr messages generated.</returns>
        public DSSearchResponse ExecuteSearch(DSSearchRequest searchRequest)
        {
            // This is the context specific to this call
            var ctx = new DSDataContext(_cache, searchRequest.APIContext);
            var search = searchRequest.Search;
            
            return _processor.ExecuteSearch(search, ctx);
        }
    }
}
