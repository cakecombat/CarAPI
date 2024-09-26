using CarAPI.Models;

public interface ICarService
{
    IEnumerable<CarModel> GetAllCars();
    CarModel GetCarById(int id);
    void AddCar(CarModel car);
    void UpdateCar(int id, CarModel car);
    void DeleteCar(int id);
}