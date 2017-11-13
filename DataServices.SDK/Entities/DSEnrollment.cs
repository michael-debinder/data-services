// <copyright file="DSEnrollment.cs" company="[None]">
//     Copyright (c) Michael DeBinder All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities
{
    using System;
    using Attrs;
    using Data;

    /// <summary>
    /// Represents a specific instance of the Enrollment entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class DSEnrollment : DSEntity
    {
        /// <summary>
        /// The public name identifying this entity.
        /// </summary>
        public const string EntityName = "Enrollment";

        /// <summary>
        /// List of all available attribute names for this entity.
        /// </summary>
        private static DSEnrollmentAttrs _attrs = new DSEnrollmentAttrs();

        /// <summary>
        /// Initializes a new instance of the <see cref="DSEnrollment"/> class.
        /// </summary>
        public DSEnrollment()
        {
            Type = EntityName;
        }

        /// <summary>
        /// Gets list of all available attribute names for this entity.
        /// </summary>
        public static DSEnrollmentAttrs Attrs
        {
            get { return _attrs; }
        }

        /// <summary>
        /// Gets or sets the EnrollmentID attribute.
        /// </summary>
        public int EnrollmentID
        {
            get { return Get<int>("EnrollmentID"); }
            set { this["EnrollmentID"] = value; }
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
        /// Gets or sets the StudentID attribute.
        /// </summary>
        public int StudentID
        {
            get { return Get<int>("StudentID"); }
            set { this["StudentID"] = value; }
        }

        /// <summary>
        /// Gets or sets the Grade attribute.
        /// </summary>
        public int Grade
        {
            get { return Get<int>("Grade"); }
            set { this["Grade"] = value; }
        }
    }
}
