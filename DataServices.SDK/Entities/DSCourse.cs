// <copyright file="DSCourse.cs" company="[None]">
//     Copyright (c) Michael DeBinder All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities
{
    using System;
    using Attrs;
    using Data;

    /// <summary>
    /// Represents a specific instance of the Course entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class DSCourse : DSEntity
    {
        /// <summary>
        /// The public name identifying this entity.
        /// </summary>
        public const string EntityName = "Course";

        /// <summary>
        /// List of all available attribute names for this entity.
        /// </summary>
        private static DSCourseAttrs _attrs = new DSCourseAttrs();

        /// <summary>
        /// Initializes a new instance of the <see cref="DSCourse"/> class.
        /// </summary>
        public DSCourse()
        {
            Type = EntityName;
        }

        /// <summary>
        /// Gets list of all available attribute names for this entity.
        /// </summary>
        public static DSCourseAttrs Attrs
        {
            get { return _attrs; }
        }

        /// <summary>
        /// Gets or sets the CourseID attribute.
        /// </summary>
        public int CourseID
        {
            get { return Get<int>("CourseID"); }
            set { this["CourseID"] = value; }
        }

        /// <summary>
        /// Gets or sets the Title attribute.
        /// </summary>
        public string Title
        {
            get { return Get<string>("Title"); }
            set { this["Title"] = value; }
        }

        /// <summary>
        /// Gets or sets the Credits attribute.
        /// </summary>
        public int Credits
        {
            get { return Get<int>("Credits"); }
            set { this["Credits"] = value; }
        }

        /// <summary>
        /// Gets or sets the DepartmentID attribute.
        /// </summary>
        public int DepartmentID
        {
            get { return Get<int>("DepartmentID"); }
            set { this["DepartmentID"] = value; }
        }
    }
}
