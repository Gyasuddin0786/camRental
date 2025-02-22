using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
namespace camRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // **Login Page**
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, password, false, false);

                if (result.Succeeded)
                {
                    // **Check Role & Redirect Accordingly**
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Dashboard", "Admin");  // 👈 Admin Panel
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "User");  // 👈 User Panel
                    }
                }
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View();
        }

        // **Logout**
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
