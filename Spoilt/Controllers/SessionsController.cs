using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spoilt.Data;
using Spoilt.Models.Services;

namespace Spoilt.Controllers
{
    public class SessionsController : Controller
    {
        private ISession _session;

        public SessionsController(ISession context)
        {
            _session = context;
        }

        // POST: Sessions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Create()
        {
            _session.Create()
        }

        // GET: Sessions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sessions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Delete(int id)
        {
        }
    }
}