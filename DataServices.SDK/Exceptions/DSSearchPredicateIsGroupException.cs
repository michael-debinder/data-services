// <copyright file="DSSearchPredicateIsGroupException.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Exceptions
{
    /// <summary>
    /// Exception thrown when DSPredicate attributes are set when it is already defined as a group of other predicates.
    /// </summary>
    public class DSSearchPredicateIsGroupException : DSSearchBuildException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSSearchPredicateIsGroupException"/> class.
        /// </summary>
        public DSSearchPredicateIsGroupException() : base("Cannot set predicate attributes when it is a group of other predicates.")
        {
        }
    }
}
