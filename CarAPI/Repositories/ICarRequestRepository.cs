using CarAPI.Models;
using System.Collections.Generic;

namespace CarAPI.Repositories
{
    public interface ICarRequestRepository
    {
        IEnumerable<CarRequestModel> GetAllRequests();
        void AddRequest(CarRequestModel request);
    }
}
