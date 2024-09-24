using CarAPI.Models;
using CarAPI.Repositories;

namespace CarAPI.Services
{
    public interface IInquiryService
    {
        IEnumerable<Inquiry> GetAllInquiries();
        Inquiry GetInquiryById(int id);
        void SubmitInquiry(Inquiry inquiry);
        void UpdateInquiryStatus(int id, string status);
    }


}
