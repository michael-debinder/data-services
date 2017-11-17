// <copyright file="DSItemAttrs.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities.Attrs
{
    using Data;

    /// <summary>
    /// Represents a specific instance of the Item entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class DSItemAttrs : DSAttrs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSItemAttrs"/> class.
        /// </summary>
        public DSItemAttrs() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSItemAttrs"/> class with its value with an alias and path.
        /// </summary>
        /// <param name="alias">Alias name for this attribute in the current tree.</param>
        /// <param name="fromPath">Path to this attribute in the current tree.</param>
        public DSItemAttrs(string alias, string fromPath) : base(alias, fromPath)
        {
        }
        

        /// <summary>Gets the Description attribute name.</summary>
        public string Description
        {
            get { return GetName("Description"); }
        }
            
        /// <summary>Gets the ID attribute name.</summary>
        public string ID
        {
            get { return GetName("ID"); }
        }
            
        /// <summary>Gets the Name attribute name.</summary>
        public string Name
        {
            get { return GetName("Name"); }
        }
            
    }
}
