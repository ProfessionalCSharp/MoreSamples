using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LazyLoading
{
    public class BooksService
    {
        private readonly BooksContext _booksContext;
        public BooksService(BooksContext booksContext)
        {
            _booksContext = booksContext ?? throw new ArgumentNullException(nameof(booksContext));
        }

        public void GetBooksWithLazyLoading()
        {
#nullable disable
            var books = _booksContext.Books.Where(b => b.Publisher.StartsWith("Wrox"));
#nullable restore

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
                Console.WriteLine(book.Publisher);
                foreach (var chapter in book.Chapters)
                {
                    Console.WriteLine($"{chapter.Number}. {chapter.Title}");
                }
                Console.WriteLine($"author: {book.Author?.Name}");
                Console.WriteLine($"reviewer: {book.Reviewer?.Name}");
                Console.WriteLine($"editor: {book.Editor?.Name}");
            }
        }

        public void GetBooksWithExplicitLoading()
        {
            var books = _booksContext.Books.Where(b => b.Publisher!.StartsWith("Wrox"));

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
                EntityEntry<Book> entry = _booksContext.Entry(book);
                entry.Collection(b => b.Chapters).Load();

                foreach (var chapter in book.Chapters)
                {
                    Console.WriteLine($"{chapter.Number}. {chapter.Title}");
                }

                entry.Reference(b => b.Author).Load();
                Console.WriteLine($"author: {book.Author?.Name}");

                entry.Reference(b => b.Reviewer).Load();
                Console.WriteLine($"reviewer: {book.Reviewer?.Name}");

                entry.Reference(b => b.Editor).Load();
                Console.WriteLine($"editor: {book.Editor?.Name}");
            }
        }

        public void GetBooksWithEagerLoading()
        {
            var books = _booksContext.Books
                .Where(b => b.Publisher!.StartsWith("Wrox"))
                .Include(b => b.Chapters)
                .Include(b => b.Author)
                .Include(b => b.Reviewer)
                .Include(b => b.Editor);

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
                foreach (var chapter in book.Chapters)
                {
                    Console.WriteLine($"{chapter.Number}. {chapter.Title}");
                }
                Console.WriteLine($"author: {book.Author?.Name}");
                Console.WriteLine($"reviewer: {book.Reviewer?.Name}");
                Console.WriteLine($"editor: {book.Editor?.Name}");
            }
        }

        public async Task DeleteDatabaseAsync()
        {
            Console.Write("Delete the database? ");
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                bool deleted = await _booksContext.Database.EnsureDeletedAsync();
                Console.WriteLine($"database deleted: {deleted}");
            }
        }

        public async Task CreateDatabaseAsync()
        {
            bool created = await _booksContext.Database.EnsureCreatedAsync();
            string info = created ? "created" : "already exists";
            Console.WriteLine($"database {info}");
        }
    }
}
