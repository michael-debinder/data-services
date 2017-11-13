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
    public class HumanResources_Department : DSEntityType
    {
        /// <summary>Class name for this Entity Type.</summary>
        public const string ClassName = "HumanResources.Department";

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanResources_Department"/> class.
        /// </summary>
        public HumanResources_Department() : base()
        {
            Name = "HumanResources.Department";
            StorageName = "HumanResources.Department";
            KeyName = "DepartmentID";

            Add(KeyName, DSElementTypeEnum.Integer);

            Add("Name", DSElementTypeEnum.String, false);
            Add("GroupName", DSElementTypeEnum.String, false);
            Add("ModifiedDate", DSElementTypeEnum.DateTime, false);
        }
    }
}
