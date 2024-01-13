namespace Travel.Models.Repositories
{
    public class PhotographerRepository
    {
        private readonly TouristContext _context;

        public PhotographerRepository(TouristContext context)
        {
            _context = context;
        }

        public void Add(Photographer Photographer)
        {
            _context.Photographers.Add(Photographer);
            _context.SaveChanges();
        }

        public void Update(Photographer Photographer)
        {
            _context.Photographers.Update(Photographer);
            _context.SaveChanges();
        }

        public void Delete(Photographer Photographer)
        {
            _context.Photographers.Remove(Photographer);
            _context.SaveChanges();
        }

        public Photographer GetPhotographerById(int id)
        {
            return _context.Photographers.Find(id);
        }

        public List<Photographer> GetAllPhotographers()
        {
            return _context.Photographers.ToList();
        }
        public Photographer GetPhotographerByContact(string contact)
        {
            return _context.Photographers.FirstOrDefault(p => p.Contact == contact);
        }
        public List<Photographer> GetPhotographersByPlaceName(string placeName)
        {
            return _context.Photographers.Where(p => p.PlaceName == placeName).ToList();
        }

        //public Photographer GetPhotographerByEmailPassword(string em, string pwd)
        //{
        //    return _context.Photographers.FirstOrDefault(a => a.Email == em && a.Password == pwd);
        //}
    }
}
