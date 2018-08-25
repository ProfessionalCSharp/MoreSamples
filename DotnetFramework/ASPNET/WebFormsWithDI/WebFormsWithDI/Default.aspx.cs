using System;
using System.Collections.Generic;
using System.Web.UI;
using WebFormsWithDI.Models;
using WebFormsWithDI.Services;

namespace WebFormsWithDI
{
    public partial class _Default : Page
    {
        private readonly IBooksService _booksService;

        public _Default(IBooksService booksService)
        {
            _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Book> GetBooks() => _booksService.GetBooks();

    }
}