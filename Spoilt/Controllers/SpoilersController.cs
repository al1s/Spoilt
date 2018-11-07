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

        public SpoilersController(IMovie movieInterface, ISpoiler spoilerInterface)
        {
            _movie = movieInterface;
            _spoiler = spoilerInterface;
        }

        public async Task<IActionResult> Create(string id)
        {
            var movie = await _movie.GetMovieById(id);
            ViewBag.Movie = movie;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string id, [Bind("SpoilerText, MovieID")] Spoiler spoiler)
        {
            bool result = false;
            if (id != spoiler.MovieID)
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
                return RedirectToAction("Details", "Movies", new { id = id });
            }
            var movie = await _movie.GetMovieById(id);
            return View(movie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var spoiler = await _spoiler.GetSpoiler(id);
            return View(spoiler);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(int id, string updatedText)
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