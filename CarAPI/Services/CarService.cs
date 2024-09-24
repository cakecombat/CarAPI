using CarAPI.Models;
using CarAPI.Repositories;

namespace CarAPI.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IEnumerable<Car> GetAllCars() => _carRepository.GetAll();

        public Car GetCarById(int id) => _carRepository.GetById(id);

        public void AddCar(Car car) => _carRepository.Add(car);

        public void UpdateCar(int id, Car car) => _carRepository.Update(id, car);

        public void DeleteCar(int id) => _carRepository.Delete(id); 
    }

}
