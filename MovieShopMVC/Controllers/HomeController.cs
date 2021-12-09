using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        // C# readonly
        private readonly IMovieService _movieService;

        // need to tell MVC MovieService class needs to be "injected"
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Call movie service to get list of movie cards to show in the index view
            var movieCards = _movieService.GetHighestGrossingMovies();

            // 3 ways to pass data/models from controller action methods to view
            // 1. Pass the models in the view method (Most important)
            // 2. ViewBag
            // 3. ViewData

            // value types we can make nullable by ?

            //string x = null;

            //var leng = x.Length;

            return View(movieCards);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TopMovies()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
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