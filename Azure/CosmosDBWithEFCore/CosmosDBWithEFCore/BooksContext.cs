using Microsoft.EntityFrameworkCore;

using System;

namespace CosmosDBWithEFCore
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property<string>("_self").ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().Property<string>("_etag").ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Book>().Property<long>("_ts").ValueGeneratedOnAddOrUpdate();
        }

        public void ShowBooksWithShadowState()
        {
            Console.WriteLine("show all shadow state");
            foreach (var book in Books)
            {
                Console.WriteLine(book.Title);
                var props = Entry<Book>(book).Properties;
                foreach (var propEntry in props)
                {
                    Console.WriteLine($"{propEntry.Metadata.Name} {propEntry.CurrentValue}");
                }
            }
            Console.WriteLine();
        }

        public void ShowCosmosDBState()
        {
            Console.WriteLine("selecte specific shadow state");
            foreach (var book in Books)
            {
                Console.WriteLine($"{book.Title}, etag: {Entry<Book>(book).Property("_etag").CurrentValue}, " +
                    $"self: {Entry(book).Property("_self").CurrentValue}, " +
                    $"ts: {Entry(book).Property("_ts").CurrentValue}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
