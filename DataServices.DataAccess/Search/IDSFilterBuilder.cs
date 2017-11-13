// <copyright file="IDSFilterBuilder.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Search
{
    using SDK.Search;

    /// <summary>
    /// Interface for filter builders used by DSSearchParser to convert DSSearch where clauses to actual data filters.
    /// </summary>
    public interface IDSFilterBuilder
    {
        /// <summary>
        /// Append supplied clause to the overall filter.
        /// </summary>
        /// <param name="column">Name of the element to filter on.</param>
        /// <param name="op">Comparison operation.</param>
        /// <param name="value">Value to compare to element.</param>
        /// <param name="appendAsOr">When true, new filter added as an "or" to the previous filters, otherwise appended as an "and".</param>
        /// <param name="first">When true, this is the first filter \ group so there is nothing to append a conjunction to, otherwise there is.</param>
        void AppendPredicate(string column, DSSearchOperatorEnum op, object value, bool appendAsOr, bool first = false);

        /// <summary>
        /// End the current group of filters.
        /// </summary>
        void CloseGroup();

        /// <summary>
        /// Finalize the filter content.
        /// </summary>
        void Complete();

        /// <summary>
        /// Begin a new logical grouping of filters.
        /// </summary>
        /// <param name="appendAsOr">When true, new group added as an "or" to the previous filters, otherwise appended as an "and".</param>
        /// <param name="first">When true, this is the first filter \ group so there is nothing to append a conjunction to, otherwise there is.</param>
        void StartGroup(bool appendAsOr, bool first = false);
    }
}
