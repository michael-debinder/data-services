// <copyright file="DSSearchBuilderException.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Exceptions
{
    using System;

    /// <summary>
    /// Exception thrown when a DSSearch build process fails.
    /// </summary>
    public class SearchBuilderException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchBuilderException"/> class with a specified message.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        public SearchBuilderException(string msg) : base(msg)
        {
        }
    }
}
