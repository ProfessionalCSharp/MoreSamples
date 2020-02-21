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
            string message = created ? "created" : "already exists";
            Console.WriteLine($"database {message}");
        }

        public async Task WriteBooksAsync()
        {
            var author = new Author("Christian", "Nagel");
            var c1 = new Chapter(1, ".NET Applications and Tools", 38);
            var c2 = new Chapter(2, "Core C#", 38);
            var c3 = new Chapter(3, "Objects and Types", 34);

            var book1 = new Book("Professional C# 7 and .NET Core 2.0", "Wrox Press", author, c1, c2, c3);
            _booksContext.Books.Add(book1);
            int changed = await _booksContext.SaveChangesAsync();
            Console.WriteLine($"created {changed} record(s)");
        }

        public void ReadBooks()
        {
            var books = _booksContext.Books.Where(b => b.Publisher == "Wrox Press");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} {book.Publisher} {book.BookId}");
                foreach (var chapter in book.Chapters)
                {
                    Console.WriteLine($"chapter: {chapter.Title}");
                }
                Console.WriteLine($"author: {book.LeadAuthor}");
                Console.WriteLine();
            }
        }
    }
}
