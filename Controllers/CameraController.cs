using Microsoft.AspNetCore.Mvc;

namespace camRental.Controllers
{
    public class CameraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DSLR()
        {
            return View();
        }
        public IActionResult MirrorLess()
        {
            return View();
        }

        public IActionResult Action()
        {
            return View();
        }

        public IActionResult Specialized()
        {
            return View();
        }
    }
}
