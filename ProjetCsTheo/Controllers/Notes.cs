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
    public class Notes : Controller
    {
        private readonly ILogger<Notes> _logger;

        public Notes(ILogger<Notes> logger)
        {
            _logger = logger;
            ApplicationDBContext context = new ApplicationDBContext();
        }

        public IActionResult Index()
        {
            ViewBag.allResto = ApplicationDBContext.getAllResto();
            return View();
        }

        public IActionResult Edit(int idResto)
        {
            ViewBag.resto = ApplicationDBContext.getRestoWithId(idResto);
            return View();
        }

        public IActionResult EditQuery(int id, int note, String noteCommentary)
        {
            Restaurant tempResto = new Restaurant();
            tempResto.Id = id;
            tempResto.Note = note;
            tempResto.NoteCommentary = noteCommentary;

            ApplicationDBContext.editRestoNote(tempResto);
            return RedirectToAction("Index");
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
