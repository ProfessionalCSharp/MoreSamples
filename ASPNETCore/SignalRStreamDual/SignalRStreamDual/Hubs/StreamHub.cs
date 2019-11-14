using Microsoft.AspNetCore.SignalR;
using SharedLib.Models;
using System.Collections.Generic;

namespace SignalRStreamDual.Hubs
{
    public class StreamHub : Hub
    {
        public async IAsyncEnumerable<OutputData> TransformAsync(IAsyncEnumerable<InputData> inputStream)
        {
            await foreach (var input in inputStream)
            {
                yield return new OutputData { Text = $"{input.Number}. {input.Text}" };
            }
        }
    }
}
