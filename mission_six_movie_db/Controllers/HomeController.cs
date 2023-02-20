using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission_six_movie_db.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission_six_movie_db.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieFormContext movieContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieFormContext x)
        {
            _logger = logger;
            movieContext = x;
        }

        // about view
        public IActionResult Index()
        {
            return View();
        }

        // podcast view
        public IActionResult Privacy()
        {
            return View();
        }

        // get view for movie form page
        [HttpGet]
        public IActionResult AddMovieForm()
        {
            ViewBag.Categories = movieContext.categories.ToList();
            return View();
        }

        public IActionResult ListAll()
        { 
            var movies = movieContext.responses
                .OrderBy(x=> x.Title)
                .ToList();
            return View("ListAll", movies);
        }

        // post controller for movie form page
        [HttpPost]
        public IActionResult AddMovieForm(MovieFormResponse mfr)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(mfr);
                movieContext.SaveChanges();

                return View("Confirmation", mfr);
            }
            else
            {
                ViewBag.Categories = movieContext.categories.ToList();
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int movieFormId)
        {
            ViewBag.Categories = movieContext.categories.ToList();

            var movieResponse = movieContext.responses.Single(x => x.MovieFormId == movieFormId);

            return View("AddMovieForm", movieResponse);
        }

        [HttpPost]
        public IActionResult Edit(MovieFormResponse mfr)
        {
            movieContext.Update(mfr);
            movieContext.SaveChanges();
            return RedirectToAction("ListAll");
        }

        [HttpGet]
        public IActionResult Delete(int movieFormId)
        {
            var movieResponse = movieContext.responses.Single(x => x.MovieFormId == movieFormId);

            return View(movieResponse);
        }

        [HttpPost]
        public IActionResult Delete(MovieFormResponse mfr)
        {
            movieContext.responses.Remove(mfr);
            movieContext.SaveChanges();

            return RedirectToAction("ListAll");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
