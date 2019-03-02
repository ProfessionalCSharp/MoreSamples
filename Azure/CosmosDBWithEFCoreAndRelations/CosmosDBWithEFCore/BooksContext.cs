using Microsoft.EntityFrameworkCore;

namespace CosmosDBWithEFCore
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToContainer("BooksCollection");
            modelBuilder.Entity<Chapter>().ToContainer("BooksCollection");
            modelBuilder.Entity<Author>().ToContainer("BooksCollection");
            //modelBuilder.Entity<Book>().OwnsOne(b => b.LeadAuthor);
            //modelBuilder.Entity<Book>().OwnsMany(b => b.Chapters);
            // modelBuilder.Owned<Chapter>()
            // modelBuilder.Owned<Author>();

            // it seems this is needed for owned types with 3.0.0-preview.19080.1
            modelBuilder.Entity<Chapter>().Property(c => c.ChapterId).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Author>().Property(a => a.AuthorId).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        }
    }
}
