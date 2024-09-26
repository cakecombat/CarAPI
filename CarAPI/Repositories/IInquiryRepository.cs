using CarAPI.Models;

namespace CarAPI.Repositories
{
    public interface IInquiryRepository
    {
        IEnumerable<InquiryModel> GetAll();
        InquiryModel GetById(int id);
        void Add(InquiryModel inquiry);
        void UpdateStatus(int id, string status);
    }



}
