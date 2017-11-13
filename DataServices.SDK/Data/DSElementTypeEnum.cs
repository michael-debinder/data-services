// <copyright file="DSElementTypeEnum.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Data
{
    /// <summary>
    /// Enumeration of the available element data types.
    /// </summary>
    public enum DSElementTypeEnum
    {
        /// <summary>Integer data type.</summary>
        Integer = 1,

        /// <summary>String data type.</summary>
        String = 2,

        /// <summary>Boolean data type.</summary>
        Boolean = 3,

        /// <summary>Date data type.</summary>
        Date = 4,

        /// <summary>DateTime data type.</summary>
        DateTime = 5,

        /// <summary>Decimal data type.</summary>
        Decimal = 6,

        /// <summary>Reference data type.</summary>
        Reference = 7,

        /// <summary>Enum data type.</summary>
        Enum = 8,
    }
}
