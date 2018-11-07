using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    public interface IVote : IServiceProvider
    {
        Task<Vote> AddVote(Vote vote);
        Task DeleteVote(int id);
        int GetVotesBySpoilerID(int id);
    }
}
