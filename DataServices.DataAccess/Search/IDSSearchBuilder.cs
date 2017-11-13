// <copyright file="IDSSearchBuilder.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Search
{
    /// <summary>
    /// Interface for search builders used by DSSearchParser to convert DSSearch to actual data retrieval.
    /// </summary>
    public interface IDSSearchBuilder
    {
        /// <summary>
        /// Gets or sets a value indicating whether to return a distinct set of values (i.e. eliminate duplicate rows)
        /// </summary>
        bool Distinct { get; set; }

        /// <summary>
        /// Gets the filter builder to be used during the parsing process.
        /// </summary>
        IDSFilterBuilder WhereBuilder { get; }

        /// <summary>
        /// Set the paging instructions for the result set.
        /// </summary>
        /// <param name="page">Page number of results to return.</param>
        /// <param name="pageSize">Number of items to return for each page.</param>
        void AddPaging(int page, int pageSize);

        /// <summary>
        /// Add the supplied data element to the result set definition.
        /// </summary>
        /// <param name="path">Path to the entity on which the data element exists.</param>
        /// <param name="name">Name of the data element.</param>
        /// <param name="alias">Alias to give to the result set element containing this element.</param>
        void AddSelect(string path, string name, string alias);

        /// <summary>
        /// Add the supplied sorting directive to the result set.
        /// </summary>
        /// <param name="name">Name of the data element.</param>
        /// <param name="desc">When true, sort descending, otherwise sort ascending.</param>
        void AddSort(string name, bool desc);

        /// <summary>
        /// Add the supplied table to the query.
        /// </summary>
        /// <param name="table">Name of the table to add.</param>
        /// <param name="pathTo">Path to this table.</param>
        /// <param name="pathKey">Key of the last table in path on which to reference.</param>
        /// <param name="tableKey">Key of the table we are adding.</param>
        /// <param name="required">When true, this table is a required element, otherwise it could be null.</param>
        void AddTable(string table, string pathTo = null, string pathKey = null, string tableKey = null, bool required = true);

        /// <summary>
        /// Finalize the search content.
        /// </summary>
        void Complete();

        /// <summary>
        /// Get the correctly aliased name of the supplied element.
        /// </summary>
        /// <param name="path">Path to the entity on which the data element exists.</param>
        /// <param name="name">Name of the data element.</param>
        /// <returns>The correctly aliased name of the supplied element.</returns>
        string GetQualifiedName(string path, string name);
    }
}
