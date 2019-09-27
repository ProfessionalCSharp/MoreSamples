using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsyncStreamSample
{
    public class StreamingService : IStreamingService
    {
        private readonly SomeDataContext _dataContext;
        public StreamingService(SomeDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateTheDatabaseAsync()
        {
            bool created = await _dataContext.Database.EnsureCreatedAsync();
            Console.WriteLine($"database created: {created}");
        }

        public async Task QueryDataAsync()
        {
            var stream = _dataContext.SomeData.TagWith("AsyncStreams").Where(d => d.Number > 3).AsAsyncEnumerable();

            await foreach (var data in stream)
            {
                Console.Write(data.SomeDataId);
                // Console.WriteLine(data);
            }
        }
    }
}
