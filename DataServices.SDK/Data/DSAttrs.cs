// <copyright file="DSAttrs.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Data
{
    /// <summary>
    /// Represents an instance in a Entity Attrs hierarchy.
    /// </summary>
    public class DSAttrs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSAttrs"/> class with its value.
        /// </summary>
        public DSAttrs()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DSAttrs"/> class with its value with an alias and path.
        /// </summary>
        /// <param name="alias">Alias name for this attribute in the current tree.</param>
        /// <param name="fromPath">Path to this attribute in the current tree.</param>
        public DSAttrs(string alias, string fromPath)
        {
            Path = string.IsNullOrEmpty(fromPath) ? alias : string.Format("{0}.{1}", fromPath, alias);
        }

        /// <summary>
        /// Gets the path to this attribute in the current tree.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Operator override so that the class auto-converts to a string when referenced as one.
        /// </summary>
        /// <param name="attr">The instance to convert to a string.</param>
        public static implicit operator string(DSAttrs attr)
        {
            return attr.ToString();
        }

        /// <summary>
        /// Gets the fully qualified name for this attribute based on its current attr tree.
        /// </summary>
        /// <param name="field">Name of the field.</param>
        /// <returns>The fully qualified name for this attribute.</returns>
        public string GetName(string field)
        {
            return string.IsNullOrEmpty(Path) ? field : string.Format("{0}.{1}", Path, field);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Path;
        }
    }
}
