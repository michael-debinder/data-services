// <copyright file="DSSearchBuildException.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Exceptions
{
    using System;

    /// <summary>
    /// Exception thrown when a DSSearch build process fails.
    /// </summary>
    public class DSSearchBuildException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSSearchBuildException"/> class with a specified message.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        public DSSearchBuildException(string msg) : base(msg)
        {
        }
    }
}
