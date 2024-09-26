using CarAPI.Models;
using CarAPI.Repositories;

namespace CarAPI.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public void SubmitContactUs(ContactUs contactUs)
        {
            _contactUsRepository.Add(contactUs);
        }

        public IEnumerable<ContactUs> GetAllMessages()
        {
            return _contactUsRepository.GetAll();
        }
    }
}
