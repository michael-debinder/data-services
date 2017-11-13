// <copyright file="DSPredicate.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Search
{
    using System.Collections.Generic;
    using Exceptions;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents a filter instruction. 
    /// </summary>
    public class DSPredicate
    {
        /// <summary>
        /// Storage for the target field to filter against.
        /// </summary>
        private string _column;

        /// <summary>
        /// Storage for the filtering operator.
        /// </summary>
        private DSSearchOperatorEnum _operator;

        /// <summary>
        /// Storage for the type of value to apply.
        /// </summary>
        private string _valueType;

        /// <summary>
        /// Storage for the value to apply to the field.
        /// </summary>
        private object _value;

        /// <summary>
        /// Storage for the list of associated additional filters.
        /// </summary>
        private List<DSPredicate> _predicates;

        /// <summary>
        /// Initializes a new instance of the <see cref="DSPredicate"/> class.
        /// </summary>
        public DSPredicate()
        {
        }

        /// <summary>
        /// Gets or sets the target field to filter against.
        /// </summary>
        public string Column
        {
            get
            {
                return _column;
            }

            set
            {
                if (IsGroup)
                {
                    throw new DSSearchPredicateIsGroupException();
                }

                _column = value;
            }
        }

        /// <summary>
        /// Gets or sets the filtering operator.
        /// </summary>
        public DSSearchOperatorEnum Operator
        {
            get
            {
                return _operator;
            }

            set
            {
                if (IsGroup)
                {
                    throw new DSSearchPredicateIsGroupException();
                }

                _operator = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of value to apply.
        /// </summary>
        public string ValueType
        {
            get
            {
                return _valueType;
            }

            set
            {
                if (IsGroup)
                {
                    throw new DSSearchPredicateIsGroupException();
                }

                _valueType = value;
            }
        }

        /// <summary>
        /// Gets or sets the value to apply to the field.
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (IsGroup)
                {
                    throw new DSSearchPredicateIsGroupException();
                }

                _value = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the group should apply an "Or" conjunction on its list of filters.
        /// </summary>
        public bool OrGroup { get; set; }

        /// <summary>
        /// Gets the list of associated additional filters.
        /// </summary>
        public List<DSPredicate> Predicates
        {
            get
            {
                if (_predicates == null)
                {
                    _predicates = new List<DSPredicate>();
                }

                return _predicates;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a group of filters.
        /// </summary>
        [IgnoreDataMember]
        public bool IsGroup
        {
            get
            {
                if (Predicates.Count > 0)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this filter is initialized correctly.
        /// </summary>
        [IgnoreDataMember]
        public bool IsValid
        {
            get
            {
                if (!(string.IsNullOrWhiteSpace(Column) || Operator == DSSearchOperatorEnum.None))
                {
                    return true;
                }

                if (IsGroup)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Indexer for the list of filters.
        /// </summary>
        /// <param name="i">The index to retrieve.</param>
        /// <returns>Filter at the supplied index.</returns>
        public DSPredicate this[int i]
        {
            get { return Predicates[i]; }
            set { Predicates[i] = value; }
        }

        /// <summary>
        /// Add the supplied filter appropriately.
        /// </summary>
        /// <param name="clause">Filter to add.</param>
        /// <returns>A reference to this instance.</returns>
        public DSPredicate Add(DSPredicate clause)
        {
            if (!clause.IsValid)
            {
                throw new DSSearchPredicateIsEmptyException();
            }

            if (string.IsNullOrWhiteSpace(Column))
            {
                if (IsGroup || string.IsNullOrWhiteSpace(clause.Column))
                {
                    // Simply append this Group \ Predicate
                    this.Predicates.Add(clause);
                }
                else
                {
                    // The new Predicate needs to be copied into this one
                    this.Column = clause.Column;
                    this.Operator = clause.Operator;
                    this.ValueType = clause.ValueType;
                    this.Value = clause.Value;
                }
            }
            else
            {
                // In this case we are adding to a "single" predicate, so make the current predicate the first of the new "group"
                var clone = new DSPredicate()
                {
                    Column = this.Column,
                    Operator = this.Operator,
                    ValueType = this.ValueType,
                    Value = this.Value,
                };

                this.Column = null;
                this.Operator = DSSearchOperatorEnum.None;
                this.ValueType = null;
                this.Value = null;

                this.Predicates.Add(clone);

                // Append the new predicate to the group
                this.Predicates.Add(clause);
            }

            return this;
        }
    }
}
