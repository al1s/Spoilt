using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Spoilt.Controllers
{
    public class SpoilersController : Controller
    {
        public async Task<Vote> Create()
        {
            return View();
        }
    }
}