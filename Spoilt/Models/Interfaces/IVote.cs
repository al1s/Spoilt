using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    interface IVote
    {
        Task<Vote> AddVote(string movieID, int spoilerID);
        Task<Vote> DeleteVote(int id);
    }
}
