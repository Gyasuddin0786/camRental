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
    }
}
