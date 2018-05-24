using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactorySample
{
    class FactorySample
    {
        internal static void Register(CommandLineApplication app)
        {
            app.Command("factory", cmd =>
            {
                cmd.Description = "Use the IHttpClientFactory";

                cmd.OnExecute(async () =>
                {
                    var sample = new FactorySample();
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
            });
            services.AddTransient<ControllerUsingClientFactory>();
            AppServices = services.BuildServiceProvider();
        }

        public IServiceProvider AppServices { get; private set; }

        public async Task RunAsync()
        {
            var controller = AppServices.GetRequiredService<ControllerUsingClientFactory>();
            await controller.CallServerAsync();
        }
    }

    class ControllerUsingClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ControllerUsingClientFactory(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        public async Task CallServerAsync()
        {
            HttpClient client = _httpClientFactory.CreateClient("cni");
            var response = await client.GetAsync("/downloads/Racers.xml");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }
}
