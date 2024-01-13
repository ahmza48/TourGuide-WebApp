using Microsoft.AspNetCore.Mvc;
using Travel.Models;
using Travel.Models.Repositories;

namespace Travel.Components
{
    public class MyViewComponent : ViewComponent
    {
        private readonly TouristContext _context;
        private readonly GuideRepository guideRepo;
        private readonly PhotographerRepository photographerRepo;
        public MyViewComponent()
        {
            _context = new TouristContext();
            guideRepo = new GuideRepository(_context);
            photographerRepo = new PhotographerRepository(_context);

        }
        public IViewComponentResult Invoke()
        {
            List<Guide> guides = guideRepo.Take(4).ToList();
            return View(guides);
        }


    }
}
