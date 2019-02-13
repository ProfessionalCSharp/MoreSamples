using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomeLibrary;

namespace ConfigSample.Controllers
{
    public class SampleConfigController : Controller
    {
        private readonly IDemoService _demoService;

        public SampleConfigController(IDemoService demoService)
        {
            _demoService = demoService ?? throw new ArgumentNullException(nameof(demoService));
        }

        public string Index() => _demoService.GetMyConfiguration();

    }
}