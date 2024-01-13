namespace Travel.Models.Repositories
{
    public class HotelRepository
    {
        private readonly TouristContext _context;

        public HotelRepository(TouristContext context)
        {
            _context = context;
        }

        public void Add(Hotel Hotel)
        {
            _context.Hotels.Add(Hotel);
            _context.SaveChanges();
        }

        public void Update(Hotel Hotel)
        {
            _context.Hotels.Update(Hotel);
            _context.SaveChanges();
        }

        public void Delete(Hotel Hotel)
        {
            _context.Hotels.Remove(Hotel);
            _context.SaveChanges();
        }

        public Hotel GetHotelById(int id)
        {
            return _context.Hotels.Find(id);
        }

        public Hotel GetHotelByName(string name)
        {
            return _context.Hotels.FirstOrDefault(p=>p.HotelName==name);
        }
        public List<Hotel> GetAllHotels()
        {
            return _context.Hotels.ToList();
        }
        public List<Hotel> GetHotelsByPlaceName(string placeName)
        {
            return _context.Hotels.Where(h => h.PlaceName == placeName).ToList();
        }


        //public Hotel GetHotelByEmailPassword(string em, string pwd)
        //{
        //    return _context.Hotels.FirstOrDefault(a => a.Email == em && a.Password == pwd);
        //}
    }
}
