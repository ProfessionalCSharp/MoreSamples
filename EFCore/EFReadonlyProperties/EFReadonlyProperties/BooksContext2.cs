using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace EFReadonlyProperties
{
    public class BooksContext2 : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=BooksSample2FieldMapping;trusted_connection=true");
        }

        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            EntityEntry<TEntity> added = base.Add<TEntity>(entity);
            PropertyValues values = added.CurrentValues.Clone();

            added.CurrentValues["AShadowProperty"] = $"created at {DateTime.Now.ToString("t")}";
            return added;
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var entries = ChangeTracker.Entries();

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey("_bookId");
            modelBuilder.Entity<Book>().Property("_bookId").HasColumnName("BookId");
            modelBuilder.Entity<Book>().Property(b => b.Publisher).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Book>().Property<string>("AShadowProperty");
        }
        public DbSet<Book> Books { get; set; }
    }
}
