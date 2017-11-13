// <copyright file="IBaseCaching.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Caching
{
    /// <summary>
    /// Interface for all caching implementations.
    /// </summary>
    public interface IBaseCaching
    {
        /// <summary>
        /// Determine if cache currently contains supplied key.
        /// </summary>
        /// <param name="key">Key to look for in cache.</param>
        /// <returns>True if key found, otherwise false.</returns>
        bool Contains(string key);

        /// <summary>
        /// Retrieve value from cache for supplied key.
        /// </summary>
        /// <param name="key">Key to look for in cache.</param>
        /// <returns>Value found for supplied key.</returns>
        object Get(string key);

        /// <summary>
        /// Add value to cache for supplied key.
        /// </summary>
        /// <param name="key">Key to add to cache.</param>
        /// <param name="value">Value to cache for supplied key.</param>
        void Set(string key, object value);
    }
}
