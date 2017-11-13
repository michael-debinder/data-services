// <copyright file="CacheNotInitializedException.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Exceptions
{
    using System;

    /// <summary>
    /// Exception thrown when a class requires a cache and it is not set.
    /// </summary>
    public class CacheNotInitializedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheNotInitializedException"/> class class with a specified message.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        public CacheNotInitializedException(string msg) : base(msg)
        {
        }
    }
}
