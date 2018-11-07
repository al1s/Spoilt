using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spoilt.Models;

namespace Spoilt.Controllers
{
    public class SpoilersController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}