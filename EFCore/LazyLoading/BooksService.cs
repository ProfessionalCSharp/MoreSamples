using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LazyLoading
{
    public class BooksService
    {
        private readonly BooksContext _booksContext;
        public BooksService(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public void GetBooksWithLazyLoading()
        {
            var books = _booksContext.Books;

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
                foreach (var chapter in book.Chapters)
                {
                    Console.WriteLine($"{chapter.Number}. {chapter.Title}");
                }
                Console.WriteLine($"author: {book.Author}");
                Console.WriteLine($"reviewer: {book.Reviewer}");
                Console.WriteLine($"editor: {book.Editor}");

            }
        }

        public void GetBooksByUsersLazyLoading()
        {
            var users = _booksContext.Users;

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                foreach (var book in user.WrittenBooks)
                {
                    Console.WriteLine($"\twritten: {book.Title}");

                    foreach (var chapter in book.Chapters)
                    {
                        Console.WriteLine($"\t\tchapter: {chapter.Title}");
                    }
                }
                foreach (var book in user.ReviewedBooks)
                {
                    Console.WriteLine($"\treviewed: {book.Title}");
                }
                foreach (var book in user.EditedBooks)
                {
                    Console.WriteLine($"\tedited: {book.Title}");
                }
            }
        }

        public void GetBooksByUsersEagerLoading()
        {
            var users = _booksContext.Users
                .Include(u => u.WrittenBooks)
                .Include(u => u.ReviewedBooks)
                .Include(u => u.EditedBooks);

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                foreach (var book in user.WrittenBooks)
                {
                    Console.WriteLine($"\twritten: {book.Title}");

                    foreach (var chapter in book.Chapters)
                    {
                        Console.WriteLine($"\t\tchapter: {chapter.Title}");
                    }
                }
                foreach (var book in user.ReviewedBooks)
                {
                    Console.WriteLine($"\treviewed: {book.Title}");
                }
                foreach (var book in user.EditedBooks)
                {
                    Console.WriteLine($"\tedited: {book.Title}");
                }
            }
        }

        public async Task DeleteDatabaseAsync()
        {
            Console.Write("Delete the database? ");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                await _booksContext.Database.EnsureDeletedAsync();
            }
        }

        public Task CreateDatabaseAsync() =>
                _booksContext.Database.EnsureCreatedAsync();

        public async Task AddBooksAsync()
        {
            Console.WriteLine(nameof(AddBooksAsync));
            var author = new User("Christian Nagel");
            var reviewer = new User("Istvan Novak");
            var editor = new User("Charlotte Kughen");
            var b1 = new Book("Professional C# 7 and .NET Core 2.0")
            {
                Editor = editor,
                Reviewer = reviewer,
                Author = author
            };

            var c1 = new Chapter(1, ".NET Applications and Tools")
            {
                Book = b1
            };
            var c2 = new Chapter(2, "Core C#")
            {
                Book = b1
            };
            var c3 = new Chapter(28, "Entity Framework Core")
            {
                Book = b1
            };

            _booksContext.Books.Add(b1);
            _booksContext.Users.AddRange(author, editor, reviewer);
            _booksContext.Chapters.AddRange(c1, c2, c3);

            int records = await _booksContext.SaveChangesAsync();

            Console.WriteLine($"{records} records added");
            Console.WriteLine();
        }
    }
}
