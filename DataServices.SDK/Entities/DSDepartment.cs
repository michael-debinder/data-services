// <copyright file="DSDepartment.cs" company="[None]">
//     Copyright (c) Michael DeBinder All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities
{
    using System;
    using Attrs;
    using Data;

    /// <summary>
    /// Represents a specific instance of the Department entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class DSDepartment : DSEntity
    {
        /// <summary>
        /// The public name identifying this entity.
        /// </summary>
        public const string EntityName = "Department";

        /// <summary>
        /// List of all available attribute names for this entity.
        /// </summary>
        private static DSDepartmentAttrs _attrs = new DSDepartmentAttrs();

        /// <summary>
        /// Initializes a new instance of the <see cref="DSDepartment"/> class.
        /// </summary>
        public DSDepartment()
        {
            Type = EntityName;
        }

        /// <summary>
        /// Gets list of all available attribute names for this entity.
        /// </summary>
        public static DSDepartmentAttrs Attrs
        {
            get { return _attrs; }
        }

        /// <summary>
        /// Gets or sets the DepartmentID attribute.
        /// </summary>
        public int DepartmentID
        {
            get { return Get<int>("DepartmentID"); }
            set { this["DepartmentID"] = value; }
        }

        /// <summary>
        /// Gets or sets the Name attribute.
        /// </summary>
        public string Name
        {
            get { return Get<string>("Name"); }
            set { this["Name"] = value; }
        }

        /// <summary>
        /// Gets or sets the Budget attribute.
        /// </summary>
        public decimal Budget
        {
            get { return Get<decimal>("Budget"); }
            set { this["Budget"] = value; }
        }

        /// <summary>
        /// Gets or sets the StartDate attribute.
        /// </summary>
        public DateTime StartDate
        {
            get { return Get<DateTime>("StartDate"); }
            set { this["StartDate"] = value; }
        }

        /// <summary>
        /// Gets or sets the InstructorID attribute.
        /// </summary>
        public int InstructorID
        {
            get { return Get<int>("InstructorID"); }
            set { this["InstructorID"] = value; }
        }
    }
}
