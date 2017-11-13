// <copyright file="TestObjectB.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.UnitTests.Common.EntityTypes
{
    using DataAccess.Data;
    using SDK.Data;

    /// <summary>
    /// Entity definition for a sample TestObjectB object.
    /// </summary>
    public class TestObjectB : DSEntityType
    {
        /// <summary>Class name for this Entity Type.</summary>
        public const string ClassName = "TestObjectB";

        /// <summary>
        /// Initializes a new instance of the <see cref="TestObjectB"/> class.
        /// </summary>
        public TestObjectB() : base()
        {
            Name = "TestObjectB";
            StorageName = "TestObjectBTable";
            KeyName = "TestObjectBKey";

            Add(KeyName, DSElementTypeEnum.Integer);
            
            AddReference("ObjectA", "ObjectAKey", "TestObjectA");

            AddVirtualElement("ObjectAFoo", "ObjectA.Foo", DSElementTypeEnum.Integer);

            Add("Foo", DSElementTypeEnum.Integer, true);
            Add("Bar", "BarCol", DSElementTypeEnum.String, true);
        }
    }
}
