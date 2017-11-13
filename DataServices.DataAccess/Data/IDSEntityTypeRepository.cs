// <copyright file="IEntityTypeRepository.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Data
{
    /// <summary>
    /// Repository for accessing all of the available Entity Types defined in the system.
    /// </summary>
    public interface IDSEntityTypeRepository
    {
        /// <summary>
        /// Gets the entity definition for the supplied name.
        /// </summary>
        /// <param name="name">Name of the entity definition to return.</param>
        /// <returns>Entity definition for the supplied name.</returns>
        DSEntityType Get(string name);

        /// <summary>
        /// Gets the element referenced by the supplied path.
        /// </summary>
        /// <param name="entityType">Entity Type where the supplied path starts.</param>
        /// <param name="path">Path to the element.</param>
        /// <returns>The element referenced by the supplied path, or 'null' if not found.</returns>
        DSEntityTypeElement GetElement(DSEntityType entityType, string path);

        /// <summary>
        /// Automatically load all of the available entity types into cache.
        /// </summary>
        void Preload();
    }
}
