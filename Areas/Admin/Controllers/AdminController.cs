using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace camRental.Areas.AdminDashboard.Controllers
{
    public class AdminController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = "Admin")] // it will be only accessible for admin
        public IActionResult Index()
        {
            // Dummy Data (Later, replace with database values)
            ViewBag.TotalUsers = 3432;
            ViewBag.TotalCameras = 120;
            ViewBag.TotalLenses = 90;
            ViewBag.TotalVideography = 230;

            // Booking Status Data
            ViewBag.CompletedBookings = 180;
            ViewBag.PendingBookings = 30;
            ViewBag.CancelledBookings = 20;

            return View();
        }
    }
}
