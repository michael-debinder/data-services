// <copyright file="DSPredicateExtensions.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Search
{
    using System.Collections.Generic;

    /// <summary>
    /// Extension methods for generating specific filter types.
    /// </summary>
    public static class DSPredicateExtensions
    {
        /// <summary>
        /// Add a "contains" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <param name="value">Value to apply.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSContains(this DSPredicate predicate, string column, string value)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.Contains,
                Value = value,
            });

            return predicate;
        }

        /// <summary>
        /// Add a "does not equal" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <param name="value">Value to apply.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSDoesNotEqual(this DSPredicate predicate, string column, object value)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.DoesNotEqual,
                Value = value,
            });

            return predicate;
        }

        /// <summary>
        /// Add a "ends with" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <param name="value">Value to apply.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSEndsWith(this DSPredicate predicate, string column, string value)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.EndsWith,
                Value = value,
            });

            return predicate;
        }

        /// <summary>
        /// Add a "equals" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <param name="value">Value to apply.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSEquals(this DSPredicate predicate, string column, object value)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.Equals,
                Value = value,
            });

            return predicate;
        }

        /// <summary>
        /// Add a "greater than" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <param name="value">Value to apply.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSGreaterThan(this DSPredicate predicate, string column, object value)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.GreaterThan,
                Value = value,
            });

            return predicate;
        }

        /// <summary>
        /// Add a "greater than or equal" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <param name="value">Value to apply.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSGreaterThanOrEqual(this DSPredicate predicate, string column, object value)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.GreaterThanOrEqual,
                Value = value,
            });

            return predicate;
        }

        /// <summary>
        /// Add a "in" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <param name="value">List of values to apply.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSIn(this DSPredicate predicate, string column, List<object> value)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.In,
                Value = value,
            });

            return predicate;
        }

        /// <summary>
        /// Add a "is blank" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSIsBlank(this DSPredicate predicate, string column)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.IsBlank,
            });

            return predicate;
        }

        /// <summary>
        /// Add a "is not blank" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSIsNotBlank(this DSPredicate predicate, string column)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.IsNotBlank,
            });

            return predicate;
        }

        /// <summary>
        /// Add a "less than" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <param name="value">Value to apply.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSLessThan(this DSPredicate predicate, string column, object value)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.LessThan,
                Value = value,
            });

            return predicate;
        }

        /// <summary>
        /// Add a "less than or equal" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <param name="value">Value to apply.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSLessThanOrEqual(this DSPredicate predicate, string column, object value)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.LessThanOrEqual,
                Value = value,
            });

            return predicate;
        }
        
        /// <summary>
        /// Add a "starts with" filter to the supplied filter.
        /// </summary>
        /// <param name="predicate">Instance to which we are adding a filter.</param>
        /// <param name="column">Field to filter on.</param>
        /// <param name="value">Value to apply.</param>
        /// <returns>A reference to the instance to which we added the filter.</returns>
        public static DSPredicate DSStartsWith(this DSPredicate predicate, string column, string value)
        {
            predicate.Add(new DSPredicate
            {
                Column = column,
                Operator = DSSearchOperatorEnum.StartsWith,
                Value = value,
            });

            return predicate;
        }
    }
}
