using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spoilt.Models;
using Spoilt.Models.Interfaces;
using Spoilt.Models.Services;
using Spoilt.Models.ViewModels;

namespace Spoilt.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovie _movie;

        public MoviesController(IMovie movieInterface)
        {
            _movie = movieInterface;
        }

        public async Task<IActionResult> Index(string title)
        {
            if (title != null)
            {
                var myMovies = await _movie.GetMoviesByTitle(title);
                return View(myMovies);
            }
            else
            {
                var myMovies = await _movie.GetMovies();
                return View(myMovies);
            }
        }

        public IActionResult Details(string id)
        {
            return View();
        }

        //public IActionResult Details(string id)
        //{
        //    return View();
        //}

        public IActionResult Details()
        {
            Movie movie = new Movie
            {
                ID = "ID33343",
                Title = "The Matrix",
                Genre = "Action, Sci-Fi",
                Plot = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers",
                PosterUrl = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg"
            };
            MovieSpoilers movieSpoilers = new MovieSpoilers()
            {
                Movie = movie,
                Spoilers = new List<Spoiler>()
                {
                    new Spoiler()
                    {
                        Text = "Neo will die",
                        DateTime = DateTime.Now,
                    },
                    new Spoiler()
                    {
                        Text = "Zeon will survive"
                    }
                }

            };
            return View(movieSpoilers);
        }
    }
}