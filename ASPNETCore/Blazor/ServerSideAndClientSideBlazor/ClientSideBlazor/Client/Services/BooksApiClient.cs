using BooksLib;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientSideBlazor.Client.Services
{
    public class BooksApiClient : IBooksService
    {
        private readonly HttpClient _httpClient;
        public BooksApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _httpClient.GetJsonAsync<IEnumerable<Book>>("/api/Books");
        }
    }
}
