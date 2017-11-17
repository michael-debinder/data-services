// <copyright file="DSItem.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities
{
    using System;
    using Attrs;
    using Data;

    /// <summary>
    /// Represents a specific instance of the Item entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public partial class DSItem : DSEntity
    {
        /// <summary>
        /// The public name identifying this entity.
        /// </summary>
        public const string EntityName = "Item";

        /// <summary>
        /// List of all available attribute names for this entity.
        /// </summary>
        private static DSItemAttrs _attrs = new DSItemAttrs();

        /// <summary>
        /// Initializes a new instance of the <see cref="DSItem"/> class.
        /// </summary>
        public DSItem()
        {
            Type = EntityName;
        }

        /// <summary>
        /// Gets list of all available attribute names for this entity.
        /// </summary>
        public static DSItemAttrs Attrs
        {
            get { return _attrs; }
        }

        /// <summary>
        /// Gets or sets the ID attribute.
        /// </summary>
        public int ID
        {
            get { return Get<int>("ID"); }
            set { this["ID"] = value; }
        }

        /// <summary>
        /// Gets or sets the Name attribute.
        /// </summary>
        public string Name
        {
            get { return Get<string>("Name"); }
            set { this["Name"] = value; }
        }

        /// <summary>
        /// Gets or sets the Description attribute.
        /// </summary>
        public string Description
        {
            get { return Get<string>("Description"); }
            set { this["Description"] = value; }
        }
    }
}
