// <copyright file="Department.cs" company="Brightree LLC">
//     Copyright (c) Brightree LLC. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.EntityTypes
{
    using Data;
    using SDK.Data;

    /// <summary>
    /// Entity definition for the Department object.
    /// </summary>
    public class Department : DSEntityType
    {
        /// <summary>Class name for this Entity Type.</summary>
        public const string ClassName = "Department";

        /// <summary>
        /// Initializes a new instance of the <see cref="Department" /> class.
        /// </summary>
        public Department() : base()
        {
            Name = "Department";
            StorageName = "Department";
            KeyName = "DepartmentID";

            Add(KeyName, DSElementTypeEnum.Integer);

            Add("Budget", DSElementTypeEnum.Decimal);
            AddReference("Instructor", "InstructorID", "Person");
            Add("Name", DSElementTypeEnum.String, true);
            Add("StartDate", DSElementTypeEnum.DateTime);
        }
    }
}
