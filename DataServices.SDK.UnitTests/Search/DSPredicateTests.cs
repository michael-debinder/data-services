// <copyright file="DSPredicateTests.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.UnitTests.Search
{
    using DataServices.UnitTests.Common.Data;
    using Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SDK.Search;

    /// <summary>
    /// Tests around the DSPredicate object.
    /// </summary>
    [TestClass]
    public class DSPredicateTests
    {
        /// <summary>
        /// Test that the IsValid check identifies empty predicate.
        /// </summary>
        [TestMethod]
        public void TestIsValidFail()
        {
            var testPredicate = new DSPredicate();

            Assert.IsFalse(testPredicate.IsValid, "Empty predicate is not valid.");
        }

        /// <summary>
        /// Test that the IsValid check works against a single predicate.
        /// </summary>
        [TestMethod]
        public void TestIsValidAsSingle()
        {
            var testPredicate = PredicateSampleData.PredicateA;

            Assert.IsTrue(testPredicate.IsValid, "Populated predicate should be valid.");
        }

        /// <summary>
        /// Test that the IsValid check works against a predicate group.
        /// </summary>
        [TestMethod]
        public void TestIsValidAsGroup()
        {
            // TODO - Is there a way to test this without having to use "Add" function? Possibly reflect and set "Predicates" directly?
            var groupPredicate = new DSPredicate();
            groupPredicate.Add(PredicateSampleData.PredicateA).Add(PredicateSampleData.PredicateB);

            Assert.IsTrue(groupPredicate.IsValid, "Group of predicates should be valid.");
        }

        /// <summary>
        /// Test that adding an empty predicate as the first one throws an error.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DSSearchPredicateIsEmptyException))]
        public void TestAddEmpty()
        {
            var testWhere = new DSPredicate();
            var testPredicate = new DSPredicate();
            testWhere.Add(testPredicate);
        }

        /// <summary>
        /// Test adding a single predicate.
        /// </summary>
        [TestMethod]
        public void TestAddSingle()
        {
            var testWhere = new DSPredicate();
            testWhere.Add(PredicateSampleData.PredicateA);

            Assert.AreEqual("A", testWhere.Column, "Column data not set properly.");
            Assert.AreEqual(DSSearchOperatorEnum.Equals, testWhere.Operator, "Operator data not set properly.");
            Assert.AreEqual(1, testWhere.Value, "Value data not set properly.");
            Assert.AreEqual(0, testWhere.Predicates.Count, "Should only be single predicate.");
        }

        /// <summary>
        /// Test that adding an empty predicate as the second one throws an error.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DSSearchPredicateIsEmptyException))]
        public void TestAddSecondEmpty()
        {
            var testWhere = new DSPredicate();
            var testPredicate = new DSPredicate();
            testWhere.Add(PredicateSampleData.PredicateA).Add(testPredicate);
        }

        /// <summary>
        /// Test that adding an empty predicate as the third one throws an error.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DSSearchPredicateIsEmptyException))]
        public void TestAddThirdEmpty()
        {
            var testWhere = new DSPredicate();
            var testPredicate = new DSPredicate();
            testWhere.Add(PredicateSampleData.PredicateA).Add(PredicateSampleData.PredicateB).Add(testPredicate);
        }

        /// <summary>
        /// Test adding multiple predicates.
        /// </summary>
        [TestMethod]
        public void TestAddMultiple()
        {
            var testWhere = new DSPredicate();
            testWhere
                .Add(PredicateSampleData.PredicateA)
                .Add(PredicateSampleData.PredicateB)
                .Add(PredicateSampleData.PredicateC);

            Assert.IsTrue(testWhere.IsGroup, "Multile Add calls should create a Group.");
            Assert.AreEqual(3, testWhere.Predicates.Count, "Multiple Add calls should have created a list of length 3.");
            Assert.AreEqual("A", testWhere[0].Column, "First Predicate Column data not set properly.");
            Assert.AreEqual(DSSearchOperatorEnum.Equals, testWhere[0].Operator, "First Predicate Operator data not set properly.");
            Assert.AreEqual(1, testWhere[0].Value, "First Predicate Value data not set properly.");
            Assert.AreEqual("B", testWhere[1].Column, "Second Predicate Column data not set properly.");
            Assert.AreEqual(DSSearchOperatorEnum.DoesNotEqual, testWhere[1].Operator, "Second Predicate Operator data not set properly.");
            Assert.AreEqual(2, testWhere[1].Value, "Second Predicate Value data not set properly.");
            Assert.AreEqual("C", testWhere[2].Column, "Third Predicate Column data not set properly.");
            Assert.AreEqual(DSSearchOperatorEnum.Equals, testWhere[2].Operator, "Third Predicate Operator data not set properly.");
            Assert.AreEqual(3, testWhere[2].Value, "Third Predicate Value data not set properly.");
        }

        /// <summary>
        /// Test adding a group predicate to a single predicate.
        /// </summary>
        [TestMethod]
        public void TestSingleAndGroupPredicate()
        {
            var testWhere = new DSPredicate();
            var group = new DSPredicate();
            group.Add(PredicateSampleData.PredicateB).Add(PredicateSampleData.PredicateC);

            testWhere.Add(PredicateSampleData.PredicateA).Add(group);

            Assert.IsTrue(testWhere.IsGroup, "Multile Add calls should create a Group.");
            Assert.AreEqual(2, testWhere.Predicates.Count, "Multiple Add calls should have created a list of length 2.");
            Assert.IsFalse(testWhere.Predicates[0].IsGroup, "First Item should be single predicate.");
            Assert.AreEqual(2, testWhere.Predicates[1].Predicates.Count, "Second Item should be a list of length 2.");
        }
    }
}
