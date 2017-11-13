// <copyright file="DSSearchOperatorEnum.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Search
{
    /// <summary>
    /// Enumeration of the available filters that can be applied.
    /// </summary>
    public enum DSSearchOperatorEnum
    {
        /// <summary>No operator.</summary>
        None,

        /// <summary>Is Blank operator.</summary>
        IsBlank,

        /// <summary>Is Not Blank operator.</summary>
        IsNotBlank,

        /// <summary>Equals operator.</summary>
        Equals,

        /// <summary>Does Not Equal operator.</summary>
        DoesNotEqual,

        /// <summary>Greater Than operator.</summary>
        GreaterThan,

        /// <summary>Greater Than Or Equal operator.</summary>
        GreaterThanOrEqual,

        /// <summary>Less Than operator.</summary>
        LessThan,

        /// <summary>Less Than Or Equal operator.</summary>
        LessThanOrEqual,

        /// <summary>In operator.</summary>
        In,

        /// <summary>Contains operator.</summary>
        Contains,

        /// <summary>Starts With operator.</summary>
        StartsWith,

        /// <summary>Ends With operator.</summary>
        EndsWith
    }
}
