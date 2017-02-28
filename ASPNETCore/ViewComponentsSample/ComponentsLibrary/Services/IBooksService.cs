using ComponentsLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComponentsLibrary.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
    }
}
