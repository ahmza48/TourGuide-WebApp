using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
