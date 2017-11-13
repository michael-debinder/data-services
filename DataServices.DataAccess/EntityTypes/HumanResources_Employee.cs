// <copyright file="AppealTracking.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.EntityTypes
{
    using Data;
    using SDK.Data;

    /// <summary>
    /// Entity definition for the AppealTracking object.
    /// </summary>
    public class HumanResources_Employee : DSEntityType
    {
        /// <summary>Class name for this Entity Type.</summary>
        public const string ClassName = "HumanResources.Employee";

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanResources_Employee"/> class.
        /// </summary>
        public HumanResources_Employee() : base()
        {
            Name = "HumanResources.Employee";
            StorageName = "HumanResources.Employee";
            KeyName = "BusinessEntityID";

            Add(KeyName, DSElementTypeEnum.Integer);

            Add("NationalIDNumber", DSElementTypeEnum.String, false);
            Add("LoginID", DSElementTypeEnum.String, false);
            Add("JobTitle", DSElementTypeEnum.String, false);
            Add("BirthDate", DSElementTypeEnum.DateTime, false);
        }
    }
}
