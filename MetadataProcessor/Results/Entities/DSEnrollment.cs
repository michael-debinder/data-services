// <copyright file="DSEnrollment.cs" company="Brightree LLC">
//     Copyright (c) Brightree LLC. All rights reserved.
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
        /// Gets or sets the Course attribute.
        /// </summary>
        public int Course
        {
            get { return Get<int>("Course"); }
            set { this["Course"] = value; }
        }

        /// <summary>
        /// Gets or sets the Student attribute.
        /// </summary>
        public int Student
        {
            get { return Get<int>("Student"); }
            set { this["Student"] = value; }
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
