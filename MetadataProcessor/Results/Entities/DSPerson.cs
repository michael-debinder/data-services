// <copyright file="DSPerson.cs" company="Brightree LLC">
//     Copyright (c) Brightree LLC. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities
{
    using System;
    using Attrs;
    using Data;

    /// <summary>
    /// Represents a specific instance of the Person entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class DSPerson : DSEntity
    {
        /// <summary>
        /// The public name identifying this entity.
        /// </summary>
        public const string EntityName = "Person";

        /// <summary>
        /// List of all available attribute names for this entity.
        /// </summary>
        private static DSPersonAttrs _attrs = new DSPersonAttrs();

        /// <summary>
        /// Initializes a new instance of the <see cref="DSPerson"/> class.
        /// </summary>
        public DSPerson()
        {
            Type = EntityName;
        }

        /// <summary>
        /// Gets list of all available attribute names for this entity.
        /// </summary>
        public static DSPersonAttrs Attrs
        {
            get { return _attrs; }
        }

        /// <summary>
        /// Gets or sets the ID attribute.
        /// </summary>
        public int ID
        {
            get { return Get<int>("ID"); }
            set { this["ID"] = value; }
        }

        /// <summary>
        /// Gets or sets the LastName attribute.
        /// </summary>
        public string LastName
        {
            get { return Get<string>("LastName"); }
            set { this["LastName"] = value; }
        }

        /// <summary>
        /// Gets or sets the FirstName attribute.
        /// </summary>
        public string FirstName
        {
            get { return Get<string>("FirstName"); }
            set { this["FirstName"] = value; }
        }

        /// <summary>
        /// Gets or sets the HireDate attribute.
        /// </summary>
        public DateTime HireDate
        {
            get { return Get<DateTime>("HireDate"); }
            set { this["HireDate"] = value; }
        }

        /// <summary>
        /// Gets or sets the EnrollmentDate attribute.
        /// </summary>
        public DateTime EnrollmentDate
        {
            get { return Get<DateTime>("EnrollmentDate"); }
            set { this["EnrollmentDate"] = value; }
        }

        /// <summary>
        /// Gets or sets the Discriminator attribute.
        /// </summary>
        public string Discriminator
        {
            get { return Get<string>("Discriminator"); }
            set { this["Discriminator"] = value; }
        }
    }
}
