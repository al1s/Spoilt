using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spoilt.Data;
using Spoilt.Models.Services;

namespace Spoilt.Controllers
{
    public class VotesController : Controller
    {
        private SpoiltDbContext _votes;

        public VotesController(SpoiltDbContext context)
        {
            _votes = context;
        }

        // POST: Votes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Votes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Votes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task DeleteConfirmed(int id)
        {
            try
            {
                var vote = _votes.Votes.FirstOrDefault(v => v.ID == id);
                _votes.Remove(vote);
                await _votes.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}