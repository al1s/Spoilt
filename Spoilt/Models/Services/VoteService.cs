using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spoilt.Models.Interfaces;
using Spoilt.Models;
using Spoilt.Data;

namespace Spoilt.Models.Services
{
    public class VoteService : IVote
    {
        private SpoiltDbContext _context;

        public VoteService(SpoiltDbContext context)
        {
            _context = context;
        }

        public async Task<Vote> AddVote(string movieID, int spoilerID)
        {
            Vote vote = new Vote() { MovieID = movieID, SpoilerID = spoilerID };
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
            return vote;
        }

        public async Task DeleteVote(int id)
        {
            Vote vote = _context.Votes.FirstOrDefault(v => v.ID == id);
            _context.Votes.Remove(vote);
            await _context.SaveChangesAsync();
        }
    }
}
