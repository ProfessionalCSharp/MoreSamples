using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleExeWithConfig.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(IConfiguration configuration)
        {
            AppSetting1 = configuration["AppConfiguration1"];
        }

        public string AppSetting1 { get; }
    }
}
