// <copyright file="PredicateSampleData.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.UnitTests.Common.Data
{
    using SDK.Search;

    /// <summary>
    /// Helper class for some commonly used DSPredicate instances.
    /// </summary>
    public static class PredicateSampleData
    {
        /// <summary>
        /// Gets PredicateA (A = 1)
        /// </summary>
        public static DSPredicate PredicateA
        {
            get
            {
                return new DSPredicate
                {
                    Column = "A",
                    Operator = DSSearchOperatorEnum.Equals,
                    Value = 1,
                };
            }
        }

        /// <summary>
        /// Gets PredicateB (B != 2)
        /// </summary>
        public static DSPredicate PredicateB
        {
            get
            {
                return new DSPredicate
                {
                    Column = "B",
                    Operator = DSSearchOperatorEnum.DoesNotEqual,
                    Value = 2,
                };
            }
        }

        /// <summary>
        /// Gets PredicateC (C = 3)
        /// </summary>
        public static DSPredicate PredicateC
        {
            get
            {
                return new DSPredicate
                {
                    Column = "C",
                    Operator = DSSearchOperatorEnum.Equals,
                    Value = 3,
                };
            }
        }

        /// <summary>
        /// Gets PredicateD (D != 4)
        /// </summary>
        public static DSPredicate PredicateD
        {
            get
            {
                return new DSPredicate
                {
                    Column = "D",
                    Operator = DSSearchOperatorEnum.DoesNotEqual,
                    Value = 4,
                };
            }
        }
    }
}
