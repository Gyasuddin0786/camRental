using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace camRental.Areas.UserDashboard.Controllers
{
    public class UserController : Controller
    {
        [Area("User")]
        [Authorize(Roles = "User")]  //it will be only accessible for users
        public IActionResult Index()
        {
            return View();
        }
    }
}
