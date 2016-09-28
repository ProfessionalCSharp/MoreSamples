using System.Collections.Generic;
using System.Globalization;

namespace WebLocalizationSample.Services
{

    public class HostToCultureMapping : IHostToCultureMapping
    {
        private readonly IDictionary<string, CultureInfo> _map;
        private readonly CultureInfo German = new CultureInfo("de-DE");
        private readonly CultureInfo English = new CultureInfo("en-US");

        public HostToCultureMapping()
        {
            _map = new Dictionary<string, CultureInfo>()
            {
                [".at"] = German,
                [".ch"] = German,
                [".de"] = German,
                [".com"] = English,
                [".net"] = English
            };
        }
        public CultureInfo GetCultureForHost(string host)
        {
           
            int lastdot = host.LastIndexOf('.');
            if (lastdot == -1)
            {
                return English;
            }
            string postfix = host.Substring(lastdot);
            if (_map.ContainsKey(postfix))
            {
                return _map[postfix];
            }
            else
            {
                return English;
            }
        }
    }
}
