using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Spoilt.Models;

namespace Spoilt.Controllers
{
    public class UserSessionsController : Controller
    {
        private Models.Interfaces.IUserSession _session;

        public UserSessionsController(Models.Interfaces.IUserSession context)
        {
            _session = context;
        }

        // POST: Sessions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Create([Bind("ID,CreatedAt")] UserSession session)
        {
            // I feel like this is weird, and I don't like it. Do we even need a Create action?
            // We never redirect to this action; instead, we call the .CreateSessionString() method from the UserSession service within the VotesController/Create action. Effectively, sessions are not stored in the Sessions table until a user votes.
            await _session.CreateSessionString(session.ID);
        }
    }
}