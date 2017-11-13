// <copyright file="DSSQLFilterBuilder.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Search
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SDK.Exceptions;
    using SDK.Search;

    /// <summary>
    /// Implementation of a filter builder for SQL Server.
    /// </summary>
    public class DSSQLFilterBuilder : IDSFilterBuilder
    {
        /// <summary>
        /// Storage for the SQL Filter expression as it is being built.
        /// </summary>
        private StringBuilder _filterClause;

        /// <summary>
        /// Initializes a new instance of the <see cref="DSSQLFilterBuilder"/> class with the parameterize flag.
        /// </summary>
        /// <param name="parameterize">Whether this search should be parameterized.</param>
        public DSSQLFilterBuilder(bool parameterize) : this()
        {
            Parameterize = parameterize;

            if (parameterize)
            {
                Parameters = new Dictionary<string, object>();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSSQLFilterBuilder"/> class.
        /// </summary>
        public DSSQLFilterBuilder()
        {
            _filterClause = new StringBuilder();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this search should be parameterized.
        /// </summary>
        public bool Parameterize { get; protected set; }

        /// <summary>
        /// Gets or sets the list of parameters
        /// </summary>
        public Dictionary<string, object> Parameters { get; protected set; }

        /// <summary>
        /// Append supplied clause to the overall filter.
        /// </summary>
        /// <param name="column">Name of the element to filter on.</param>
        /// <param name="op">Comparison operation.</param>
        /// <param name="value">Value to compare to element.</param>
        /// <param name="appendAsOr">When true, new filter added as an "or" to the previous filters, otherwise appended as an "and".</param>
        /// <param name="first">When true, this is the first filter \ group so there is nothing to append a conjunction to, otherwise there is.</param>
        public void AppendPredicate(string column, DSSearchOperatorEnum op, object value, bool appendAsOr, bool first = false)
        {
            if (Parameterize)
            {
                // convert the values to parameters
                if (op == DSSearchOperatorEnum.In)
                {
                    var list = value as List<object>;
                    if (list != null)
                    {
                        var paramList = new List<object>();
                        foreach (var o in list)
                        {
                            var paramName = AddParam(o);
                            paramList.Add(new DSParam(paramName));
                        }

                        value = paramList;
                    }
                }
                else
                {
                    var paramName = AddParam(value);

                    value = new DSParam(paramName);
                }
            }

            if (!first)
            {
                AppendConjunction(appendAsOr);
            }

            _filterClause.AppendFormat("{0} {1}{2}", column, GetOperatorText(op), GetValueText(op, value));
        }

        /// <summary>
        /// End the current group of filters.
        /// </summary>
        public void CloseGroup()
        {
            _filterClause.Append(")");
        }

        /// <summary>
        /// Finalize the filter content.
        /// </summary>
        public void Complete()
        {
            // Don't really need to do anything
        }

        /// <summary>
        /// Begin a new logical grouping of filters.
        /// </summary>
        /// <param name="appendAsOr">When true, new group added as an "or" to the previous filters, otherwise appended as an "and".</param>
        /// <param name="first">When true, this is the first filter \ group so there is nothing to append a conjunction to, otherwise there is.</param>
        public void StartGroup(bool appendAsOr, bool first = false)
        {
            if (!first)
            {
                AppendConjunction(appendAsOr);
            }

            _filterClause.Append("(");
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            if (_filterClause == null)
            {
                return string.Empty;
            }

            return _filterClause.ToString();
        }

        /// <summary>
        /// Append a conjunction to the filter expression.
        /// </summary>
        /// <param name="appendAsOr">When true, new group added as an "or" to the previous filters, otherwise appended as an "and".</param>
        private void AppendConjunction(bool appendAsOr)
        {
            _filterClause.AppendFormat(" {0} ", appendAsOr ? "OR" : "AND");
        }

        /// <summary>
        /// Convert the supplied operator to the SQL expression to use.
        /// </summary>
        /// <param name="op">The operator to convert.</param>
        /// <returns>The SQL expression for the supplied operator.</returns>
        /// <exception cref="DSSearchBuildException">Throws when operator is not handled.</exception>
        private string GetOperatorText(DSSearchOperatorEnum op)
        {
            switch (op)
            {
                case DSSearchOperatorEnum.Contains:
                case DSSearchOperatorEnum.EndsWith:
                case DSSearchOperatorEnum.StartsWith:
                    return "LIKE";

                case DSSearchOperatorEnum.DoesNotEqual:
                    return "<>";

                case DSSearchOperatorEnum.Equals:
                    return "=";

                case DSSearchOperatorEnum.GreaterThan:
                    return ">";

                case DSSearchOperatorEnum.GreaterThanOrEqual:
                    return ">=";

                case DSSearchOperatorEnum.In:
                    return "IN";

                case DSSearchOperatorEnum.IsBlank:
                    return "IS NULL";

                case DSSearchOperatorEnum.IsNotBlank:
                    return "IS NOT NULL";

                case DSSearchOperatorEnum.LessThan:
                    return "<";

                case DSSearchOperatorEnum.LessThanOrEqual:
                    return "<=";
            }

            throw new DSSearchBuildException(string.Format("Unknown Operator: {0}", op));
        }

        /// <summary>
        /// Convert the supplied value to the necessary SQL expression based on the supplied operator.
        /// </summary>
        /// <param name="op">The operator used to determine conversion.</param>
        /// <param name="value">The value to convert.</param>
        /// <returns>The SQL expression for the supplied value based on the supplied operator.</returns>
        /// <exception cref="DSSearchBuildException">Throws when operator is not handled or value is incorrect type.</exception>
        private string GetValueText(DSSearchOperatorEnum op, object value)
        {
            switch (op)
            {
                case DSSearchOperatorEnum.Contains:
                    return FormatStringValue(" '%{0}%'", " '%'+{0}+'%'", value);

                case DSSearchOperatorEnum.EndsWith:
                    return FormatStringValue(" '%{0}'", " '%'+{0}", value);

                case DSSearchOperatorEnum.Equals:
                case DSSearchOperatorEnum.DoesNotEqual:
                case DSSearchOperatorEnum.GreaterThan:
                case DSSearchOperatorEnum.GreaterThanOrEqual:
                case DSSearchOperatorEnum.LessThan:
                case DSSearchOperatorEnum.LessThanOrEqual:
                    return string.Format(" {0}", FormatValue(value));

                case DSSearchOperatorEnum.In:
                    var list = value as List<object>;
                    if (list == null)
                    {
                        throw new DSSearchBuildException(string.Format("IN Operator requires a List but received {0}.", value.GetType()));
                    }

                    return string.Format(" ({0})", string.Join(", ", list.Select(i => FormatValue(i))));

                case DSSearchOperatorEnum.IsBlank:
                case DSSearchOperatorEnum.IsNotBlank:
                    return string.Empty;

                case DSSearchOperatorEnum.StartsWith:
                    return FormatStringValue(" '{0}%'", " {0}+'%'", value);
            }

            throw new DSSearchBuildException(string.Format("Unknown Operator: {0}", op));
        }

        /// <summary>
        /// Convert the supplied value to the necessary SQL expression based on its type.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <returns>The SQL expression for the supplied value.</returns>
        private string FormatValue(object value)
        {
            if (value is DSParam)
            {
                return string.Format("{0}", value);
            }

            if (value is string || value is DateTime)
            {
                return string.Format("'{0}'", value);
            }

            if (value is bool)
            {
                return string.Format("{0}", (bool)value ? 1 : 0);
            }

            if (value is int || value is decimal || value is long || value is double || value is byte || value is short || value is float)
            {
                return string.Format("{0}", value);
            }

            return string.Format("'{0}'", value);
        }

        /// <summary>
        /// Returns the correct template application based on the supplied value's type.
        /// </summary>
        /// <param name="template">Default template.</param>
        /// <param name="paramTemplate">Template to use if the vlue is a parameter (as in during a parameterized filter build).</param>
        /// <param name="value">Value to convert.</param>
        /// <returns>The correct template application based on the supplied value's type.</returns>
        private string FormatStringValue(string template, string paramTemplate, object value)
        {
            if (value is DSParam)
            {
                return string.Format(paramTemplate, value);
            }

            return string.Format(template, value);
        }

        /// <summary>
        /// Convert supplied value to a parameter.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <returns>Name of the parameter created.</returns>
        private string AddParam(object value)
        {
            var paramName = string.Format("@p{0}", Parameters.Count);
            Parameters.Add(paramName, value);

            return paramName;
        }
    }
}
