using Microsoft.EntityFrameworkCore;

namespace CosmosDBWithEFCore
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("BooksContainer");
            // entity types can be explicitly mapped to containers
            // modelBuilder.Entity<Book>().ToContainer("BooksContainer");
            modelBuilder.Entity<Book>().OwnsOne(b => b.LeadAuthor);
            modelBuilder.Entity<Book>().OwnsMany(b => b.Chapters);
            //modelBuilder.Owned<Chapter>();  // alternative version to use owned fromt he other direction
            //modelBuilder.Owned<Author>();
        }
    }
}
