// <copyright file="IDSSearchProcessor.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Processors
{
    using Context;
    using SDK.API;
    using SDK.Search;

    /// <summary>
    /// Interface for processors to run DSSearch against storage.
    /// </summary>
    public interface IDSSearchProcessor
    {
        /// <summary>
        /// Executes a supplied DSSearch against appropriate storage.
        /// </summary>
        /// <param name="searchRequest">Search definition and context.</param>
        /// <param name="ctx">The current data context.</param>
        /// <returns>Results from the search or any erorr messages generated.</returns>
        DSSearchResponse ExecuteSearch(DSSearch searchRequest, DSDataContext ctx);
    }
}
