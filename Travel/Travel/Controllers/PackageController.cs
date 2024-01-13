using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class PackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
