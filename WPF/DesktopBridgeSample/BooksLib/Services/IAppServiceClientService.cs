using System.Threading.Tasks;

namespace BooksLib.Services
{
    public interface IAppServiceClientService
    {
        Task SendMessageAsync(string message);
    }
}
