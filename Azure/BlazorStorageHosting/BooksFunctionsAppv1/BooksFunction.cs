using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BooksLib;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace BooksFunctionsAppv1
{
    public static class BooksFunction
    {
        [FunctionName("BooksFunction1")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            return req.CreateResponse<IEnumerable<Book>>(HttpStatusCode.OK, GetBooks());

            // parse query parameter
            //string name = req.GetQueryNameValuePairs()
            //    .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
            //    .Value;

            //if (name == null)
            //{
            //    // Get request body
            //    dynamic data = await req.Content.ReadAsAsync<object>();
            //    name = data?.name;
            //}

            //return name == null
            //    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
            //    : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
        }

        public static IEnumerable<Book> GetBooks() =>
            new List<Book>
            {
                        new Book(1, "Enterprise Services with the .NET Framework", "Addison Wesley"),
                        new Book(2, "Professional C# 6 and .NET Core 1.0", "Wrox Press"),
                        new Book(3, "Professional C# 7 and .NET Core 2.0", "Wrox Press")
            };
    }
}
