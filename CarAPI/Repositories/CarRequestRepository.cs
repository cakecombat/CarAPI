using CarAPI.Models;
using CarAPI.Repositories;
using Microsoft.EntityFrameworkCore;

public class CarRequestRepository : ICarRequestRepository
{
    private readonly ApplicationDbContext _context;

    public CarRequestRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CarRequestModel> GetAllRequests()
    {
        return _context.CarRequests
            .Include(cr => cr.Car)
            .ToList();
    }

    public void AddRequest(CarRequestModel request)
    {
        _context.CarRequests.Add(request);
        _context.SaveChanges();
    }
}