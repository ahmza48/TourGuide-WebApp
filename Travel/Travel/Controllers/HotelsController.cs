using Microsoft.AspNetCore.Mvc;
using Travel.Models.Repositories;
using Travel.Models;

namespace Travel.Controllers
{
    public class HotelsController : Controller
    {
        private readonly TouristContext _context;
        private readonly HotelRepository hotelRepository;
        public HotelsController()
        {
            _context = new TouristContext();
            hotelRepository = new HotelRepository(_context);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HotelsByPlace(string name)
        {
            List<Hotel> list = hotelRepository.GetHotelsByPlaceName(name);
            return View("~/Views/Hotels/specificHotels.cshtml",list);
        }
        
    }
}
