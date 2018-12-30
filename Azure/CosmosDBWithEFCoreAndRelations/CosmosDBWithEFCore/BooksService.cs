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
            var author = new Author { FirstName = "Christian", LastName = "Nagel" };

            //var book1 = Book.Create("Professional C# 7 and .NET Core 2.0", "Wrox Press",
            var c1 = Chapter.Create(1, ".NET Applications and Tools", 34);
            var c2 = Chapter.Create(2, "Core C#", 38);
            var c3 = Chapter.Create(3, "Objects and Types", 34);
            //    Chapter.Create(4, "Object-Oriented Programming with C#", 20),
            //    Chapter.Create(5, "Generics", 22),
            //    Chapter.Create(6, "Operators and Casts", 42),
            //    Chapter.Create(7, "Arrays", 22),
            //    Chapter.Create(8, "Delegates, Lambdas, and Events", 20),
            //    Chapter.Create(9, "Strings and Regular Expressions", 20),
            //    Chapter.Create(10, "Collections", 32),
            //    Chapter.Create(11, "Special Collections", 18),
            //    Chapter.Create(12, "LINQ", 38),
            //    Chapter.Create(13, "Functional Programming with C#", 24));
            //var c1 = new Chapter(1, ".NET Applications and Tools", 34);
            //var c2 = new Chapter(2, "Core C#", 38);
            //var c3 = new Chapter(3, "Objects and Types", 34);
            var book1 = Book.Create("Professional C# 7 and .NET Core 2.0", "Wrox Press", author, c1, c2, c3);
            //    Chapter.Create(4, "Object-Oriented Programming with C#", 20),f
            //    Chapter.Create(5, "Generics", 22),
            //    Chapter.Create(6, "Operators and Casts", 42),
            //    Chapter.Create(7, "Arrays", 22),
            //    Chapter.Create(8, "Delegates, Lambdas, and Events", 20),
            //    Chapter.Create(9, "Strings and Regular Expressions", 20),
            //    Chapter.Create(10, "Collections", 32),
            //    Chapter.Create(11, "Special Collections", 18),
            //    Chapter.Create(12, "LINQ", 38),
            //    Chapter.Create(13, "Functional Programming with C#", 24);
            //_booksContext.Books.Add(book1);
            _booksContext.Books.Add(book1);

            //_booksContext.Books.Add(Book.Create("Professional C# 7 and .NET Core 2.0", "Wrox Press"));
            //_booksContext.Books.Add(Book.Create("Professional C# 6 and .NET Core 1.0", "Wrox Press"));
            //_booksContext.Books.Add(Book.Create("Enterprise Services with the .NET Framework", "Addison Wesley" ));
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
