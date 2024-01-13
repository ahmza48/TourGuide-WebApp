using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
