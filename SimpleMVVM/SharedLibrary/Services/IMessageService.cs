using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public interface IMessageService
    {
        Task MessageAsync(string message);
    }
}
