using Microsoft.AspNetCore.Mvc;
using Spoilt.Models;
using Spoilt.Models.Interfaces;
using System.Threading.Tasks;

namespace Spoilt.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovie _movies;
        private readonly IVote _votes;

        public MoviesController(IMovie movieService)
        {
            _movies = movieService;
            //_votes = voteService;
        }

        public async Task<IActionResult> Index(string title)
        {
            if (title != null)
            {
                var myMovies = await _movies.GetMoviesByTitle(title);
                return View(myMovies);
            }
            else
            {
                var myMovies = await _movies.GetMovies();
                return View(myMovies);
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            var movie = await _movies.GetMovieById(id);

            // Set the Votes property per each spoiler object using a method provided by the VoteService
            foreach (Spoiler spoiler in movie.Spoilers)
            {
                int numberOfVotesPerSpoiler = _votes.GetVotesBySpoilerID(spoiler.ID);
                spoiler.Votes = numberOfVotesPerSpoiler;
            }

            return View(movie);
        }

        //public IActionResult Details()
        //{
        //    Movie movie = new Movie
        //    {
        //        ID = "ID33343",
        //        Title = "The Matrix",
        //        Genre = "Action, Sci-Fi",
        //        Plot = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers",
        //        PosterUrl = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg"
        //    };
        //    MovieSpoilers movieSpoilers = new MovieSpoilers()
        //    {
        //        Movie = movie,
        //        Spoilers = new List<Spoiler>()
        //        {
        //            new Spoiler()
        //            {
        //                Text = "Neo will die",
        //                DateTime = DateTime.Now,
        //            },
        //            new Spoiler()
        //            {
        //                Text = "Zeon will survive"
        //            }
        //        }

        //    };
        //    return View(movieSpoilers);
        //}
    }
}