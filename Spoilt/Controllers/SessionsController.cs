using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Spoilt.Controllers
{
    public class SessionsController : Controller
    {
        private Models.Interfaces.IUserSession _session;

        public SessionsController(Models.Interfaces.IUserSession context)
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