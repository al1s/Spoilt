using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spoilt.Models.Interfaces;

namespace Spoilt.Models.Services
{
    public class VoteService : IVote
    {
        Task<Vote> IVote.AddVote(string movieID, int spoilerID)
        {
            throw new NotImplementedException();
        }

        Task<Vote> IVote.DeleteVote(int id)
        {
            throw new NotImplementedException();
        }
    }
}
