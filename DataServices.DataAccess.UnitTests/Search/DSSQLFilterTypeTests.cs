// <copyright file="DSSQLFilterTypeTests.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.UnitTests.Search
{
    using System;
    using System.Collections.Generic;
    using Caching;
    using DataAccess.Data;
    using DataAccess.Search;
    using DataServices.UnitTests.Common.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SDK.Search;

    /// <summary>
    /// Tests around the different SQL filter types.
    /// </summary>
    [TestClass]
    public class DSSQLFilterTypeTests
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
        /// Test the string "Contains" filter
        /// </summary>
        [TestMethod]
        public void TestStringContainsFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSContains("Bar", "a");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol LIKE '%a%'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the string "DoesNotEqual" filter
        /// </summary>
        [TestMethod]
        public void TestStringDoesNotEqualFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSDoesNotEqual("Bar", "a");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol <> 'a'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the string "EndsWith" filter
        /// </summary>
        [TestMethod]
        public void TestStringEndsWithFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSEndsWith("Bar", "a");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol LIKE '%a'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the string "Equals" filter
        /// </summary>
        [TestMethod]
        public void TestStringEqualsFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSEquals("Bar", "a");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol = 'a'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the string "GreaterThan" filter
        /// </summary>
        [TestMethod]
        public void TestStringGreaterThanFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSGreaterThan("Bar", "a");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol > 'a'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the string "GreaterThanOrEqual" filter
        /// </summary>
        [TestMethod]
        public void TestStringGreaterThanOrEqualFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSGreaterThanOrEqual("Bar", "a");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol >= 'a'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the string "IN" filter
        /// </summary>
        [TestMethod]
        public void TestStringInFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSIn("Bar", new List<object> { "a", "b", "c", "d", "e" });

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol IN ('a', 'b', 'c', 'd', 'e')";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the string "IsBlank" filter
        /// </summary>
        [TestMethod]
        public void TestStringIsBlankFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSIsBlank("Bar");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol IS NULL";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the string "IsNotBlank" filter
        /// </summary>
        [TestMethod]
        public void TestStringIsNotBlankFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSIsNotBlank("Bar");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol IS NOT NULL";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the string "LessThan" filter
        /// </summary>
        [TestMethod]
        public void TestStringLessThanFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSLessThan("Bar", "a");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol < 'a'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the string "LessThanOrEqual" filter
        /// </summary>
        [TestMethod]
        public void TestStringLessThanOrEqualFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSLessThanOrEqual("Bar", "a");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol <= 'a'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the string "StartsWith" filter
        /// </summary>
        [TestMethod]
        public void TestStringStartsWithFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSStartsWith("Bar", "a");

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol LIKE 'a%'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the numeric "DoesNotEqual" filter
        /// </summary>
        [TestMethod]
        public void TestNumericDoesNotEqualFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSDoesNotEqual("Foo", 1234);

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.Foo <> 1234";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the numeric "Equals" filter
        /// </summary>
        [TestMethod]
        public void TestNumericEqualsFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSEquals("Foo", 1234);

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.Foo = 1234";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the numeric "GreaterThan" filter
        /// </summary>
        [TestMethod]
        public void TestNumericGreaterThanFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSGreaterThan("Foo", 1234);

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.Foo > 1234";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the numeric "GreaterThanOrEqual" filter
        /// </summary>
        [TestMethod]
        public void TestNumericGreaterThanOrEqualFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSGreaterThanOrEqual("Foo", 1234);

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.Foo >= 1234";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the numeric "In" filter
        /// </summary>
        [TestMethod]
        public void TestNumericInFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSIn("Foo", new List<object> { 1234, 2345, 3456, 4567, 5678 });

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.Foo IN (1234, 2345, 3456, 4567, 5678)";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the numeric "LessThan" filter
        /// </summary>
        [TestMethod]
        public void TestNumericLessThanFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSLessThan("Foo", 1234);

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.Foo < 1234";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the numeric "LessThanOrEqual" filter
        /// </summary>
        [TestMethod]
        public void TestNumericLessThanOrEqualFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSLessThanOrEqual("Foo", 1234);

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.Foo <= 1234";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the date "DoesNotEqual" filter
        /// </summary>
        [TestMethod]
        public void TestDateDoesNotEqualFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSDoesNotEqual("FooBar", DateTime.Parse("12/20/2016 4:45 PM"));

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.FooBar <> '12/20/2016 4:45:00 PM'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the date "Equals" filter
        /// </summary>
        [TestMethod]
        public void TestDateEqualsFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSEquals("FooBar", DateTime.Parse("12/20/2016 4:45 PM"));

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.FooBar = '12/20/2016 4:45:00 PM'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the date "GreaterThan" filter
        /// </summary>
        [TestMethod]
        public void TestDateGreaterThanFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSGreaterThan("FooBar", DateTime.Parse("12/20/2016 4:45 PM"));

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.FooBar > '12/20/2016 4:45:00 PM'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the date "GreaterThanOrEqual" filter
        /// </summary>
        [TestMethod]
        public void TestDateGreaterThanOrEqualFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSGreaterThanOrEqual("FooBar", DateTime.Parse("12/20/2016 4:45 PM"));

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.FooBar >= '12/20/2016 4:45:00 PM'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the date "In" filter
        /// </summary>
        [TestMethod]
        public void TestDateInFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSIn("FooBar", new List<object> { DateTime.Parse("12/20/2016 4:45 PM"), new DateTime(2016, 12, 15), new DateTime(2016, 12, 1) });

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.FooBar IN ('12/20/2016 4:45:00 PM', '12/15/2016 12:00:00 AM', '12/1/2016 12:00:00 AM')";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the date "LessThan" filter
        /// </summary>
        [TestMethod]
        public void TestDateLessThanFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSLessThan("FooBar", DateTime.Parse("12/20/2016 4:45 PM"));

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.FooBar < '12/20/2016 4:45:00 PM'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the date "LessThanOrEqual" filter
        /// </summary>
        [TestMethod]
        public void TestDateLessThanOrEqualFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSLessThanOrEqual("FooBar", DateTime.Parse("12/20/2016 4:45 PM"));

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.FooBar <= '12/20/2016 4:45:00 PM'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the numeric "Contains" filter
        /// </summary>
        [TestMethod]
        public void TestFringeNumericContainsFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where = new DSPredicate
            {
                Column = "Foo",
                Operator = DSSearchOperatorEnum.Contains,
                Value = 1234
            };

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.Foo LIKE '%1234%'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the numeric "IsBlank" filter
        /// </summary>
        [TestMethod]
        public void TestFringeNumericIsBlankFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where = new DSPredicate
            {
                Column = "Foo",
                Operator = DSSearchOperatorEnum.IsBlank,
                Value = 1234
            };

            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.Foo IS NULL";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());
        }

        /// <summary>
        /// Test the parameterized "Contains" filter
        /// </summary>
        [TestMethod]
        public void TestParameterizedContainsFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSContains("Bar", "a");

            DSSearchParser searchParser;
            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch, out searchParser, true);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.BarCol LIKE '%'+@p0+'%'";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());

            var sqlFilterBuilder = queryBuilder.WhereBuilder as DSSQLFilterBuilder;

            Assert.AreEqual(sqlFilterBuilder.Parameters.Count, 1, "Should be one parameter.");
            Assert.IsTrue(sqlFilterBuilder.Parameters.ContainsKey("@p0"), "Should have an '@p0' parameter.");
            Assert.AreEqual(sqlFilterBuilder.Parameters["@p0"], "a", "Parameter value should be '%a%'.");
        }

        /// <summary>
        /// Test the parameterized "In" filter
        /// </summary>
        [TestMethod]
        public void TestParameterizedNumericInFilter()
        {
            var simpleSearch = SearchSampleData.SimpleTestObjectASearch;
            simpleSearch.Where.DSIn("Foo", new List<object> { 1234, 2345, 3456, 4567, 5678 });

            DSSearchParser searchParser;
            var queryBuilder = DSSearchTestHelpers.CreateSearchBuilder(_entityTypeRepository, simpleSearch, out searchParser, true);

            var expectedQuery = "SELECT t.Foo" +
                " FROM dbo.TestObjectATable t WITH(NOLOCK)" +
                " WHERE t.Foo IN (@p0, @p1, @p2, @p3, @p4)";
            Assert.AreEqual(DSSearchTestHelpers.AddDefaultQueryOrder(expectedQuery, "t.TestObjectAKey"), queryBuilder.ToString());

            var sqlFilterBuilder = queryBuilder.WhereBuilder as DSSQLFilterBuilder;

            Assert.AreEqual(sqlFilterBuilder.Parameters.Count, 5, "Should be one parameter.");
            Assert.IsTrue(sqlFilterBuilder.Parameters.ContainsKey("@p0"), "Should have an '@p0' parameter.");
            Assert.AreEqual(sqlFilterBuilder.Parameters["@p0"], 1234, "Parameter value should be '1234'.");
            Assert.IsTrue(sqlFilterBuilder.Parameters.ContainsKey("@p4"), "Should have an '@p4' parameter.");
            Assert.AreEqual(sqlFilterBuilder.Parameters["@p4"], 5678, "Parameter value should be '5678'.");
        }
    }
}
