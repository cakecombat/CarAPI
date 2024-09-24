using CarAPI.Models;

public interface ICarService
{
    IEnumerable<Car> GetAllCars();
    Car GetCarById(int id);
    void AddCar(Car car);
    void UpdateCar(int id, Car car);
    void DeleteCar(int id);
}