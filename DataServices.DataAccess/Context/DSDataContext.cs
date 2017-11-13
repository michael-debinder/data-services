// <copyright file="DSDataContext.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Context
{
    using System.Configuration;
    using Caching;
    using SDK.API;

    /// <summary>
    /// Wrapper class for using the api context.
    /// </summary>
    public class DSDataContext
    {
        /// <summary>
        /// Internal cache provider.
        /// </summary>
        private IBaseCaching _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="DSDataContext"/> class.
        /// </summary>
        /// <param name="cacheProvider">Link to a cache provider for the repository.</param>
        /// <param name="apiContext">The current API Context.</param>
        public DSDataContext(IBaseCaching cacheProvider, DSAPIContext apiContext)
        {
            _cache = cacheProvider;
            APIContext = apiContext;
        }

        /// <summary>
        /// Gets the API Context.
        /// </summary>
        public DSAPIContext APIContext { get; private set; }

        /// <summary>
        /// Get the connection string for the current context.
        /// </summary>
        /// <returns>The connection string for the current context.</returns>
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}
