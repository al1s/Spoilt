using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Spoilt.Models;

namespace Spoilt.Controllers
{
    public class UserSessionsController : Controller
    {
        private Models.Interfaces.IUserSession _session;

        /// <summary>
        /// Passes the methods from the UserSession interface/service to get UserSession data from the database
        /// </summary>
        /// <param name="context">The Database context for the UserSession's table</param>
        public UserSessionsController(Models.Interfaces.IUserSession context)
        {
            _session = context;
        }

        /// <summary>
        /// Creates a new instance of the UserSession class
        /// </summary>
        /// <param name="session">The new UserSession Object to add to the database</param>
        /// <returns>Adds a new UserSession Object but does not redirect the user</returns>
        // POST: Sessions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Create([Bind("ID,CreatedAt")] UserSession session)
        {
            await _session.CreateSessionString(session.ID);
        }
    }
}