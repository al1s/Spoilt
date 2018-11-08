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

        /// <summary>
        /// Passes the methods from the Vote and UserSession interfaces so the controller can perform CRUD operations on database
        /// </summary>
        /// <param name="votes">The interface the controller uses to get vote data from the database</param>
        /// <param name="sessions">The interface the controller uses to get session data from the database</param>
        public VotesController(IVote votes, IUserSession sessions)
        {
            _votes = votes;
            _sessions = sessions;
        }

        /// <summary>
        /// Instatiates a new instance of the vote class and adds it to the database
        /// </summary>
        /// <param name="vote">The new vote object to be added to the database</param>
        /// <returns>Adds a new vote object to the vote database. Does not redirect the user.</returns>
        // POST: Votes/Create
        [HttpPost]
        public async Task Create([Bind("ID,MovieID,SpoilerID,UserSessionID")] Vote vote)
        {
            // Creates the Session instance as a part of the UserSession service
            await _sessions.CreateSessionString(vote.UserSessionID);

            var checkIfVoteAlreadyExists = _votes.CheckIfUserAlreadyVotedForSpoiler(vote.SpoilerID, vote.UserSessionID);
            if (checkIfVoteAlreadyExists == 0) await _votes.AddVote(vote);
        }

        /// <summary>
        /// Removes a vote from the database
        /// </summary>
        /// <param name="id">The id number of the vote to be deleted</param>
        /// <returns>Removes a vote from the database but does not redirect the user</returns>
        // POST: Votes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task DeleteConfirmed(int id)
        {
            return _votes.DeleteVote(id);
        }
    }
}