// <copyright file="EntityConversionTests.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.UnitTests.Data
{
    using System.Data;
    using DataAccess.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SDK.Data;

    /// <summary>
    /// Tests for the entity conversion library.
    /// </summary>
    [TestClass]
    public class EntityConversionTests
    {
        /// <summary>
        /// Tests the conversion of a DataTable to a List of Entity. 
        /// </summary>
        [TestMethod]
        public void TestToEntityList()
        {
            var testTable = new DataTable();
            testTable.Columns.Add("Key");
            testTable.Columns.Add("Name");
            testTable.Columns.Add("Branch.Name");
            testTable.Columns.Add("Patient.Branch.Name");

            var row = testTable.NewRow();
            row["Key"] = 123;
            row["Name"] = "Name123";
            row["Branch.Name"] = "Branch123";
            row["Patient.Branch.Name"] = "PtBranch123";
            testTable.Rows.Add(row);

            row = testTable.NewRow();
            row["Key"] = 234;
            row["Name"] = "Name234";
            row["Branch.Name"] = "Branch234";
            row["Patient.Branch.Name"] = "PtBranch234";
            testTable.Rows.Add(row);

            var entityList = testTable.ToEntityList<DSEntity>();

            Assert.AreEqual(2, entityList.Count, "Should have been 2 entries created.");
            Assert.AreEqual("Name123", entityList[0]["Name"], "First entry Name incorrect.");
            Assert.AreEqual("PtBranch234", entityList[1]["Patient.Branch.Name"], "Second entry Patient.Branch.Name incorrect.");
        }
    }
}
