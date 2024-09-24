using CarAPI.Models;

namespace CarAPI.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        void Add(Car car);
        void Update(int id, Car car); 
        void Delete(int id); 
    }



}
