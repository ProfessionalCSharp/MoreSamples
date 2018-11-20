using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SeedSample
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\MSSQLLocalDb;database=Books1;trusted_connection=true";
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString)
                   .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(b => b.Publisher)
                .IsRequired(false)
                .HasMaxLength(30);

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Professional C# 6", Publisher = "Wrox Press"},
                new Book { BookId = 2, Title = "Professional C# 7", Publisher = "Wrox Press"},
                new Book { BookId = 3, Title = "Professional C# 8", Publisher = "Wrox Press"}
            );
        }
    }
}
