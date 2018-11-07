using Microsoft.AspNetCore.Mvc;
using Spoilt.Models.Interfaces;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Details(string id)
        {
            var movie = await _movie.GetMovieById(id);
            return View(movie);
        }
    }
}