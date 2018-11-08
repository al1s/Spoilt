using Microsoft.AspNetCore.Mvc;
using Spoilt.Models;
using Spoilt.Models.Interfaces;
using System.Threading.Tasks;

namespace Spoilt.Controllers
{
    public class VotesController : Controller
    {
        private IVote _votes;
        private IUserSession _sessions;

        public VotesController(IVote votes, IUserSession sessions)
        {
            _votes = votes;
            _sessions = sessions;
        }

        // POST: Votes/Create
        [HttpPost]
        public async Task Create([Bind("ID,MovieID,SpoilerID,UserSessionID")] Vote vote)
        {
            // Creates the Session instance as a part of the UserSession service
            await _sessions.CreateSessionString(vote.UserSessionID);

            var checkIfVoteAlreadyExists = _votes.CheckIfUserAlreadyVotedForSpoiler(vote.SpoilerID, vote.UserSessionID);
            if (checkIfVoteAlreadyExists == 0) await _votes.AddVote(vote);
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