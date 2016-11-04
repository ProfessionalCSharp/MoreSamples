using Microsoft.EntityFrameworkCore;

namespace EFReadonlyProperties
{

    public class BooksContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=BooksSample;trusted_connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.BookId).HasField("_bookId");
            modelBuilder.Entity<Book>().Property(b => b.Publisher).HasField("_publisher");

            modelBuilder.Entity<Book>().Property<string>("JustABackingField").HasField("_internalState");
        }
        public DbSet<Book> Books { get; set; }
    }
}
