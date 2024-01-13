using Microsoft.AspNetCore.Mvc;
using Travel.Models.Repositories;
using Travel.Models;

namespace Travel.Controllers
{
    public class TeamController : Controller
    {

        private readonly TouristContext _context;
        private readonly GuideRepository guideRepository;
        public TeamController()
        {
            _context = new TouristContext();
            guideRepository = new GuideRepository(_context);
        }
        public IActionResult Index()
        {
            List<Guide> list = guideRepository.GetAllGuides();
            return View("~/Views/Team/Index.cshtml", list);
        }
        public IActionResult GuidesByPlace(string name)
        {
            List<Guide> list = guideRepository.GetGuidesByPlaceName(name);
            return View("~/Views/Team/SpecificGuides.cshtml", list);
        }

    }
}
