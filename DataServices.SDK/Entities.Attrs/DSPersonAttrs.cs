// <copyright file="DSPersonAttrs.cs" company="[None]">
//     Copyright (c) Michael DeBinder All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities.Attrs
{
    using Data;

    /// <summary>
    /// Represents a specific instance of the Person entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class DSPersonAttrs : DSAttrs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSPersonAttrs"/> class.
        /// </summary>
        public DSPersonAttrs() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSPersonAttrs"/> class with its value with an alias and path.
        /// </summary>
        /// <param name="alias">Alias name for this attribute in the current tree.</param>
        /// <param name="fromPath">Path to this attribute in the current tree.</param>
        public DSPersonAttrs(string alias, string fromPath) : base(alias, fromPath)
        {
        }
        

        /// <summary>Gets the Discriminator attribute name.</summary>
        public string Discriminator
        {
            get { return GetName("Discriminator"); }
        }
            
        /// <summary>Gets the EnrollmentDate attribute name.</summary>
        public string EnrollmentDate
        {
            get { return GetName("EnrollmentDate"); }
        }
            
        /// <summary>Gets the FirstName attribute name.</summary>
        public string FirstName
        {
            get { return GetName("FirstName"); }
        }
            
        /// <summary>Gets the HireDate attribute name.</summary>
        public string HireDate
        {
            get { return GetName("HireDate"); }
        }
            
        /// <summary>Gets the ID attribute name.</summary>
        public string ID
        {
            get { return GetName("ID"); }
        }
            
        /// <summary>Gets the LastName attribute name.</summary>
        public string LastName
        {
            get { return GetName("LastName"); }
        }
            
    }
}
