using CarAPI.Models;

namespace CarAPI.Repositories
{
    public class InquiryRepository : IInquiryRepository
    {
        private readonly ApplicationDbContext _context;

        public InquiryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<InquiryModel> GetAll() => _context.Inquiries.ToList();

        public InquiryModel GetById(int id) => _context.Inquiries.FirstOrDefault(i => i.Id == id);

        public void Add(InquiryModel inquiry)
        {
            inquiry.CreatedAt = DateTime.Now;  // Set creation time
            inquiry.UpdatedAt = DateTime.Now;  // Set update time (same on creation)
            _context.Inquiries.Add(inquiry);
            _context.SaveChanges(); // Saves changes to the database, including auto-generated ID
        }

        public void UpdateStatus(int id, string status)
        {
            var inquiry = GetById(id);
            if (inquiry != null)
            {
                inquiry.Status = status;
                inquiry.UpdatedAt = DateTime.Now; // Update the timestamp when status changes
                _context.SaveChanges(); // Save the update to the database
            }
        }
    }



}
