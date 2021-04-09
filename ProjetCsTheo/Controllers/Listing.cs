using ds.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetCsTheo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetCsTheo.Controllers
{
    public class Listing : Controller
    {
        private readonly ILogger<Listing> _logger;

        public Listing(ILogger<Listing> logger)
        {
            _logger = logger;
            ApplicationDBContext context = new ApplicationDBContext();
        }

        public IActionResult Index()
        {
            ViewBag.allResto = ApplicationDBContext.getAllResto();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
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
