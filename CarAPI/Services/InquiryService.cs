using CarAPI.Models;
using CarAPI.Repositories;

namespace CarAPI.Services
{
    public class InquiryService : IInquiryService
    {
        private readonly IInquiryRepository _inquiryRepository;

        public InquiryService(IInquiryRepository inquiryRepository)
        {
            _inquiryRepository = inquiryRepository;
        }

        public IEnumerable<InquiryModel> GetAllInquiries()
        {
            return _inquiryRepository.GetAll();
        }

        public InquiryModel GetInquiryById(int id)
        {
            return _inquiryRepository.GetById(id);
        }

        public void SubmitInquiry(InquiryModel inquiry)
        {
            _inquiryRepository.Add(inquiry);
        }

        public void UpdateInquiryStatus(int id, string status)
        {
            _inquiryRepository.UpdateStatus(id, status);
        }
    }


}
