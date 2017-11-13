// <copyright file="DSSearch.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Search
{
    using System;
    using System.Collections.Generic;
    using Data;

    /// <summary>
    /// Represents a search definition. 
    /// </summary>
    public class DSSearch
    {
        /// <summary>
        /// Storage for whether this is a DISTINCT serach or not.
        /// </summary>
        private bool? _distinct;

        /// <summary>
        /// Storage for the list of sort instructions.
        /// </summary>
        private List<DSOrder> _order;

        /// <summary>
        /// Storage for the filter instructions.
        /// </summary>
        private DSPredicate _where;

        /// <summary>
        /// Initializes a new instance of the <see cref="DSSearch"/> class.
        /// </summary>
        public DSSearch()
        {
            // Initialize the core objects to avoid Null references
            Select = new List<string>();

            Page = 1;
            PageSize = 25;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSSearch"/> class with a type.
        /// </summary>
        /// <param name="entityType">The type of entity to search against.</param>
        public DSSearch(string entityType) : this()
        {
            Type = entityType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSSearch"/> class with a type.
        /// </summary>
        /// <param name="entityType">The type of entity to search against.</param>
        public DSSearch(Type entityType) : this()
        {
            if (entityType.IsSubclassOf(typeof(DSEntity)))
            {

            }
            else
            {
                throw new ArgumentException("Expected a type of DSEntity.");
            }
        }

        /// <summary>
        /// Gets or sets the type of entity to search against.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the number of items to return in a page of data.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the page of data to return.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a DISTINCT serach or not.
        /// </summary>
        public bool Distinct
        {
            get { return _distinct.HasValue && _distinct.Value; }
            set { _distinct = value; }
        }

        /// <summary>
        /// Gets or sets the list of fields to return in the result set.
        /// </summary>
        public List<string> Select { get; set; }

        /// <summary>
        /// Gets or sets the filter instructions.
        /// </summary>
        public DSPredicate Where
        {
            get
            {
                if (_where == null)
                {
                    _where = new DSPredicate();
                }

                return _where;
            }

            set
            {
                _where = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of sort instructions.
        /// </summary>
        public List<DSOrder> Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new List<DSOrder>();
                }

                return _order;
            }

            set
            {
                _order = value;
            }
        }

        /// <summary>
        /// Append a sort instruction using the supplied field.
        /// </summary>
        /// <param name="field">Field to sort by (ascending).</param>
        /// <returns>A reference to this DSSearch instance.</returns>
        public DSSearch AddOrder(string field)
        {
            Order.Add(new DSOrder(field));
            return this;
        }

        /// <summary>
        /// Append a descending sort instruction using the supplied field.
        /// </summary>
        /// <param name="field">Field to sort by (descending).</param>
        /// <returns>A reference to this DSSearch instance.</returns>
        public DSSearch AddOrderDesc(string field)
        {
            Order.Add(new DSOrder(field, true));
            return this;
        }

        /// <summary>
        /// Append multiple fields to the select list.
        /// </summary>
        /// <param name="select">List of fields to add.</param>
        /// <returns>A reference to this DSSearch instance.</returns>
        public DSSearch AddSelect(params string[] select)
        {
            Select.AddRange(select);
            return this;
        }

        /// <summary>
        /// Added for JSON Serialization to skip Distinct attribute if it has not been set.
        /// This is done to reduce the overall size of the JSON by excluding this data.
        /// </summary>
        /// <returns>True if the Distinct attribute is set, False otherwise.</returns>
        public bool ShouldSerializeDistinct()
        {
            return _distinct.HasValue;
        }

        /// <summary>
        /// Added for JSON Serialization to skip Where attribute if it has not been set.
        /// This is done to reduce the overall size of the JSON by excluding this data.
        /// </summary>
        /// <returns>True if the Where attribute is set, False otherwise.</returns>
        public bool ShouldSerializeWhere()
        {
            return _where != null;
        }

        /// <summary>
        /// Added for JSON Serialization to skip Order attribute if it has not been set.
        /// This is done to reduce the overall size of the JSON by excluding this data.
        /// </summary>
        /// <returns>True if the Order attribute is set, False otherwise.</returns>
        public bool ShouldSerializeOrder()
        {
            return _order != null;
        }
    }
}
