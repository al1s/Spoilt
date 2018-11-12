using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spoilt.Models;
using Spoilt.Models.Interfaces;
using System.Threading.Tasks;

namespace Spoilt.Controllers
{
    public class SpoilersController : Controller
    {
        private readonly IMovie _movie;
        private readonly ISpoiler _spoiler;

        /// <summary>
        /// Passes the methods from the movie and spoiler interfaces/services to communicate with the custom api
        /// </summary>
        /// <param name="movieInterface">The interface the controller needs to impliment to get movie data</param>
        /// <param name="spoilerInterface">The interface the controller needs to impliment to get spoiler data</param>
        public SpoilersController(IMovie movieInterface, ISpoiler spoilerInterface)
        {
            _movie = movieInterface;
            _spoiler = spoilerInterface;
        }

        /// <summary>
        /// Displays a view with a form for the user to contribute a new movie spoiler
        /// </summary>
        /// <param name="id">The IMDB id for the movie the spoiler will be associated with</param>
        /// <returns>A view at Spoilers/Create with movie data passed in</returns>
        public async Task<IActionResult> Create(string id)
        {
            Movie movie = await _movie.GetMovieById(id);
            ViewBag.Movie = movie;
            return View();
        }

        /// <summary>
        /// Action that creates a new spoiler object and makes a POST api call to custom database and returns user to movie details view
        /// </summary>
        /// <param name="id">IMDB id for the movie the spoiler is being created for</param>
        /// <param name="spoiler">Relevent data from the form to create the new Spoiler object</param>
        /// <returns>Redirects the user to view at Movies/Details for movie after creating new spoiler object via call to custom api</returns>
        [HttpPost]
        public async Task<IActionResult> Create(string MovieID, [Bind("SpoilerText, MovieID")] Spoiler spoiler)
        {
            bool result = false;
            if (MovieID != spoiler.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    result = await _spoiler.AddOne(spoiler);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!result)
                    {
                        return new JsonResult(new { error = true, message = "Unable to add spoiler. Try again later" });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Movies", new { id = MovieID });
            }
            var movie = await _movie.GetMovieById(MovieID);
            ViewBag.Movie = movie;
            return View();
        }

        /// <summary>
        /// Displays the Edit page for a specific movie spoiler
        /// </summary>
        /// <param name="id">The id for the spoiler being edited</param>
        /// <returns>A view at Spoilers/Edit with spoiler data from custom api passed in</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var spoiler = await _spoiler.GetSpoiler(id);
            return View(spoiler);
        }

        /// <summary>
        /// Action that updates a spoiler object in the custom api via a put request with updated spoiler data
        /// </summary>
        /// <param name="id">The id for the spoiler being updated</param>
        /// <param name="updatedText">The text that will replace the previous spoiler text</param>
        /// <returns>Redirects the user to the view at Movies/Details after making the put request to the custom api</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("updatedText")] string updatedText)
        {
            var spoiler = await _spoiler.GetSpoiler(id);
            if (spoiler == null)
            {
                return NotFound();
            }
            spoiler.SpoilerText = updatedText;
            var result = false;
            try
            {
                result = await _spoiler.UpdateOne(id, spoiler);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!result)
                {
                    return new JsonResult(new { error = true, message = "Unable to add spoiler. Try again later" });
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Details", "Movies", new { id = spoiler.MovieID });
        }
    }
}