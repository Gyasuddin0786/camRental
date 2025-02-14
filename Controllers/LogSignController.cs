using Microsoft.AspNetCore.Mvc;

namespace camRental.Controllers
{
    public class LogSignController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogSign()
        {
            return View();
        }
    }
}
