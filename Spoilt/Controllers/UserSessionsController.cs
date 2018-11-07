using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task Create()
        {
            await _session.CreateSessionString();
        }
    }
}