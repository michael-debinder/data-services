// <copyright file="DSCourse.cs" company="Brightree LLC">
//     Copyright (c) Brightree LLC. All rights reserved.
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
        /// Gets or sets the Department attribute.
        /// </summary>
        public int Department
        {
            get { return Get<int>("Department"); }
            set { this["Department"] = value; }
        }
    }
}
