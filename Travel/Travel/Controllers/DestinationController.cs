using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;
using Travel.Models.Repositories;

namespace Travel.Controllers
{
    public class DestinationController : Controller
    {

        private readonly TouristContext _context;
        private readonly PlaceRepository placeRepository;
        public DestinationController()
        {
            _context = new TouristContext();
            placeRepository = new PlaceRepository(_context);
        }
        public IActionResult Index()
        {
            List <Place> list= placeRepository.GetAllPlaces();
            return View("~/Views/Destination/Index.cshtml",list);
        }
    }
}
