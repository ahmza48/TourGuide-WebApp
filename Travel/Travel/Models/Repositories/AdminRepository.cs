namespace Travel.Models.Repositories
{
    public class AdminRepository
    {
        private readonly TouristContext _context;

        public AdminRepository(TouristContext context)
        {
            _context = context;
        }

        public void Add(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }

        public void Update(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }

        public void Delete(Admin admin)
        {
            _context.Admins.Remove(admin);
            _context.SaveChanges();
        }

        public Admin GetAdminById(int id)
        {
            return _context.Admins.Find(id);
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _context.Admins.ToList();
        }

        public Admin GetAdminByEmailPassword(string em, string pwd)
        {
            return _context.Admins.FirstOrDefault(a=>a.Email == em && a.Password == pwd);
        }
    }
}
