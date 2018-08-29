using Microsoft.EntityFrameworkCore;

namespace EFReadonlyProperties
{

    public class BooksContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=BooksSampleFieldMapping;trusted_connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey("_bookId");
            modelBuilder.Entity<Book>().Property("_bookId").HasColumnName("BookId");
            modelBuilder.Entity<Book>().Property(b => b.Publisher).HasField("_publisher");

            modelBuilder.Entity<Book>().Property<string>("JustABackingField").HasField("_internalState");
        }
        public DbSet<Book> Books { get; set; }
    }
}
