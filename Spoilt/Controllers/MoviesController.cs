using Microsoft.AspNetCore.Mvc;
using Spoilt.Models;
using Spoilt.Models.Interfaces;
using System.Threading.Tasks;
using System;
using Spoilt.Models.Services;

namespace Spoilt.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovie _movies;
        private readonly IVote _votes;

        public MoviesController(IMovie movies, IVote votes)
        {
            _movies = movies;
            _votes = votes;
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

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();
            var movie = await _movies.GetMovieById(id.ToString());
            if (movie == null) return NotFound();

            // Set the Votes property per each spoiler object using a method provided by the VoteService
            foreach (Spoiler spoiler in movie.Spoilers)
            {
                int numberOfVotesPerSpoiler = _votes.GetVotesBySpoilerID(spoiler.ID);
                spoiler.Votes = numberOfVotesPerSpoiler;
            }

            return View(movie);
        }
    }
}