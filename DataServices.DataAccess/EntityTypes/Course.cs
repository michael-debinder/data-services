// <copyright file="Course.cs" company="Brightree LLC">
//     Copyright (c) Brightree LLC. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.EntityTypes
{
    using Data;
    using SDK.Data;

    /// <summary>
    /// Entity definition for the Course object.
    /// </summary>
    public class Course : DSEntityType
    {
        /// <summary>Class name for this Entity Type.</summary>
        public const string ClassName = "Course";

        /// <summary>
        /// Initializes a new instance of the <see cref="Course" /> class.
        /// </summary>
        public Course() : base()
        {
            Name = "Course";
            StorageName = "Course";
            KeyName = "CourseID";

            Add(KeyName, DSElementTypeEnum.Integer);

            Add("Credits", DSElementTypeEnum.Integer);
            AddReference("Department", "DepartmentID", "Department");
            Add("Title", DSElementTypeEnum.String, true);
        }
    }
}
