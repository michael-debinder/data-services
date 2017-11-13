// <copyright file="DSEnrollmentAttrs.cs" company="[None]">
//     Copyright (c) Michael DeBinder All rights reserved.
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
        
        /// <summary>Storage for the linked CourseID attributes. Note we will be lazy loading to avoid infinite loops.</summary>
        private DSCourseAttrs _courseID;

        /// <summary>Storage for the linked StudentID attributes. Note we will be lazy loading to avoid infinite loops.</summary>
        private DSPersonAttrs _studentID;


        /// <summary>Gets the CourseID attribute.</summary>
        public DSCourseAttrs Course
        {
            get
            {
                if (_courseID == null)
                {
                    _courseID = new DSCourseAttrs("Course", Path);
                }

                return _courseID;
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
            
        /// <summary>Gets the StudentID attribute.</summary>
        public DSPersonAttrs Student
        {
            get
            {
                if (_studentID == null)
                {
                    _studentID = new DSPersonAttrs("Student", Path);
                }

                return _studentID;
            }
        }

    }
}
