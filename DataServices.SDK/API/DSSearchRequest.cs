// <copyright file="DSSearchRequest.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.API
{
    using Search;

    /// <summary>
    /// Search request to be processed by the API.
    /// </summary>
    public class DSSearchRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSSearchRequest"/> class.
        /// </summary>
        public DSSearchRequest()
        {
        }

        /// <summary>
        /// Gets or sets the security information about user requesting search and the site to run it on.
        /// </summary>
        public DSAPIContext APIContext { get; set; }

        /// <summary>
        /// Gets or sets the search definition to execute.
        /// </summary>
        public DSSearch Search { get; set; }
    }
}