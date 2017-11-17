// <copyright file="DSSQLSearchBuilderTests.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.UnitTests.Search
{
    using Caching;
    using DataAccess.Data;
    using DataAccess.Search;
    using DataServices.UnitTests.Common.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SDK.Entities;
    using SDK.Search;

    /// <summary>
    /// Tests around the SQL search builder process.
    /// </summary>
    [TestClass]
    public class DSSQLSearchBuilderTests
    {
        /// <summary>
        /// List of entity definitions known to the system.
        /// </summary>
        private static IDSEntityTypeRepository _entityTypeRepository;

        /// <summary>
        /// Initializes the class for the test run.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            var entityTypeResolver = new SampleEntityTypeResolver();
            _entityTypeRepository = new DSEntityTypeRepository(new MemoryCache(), entityTypeResolver);
        }

        /// <summary>
        /// Test a simple query with 1 table and 2 columns.
        /// </summary>
        [TestMethod]
        public void TestSimpleQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.AddSelect("Bar");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo, t.BarCol [Bar] FROM dbo.TestObjectATable t WITH(NOLOCK)";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());

            expectedQuery = "SELECT COUNT(*) FROM dbo.TestObjectATable t WITH(NOLOCK)";
            Assert.AreEqual(expectedQuery, ((DSSQLSearchBuilder)queryBuilder).ToStringForCount());
        }

        /// <summary>
        /// Test a query with a joined table.
        /// </summary>
        [TestMethod]
        public void TestJoinQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectBSearch;
            simpleSearch.AddSelect("ObjectA");
            simpleSearch.AddSelect("ObjectA.Foo");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo, t.ObjectAKey [ObjectA], t2.Foo [ObjectA.Foo]" +
                " FROM dbo.TestObjectBTable t WITH(NOLOCK)" +
                " JOIN dbo.TestObjectATable t2 WITH(NOLOCK) ON t.ObjectAKey = t2.TestObjectAKey";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectBKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query where we get a reference key.
        /// </summary>
        [TestMethod]
        public void TestReferenceKeyQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectBSearch;
            simpleSearch.AddSelect("ObjectA");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo, t.ObjectAKey [ObjectA]" +
                " FROM dbo.TestObjectBTable t WITH(NOLOCK)";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectBKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query with a select that requires 2 joined tables and returns a reference key.
        /// </summary>
        [TestMethod]
        public void TestSecondLevelReferenceKeyQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectCSearch;
            simpleSearch.AddSelect("ObjectB.ObjectA");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.A, t2.ObjectAKey [ObjectB.ObjectA]" +
                " FROM dbo.TestObjectCTable t WITH(NOLOCK)" +
                " JOIN dbo.TestObjectBTable t2 WITH(NOLOCK) ON t.ObjectBKey = t2.TestObjectBKey";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectCKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query with a select that expands as a virtual path.
        /// </summary>
        [TestMethod]
        public void TestVirtualPathQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectBSearch;
            simpleSearch.AddSelect("ObjectAFoo");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo, t2.Foo [ObjectAFoo]" +
                " FROM dbo.TestObjectBTable t WITH(NOLOCK)" +
                " JOIN dbo.TestObjectATable t2 WITH(NOLOCK) ON t.ObjectAKey = t2.TestObjectAKey";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectBKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query that selects a virtual path and that same path manually.
        /// </summary>
        [TestMethod]
        public void TestVirtualPathWithRegularQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectBSearch;
            simpleSearch.AddSelect("ObjectAFoo");
            simpleSearch.AddSelect("ObjectA.Foo");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo, t2.Foo [ObjectAFoo], t2.Foo [ObjectA.Foo]" +
                " FROM dbo.TestObjectBTable t WITH(NOLOCK)" +
                " JOIN dbo.TestObjectATable t2 WITH(NOLOCK) ON t.ObjectAKey = t2.TestObjectAKey";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectBKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query that uses a reference that is also a virtual path.
        /// </summary>
        [TestMethod]
        public void TestVirtualReferenceQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectCSearch;
            simpleSearch.AddSelect("ObjectA.Foo");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.A, t3.Foo [ObjectA.Foo]" +
                " FROM dbo.TestObjectCTable t WITH(NOLOCK)" +
                " JOIN dbo.TestObjectBTable t2 WITH(NOLOCK) ON t.ObjectBKey = t2.TestObjectBKey" +                
                " JOIN dbo.TestObjectATable t3 WITH(NOLOCK) ON t2.ObjectAKey = t3.TestObjectAKey";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectCKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query with a select on a virtual path on a reference.
        /// </summary>
        [TestMethod]
        public void TestVirtualOnReferenceQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectCSearch;
            simpleSearch.AddSelect("ObjectB.ObjectAFoo");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.A, t3.Foo [ObjectB.ObjectAFoo]" +
                " FROM dbo.TestObjectCTable t WITH(NOLOCK)" +
                " JOIN dbo.TestObjectBTable t2 WITH(NOLOCK) ON t.ObjectBKey = t2.TestObjectBKey" +
                " JOIN dbo.TestObjectATable t3 WITH(NOLOCK) ON t2.ObjectAKey = t3.TestObjectAKey";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectCKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query with a simple sort clause.
        /// </summary>
        [TestMethod]
        public void TestSimpleSortQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.AddSelect("Bar");
            simpleSearch.AddOrder("Foo");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo, t.BarCol [Bar] FROM dbo.TestObjectATable t WITH(NOLOCK)";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.Foo, t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query with multiple sort clauses.
        /// </summary>
        [TestMethod]
        public void TestMultipleSortsQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.AddSelect("Bar");
            simpleSearch.AddOrder("Foo").AddOrderDesc("Bar");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo, t.BarCol [Bar] FROM dbo.TestObjectATable t WITH(NOLOCK)";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.Foo, t.BarCol DESC, t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query with sort clause on a reference key.
        /// </summary>
        [TestMethod]
        public void TestSortOnReferenceKeyQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectBSearch;
            simpleSearch.AddSelect("Bar");
            simpleSearch.AddOrder("ObjectA").AddOrderDesc("Bar");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo, t.BarCol [Bar] FROM dbo.TestObjectBTable t WITH(NOLOCK)";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.ObjectAKey, t.BarCol DESC, t.TestObjectBKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query with sort clause on a referenced column.
        /// </summary>
        [TestMethod]
        public void TestSortOnReferenceColumnQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectBSearch;
            simpleSearch.AddSelect("Bar");
            simpleSearch.AddOrderDesc("ObjectA.Foo").AddOrderDesc("Bar");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo, t.BarCol [Bar] FROM dbo.TestObjectBTable t WITH(NOLOCK)" +
                " JOIN dbo.TestObjectATable t2 WITH(NOLOCK) ON t.ObjectAKey = t2.TestObjectAKey";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t2.Foo DESC, t.BarCol DESC, t.TestObjectBKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query with no explicit sort.
        /// </summary>
        [TestMethod]
        public void TestNoSortQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.AddSelect("Bar");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo, t.BarCol [Bar] FROM dbo.TestObjectATable t WITH(NOLOCK)";

            // By default should always be adding the Primary Key as a Sort
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test a query with the DISTINCT option.
        /// </summary>
        [TestMethod]
        public void TestSimpleDistinctQuery()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Distinct = true;
            simpleSearch.AddSelect("Bar");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT DISTINCT t.Foo, t.BarCol [Bar] FROM dbo.TestObjectATable t WITH(NOLOCK)";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());

            expectedQuery = "SELECT COUNT(*) FROM (SELECT DISTINCT t.Foo, t.BarCol [Bar] FROM dbo.TestObjectATable t WITH(NOLOCK)) dis";
            Assert.AreEqual(expectedQuery, ((DSSQLSearchBuilder)queryBuilder).ToStringForCount());
        }

        //// TODO - Test getting Key

        //// TODO - Test Build Exceptions

        /// <summary>
        /// Test a query on the Appeal Tracking definition (more for research than testing).
        /// </summary>
        [TestMethod]
        public void TestEnrollmentQuery()
        {
            /*
            var entityTypeResolver = new DSStaticEntityTypeResolver();
            var entityTypeRepository = new DSEntityTypeRepository(new MemoryCache(), entityTypeResolver);

            var search = new DSSearch(DSEnrollment.EntityName);
            search.AddSelect(DSEnrollment.Attrs.EnrollmentID);
            search.AddSelect(DSEnrollment.Attrs.Student.LastName);
            search.AddSelect(DSEnrollment.Attrs.Student.ID);
            search.AddSelect(DSEnrollment.Attrs.Course.Title);
            search.AddSelect(DSEnrollment.Attrs.Course.Department.Name);
            search.AddSelect(DSEnrollment.Attrs.Grade);

            search.Where.DSContains(DSEnrollment.Attrs.Course.Title, "e");

            search.AddOrder(DSEnrollment.Attrs.Student.LastName);
            search.Page = 1;
            search.PageSize = 25;

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(entityTypeRepository, search, true);

            var expectedQuery = "SELECT e.EnrollmentID, p.LastName [Student.LastName], p.ID [Student.ID], c.Title [Course.Title], d.Name [Course.Department.Name], e.Grade" +
                " FROM dbo.Enrollment e WITH(NOLOCK)" +
                " JOIN dbo.Person p WITH(NOLOCK) ON e.StudentID = p.ID" +
                " JOIN dbo.Course c WITH(NOLOCK) ON e.CourseID = c.CourseID" +
                " JOIN dbo.Department d WITH(NOLOCK) ON c.DepartmentID = d.DepartmentID" +
                " WHERE c.Title LIKE '%'+@p0+'%'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "p.LastName, e.EnrollmentID"), queryBuilder.ToString());
            */
        }
    }
}
