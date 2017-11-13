// <copyright file="DSDepartmentAttrs.cs" company="Brightree LLC">
//     Copyright (c) Brightree LLC. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities.Attrs
{
    using Data;

    /// <summary>
    /// Represents a specific instance of the Department entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class DSDepartmentAttrs : DSAttrs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSDepartmentAttrs"/> class.
        /// </summary>
        public DSDepartmentAttrs() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSDepartmentAttrs"/> class with its value with an alias and path.
        /// </summary>
        /// <param name="alias">Alias name for this attribute in the current tree.</param>
        /// <param name="fromPath">Path to this attribute in the current tree.</param>
        public DSDepartmentAttrs(string alias, string fromPath) : base(alias, fromPath)
        {
        }
        
        /// <summary>Storage for the linked Instructor attributes. Note we will be lazy loading to avoid infinite loops.</summary>
        private DSPersonAttrs _instructor;


        /// <summary>Gets the Budget attribute name.</summary>
        public string Budget
        {
            get { return GetName("Budget"); }
        }
            
        /// <summary>Gets the DepartmentID attribute name.</summary>
        public string DepartmentID
        {
            get { return GetName("DepartmentID"); }
        }
            
        /// <summary>Gets the Instructor attribute.</summary>
        public DSPersonAttrs Instructor
        {
            get
            {
                if (_instructor == null)
                {
                    _instructor = new DSPersonAttrs("Instructor", Path);
                }

                return _instructor;
            }
        }

        /// <summary>Gets the Name attribute name.</summary>
        public string Name
        {
            get { return GetName("Name"); }
        }
            
        /// <summary>Gets the StartDate attribute name.</summary>
        public string StartDate
        {
            get { return GetName("StartDate"); }
        }
            
    }
}
