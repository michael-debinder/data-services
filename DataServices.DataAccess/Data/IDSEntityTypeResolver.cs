// <copyright file="IEntityTypeResolver.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the retrieval of all the Entity MetaData. The initial "Static" implementation is one built by code 
    /// where everything is hard-coded into the class. If this proves to be too slow, other options would be to pull from
    /// the database directly or to pull from something like an XML file. Ultimately the idea would be for everything to
    /// end up in the IBaseCaching provider for optimal performance.
    /// </summary>
    public interface IDSEntityTypeResolver
    {
        /// <summary>
        /// Gets the list of all available types.
        /// </summary>
        /// <returns>The list of all available types.</returns>
        List<string> Types { get; }

        /// <summary>
        /// Gets the entity definition for the supplied name.
        /// </summary>
        /// <param name="name">Name of the entity definition to return.</param>
        /// <returns>Entity definition for the supplied name.</returns>
        DSEntityType Get(string name);
    }
}
