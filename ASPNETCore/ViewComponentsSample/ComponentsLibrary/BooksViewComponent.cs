using ComponentsLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentsLibrary
{
    [ViewComponent(Name = "BooksList")]
    public class BooksViewComponent : ViewComponent
    {
        private readonly IBooksService _booksService;

        public BooksViewComponent(IBooksService booksService) =>
            _booksService = booksService;

        // InvokeAsync
        public async Task<IViewComponentResult> InvokeAsync(string publisher)
        {
            var books = await _booksService.GetBooksAsync();
            return View(books.Where(b => b.Publisher == publisher));
        }
    }
}
