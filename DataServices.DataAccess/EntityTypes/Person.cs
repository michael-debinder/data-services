// <copyright file="Person.cs" company="Brightree LLC">
//     Copyright (c) Brightree LLC. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.EntityTypes
{
    using Data;
    using SDK.Data;

    /// <summary>
    /// Entity definition for the Person object.
    /// </summary>
    public class Person : DSEntityType
    {
        /// <summary>Class name for this Entity Type.</summary>
        public const string ClassName = "Person";

        /// <summary>
        /// Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
        public Person() : base()
        {
            Name = "Person";
            StorageName = "Person";
            KeyName = "ID";

            Add(KeyName, DSElementTypeEnum.Integer);

            Add("Discriminator", DSElementTypeEnum.String);
            Add("EnrollmentDate", DSElementTypeEnum.DateTime, true);
            Add("FirstName", DSElementTypeEnum.String);
            Add("HireDate", DSElementTypeEnum.DateTime, true);
            Add("LastName", DSElementTypeEnum.String);
        }
    }
}
