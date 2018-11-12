using Microsoft.AspNetCore.Mvc;
using Spoilt.Models;
using Spoilt.Models.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Spoilt.Models.Services;
using System.Linq;


namespace Spoilt.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovie _movies;
        private readonly IVote _votes;

        /// <summary>
        /// Passes the methods from the movie and votes interfaces/services to communicate with the custom api and the app's database
        /// </summary>
        /// <param name="movies">The interface the controller will use to get movie data from the custom api</param>
        /// <param name="votes">The interface the controller will use to get vote data from the database</param>
        public MoviesController(IMovie movies, IVote votes)
        {
            _movies = movies;
            _votes = votes;
        }

        /// <summary>
        /// Gets all movies from the custom API
        /// </summary>
        /// <returns>View at Movies/Index with movie data provided by custom API</returns>
        public async Task<IActionResult> Index()
        {
            var myMovies = await _movies.GetMovies();
            return View(myMovies);
        }

        /// <summary>
        /// Gets all movies from the custom API, or all movies with titles containing a string if one is provided
        /// </summary>
        /// <param name="title">A string the user inputs into a search bar</param>
        /// <returns>View at Movies/Index with movie data provided by custom API</returns>
        public async Task<IActionResult> Search(string title)
        {
            ViewBag.Error = null;
            var myMovies = await _movies.GetMoviesByTitle(title);
            if (myMovies.Count() == 0)
            {
                myMovies = await _movies.GetMovies();
                ViewBag.Error = "Too Many Results! Please refine your search.";
            }
            return View("Index", myMovies);
        }

        /// <summary>
        /// Gets one movie along with all of its associated spoilers from the custom API, and the votes associated with each spoiler from frontend database
        /// </summary>
        /// <param name="id">A string indicating the IMDB id to retrieve movie data from custom API</param>
        /// <returns>A view at Movies/Details with movie, spoiler, and vote data</returns>
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movies.GetMovieById(id.ToString());
            if (movie == null)
            {
                return NotFound();
            }

            // Set the Votes property per each spoiler object using a method provided by the VoteService
            foreach (Spoiler spoiler in movie.Spoilers)
            {
                int numberOfVotesPerSpoiler = _votes.GetVotesBySpoilerID(spoiler.ID);
                spoiler.Votes = numberOfVotesPerSpoiler;
            }


            var sorted = movie.Spoilers.OrderByDescending(x => x.Votes);
            movie.Spoilers = sorted.ToList();
            return View(movie);
        }
    }
}