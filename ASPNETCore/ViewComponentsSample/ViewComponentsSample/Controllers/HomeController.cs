using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ViewComponentsSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Books1() =>
            ViewComponent("BooksList", "Wrox Press");

        public IActionResult Books1a() =>
            ViewComponent("BooksList", new { publisher = "Wrox Press" });

        public IActionResult Books2() => View();

        public IActionResult Books3() => View();
    }
}
