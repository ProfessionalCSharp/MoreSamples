using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactorySample
{
    class PolicySample
    {
        internal static void Register(CommandLineApplication app)
        {
            app.Command("policy", cmd =>
            {
                cmd.Description = "Use a policy";

                cmd.OnExecute(async () =>
                {
                    var sample = new PolicySample();
                    await sample.RunAsync();
                    return 0;
                });
            });
        }

        public PolicySample() => AppServices = ConfigureServices();

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
                client.BaseAddress = new Uri("https://www.cninnovation1.com"); // not found server
            })
            //.AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10)))
            .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(new [] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10) }))  // network failures, HTTP 5xx, HTTP 408
            .AddTypedClient<PolicyClient>();
            return services.BuildServiceProvider();
        }

        public IServiceProvider AppServices { get; private set; }

        public async Task RunAsync()
        {
            var controller = AppServices.GetRequiredService<PolicyClient>();
            await controller.CallServerAsync();
        }
    }


    class PolicyClient
    {
        private readonly HttpClient _httpClient;
        public PolicyClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CallServerAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/downloads/Racers.xml");
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
