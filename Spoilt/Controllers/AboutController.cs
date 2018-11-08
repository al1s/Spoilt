using Microsoft.AspNetCore.Mvc;

namespace Spoilt.Controllers
{
    public class AboutController : Controller
    {
        /// <summary>
        /// Displays the About Us page
        /// </summary>
        /// <returns>A View at About/Index</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}