using Microsoft.AspNetCore.Mvc;

namespace camRental.Controllers
{
    public class UserLoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
    }
}
