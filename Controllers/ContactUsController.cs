using Microsoft.AspNetCore.Mvc;

namespace camRental.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
