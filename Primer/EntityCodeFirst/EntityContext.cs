using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Primer.EntityCodeFirst
{
    public partial class EntityContext : DbContext
    {
        public EntityContext()
            : base("name=EntityContext")
        {
        }

        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Roll> Roll { get; set; }
        public virtual DbSet<Structure> Structure { get; set; }
        public virtual DbSet<Userdate> Userdate { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>()
                .HasMany(e => e.Roll)
                .WithRequired(e => e.Color)
                .HasForeignKey(e => e.IdColor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Roll)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.IdCountry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Userdate)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.IdRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roll>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Structure>()
                .HasMany(e => e.Roll)
                .WithRequired(e => e.Structure)
                .HasForeignKey(e => e.IdStructure)
                .WillCascadeOnDelete(false);
        }
    }
}
