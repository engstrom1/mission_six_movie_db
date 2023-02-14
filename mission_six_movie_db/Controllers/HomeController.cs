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
            return View();
        }

        // post controller for movie form page
        [HttpPost]
        public IActionResult AddMovieForm(MovieFormResponse mfr)
        {
            movieContext.Add(mfr);
            movieContext.SaveChanges();

            return View("Confirmation", mfr);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
