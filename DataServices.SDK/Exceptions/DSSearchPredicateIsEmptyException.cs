// <copyright file="DSSearchPredicateIsEmptyException.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Exceptions
{
    /// <summary>
    /// Exception thrown when an empty DSPredicate is added to an existing DSPredicate.
    /// </summary>
    public class DSSearchPredicateIsEmptyException : DSSearchBuildException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSSearchPredicateIsEmptyException"/> class.
        /// </summary>
        public DSSearchPredicateIsEmptyException() : base("Cannot add an empty predicate.")
        {
        }
    }
}
