// <copyright file="EntityTests.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.UnitTests.Entities
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SDK.Entities;

    /// <summary>
    /// Tests around the entity classes and attributes.
    /// </summary>
    [TestClass]
    public class EntityTests
    {
        /// <summary>
        /// Tests many different strongly typed attributes converting to string paths.
        /// </summary>
        [TestMethod]
        public void StronglyTypeAttributePathTests()
        {
            /*
            Assert.AreEqual("Course", DSEnrollment.Attrs.Course);
            Assert.AreEqual("Course.Title", DSEnrollment.Attrs.Course.Title);
            Assert.AreEqual("Course.Department", DSEnrollment.Attrs.Course.Department);
            Assert.AreEqual("Course.Department.Name", DSEnrollment.Attrs.Course.Department.Name);

            Assert.AreEqual("Student", DSEnrollment.Attrs.Student);
            Assert.AreEqual("Student.FirstName", DSEnrollment.Attrs.Student.FirstName);
            Assert.AreEqual("Student.LastName", DSEnrollment.Attrs.Student.LastName);
            Assert.AreEqual("Student.HireDate", DSEnrollment.Attrs.Student.HireDate);
            */
        }
    }
}
