using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
