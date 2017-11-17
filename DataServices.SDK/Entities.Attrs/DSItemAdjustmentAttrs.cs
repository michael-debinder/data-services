// <copyright file="DSItemAdjustmentAttrs.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities.Attrs
{
    using Data;

    /// <summary>
    /// Represents a specific instance of the ItemAdjustment entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class DSItemAdjustmentAttrs : DSAttrs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSItemAdjustmentAttrs"/> class.
        /// </summary>
        public DSItemAdjustmentAttrs() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSItemAdjustmentAttrs"/> class with its value with an alias and path.
        /// </summary>
        /// <param name="alias">Alias name for this attribute in the current tree.</param>
        /// <param name="fromPath">Path to this attribute in the current tree.</param>
        public DSItemAdjustmentAttrs(string alias, string fromPath) : base(alias, fromPath)
        {
        }
        
        /// <summary>Storage for the linked ItemID attributes. Note we will be lazy loading to avoid infinite loops.</summary>
        private DSItemAttrs _itemID;


        /// <summary>Gets the Brand attribute name.</summary>
        public string Brand
        {
            get { return GetName("Brand"); }
        }
            
        /// <summary>Gets the Cost attribute name.</summary>
        public string Cost
        {
            get { return GetName("Cost"); }
        }
            
        /// <summary>Gets the Date attribute name.</summary>
        public string Date
        {
            get { return GetName("Date"); }
        }
            
        /// <summary>Gets the ID attribute name.</summary>
        public string ID
        {
            get { return GetName("ID"); }
        }
            
        /// <summary>Gets the ItemID attribute.</summary>
        public DSItemAttrs ItemID
        {
            get
            {
                if (_itemID == null)
                {
                    _itemID = new DSItemAttrs("ItemID", Path);
                }

                return _itemID;
            }
        }

        /// <summary>Gets the ItemsPerPkg attribute name.</summary>
        public string ItemsPerPkg
        {
            get { return GetName("ItemsPerPkg"); }
        }
            
        /// <summary>Gets the Qty attribute name.</summary>
        public string Qty
        {
            get { return GetName("Qty"); }
        }
            
        /// <summary>Gets the Rating attribute name.</summary>
        public string Rating
        {
            get { return GetName("Rating"); }
        }
            
    }
}
