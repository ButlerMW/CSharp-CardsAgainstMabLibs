using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CardsAgainstMadLibs3._0.Models;
using Microsoft.AspNetCore.Http;

namespace CardsAgainstMadLibs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/chat")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("currentuser") == null)
            {
                return Redirect("/loginreg");
            }
            return View();
        }

        [HttpGet("/chatdashboard")]
        public IActionResult ChatDashboard()
        {
            if(HttpContext.Session.GetInt32("currentuser") == null)
            {
                return Redirect("/loginreg");
            }
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
