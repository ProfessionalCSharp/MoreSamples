using System;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBWithEFCore
{
    public class BooksService
    {
        private BooksContext _booksContext;
        public BooksService(BooksContext booksContext) => 
            _booksContext = booksContext ?? throw new ArgumentNullException(nameof(booksContext));

        public async Task CreateTheDatabaseAsync()
        {
            var created = await _booksContext.Database.EnsureCreatedAsync();
            if (created)
            {
                Console.WriteLine("database created");
            }
            else
            {
                Console.WriteLine("database already exists");
            }
        }

        public async Task WriteBooksAsync()
        {
            _booksContext.Books.Add(new Book { BookId = Guid.NewGuid(), Title = "Professional C# 7 and .NET Core 2.0", Publisher = "Wrox Press" });
            _booksContext.Books.Add(new Book { BookId = Guid.NewGuid(), Title = "Professional C# 6 and .NET Core 1.0", Publisher = "Wrox Press" });
            _booksContext.Books.Add(new Book { BookId = Guid.NewGuid(), Title = "Enterprise Services with the .NET Framework", Publisher = "Addison Wesley" });
            int changed = await _booksContext.SaveChangesAsync();
            Console.WriteLine($"created {changed} records");
        }

        public void ReadBooks()
        {
            var books = _booksContext.Books.Where(b => b.Publisher == "Wrox Press");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} {book.Publisher} {book.BookId}");
            }

            _booksContext.ShowBooksWithShadowState();
            _booksContext.ShowCosmosDBState();
        }
    }
}
