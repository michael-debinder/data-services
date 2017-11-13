// <copyright file="MissingFromCacheException.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Exceptions
{
    using System;

    /// <summary>
    /// Exception thrown when requested item missing from cache.
    /// </summary>
    public class MissingFromCacheException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingFromCacheException"/> class class with a specified message.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        public MissingFromCacheException(string msg) : base(msg)
        {
        }
    }
}
