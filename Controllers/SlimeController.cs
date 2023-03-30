using Microsoft.AspNetCore.Mvc;

namespace Slimepen.Controllers
{
    public class SlimeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
