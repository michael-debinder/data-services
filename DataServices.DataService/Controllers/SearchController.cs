// <copyright file="SearchController.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataService.Controllers
{
    using System.Web.Http;
    using DataAccess;
    using DataAccess.Caching;
    using DataAccess.Data;
    using DataAccess.Processors;
    using SDK.API;

    /// <summary>
    /// Controller to receive API search calls and execute.
    /// </summary>
    public class SearchController : ApiController
    {
        /// <summary>
        /// Internal cache provider.
        /// </summary>
        private static IBaseCaching _cache;

        /// <summary>
        /// List of entity definitions known to the system.
        /// </summary>
        private static DataAccessController _dataAccess;

        /// <summary>
        /// Initializes static members of the <see cref="SearchController"/> class.
        /// </summary>
        static SearchController()
        {
            // TODO - Ultimately all of this should be handled by Unity (or some other IoC Container implementation).
            _cache = new MemoryCache();
            var entityTypeResolver = new DSStaticEntityTypeResolver();
            var entityTypeRepository = new DSEntityTypeRepository(_cache, entityTypeResolver);
            var processor = new DSSQLSearchProcessor(_cache, entityTypeRepository);

            _dataAccess = new DataAccessController(_cache, entityTypeRepository, processor);
        }
        
        /// <summary>
        /// Method for handling: POST api/search
        /// </summary>
        /// <param name="searchRequest">Incoming Search Request.</param>
        /// <returns>Search results or errors.</returns>
        [HttpPost]
        [Route("api/search")]
        public DSSearchResponse Search([FromBody] DSSearchRequest searchRequest)
        {
            return _dataAccess.ExecuteSearch(searchRequest);
        }
    }
}
