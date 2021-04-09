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

        public IActionResult CreateResto(String name, String phone, String commentary, String email, String street, int zip, String city, String lastTimeVisited, int note, String noteCommentary)
        {
            Restaurant tempResto = new Restaurant();
            tempResto.Name = name;
            tempResto.Phone = phone;
            tempResto.Commentary = commentary;
            tempResto.Email = email;
            tempResto.Street = street;
            tempResto.Zip = zip;
            tempResto.City = city;
            tempResto.LastTimeVisited = lastTimeVisited;
            tempResto.Note = note;
            tempResto.NoteCommentary = noteCommentary;

            ApplicationDBContext.addResto(tempResto);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int idResto)
        {
            ApplicationDBContext.deleteResto(idResto);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int idResto)
        {
            ViewBag.resto = ApplicationDBContext.getRestoWithId(idResto);
            return View();
        }

        public IActionResult EditQuery(int id, String name, String phone, String commentary, String email, String street, int zip, String city, String lastTimeVisited, int note, String noteCommentary)
        {
            Restaurant tempResto = new Restaurant();
            tempResto.Id = id;
            tempResto.Name = name;
            tempResto.Phone = phone;
            tempResto.Commentary = commentary;
            tempResto.Email = email;
            tempResto.Street = street;
            tempResto.Zip = zip;
            tempResto.City = city;
            tempResto.LastTimeVisited = lastTimeVisited;
            tempResto.Note = note;
            tempResto.NoteCommentary = noteCommentary;

            ApplicationDBContext.editResto(tempResto);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
