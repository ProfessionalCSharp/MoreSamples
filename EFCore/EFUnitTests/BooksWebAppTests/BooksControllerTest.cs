using BooksWebApp.Controllers;
using BooksWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace BooksWebAppTests
{
    public class BooksControllerTest
    {
        public BooksControllerTest()
        {
            InitContext();
        }

        private BooksContext _booksContext;

        public void InitContext()
        {
            var builder = new DbContextOptionsBuilder<BooksContext>()
                .UseInMemoryDatabase();

            var context = new BooksContext(builder.Options);
            var books = Enumerable.Range(1, 10)
                .Select(i => new Book { BookId = i, Title = $"Sample{i}", Publisher = "Wrox Press" });
            context.Books.AddRange(books);
            int changed = context.SaveChanges();
            _booksContext = context;
        }

        [Fact]
        public void TestGetBookById()
        {
            string expectedTitle = "Sample2";
            var controller = new BooksController(_booksContext);
            Book result = controller.Get(2);
            Assert.Equal(expectedTitle, result.Title);
        }
    }
}
