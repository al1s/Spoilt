using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spoilt.Models;
using Spoilt.Models.Interfaces;

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