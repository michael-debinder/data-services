// <copyright file="EntityTypeElement.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Data
{
    using SDK.Data;

    /// <summary>
    /// Definition of an element on an entity definition.
    /// </summary>
    public class DSEntityTypeElement
    {
        /// <summary>
        /// Gets or sets a value indicating whether the element can be null or not.
        /// </summary>
        public bool AllowNull { get; set; }

        /// <summary>
        /// Gets or sets the Name of the element for public consumption.
        /// </summary>
        public DSElementTypeEnum DataType { get; set; }

        /// <summary>
        /// Gets or sets the Name of the element for public consumption.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ReferenceTypeName representing an entity this element references.
        /// </summary>
        public string ReferenceTypeName { get; set; }

        /// <summary>
        /// Gets or sets the StorageName of the entity definition representing physical storage location.
        /// </summary>
        public string StorageName { get; set; }

        /// <summary>
        /// Gets or sets the VirtualPath of an element if it represents a referenced element.
        /// </summary>
        public string VirtualPath { get; set; }
    }
}
