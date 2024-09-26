using CarAPI.Models;

namespace CarAPI.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<CarModel> GetAll();
        CarModel GetById(int id);
        void Add(CarModel car);
        void Update(int id, CarModel car); 
        void Delete(int id); 
    }



}
