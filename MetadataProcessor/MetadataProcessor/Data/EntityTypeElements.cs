namespace MetadataProcessor.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EntityTypeElements
    {
        [Key]
        public int EntityTypeElementKey { get; set; }

        public int EntityTypeKey { get; set; }

        public int? SortOrder { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string StorageName { get; set; }

        public int DataType { get; set; }

        [StringLength(50)]
        public string DataSize { get; set; }

        public bool AllowNull { get; set; }

        [StringLength(200)]
        public string Default { get; set; }

        [StringLength(50)]
        public string ReferenceTypeName { get; set; }

        public string VirtualPath { get; set; }

        public string Calculated { get; set; }

        public virtual EntityTypes EntityTypes { get; set; }
    }
}
