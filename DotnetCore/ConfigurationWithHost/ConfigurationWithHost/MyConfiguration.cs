using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationWithHost
{
    public class InnerConfiguration
    {
        public string InnerText { get; set; } = string.Empty;
    }

    public class MyConfiguration
    {
        public string Text1 { get; set; } = string.Empty;
        public int Number1 { get; set; }

        public InnerConfiguration Inner { get; } = new InnerConfiguration();
    }
}
