using Books.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Books.App
{
    public class BooksClient
    {
        private readonly HttpClient _httpClient;

        public BooksClient(HttpClient httpClient) => _httpClient = httpClient; 

        public async Task<Book[]> GetBooksAsync()
        {
            var response = await _httpClient.GetAsync("/api/Books");
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Book[]>(stream);
        }
    }
}
