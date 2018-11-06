using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spoilt.Models;
using Spoilt.Models.Interfaces;
using Spoilt.Models.Services;

namespace Spoilt.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovie _movie;

        public MoviesController(IMovie movieInterface)
        {
            _movie = movieInterface;
        }

        public async Task<IActionResult> Index()
        {
            var myMovies = await _movie.GetMovies();
            return View(myMovies);
        }

        public IActionResult Details(string id)
        {
            return View();
        }
    }
}