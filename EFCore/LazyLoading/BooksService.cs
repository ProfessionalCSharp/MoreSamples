using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

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
                Console.WriteLine($"author: {book.Author?.Name}");
                Console.WriteLine($"reviewer: {book.Reviewer?.Name}");
                Console.WriteLine($"editor: {book.Editor?.Name}");
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
