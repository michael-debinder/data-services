// <copyright file="DSSearchTests.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.UnitTests.Search
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SDK.Entities;
    using SDK.Search;

    /// <summary>
    /// Tests around the DSSearch object.
    /// </summary>
    [TestClass]
    public class DSSearchTests
    {
        /// <summary>
        /// Test the single and multiple options for AddSelect.
        /// </summary>
        [TestMethod]
        public void TestAddSelect()
        {
            /*
            var testSearch = new DSSearch();
            testSearch.AddSelect(DSEnrollment.Attrs.EnrollmentID);

            Assert.AreEqual(1, testSearch.Select.Count);
            Assert.AreEqual("EnrollmentID", testSearch.Select[0]);

            testSearch.AddSelect(
                DSEnrollment.Attrs.Course,
                DSEnrollment.Attrs.Course.Title,
                DSEnrollment.Attrs.Student,
                DSEnrollment.Attrs.Student.FirstName);

            Assert.AreEqual(5, testSearch.Select.Count);
            Assert.AreEqual("Course", testSearch.Select[1]);
            Assert.AreEqual("Course.Title", testSearch.Select[2]);
            Assert.AreEqual("Student", testSearch.Select[3]);
            Assert.AreEqual("Student.FirstName", testSearch.Select[4]);
            */
        }
    }
}
