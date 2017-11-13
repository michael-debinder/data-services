// <copyright file="DSAPIContext.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.API
{
    /// <summary>
    /// Security context for someone making an API call. Helps define the User and Site information.
    /// </summary>
    public class DSAPIContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSAPIContext"/> class.
        /// </summary>
        public DSAPIContext()
        {
        }

        /// <summary>
        /// Gets or sets the SessionID.
        /// </summary>
        public string SessionID { get; set; }

        /// <summary>
        /// Gets or sets the UserID.
        /// </summary>
        public int UserID { get; set; }
    }
}
