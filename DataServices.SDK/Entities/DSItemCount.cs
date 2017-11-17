// <copyright file="DSItemCount.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities
{
    using System;
    using Attrs;
    using Data;

    /// <summary>
    /// Represents a specific instance of the ItemCount entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public partial class DSItemCount : DSEntity
    {
        /// <summary>
        /// The public name identifying this entity.
        /// </summary>
        public const string EntityName = "ItemCount";

        /// <summary>
        /// List of all available attribute names for this entity.
        /// </summary>
        private static DSItemCountAttrs _attrs = new DSItemCountAttrs();

        /// <summary>
        /// Initializes a new instance of the <see cref="DSItemCount"/> class.
        /// </summary>
        public DSItemCount()
        {
            Type = EntityName;
        }

        /// <summary>
        /// Gets list of all available attribute names for this entity.
        /// </summary>
        public static DSItemCountAttrs Attrs
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
        /// Gets or sets the Date attribute.
        /// </summary>
        public DateTime Date
        {
            get { return Get<DateTime>("Date"); }
            set { this["Date"] = value; }
        }

        /// <summary>
        /// Gets or sets the ItemID attribute.
        /// </summary>
        public int ItemID
        {
            get { return Get<int>("ItemID"); }
            set { this["ItemID"] = value; }
        }

        /// <summary>
        /// Gets or sets the ItemLocationID attribute.
        /// </summary>
        public int ItemLocationID
        {
            get { return Get<int>("ItemLocationID"); }
            set { this["ItemLocationID"] = value; }
        }

        /// <summary>
        /// Gets or sets the Count attribute.
        /// </summary>
        public decimal Count
        {
            get { return Get<decimal>("Count"); }
            set { this["Count"] = value; }
        }
    }
}
