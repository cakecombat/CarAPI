using CarAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarAPI.Repositories
{
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
                .Include(cr => cr.Car) // Include car details
                .ToList();
        }

        public void AddRequest(CarRequestModel request)
        {
            request.DateRequested = DateTime.Now;
            _context.CarRequests.Add(request);
            _context.SaveChanges();
        }
    }
}
