using Microsoft.AspNetCore.Mvc;
using Travel.Models.Repositories;
using Travel.Models;

namespace Travel.Controllers
{
    public class PhotographerController : Controller
    {
        private readonly TouristContext _context;
        private readonly PhotographerRepository photographerRepository;
        public PhotographerController()
        {
            _context = new TouristContext();
            photographerRepository = new PhotographerRepository(_context);
        }
        public IActionResult Index()
        {
            List<Photographer> list = photographerRepository.GetAllPhotographers();
            return View("~/Views/Photographer/Index.cshtml", list);
        }
        public IActionResult PhotographersByPlace(string name)
        {
            List<Photographer> list = photographerRepository.GetPhotographersByPlaceName(name);
            return View("~/Views/Photographer/SpecificPhotographers.cshtml", list);
        }
        

    }
}
