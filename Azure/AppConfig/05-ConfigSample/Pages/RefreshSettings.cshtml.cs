using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigSample.Pages
{
    public class RefreshSettingsModel : PageModel
    {
        private readonly IConfigurationRefresher _configurationRefresher;
        public RefreshSettingsModel(IConfigurationRefresherProvider refresherProvider)
        {
            _configurationRefresher = refresherProvider.Refreshers.First();
        }
        public async Task OnGet()
        {
            _configurationRefresher.SetDirty(TimeSpan.FromSeconds(1));
            await Task.Delay(1000);
            bool success = await _configurationRefresher.TryRefreshAsync();
        }
    }
}
