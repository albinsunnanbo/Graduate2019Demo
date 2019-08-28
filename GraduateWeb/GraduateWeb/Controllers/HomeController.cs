using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraduateWeb.Models;
using GraduateWeb.Services;

namespace GraduateWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly RandomGreetingService rndGreetingService;

        public HomeController(RandomGreetingService rndGreetingService)
        {
            this.rndGreetingService = rndGreetingService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var initial = new CustomerModel
            {
                Gender = Gender.Other,
                Name = $"{rndGreetingService.SayHi()}, vad heter du?"
            };
            return View(initial);
        }

        //[ActionName("Index")]
        [HttpPost]
        public IActionResult Index(CustomerModel model)
        {
            return View(model);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
