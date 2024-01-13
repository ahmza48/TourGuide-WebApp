using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View("Chat");
        }
    }
}
