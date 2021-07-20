using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConfigSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IOptionsSnapshot<IndexAppSettings> options, ILogger<IndexModel> logger)
        {
            _logger = logger;
            Setting1 = options.Value.Config1 ?? "no value configured";
        }

        public string Setting1 { get; init; }

        public void OnGet()
        {

        }
    }
}
