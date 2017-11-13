// <copyright file="EntityTypeBuildException.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Exceptions
{
    using System;

    /// <summary>
    /// Exception thrown when the building of an entity definition runs into an issue.
    /// </summary>
    public class EntityTypeBuildException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityTypeBuildException"/> class class with a specified message.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        public EntityTypeBuildException(string msg) : base(msg)
        {
        }
    }
}
