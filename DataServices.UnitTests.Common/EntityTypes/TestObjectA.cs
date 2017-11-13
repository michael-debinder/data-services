// <copyright file="TestObjectA.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.UnitTests.Common.EntityTypes
{
    using DataAccess.Data;
    using SDK.Data;

    /// <summary>
    /// Entity definition for a sample TestObjectA object.
    /// </summary>
    public class TestObjectA : DSEntityType
    {
        /// <summary>Class name for this Entity Type.</summary>
        public const string ClassName = "TestObjectA";

        /// <summary>
        /// Initializes a new instance of the <see cref="TestObjectA"/> class.
        /// </summary>
        public TestObjectA() : base()
        {
            Name = "TestObjectA";
            StorageName = "TestObjectATable";
            KeyName = "TestObjectAKey";

            Add(KeyName, DSElementTypeEnum.Integer);

            Add("Foo", DSElementTypeEnum.Integer, true);
            Add("Bar", "BarCol", DSElementTypeEnum.String, true);
            Add("FooBar", DSElementTypeEnum.DateTime, true);
        }
    }
}
