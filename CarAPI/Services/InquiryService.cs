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

        public IEnumerable<Inquiry> GetAllInquiries()
        {
            return _inquiryRepository.GetAll();
        }

        public Inquiry GetInquiryById(int id)
        {
            return _inquiryRepository.GetById(id);
        }

        public void SubmitInquiry(Inquiry inquiry)
        {
            _inquiryRepository.Add(inquiry);
        }

        public void UpdateInquiryStatus(int id, string status)
        {
            _inquiryRepository.UpdateStatus(id, status);
        }
    }


}
