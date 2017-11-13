// <copyright file="Entity.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Data
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents a generic search result item.
    /// </summary>
    [DataContract]
    public class DSEntity
    {
        /// <summary>
        /// Storage for the dictionary of attributes associated to this result.
        /// </summary>
        private Dictionary<string, object> _attributes = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets the type of the entity.
        /// </summary>
        [DataMember]
        public virtual string Type { get; set; }

        /// <summary>
        /// Gets or sets the dictionary of attributes associated to this result.
        /// </summary>
        [DataMember]
        public Dictionary<string, object> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        /// <summary>
        /// Indexer for the attributes on this entity.
        /// </summary>
        /// <param name="index">Name of the attribute to get.</param>
        /// <returns>The value associated to the supplied attribute name.</returns>
        public object this[string index]
        {
            get { return _attributes[index]; }
            set { _attributes[index] = value; }
        }

        /// <summary>
        /// Returns a strongly typed value for the supplied attribute name.
        /// </summary>
        /// <typeparam name="T">Type of value expected.</typeparam>
        /// <param name="attribute">Name of the attribute to get.</param>
        /// <returns>A strongly typed value for the supplied attribute name.</returns>
        public T Get<T>(string attribute)
        {
            var val = this[attribute];

            if (val is T)
            {
                return (T)val;
            }

            return default(T);
        }
    }
}
