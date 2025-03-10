using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace camRental.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult ManageUsers() => View();
        public IActionResult AddCamLensVideo() => View();
        public IActionResult AddTrandingCamLensVideo() => View();
        public IActionResult CardProdList() => View();
        public IActionResult TrandingProdList() => View();

        public IActionResult ManageBookings() => View();
    }
}
