using System.Globalization;

namespace WebLocalizationSample.Services
{
    public interface IHostToCultureMapping
    {
        CultureInfo GetCultureForHost(string host);
    }
}