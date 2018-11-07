using Microsoft.AspNetCore.Mvc;
using Spoilt.Models;
using Spoilt.Models.Interfaces;
using System.Threading.Tasks;

namespace Spoilt.Controllers
{
    public class VotesController : Controller
    {
        private IVote _votes;

        public VotesController(IVote context)
        {
            _votes = context;
        }

        // POST: Votes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task Create([Bind("ID,MovieID,SpoilerID,SessionID")] Vote vote)
        {
            return _votes.AddVote(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task DeleteConfirmed(int id)
        {
            return _votes.DeleteVote(id);
        }
    }
}