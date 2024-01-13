namespace Travel.Models.Repositories
{
    public class PlaceRepository
    {
        private readonly TouristContext _context;

        public PlaceRepository(TouristContext context)
        {
            _context = context;
        }

        public void Add(Place Place)
        {
            _context.Places.Add(Place);
            _context.SaveChanges();
        }

        public void Update(Place Place)
        {
            _context.Places.Update(Place);
            _context.SaveChanges();
        }

        public void Delete(Place Place)
        {
            _context.Places.Remove(Place);
            _context.SaveChanges();
        }

        public Place GetPlaceById(int id)
        {
            return _context.Places.Find(id);
        }
        public Place GetPlaceByName(string name)
        {
            return _context.Places.FirstOrDefault(p=>p.Name==name);
        }

        public List<Place> GetAllPlaces()
        {
            return _context.Places.ToList();
        }

        //public Place GetPlaceByEmailPassword(string em, string pwd)
        //{
        //    return _context.Places.FirstOrDefault(a => a.Email == em && a.Password == pwd);
        //}
    }
}
