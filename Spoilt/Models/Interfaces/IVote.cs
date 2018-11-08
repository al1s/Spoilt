using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    public interface IVote
    {
        /// <summary>
        /// Create vote
        /// </summary>
        /// <param name="vote">Vote object</param>
        /// <returns>Vote object</returns>
        Task<Vote> AddVote(Vote vote);

        /// <summary>
        /// Delete vote by ID
        /// </summary>
        /// <param name="id">ID of vote to be deleted</param>
        /// <returns>No return val</returns>
        Task DeleteVote(int id);

        int GetVotesBySpoilerID(int id);
        int CheckIfUserAlreadyVotedForSpoiler(int spoilerID, string userSession);
    }
}
