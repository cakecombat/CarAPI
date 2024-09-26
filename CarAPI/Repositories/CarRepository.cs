using CarAPI.Models;
using CarAPI.Repositories;
using System.Collections.Generic;
using System.Linq;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;

    public CarRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CarModel> GetAll() => _context.Cars.ToList();

    public CarModel? GetById(int id) => _context.Cars.FirstOrDefault(c => c.Id == id);

    public void Add(CarModel car)
    {
        car.CreatedAt = DateTime.Now; 
        car.UpdatedAt = DateTime.Now;  
        _context.Cars.Add(car);
        _context.SaveChanges(); 
    }

    public void Update(int id, CarModel car)
    {
        var existingCar = GetById(id);
        if (existingCar != null)
        {
            existingCar.Make = car.Make;
            existingCar.Model = car.Model;
            existingCar.Price = car.Price;
            existingCar.Picture = car.Picture; 
            existingCar.UpdatedAt = DateTime.Now; 
            _context.SaveChanges(); 
        }
    }

    public void Delete(int id)
    {
        var car = GetById(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges(); 
        }
    }

    public CarModel GetCarById(int id)
    {
        return _context.Cars.Find(id);
    }
}
