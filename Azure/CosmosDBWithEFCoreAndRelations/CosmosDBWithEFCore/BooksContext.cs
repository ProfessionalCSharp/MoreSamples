using Microsoft.EntityFrameworkCore;

namespace CosmosDBWithEFCore
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options) { }

        public DbSet<Book>? Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainerName("BooksContainer");
            // modelBuilder.Entity<Book>().ToContainer("BooksContainer");
            //modelBuilder.Entity<Chapter>().ToContainer("BooksCollection");
            //modelBuilder.Entity<Author>().ToContainer("BooksCollection");
            //modelBuilder.Entity<Book>().OwnsOne(b => b.LeadAuthor);
            //modelBuilder.Entity<Book>().OwnsMany(b => b.Chapters);
            modelBuilder.Owned<Chapter>();
            modelBuilder.Owned<Author>();
        }
    }
}
