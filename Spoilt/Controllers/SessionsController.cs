﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spoilt.Data;

namespace Spoilt.Controllers
{
    public class SessionsController : Controller
    {
        private SpoiltDbContext _context;

        public SessionsController(SpoiltDbContext context)
        {
            _context = context;
        }

        // GET: Sessions
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sessions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sessions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sessions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
            try
            {


                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}