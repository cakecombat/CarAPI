using CarAPI.Models;

namespace CarAPI.Repositories
{
    public interface IInquiryRepository
    {
        IEnumerable<Inquiry> GetAll();
        Inquiry GetById(int id);
        void Add(Inquiry inquiry);
        void UpdateStatus(int id, string status);
    }



}
