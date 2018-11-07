using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    public interface IVote
    {
        Task<Vote> AddVote(Vote vote);
        Task DeleteVote(int id);
        int GetVotesBySpoilerID(int id);
    }
}
