// <copyright file="TestObjectC.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.UnitTests.Common.EntityTypes
{
    using DataAccess.Data;
    using SDK.Data;

    /// <summary>
    /// Entity definition for a sample TestObjectC object.
    /// </summary>
    public class TestObjectC : DSEntityType
    {
        /// <summary>Class name for this Entity Type.</summary>
        public const string ClassName = "TestObjectC";

        /// <summary>
        /// Initializes a new instance of the <see cref="TestObjectC"/> class.
        /// </summary>
        public TestObjectC() : base()
        {
            Name = "TestObjectC";
            StorageName = "TestObjectCTable";
            KeyName = "TestObjectCKey";

            Add(KeyName, DSElementTypeEnum.Integer);

            AddReference("ObjectB", "ObjectBKey", "TestObjectB");

            AddVirtualElement("ObjectA", "ObjectB.ObjectA", DSElementTypeEnum.Reference);

            Add("A", DSElementTypeEnum.Integer, true);
            Add("B", DSElementTypeEnum.Integer, true);
            Add("C", DSElementTypeEnum.Integer, true);
            Add("D", DSElementTypeEnum.Integer, true);
        }
    }
}
