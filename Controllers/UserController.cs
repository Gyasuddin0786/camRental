using Microsoft.AspNetCore.Mvc;
using System.Linq;
using camRental.Models;
using camRental.Database;
using Microsoft.AspNetCore.Authorization;

namespace camRental.Controllers
{
    [Authorize(Roles = "Admin")]  // Admin access
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Show All Users
        public IActionResult Dashoard() // Dashboard
        {
            var users = _context.Users.ToList(); // Fetch All Users
            return View(users);
        }

        // Delete User
        public IActionResult Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard"); // Redirecting to Index
        }
    }
}
