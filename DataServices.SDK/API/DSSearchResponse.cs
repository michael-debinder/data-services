// <copyright file="DSSearchResponse.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.API
{
    using System.Collections.Generic;
    using Data;

    /// <summary>
    /// Results of a search containing either the requested data or error information.
    /// </summary>
    public class DSSearchResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSSearchResponse"/> class.
        /// </summary>
        public DSSearchResponse()
        {
        }

        /// <summary>
        /// Gets or sets the list of any error messages occurring during the search.
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Gets or sets the total records in the system matching the search criteria.
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Gets or sets the requested page of results from the search.
        /// </summary>
        public List<DSEntity> Results { get; set; }
    }
}
