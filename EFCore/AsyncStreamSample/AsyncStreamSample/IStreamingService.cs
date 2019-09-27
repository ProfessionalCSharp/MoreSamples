using System.Threading.Tasks;

namespace AsyncStreamSample
{
    public interface IStreamingService
    {
        Task CreateTheDatabaseAsync();
        Task QueryDataAsync();
    }
}