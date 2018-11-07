using Microsoft.AspNetCore.Mvc;

namespace Spoilt.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}