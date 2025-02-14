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
    }
}
