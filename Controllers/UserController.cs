using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace camRental.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Roles = "User")]  // ❌ Unauthorized Users Yaha Nahi Aa Sakte
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult MyBookings() => View();
        public IActionResult Profile() => View();
        public IActionResult AvailableCameras() => View();
    }
}
