namespace MetadataProcessor.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EntityTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EntityTypes()
        {
            EntityTypeElements = new HashSet<EntityTypeElements>();
        }

        [Key]
        public int EntityTypeKey { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string StorageName { get; set; }

        public bool ReadOnly { get; set; }

        [Required]
        [StringLength(50)]
        public string KeyName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntityTypeElements> EntityTypeElements { get; set; }
    }
}
