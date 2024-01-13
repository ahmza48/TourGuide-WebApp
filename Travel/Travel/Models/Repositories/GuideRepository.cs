namespace Travel.Models.Repositories
{
    public class GuideRepository
    {
        private readonly TouristContext _context;

        public GuideRepository(TouristContext context)
        {
            _context = context;
        }

        public void Add(Guide Guide)
        {
            _context.Guides.Add(Guide);
            _context.SaveChanges();
        }

        public void Update(Guide Guide)
        {
            _context.Guides.Update(Guide);
            _context.SaveChanges();
        }

        public void Delete(Guide Guide)
        {
            _context.Guides.Remove(Guide);
            _context.SaveChanges();
        }
        public List<Guide> Take(int num)
        {
            return   _context.Guides.Take(num).ToList();
        }
        public Guide GetGuideById(int id)
        {
            return _context.Guides.Find(id);
        }
        public Guide GetGuideByContact(string contact)
        {
            return _context.Guides.FirstOrDefault(p=>p.Contact==contact);
        }
        public List<Guide> GetGuidesByPlaceName(string placeName)
        {
            return _context.Guides.Where(g => g.PlaceName == placeName).ToList();
        }


        public List<Guide> GetAllGuides()
        {
            return _context.Guides.ToList();
        }

        //public Guide GetGuideByEmailPassword(string em, string pwd)
        //{
        //    return _context.Guides.FirstOrDefault(a => a.Email == em && a.Password == pwd);
        //}
    }
}
