using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactorySample
{
    class TypedClientSample
    {
        internal static void Register(CommandLineApplication app)
        {
            app.Command("typed", cmd =>
            {
                cmd.Description = "Use a typed client";

                cmd.OnExecute(async () =>
                {
                    var sample = new TypedClientSample();
                    sample.ConfigureServices();
                    await sample.RunAsync();
                    return 0;
                });
            });
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.AddFilter((category, level) => true);
                builder.AddConsole(options => options.IncludeScopes = true);
            });
            services.AddHttpClient("cni", client =>
            {
                client.BaseAddress = new Uri("https://www.cninnovation.com");
            })
            .AddTypedClient<TypedClient>();
            AppServices = services.BuildServiceProvider();
        }

        public IServiceProvider AppServices { get; private set; }

        public async Task RunAsync()
        {
            var controller = AppServices.GetRequiredService<TypedClient>();
            await controller.CallServerAsync();
        }
    }


    class TypedClient
    {
        private readonly HttpClient _httpClient;
        public TypedClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CallServerAsync()
        {
            var response = await _httpClient.GetAsync("/downloads/Racers.xml");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }
}
