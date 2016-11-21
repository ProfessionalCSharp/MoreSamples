using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksWebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksWebApp.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BooksContext _booksContext;
        public BooksController(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get() => _booksContext.Books;

        // GET api/values/5
        [HttpGet("{id}")]
        public Book Get(int id) => _booksContext.Books.Find(id);

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Book value)
        {
            _booksContext.Books.Add(value);
            _booksContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Book value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            if (id != value.BookId)
                throw new ArgumentException("id != value.id");
            _booksContext.Books.Update(value);
            _booksContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Book b = _booksContext.Books.Find(id);
            _booksContext.Books.Remove(b);
            _booksContext.SaveChanges();
        }
    }
}
