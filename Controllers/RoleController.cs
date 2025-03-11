using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace camRental.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> CreateRoles()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await _roleManager.RoleExistsAsync("User"))
                await _roleManager.CreateAsync(new IdentityRole("User"));

            return Content("Roles Created Successfully!");
        }

        [HttpGet("AssignAdminRole")]
        public async Task<IActionResult> AssignAdminRole()
        {
            var user = await _userManager.FindByEmailAsync("admin@gmail.com");
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                return Ok("Admin Role Assigned Successfully!");
            }
            return NotFound("Admin User Not Found!");
        }

    }
}
