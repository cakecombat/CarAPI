using CarAPI.Models;

namespace CarAPI.Services
{
    public interface IContactUsService
    {
        void SubmitContactUs(ContactUs contactUs);
        IEnumerable<ContactUs> GetAllMessages();
    }
}
