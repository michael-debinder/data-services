// <copyright file="EntityType.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Data
{
    using System.Collections.Generic;
    using Exceptions;
    using SDK.Data;

    /// <summary>
    /// Base class for a definition of an entity in the system.
    /// </summary>
    public class DSEntityType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSEntityType"/> class.
        /// </summary>
        public DSEntityType()
        {
            Elements = new Dictionary<string, DSEntityTypeElement>();
        }

        /// <summary>
        /// Gets or sets the KeyName of the entity definition representing unique, primary key for physical storage.
        /// </summary>
        public string KeyName { get; protected set; }

        /// <summary>
        /// Gets or sets the Name of the entity definition for public consumption.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a ReadOnly entity type.
        /// </summary>
        public bool ReadOnly { get; protected set; }

        /// <summary>
        /// Gets or sets the StorageName of the entity definition representing physical storage location.
        /// </summary>
        public string StorageName { get; protected set; }

        /// <summary>
        /// Gets or sets the List of the data elements available for this entity definition.
        /// </summary>
        public Dictionary<string, DSEntityTypeElement> Elements { get; protected set; }

        /// <summary>
        /// Add new element to the entity definition. When public name and physical name are identical.
        /// </summary>
        /// <param name="name">Public name of the element.</param>
        /// <param name="dataType">Type of data represented by this element.</param>
        /// <param name="allowNull">Whether this element can be null or not.</param>
        /// <exception cref="EntityTypeBuildException">Throws when element not allowed.</exception>
        protected void Add(string name, DSElementTypeEnum dataType, bool allowNull = false)
        {
            Add(name, name, dataType, allowNull);
        }

        /// <summary>
        /// Add new element to the entity definition.
        /// </summary>
        /// <param name="name">Public name of the element.</param>
        /// <param name="columnName">Name representing the physical storage of the element.</param>
        /// <param name="dataType">Type of data represented by this element.</param>
        /// <param name="allowNull">Whether this element can be null or not.</param>
        /// <exception cref="EntityTypeBuildException">Throws when element not allowed.</exception>
        protected void Add(string name, string columnName, DSElementTypeEnum dataType, bool allowNull = false)
        {
            if (dataType == DSElementTypeEnum.Reference)
            {
                throw new EntityTypeBuildException("Cannot directly add Reference. Please use 'AddReference'.");
            }

            if (Elements.ContainsKey(name))
            {
                throw new EntityTypeBuildException(string.Format("Element '{0}' has already been added.", name));
            }

            // TODO - Consider validating everything on entry - Cons: would be a little slower, circular references may cause problems
            //   - Other option would be a validation process as part of Build \ Unit Testing
            // TODO - Consider option for masking columns with "Public" names ("PatientNumber" instead of "PtID") for easier use. This could be lower
            //   at the MetaData layer rather than in the public SDK space.
            Elements.Add(
                name,
                new DSEntityTypeElement
                {
                    Name = name,
                    StorageName = columnName,
                    DataType = dataType,
                    AllowNull = allowNull,
                });
        }

        /// <summary>
        /// Add new reference element to the entity definition.
        /// </summary>
        /// <param name="name">Public name of the element.</param>
        /// <param name="columnName">Name representing the physical storage of the element.</param>
        /// <param name="referenceEntityName">Name of the Entity this element references.</param>
        /// <param name="allowNull">Whether this element can be null or not.</param>
        /// <exception cref="EntityTypeBuildException">Throws when element not allowed.</exception>
        protected void AddReference(string name, string columnName, string referenceEntityName, bool allowNull = false)
        {
            if (Elements.ContainsKey(name))
            {
                throw new EntityTypeBuildException(string.Format("Element '{0}' has already been added.", name));
            }

            Elements.Add(
                name,
                new DSEntityTypeElement
                {
                    Name = name,
                    StorageName = columnName,
                    DataType = DSElementTypeEnum.Reference,
                    AllowNull = allowNull,
                    ReferenceTypeName = referenceEntityName
                });
        }

        /// <summary>
        /// Add new virtual element to the entity definition. This is not included in physical storage, but instead
        /// represents a path to an element further down the reference tree.
        /// </summary>
        /// <param name="name">Public name of the element.</param>
        /// <param name="virtualPath">Multi-part element path this </param>
        /// <param name="dataType">Type of data represented by this element.</param>
        /// <param name="allowNull">Whether this element can be null or not.</param>
        /// <exception cref="EntityTypeBuildException">Throws when element not allowed.</exception>
        protected void AddVirtualElement(string name, string virtualPath, DSElementTypeEnum dataType, bool allowNull = false)
        {
            if (Elements.ContainsKey(name))
            {
                throw new EntityTypeBuildException(string.Format("Element '{0}' has already been added.", name));
            }

            Elements.Add(
                name,
                new DSEntityTypeElement
                {
                    Name = name,
                    DataType = DSElementTypeEnum.Reference,
                    AllowNull = allowNull,
                    VirtualPath = virtualPath
                });
        }
    }
}
