using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spoilt.Data;
using Spoilt.Models;
using Spoilt.Models.Interfaces;

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