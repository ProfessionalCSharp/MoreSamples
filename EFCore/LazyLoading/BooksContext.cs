using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LazyLoading
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; private set; } = default!;
        public DbSet<Chapter> Chapters { get; private set; } = default!;
        public DbSet<User> Users { get; private set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new ChapterConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            SeedData(modelBuilder);
        }

        private User[] _users = new[]
        {
            new User(1, "Christian Nagel"),
            new User(2, "Istvan Novak"),
            new User(3, "Charlotte Kughen")
        };
        private Book _book = new Book(1, "Professional C# 7 and .NET Core 2.0", "Wrox Press");
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
