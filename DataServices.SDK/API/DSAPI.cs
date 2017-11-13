// <copyright file="DSAPI.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.API
{
    /// <summary>
    /// Main wrapper for the API method calls.
    /// </summary>
    public class DSAPI
    {
        /// <summary>
        /// Link to an API connection handler.
        /// </summary>
        private IDSAPIConnector _connector;

        /// <summary>
        /// Initializes a new instance of the <see cref="DSAPI"/> class with an API connection handler.
        /// </summary>
        /// <param name="connector">API connection handler.</param>
        public DSAPI(IDSAPIConnector connector)
        {
            _connector = connector;
        }

        /// <summary>
        /// Execute the supplied search request.
        /// </summary>
        /// <param name="searchRequest">The search request definition.</param>
        /// <returns>A search response with results.</returns>
        public DSSearchResponse ExecuteSearch(DSSearchRequest searchRequest)
        {
            return _connector.ExecuteSearch(searchRequest);
        }
    }
}
