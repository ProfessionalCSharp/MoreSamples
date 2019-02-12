using Microsoft.EntityFrameworkCore;

using System;

namespace CosmosDBWithEFCore
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
//        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToContainer("BooksContainer");
            modelBuilder.Entity<Book>().OwnsOne(b => b.LeadAuthor).HasKey(a => a.AuthorId);
            modelBuilder.Entity<Book>().OwnsMany(b => b.Chapters).HasKey(c => c.ChapterId);

            modelBuilder.Entity<Book>().Property(b => b.BookId).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Book>().Property(b => b.Title).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Book>().Property(b => b.Publisher).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
           // modelBuilder.Entity<Book>().Property(b => b.LeadAuthor).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            modelBuilder.Entity<Chapter>().ToContainer("BooksContainer");

            modelBuilder.Entity<Chapter>().HasKey(c => c.ChapterId);

            modelBuilder.Entity<Chapter>().Property(c => c.ChapterId).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Chapter>().Property(c => c.Number).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Chapter>().Property(c => c.Pages).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Chapter>().Property(c => c.Title).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            modelBuilder.Entity<Author>().ToContainer("BooksContainer");
            modelBuilder.Entity<Author>().Property(a => a.AuthorId).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Author>().Property(a => a.FirstName).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Author>().Property(a => a.LastName).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        }
    }
}
