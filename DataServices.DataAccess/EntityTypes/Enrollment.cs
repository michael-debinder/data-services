// <copyright file="Enrollment.cs" company="Brightree LLC">
//     Copyright (c) Brightree LLC. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.EntityTypes
{
    using Data;
    using SDK.Data;

    /// <summary>
    /// Entity definition for the Enrollment object.
    /// </summary>
    public class Enrollment : DSEntityType
    {
        /// <summary>Class name for this Entity Type.</summary>
        public const string ClassName = "Enrollment";

        /// <summary>
        /// Initializes a new instance of the <see cref="Enrollment" /> class.
        /// </summary>
        public Enrollment() : base()
        {
            Name = "Enrollment";
            StorageName = "Enrollment";
            KeyName = "EnrollmentID";

            Add(KeyName, DSElementTypeEnum.Integer);

            AddReference("Course", "CourseID", "Course");
            Add("Grade", DSElementTypeEnum.Integer, true);
            AddReference("Student", "StudentID", "Person");
        }
    }
}
