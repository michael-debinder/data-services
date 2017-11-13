// <copyright file="DSSQLSearchBuilder.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Search
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Implementation of a search builder for SQL Server 2012 and later (due to the use of the OFFSET...FETCH construct for paging).
    /// </summary>
    public class DSSQLSearchBuilder : IDSSearchBuilder
    {
        /// <summary>
        /// Storage for the "SELECT" list as it is being built.
        /// </summary>
        private StringBuilder _columnList;

        /// <summary>
        /// List of the columns already added to the "SELECT" list for easy searching.
        /// </summary>
        private List<string> _columnsAdded;

        /// <summary>
        /// Storage for the "FROM" clause as it is being built.
        /// </summary>
        private StringBuilder _tables;

        /// <summary>
        /// Dictionary of the table paths already added to the "FROM" clause with their corresponding aliases.
        /// </summary>
        private Dictionary<string, string> _tablesAdded;

        /// <summary>
        /// Storage for the "ORDER BY" clause as it is being built.
        /// </summary>
        private StringBuilder _orderByList;

        /// <summary>
        /// Storage for the current page to be returned.
        /// </summary>
        private int _page;

        /// <summary>
        /// Storage for the number of items to be returned.
        /// </summary>
        private int _pageSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="DSSQLSearchBuilder"/> class with the parameterize flag.
        /// </summary>
        /// <param name="parameterize">Whether this search should be parameterized.</param>
        public DSSQLSearchBuilder(bool parameterize)
        {
            _columnList = new StringBuilder();
            _tables = new StringBuilder();
            _orderByList = new StringBuilder();

            WhereBuilder = new DSSQLFilterBuilder(parameterize);

            _columnsAdded = new List<string>();
            _tablesAdded = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSSQLSearchBuilder"/> class.
        /// </summary>
        public DSSQLSearchBuilder() : this(false)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether to return a distinct set of values (i.e. eliminate duplicate rows)
        /// </summary>
        public bool Distinct { get; set; }

        /// <summary>
        /// Gets a value indicating whether this search should be parameterized.
        /// </summary>
        public bool Parameterize
        {
            get
            {
                if (WhereBuilder is DSSQLFilterBuilder)
                {
                    return ((DSSQLFilterBuilder)WhereBuilder).Parameterize;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets or sets the filter builder to be used during the parsing process.
        /// </summary>
        public IDSFilterBuilder WhereBuilder { get; protected set; }

        /// <summary>
        /// Set the paging instructions for the result set.
        /// </summary>
        /// <param name="page">Page number of results to return.</param>
        /// <param name="pageSize">Number of items to return for each page.</param>
        public void AddPaging(int page, int pageSize)
        {
            _page = page;
            _pageSize = pageSize;
        }

        /// <summary>
        /// Add the supplied data element to the result set definition.
        /// </summary>
        /// <param name="path">Path to the entity on which the data element exists.</param>
        /// <param name="name">Name of the data element.</param>
        /// <param name="alias">Alias to give to the result set element containing this element.</param>
        public void AddSelect(string path, string name, string alias)
        {
            if (!_columnsAdded.Contains(alias ?? name))
            {
                if (_columnList.Length > 0)
                {
                    _columnList.Append(", ");
                }

                _columnList.AppendFormat(
                    "{0}.{1}{2}{3}",
                    _tablesAdded[path ?? string.Empty],
                    name,
                    string.IsNullOrEmpty(alias) ? string.Empty : " ",
                    alias);

                _columnsAdded.Add(alias ?? name);
            }
        }

        /// <summary>
        /// Add the supplied sorting directive to the result set.
        /// </summary>
        /// <param name="name">Name of the data element.</param>
        /// <param name="desc">When true, sort descending, otherwise sort ascending.</param>
        public void AddSort(string name, bool desc)
        {
            if (_orderByList.Length > 0)
            {
                _orderByList.Append(", ");
            }

            _orderByList.AppendFormat("{0}{1}", name, desc ? " DESC" : string.Empty);
        }

        /// <summary>
        /// Add the supplied table to the query.
        /// </summary>
        /// <param name="table">Name of the table to add.</param>
        /// <param name="pathTo">Path to this table.</param>
        /// <param name="pathKey">Key of the last table in path on which to reference.</param>
        /// <param name="tableKey">Key of the table we are adding.</param>
        /// <param name="required">When true, this table is a required element, otherwise it could be null.</param>
        public void AddTable(string table, string pathTo = null, string pathKey = null, string tableKey = null, bool required = true)
        {
            var path = string.IsNullOrEmpty(pathTo) ? table : string.Format("{0}.{1}", pathTo, table);

            // Check if this path has already been accounted for
            if (!_tablesAdded.ContainsKey(path))
            {
                if (!string.IsNullOrEmpty(pathTo))
                {
                    // New table to join, so add JOIN and make LEFT JOIN if not required
                    _tables.AppendFormat(" {0}JOIN ", required ? "LEFT " : string.Empty);
                }

                var alias = GetAlias(table);
                AppendTable(table, alias);

                if (!string.IsNullOrEmpty(pathTo))
                {
                    // With a JOIN, must also supply the ON clause
                    _tables.AppendFormat(
                    " ON {0}.{1} = {2}.{3}",
                    _tablesAdded[pathTo],
                    pathKey,
                    alias,
                    tableKey);
                }

                _tablesAdded.Add(path, alias);
            }
        }

        /// <summary>
        /// Finalize the search content.
        /// </summary>
        public void Complete()
        {
            // Nothing really needed
        }
        
        /// <summary>
        /// Get the correctly aliased name of the supplied element.
        /// </summary>
        /// <param name="path">Path to the entity on which the data element exists.</param>
        /// <param name="name">Name of the data element.</param>
        /// <returns>The correctly aliased name of the supplied element.</returns>
        public string GetQualifiedName(string path, string name)
        {
            return string.Format("{0}.{1}", _tablesAdded[path ?? string.Empty], name);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var whereClause = WhereBuilder.ToString();
            if (whereClause.Length > 0)
            {
                whereClause = " WHERE " + whereClause;
            }

            // TODO - Implement Parameterized.
            return string.Format(
                "SELECT {0}{1} FROM {2}{3}{4}{5} OFFSET {6} ROWS FETCH NEXT {7} ROWS ONLY",
                Distinct ? "DISTINCT " : string.Empty,
                _columnList.ToString(),
                _tables.ToString(),
                whereClause,
                _orderByList.Length > 0 ? " ORDER BY " : string.Empty,
                _orderByList.ToString(),
                (_page - 1) * _pageSize,
                _pageSize);
        }

        /// <summary>
        /// Returns a string that represents the "count" version of the current object.
        /// </summary>
        /// <returns>A string that represents the "count" version of the current object.</returns>
        public string ToStringForCount()
        {
            var whereClause = WhereBuilder.ToString();
            if (whereClause.Length > 0)
            {
                whereClause = " WHERE " + whereClause;
            }

            // TODO - Implement Parameterized.
            if (Distinct)
            {
                return string.Format(
                    "SELECT COUNT(*) FROM (SELECT DISTINCT {0} FROM {1}{2}) dis",
                    _columnList.ToString(),
                    _tables.ToString(),
                    whereClause);
            }
            else
            {
                return string.Format(
                    "SELECT COUNT(*) FROM {0}{1}",
                    _tables.ToString(),
                    whereClause);
            }
        }

        /// <summary>
        /// Append the table with proper formatting to the FROM clause.
        /// </summary>
        /// <param name="table">The physical table name.</param>
        /// <param name="alias">The alias to be used by this query.</param>
        private void AppendTable(string table, string alias)
        {
            _tables.AppendFormat("dbo.{0} {1} WITH(NOLOCK)", table, alias);
        }

        /// <summary>
        /// Generate an alias for supplied table.
        /// </summary>
        /// <param name="table">Table to generate an alias for.</param>
        /// <returns>Alias for supplied table.</returns>
        private string GetAlias(string table)
        {
            var firstChar = table[0].ToString().ToLower();
            var i = 1;

            var alias = firstChar;
            var currentAliases = _tablesAdded.Values.ToList();
            while (currentAliases.Contains(alias))
            {
                // We actually want to start with 2 to designate it as the second
                i++;
                alias = firstChar + i;
            }

            return alias;
        }
    }
}
