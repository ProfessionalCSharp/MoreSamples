using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LazyLoading
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; private set; }
        public DbSet<Chapter> Chapters { get; private set; }
        public DbSet<User> Users { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Chapters)
                .WithOne(c => c.Book)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.WrittenBooks)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Reviewer)
                .WithMany(r => r.ReviewedBooks)
                .HasForeignKey(b => b.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Editor)
                .WithMany(e => e.EditedBooks)
                .HasForeignKey(e => e.EditorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chapter>()
                .HasOne(c => c.Book)
                .WithMany(b => b.Chapters)
                .HasForeignKey(c => c.BookId);

            modelBuilder.Entity<User>()
                .HasMany(a => a.WrittenBooks)
                .WithOne(nameof(Book.Author))
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasMany(r => r.ReviewedBooks)
                .WithOne(nameof(Book.Reviewer))
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasMany(e => e.EditedBooks)
                .WithOne(nameof(Book.Editor))
                .OnDelete(DeleteBehavior.Restrict);

            SeedData(modelBuilder);
        }

        private User[] _users = new[]
        {
            new User(1, "Christian Nagel"),
            new User(2, "Istvan Novak"),
            new User(3, "Charlotte Kughen")
        };
        private Book _book = new Book(1, "Professional C# 7 and .NET Core 2.0");
        private Chapter[] _chapters = new[]
        {
            new Chapter(1, 1, ".NET Applications and Tools"),
            new Chapter(2, 2, "Core C#"),
            new Chapter(3, 28, "Entity Framework Core")
        };

        protected void SeedData(ModelBuilder modelBuilder)
        {
            _book.AuthorId = 1;
            _book.ReviewerId = 2;
            _book.EditorId = 3;
            foreach (var c in _chapters)
            {
                c.BookId = 1;
            }

            modelBuilder.Entity<User>().HasData(_users);
            modelBuilder.Entity<Book>().HasData(_book);
            modelBuilder.Entity<Chapter>().HasData(_chapters);
        }
    }
}
