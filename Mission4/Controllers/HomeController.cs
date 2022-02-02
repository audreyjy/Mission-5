using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {

        private MovieFormContext MfContext { get; set; }

        public HomeController(MovieFormContext someName)
        {

            MfContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = MfContext.Categories.ToList();
            return View();

        }

        [HttpPost]
        public IActionResult MovieForm(FormResponse fr)
        {
            if (ModelState.IsValid)
            {
                MfContext.Add(fr);
                MfContext.SaveChanges();
                return View("Response", fr);
            }

            else
            {
                ViewBag.Categories = MfContext.Categories.ToList();
                return View(fr);
            }

        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var movie = MfContext.Responses
                .Include(x => x.Category) // this includes the major object that is in the major model
                .ToList(); // stores the data from the movieform to a list in variable called 'movie'
            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(int entryid)
        {
            ViewBag.Categories = MfContext.Categories.ToList();

            var movieentry = MfContext.Responses.Single(x => x.EntryId == entryid);

            return View("MovieForm", movieentry);
        }

        [HttpPost]
        public IActionResult Edit(FormResponse fr)
        {
            if (ModelState.IsValid)
            {
                MfContext.Update(fr);
                MfContext.SaveChanges();
                return RedirectToAction("MovieList");
            }

            else
            {
                ViewBag.Categories = MfContext.Categories.ToList();
                return View("MovieForm", fr);
            }


        }

        [HttpGet]
        public IActionResult DeleteMovie(int entryid)
        {
            var movieentry = MfContext.Responses.Single(x => x.EntryId == entryid);

            return View(movieentry);
        }

        [HttpPost]
        public IActionResult DeleteMovie(FormResponse fr)
        {
            MfContext.Responses.Remove(fr);
            MfContext.SaveChanges();
            return RedirectToAction("MovieList"); 
        }

        //[HttpPost]
        //public IActionResult Delete(FormResponse fr)
        //{
        //    MfContext.Responses.Remove(fr);
        //    MfContext.SaveChanges(); 
        //    RedirectToAction("MovieList");

        //}

    }
}
