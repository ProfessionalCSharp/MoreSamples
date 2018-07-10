using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactorySample
{
    class UseClientHandlerSample
    {
        internal static void Register(CommandLineApplication app)
        {
            app.Command("usehandler", cmd =>
            {
                cmd.Description = "Use a ClientMessageHandler";

                cmd.OnExecute(async () =>
                {
                    var sample = new UseClientHandlerSample();
                    await sample.RunAsync();
                    return 0;
                });
            });
        }

        public UseClientHandlerSample() => AppServices = ConfigureServices();

        private ServiceProvider ConfigureServices()
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
            }).ConfigureHttpMessageHandlerBuilder(config => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            }).AddTypedClient<Client>();
            return services.BuildServiceProvider();
        }

        public IServiceProvider AppServices { get; private set; }

        public async Task RunAsync()
        {
            var controller = AppServices.GetRequiredService<Client>();
            await controller.CallServerAsync();
        }
    }

    class Client
    {
        private readonly HttpClient _httpClient;
        public Client(HttpClient httpClient)
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
