using Books.Shared;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Books.App
{
    public class BooksClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public BooksClient(HttpClient httpClient)
            => _httpClient = httpClient;

        public async Task<Book[]> GetBooksAsync()
        {
            var response = await _httpClient.GetAsync("/api/Books");
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Book[]>(stream, serializerOptions);
        }
    }
}
