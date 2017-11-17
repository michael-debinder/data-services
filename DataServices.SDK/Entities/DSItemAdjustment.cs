// <copyright file="DSItemAdjustment.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities
{
    using System;
    using Attrs;
    using Data;

    /// <summary>
    /// Represents a specific instance of the ItemAdjustment entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public partial class DSItemAdjustment : DSEntity
    {
        /// <summary>
        /// The public name identifying this entity.
        /// </summary>
        public const string EntityName = "ItemAdjustment";

        /// <summary>
        /// List of all available attribute names for this entity.
        /// </summary>
        private static DSItemAdjustmentAttrs _attrs = new DSItemAdjustmentAttrs();

        /// <summary>
        /// Initializes a new instance of the <see cref="DSItemAdjustment"/> class.
        /// </summary>
        public DSItemAdjustment()
        {
            Type = EntityName;
        }

        /// <summary>
        /// Gets list of all available attribute names for this entity.
        /// </summary>
        public static DSItemAdjustmentAttrs Attrs
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
        /// Gets or sets the Brand attribute.
        /// </summary>
        public string Brand
        {
            get { return Get<string>("Brand"); }
            set { this["Brand"] = value; }
        }

        /// <summary>
        /// Gets or sets the Rating attribute.
        /// </summary>
        public int Rating
        {
            get { return Get<int>("Rating"); }
            set { this["Rating"] = value; }
        }

        /// <summary>
        /// Gets or sets the Cost attribute.
        /// </summary>
        public decimal Cost
        {
            get { return Get<decimal>("Cost"); }
            set { this["Cost"] = value; }
        }

        /// <summary>
        /// Gets or sets the Qty attribute.
        /// </summary>
        public decimal Qty
        {
            get { return Get<decimal>("Qty"); }
            set { this["Qty"] = value; }
        }

        /// <summary>
        /// Gets or sets the ItemsPerPkg attribute.
        /// </summary>
        public decimal ItemsPerPkg
        {
            get { return Get<decimal>("ItemsPerPkg"); }
            set { this["ItemsPerPkg"] = value; }
        }
    }
}
