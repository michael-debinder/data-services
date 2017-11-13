// <copyright file="DSParam.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Search
{
    /// <summary>
    /// Wrapper to signify we are using a Parameter in the SQL
    /// </summary>
    public class DSParam
    {
        /// <summary>
        /// Internal value of the parameter name.
        /// </summary>
        private string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="DSParam"/> class with its value.
        /// </summary>
        /// <param name="value">Parameter name.</param>
        public DSParam(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return _value;
        }
    }
}
