using BooksLib;
using Microsoft.EntityFrameworkCore;

namespace ServerSideBlazor.Services
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(b => b.Publisher).IsRequired(false).HasMaxLength(30);

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Professional C# 6", Publisher = "Wrox Press" },
                new Book { BookId = 2, Title = "Professional C# 7", Publisher = "Wrox Press" },
                new Book { BookId = 3, Title = "Professional C# 8", Publisher = "Wrox Press" });
        }
    }
}
