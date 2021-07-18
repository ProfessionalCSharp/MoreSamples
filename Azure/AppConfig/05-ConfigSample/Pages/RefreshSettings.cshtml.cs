using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

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
            await _configurationRefresher.RefreshAsync();
        }
    }
}
