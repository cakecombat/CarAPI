using CarAPI.Models;
using CarAPI.Repositories;

namespace CarAPI.Services
{
    public interface IInquiryService
    {
        IEnumerable<InquiryModel> GetAllInquiries();
        InquiryModel GetInquiryById(int id);
        void SubmitInquiry(InquiryModel inquiry);
        void UpdateInquiryStatus(int id, string status);
    }


}
