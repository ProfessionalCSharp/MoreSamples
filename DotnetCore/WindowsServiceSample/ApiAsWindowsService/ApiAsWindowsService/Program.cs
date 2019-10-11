using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ApiAsWindowsService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureWebHost(config => 
                {
                    config.UseUrls("http://localhost:5050"); 
                }).UseWindowsService();
    }
}
