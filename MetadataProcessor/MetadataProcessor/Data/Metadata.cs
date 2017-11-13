namespace MetadataProcessor.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Metadata : DbContext
    {
        public Metadata()
            : base("name=Metadata")
        {
        }

        public virtual DbSet<EntityTypeElements> EntityTypeElements { get; set; }
        public virtual DbSet<EntityTypes> EntityTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Metadata>(null);

            modelBuilder.Entity<EntityTypeElements>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypeElements>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypeElements>()
                .Property(e => e.StorageName)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypeElements>()
                .Property(e => e.DataSize)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypeElements>()
                .Property(e => e.Default)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypeElements>()
                .Property(e => e.ReferenceTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypeElements>()
                .Property(e => e.VirtualPath)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypeElements>()
                .Property(e => e.Calculated)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypes>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypes>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypes>()
                .Property(e => e.StorageName)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypes>()
                .Property(e => e.KeyName)
                .IsUnicode(false);

            modelBuilder.Entity<EntityTypes>()
                .HasMany(e => e.EntityTypeElements)
                .WithRequired(e => e.EntityTypes)
                .WillCascadeOnDelete(false);
        }
    }
}
