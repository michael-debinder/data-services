// <copyright file="DSItemCountAttrs.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities.Attrs
{
    using Data;

    /// <summary>
    /// Represents a specific instance of the ItemCount entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class DSItemCountAttrs : DSAttrs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSItemCountAttrs"/> class.
        /// </summary>
        public DSItemCountAttrs() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSItemCountAttrs"/> class with its value with an alias and path.
        /// </summary>
        /// <param name="alias">Alias name for this attribute in the current tree.</param>
        /// <param name="fromPath">Path to this attribute in the current tree.</param>
        public DSItemCountAttrs(string alias, string fromPath) : base(alias, fromPath)
        {
        }
        
        /// <summary>Storage for the linked ItemID attributes. Note we will be lazy loading to avoid infinite loops.</summary>
        private DSItemAttrs _itemID;

        /// <summary>Storage for the linked ItemLocationID attributes. Note we will be lazy loading to avoid infinite loops.</summary>
        private DSItemLocationAttrs _itemLocationID;


        /// <summary>Gets the Count attribute name.</summary>
        public string Count
        {
            get { return GetName("Count"); }
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

        /// <summary>Gets the ItemLocationID attribute.</summary>
        public DSItemLocationAttrs ItemLocationID
        {
            get
            {
                if (_itemLocationID == null)
                {
                    _itemLocationID = new DSItemLocationAttrs("ItemLocationID", Path);
                }

                return _itemLocationID;
            }
        }

    }
}
