// <copyright file="DSCourseAttrs.cs" company="Brightree LLC">
//     Copyright (c) Brightree LLC. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities.Attrs
{
    using Data;

    /// <summary>
    /// Represents a specific instance of the Course entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class DSCourseAttrs : DSAttrs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSCourseAttrs"/> class.
        /// </summary>
        public DSCourseAttrs() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSCourseAttrs"/> class with its value with an alias and path.
        /// </summary>
        /// <param name="alias">Alias name for this attribute in the current tree.</param>
        /// <param name="fromPath">Path to this attribute in the current tree.</param>
        public DSCourseAttrs(string alias, string fromPath) : base(alias, fromPath)
        {
        }
        
        /// <summary>Storage for the linked Department attributes. Note we will be lazy loading to avoid infinite loops.</summary>
        private DSDepartmentAttrs _department;


        /// <summary>Gets the CourseID attribute name.</summary>
        public string CourseID
        {
            get { return GetName("CourseID"); }
        }
            
        /// <summary>Gets the Credits attribute name.</summary>
        public string Credits
        {
            get { return GetName("Credits"); }
        }
            
        /// <summary>Gets the Department attribute.</summary>
        public DSDepartmentAttrs Department
        {
            get
            {
                if (_department == null)
                {
                    _department = new DSDepartmentAttrs("Department", Path);
                }

                return _department;
            }
        }

        /// <summary>Gets the Title attribute name.</summary>
        public string Title
        {
            get { return GetName("Title"); }
        }
            
    }
}
