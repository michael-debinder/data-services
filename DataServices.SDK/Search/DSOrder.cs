// <copyright file="DSOrder.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Search
{
    /// <summary>
    /// Represents a sort instruction. 
    /// </summary>
    public class DSOrder
    {
        /// <summary>
        /// Storage for whether the sort direction is descending or not.
        /// </summary>
        private bool? _desc;

        /// <summary>
        /// Initializes a new instance of the <see cref="DSOrder"/> class.
        /// </summary>
        public DSOrder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSOrder"/> class with the field.
        /// </summary>
        /// <param name="name">The field to sort on.</param>
        public DSOrder(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSOrder"/> class with the field and direction.
        /// </summary>
        /// <param name="name">The field to sort on.</param>
        /// <param name="desc">Whether the sort direction is descending or not.</param>
        public DSOrder(string name, bool desc) : this(name)
        {
            Desc = desc;
        }

        /// <summary>
        /// Gets or sets the field to sort on.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the sort direction is descending or not.
        /// </summary>
        public bool Desc
        {
            get { return _desc.HasValue && _desc.Value; }
            set { _desc = value; }
        }
        
        /// <summary>
        /// Added for JSON Serialization to skip Desc attribute if it has not been set.
        /// This is done to reduce the overall size of the JSON by excluding this data.
        /// </summary>
        /// <returns>True if the Desc attribute is set, False otherwise.</returns>
        public bool ShouldSerializeDesc()
        {
            return _desc.HasValue;
        }
    }
}
