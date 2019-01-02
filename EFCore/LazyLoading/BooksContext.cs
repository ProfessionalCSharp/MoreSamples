using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

#nullable disable

namespace LazyLoading
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasMany(b => b.Chapters).WithOne(c => c.Book);
            modelBuilder.Entity<Book>().HasOne(b => b.Author).WithMany(a => a.WrittenBooks);
            modelBuilder.Entity<Book>().HasOne(b => b.Reviewer).WithMany(r => r.ReviewedBooks);
            modelBuilder.Entity<Book>().HasOne(b => b.Editor).WithMany(e => e.EditedBooks);

            modelBuilder.Entity<Chapter>().HasOne(c => c.Book).WithMany(b => b.Chapters).HasForeignKey(c => c.BookId);

            modelBuilder.Entity<User>().HasMany(a => a.WrittenBooks).WithOne(nameof(Book.Author));
            modelBuilder.Entity<User>().HasMany(r => r.ReviewedBooks).WithOne(nameof(Book.Reviewer));
            modelBuilder.Entity<User>().HasMany(e => e.EditedBooks).WithOne(nameof(Book.Editor));
        }
    }
}
