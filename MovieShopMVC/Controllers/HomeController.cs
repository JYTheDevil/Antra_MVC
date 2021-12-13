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
        public async Task<IActionResult> Index()
        {
            // Call movie service to get list of movie cards to show in the index view
            var movieCards = await _movieService.GetHighestGrossingMovies();

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
        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TopMovies()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}