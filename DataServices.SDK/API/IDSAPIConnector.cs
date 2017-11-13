// <copyright file="IDSAPIConnector.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.API
{
    /// <summary>
    /// Interface representing all methods available in the API service to be handled.
    /// </summary>
    public interface IDSAPIConnector
    {
        /// <summary>
        /// Execute the supplied search request.
        /// </summary>
        /// <param name="searchRequest">Incoming Search Request.</param>
        /// <returns>Search results or errors.</returns>
        DSSearchResponse ExecuteSearch(DSSearchRequest searchRequest);
    }
}
