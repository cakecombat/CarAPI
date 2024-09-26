using CarAPI.Models;

namespace CarAPI.Repositories
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactUsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ContactUs contactUs)
        {
            _context.ContactUs.Add(contactUs);
            _context.SaveChanges();
        }

        public IEnumerable<ContactUs> GetAll()
        {
            return _context.ContactUs.ToList();
        }
    }
}
