// <copyright file="DSEnrollmentAttrs.cs" company="Brightree LLC">
//     Copyright (c) Brightree LLC. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities.Attrs
{
    using Data;

    /// <summary>
    /// Represents a specific instance of the Enrollment entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class DSEnrollmentAttrs : DSAttrs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSEnrollmentAttrs"/> class.
        /// </summary>
        public DSEnrollmentAttrs() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSEnrollmentAttrs"/> class with its value with an alias and path.
        /// </summary>
        /// <param name="alias">Alias name for this attribute in the current tree.</param>
        /// <param name="fromPath">Path to this attribute in the current tree.</param>
        public DSEnrollmentAttrs(string alias, string fromPath) : base(alias, fromPath)
        {
        }
        
        /// <summary>Storage for the linked Course attributes. Note we will be lazy loading to avoid infinite loops.</summary>
        private DSCourseAttrs _course;

        /// <summary>Storage for the linked Student attributes. Note we will be lazy loading to avoid infinite loops.</summary>
        private DSPersonAttrs _student;


        /// <summary>Gets the Course attribute.</summary>
        public DSCourseAttrs Course
        {
            get
            {
                if (_course == null)
                {
                    _course = new DSCourseAttrs("Course", Path);
                }

                return _course;
            }
        }

        /// <summary>Gets the EnrollmentID attribute name.</summary>
        public string EnrollmentID
        {
            get { return GetName("EnrollmentID"); }
        }
            
        /// <summary>Gets the Grade attribute name.</summary>
        public string Grade
        {
            get { return GetName("Grade"); }
        }
            
        /// <summary>Gets the Student attribute.</summary>
        public DSPersonAttrs Student
        {
            get
            {
                if (_student == null)
                {
                    _student = new DSPersonAttrs("Student", Path);
                }

                return _student;
            }
        }

    }
}
