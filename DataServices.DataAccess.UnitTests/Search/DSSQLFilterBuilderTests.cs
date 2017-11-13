// <copyright file="DSSQLFilterBuilderTests.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.UnitTests.Search
{
    using Caching;
    using DataAccess.Data;
    using DataAccess.Search;
    using DataServices.UnitTests.Common.Data;
    using DataServices.UnitTests.Common.EntityTypes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SDK.Search;

    /// <summary>
    /// Tests around the SQL filter builder process.
    /// </summary>
    [TestClass]
    public class DSSQLFilterBuilderTests
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
        /// Test rendering a single predicate into SQL where clause syntax.
        /// </summary>
        [TestMethod]
        public void TestSinglePredicate()
        {
            var testwhere = new DSPredicate();
            testwhere.Add(PredicateSampleData.PredicateA);

            var sqlBuilder = GetBuilder(testwhere);

            Assert.AreEqual("t.A = 1", sqlBuilder.ToString());
        }

        /// <summary>
        /// Test rendering a group predicate into SQL where clause syntax.
        /// </summary>
        [TestMethod]
        public void TestSingleGroupPredicate()
        {
            var testwhere = new DSPredicate();
            testwhere.Add(PredicateSampleData.PredicateA).Add(PredicateSampleData.PredicateB);

            var sqlBuilder = GetBuilder(testwhere);

            Assert.AreEqual("(t.A = 1 AND t.B <> 2)", sqlBuilder.ToString());
        }

        /// <summary>
        /// Test rendering a group of a single "and" a group predicate into SQL where clause syntax.
        /// </summary>
        [TestMethod]
        public void TestSingleAndGroupPredicate()
        {
            var testwhere = new DSPredicate();
            var group = new DSPredicate { OrGroup = true };
            group.Add(PredicateSampleData.PredicateB).Add(PredicateSampleData.PredicateC);

            testwhere.Add(PredicateSampleData.PredicateA).Add(group);

            var sqlBuilder = GetBuilder(testwhere);

            Assert.AreEqual("(t.A = 1 AND (t.B <> 2 OR t.C = 3))", sqlBuilder.ToString());
        }

        /// <summary>
        /// Test rendering a group of a single "or" a group predicate into SQL where clause syntax.
        /// </summary>
        [TestMethod]
        public void TestSingleOrGroupPredicate()
        {
            var testwhere = new DSPredicate();
            var group = new DSPredicate();
            group.Add(PredicateSampleData.PredicateB).Add(PredicateSampleData.PredicateC);

            testwhere.OrGroup = true;
            testwhere.Add(PredicateSampleData.PredicateA).Add(group);

            var sqlBuilder = GetBuilder(testwhere);

            Assert.AreEqual("(t.A = 1 OR (t.B <> 2 AND t.C = 3))", sqlBuilder.ToString());
        }

        /// <summary>
        /// Test rendering an "or" group of "and" predicate groups into SQL where clause syntax.
        /// </summary>
        [TestMethod]
        public void TestMultipleGroupPredicate()
        {
            var testwhere = new DSPredicate();
            var group1 = new DSPredicate();
            group1.Add(PredicateSampleData.PredicateA).Add(PredicateSampleData.PredicateB);

            var group2 = new DSPredicate();
            group2.Add(PredicateSampleData.PredicateC).Add(PredicateSampleData.PredicateD);

            testwhere.OrGroup = true;
            testwhere.Add(group1).Add(group2);

            var sqlBuilder = GetBuilder(testwhere);

            Assert.AreEqual("((t.A = 1 AND t.B <> 2) OR (t.C = 3 AND t.D <> 4))", sqlBuilder.ToString());
        }

        /// <summary>
        /// Test rendering an "and" group of "or" predicate groups into SQL where clause syntax.
        /// </summary>
        [TestMethod]
        public void TestMultipleOrGroupPredicate()
        {
            var testwhere = new DSPredicate();
            var group1 = new DSPredicate { OrGroup = true };
            group1.Add(PredicateSampleData.PredicateA).Add(PredicateSampleData.PredicateB);

            var group2 = new DSPredicate { OrGroup = true };
            group2.Add(PredicateSampleData.PredicateC).Add(PredicateSampleData.PredicateD);

            testwhere.Add(group1).Add(group2);

            var sqlBuilder = GetBuilder(testwhere);

            Assert.AreEqual("((t.A = 1 OR t.B <> 2) AND (t.C = 3 OR t.D <> 4))", sqlBuilder.ToString());
        }

        /// <summary>
        /// Initialize a proper search builder for the supplied filter.
        /// </summary>
        /// <param name="testWhere">The filter to generate a search builder for.</param>
        /// <returns>Search builder for the supplied filter</returns>
        private DSSQLFilterBuilder GetBuilder(DSPredicate testWhere)
        {
            var sqlBuilder = new DSSQLSearchBuilder();
            var searchParser = new DSSearchParser(_entityTypeRepository, sqlBuilder);
            var search = new DSSearch(TestObjectC.ClassName);
            search.Where = testWhere;

            searchParser.BuildSearch(search);

            return (DSSQLFilterBuilder)sqlBuilder.WhereBuilder;
        }
    }
}
