using Microsoft.AspNetCore.Mvc;

namespace camRental.Controllers
{
    public class LensController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Nicon()
        {
            return View();
        }
        public IActionResult Canon()
        {
            return View();
        }
        public IActionResult Sigma()
        {
            return View();
        }

        public IActionResult Tamron()
        {
            return View();
        }
    }
}
