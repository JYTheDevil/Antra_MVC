﻿using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Views.Shared.Components.Genres
{
    public class GenresViewComponents : ViewComponent
    {
        private readonly IGenreService _genreService;

        public GenresViewComponents(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _genreService.GetAllGenres();
            return View(genres);
        }
    }
}