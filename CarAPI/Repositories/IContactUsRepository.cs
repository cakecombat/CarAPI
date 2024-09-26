using CarAPI.Models;


namespace CarAPI.Repositories
{
    public interface IContactUsRepository
    {
        void Add(ContactUs contactUs);
        IEnumerable<ContactUs> GetAll();
    }
}
