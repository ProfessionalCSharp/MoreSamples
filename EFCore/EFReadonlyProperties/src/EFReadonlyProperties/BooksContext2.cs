using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace JetBrains.Annotations
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate)]
    internal sealed class NotNullAttribute : Attribute
    {
        public NotNullAttribute() { }
    }
}

namespace EFReadonlyProperties
{


    public class BooksContext2 : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=BooksSample2;trusted_connection=true");
        }


        public override EntityEntry Add([NotNull] object entity)
        {
            return base.Add(entity);
        }

        public override EntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity)
        {

            EntityEntry<TEntity> added = base.Add<TEntity>(entity);
            PropertyValues values = added.CurrentValues.Clone();

            added.CurrentValues["JustABackingField"] = $"created at {DateTime.Now.ToString("t")}";

            return added;
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var entries = this.ChangeTracker.Entries();

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Publisher).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Book>().Property(b => b.BookId).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Book>().Property<string>("JustABackingField").HasField("_internalState");
        }
        public DbSet<Book> Books { get; set; }
    }
}
