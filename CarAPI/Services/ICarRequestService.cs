using CarAPI.DTOs;
using CarAPI.Models;
using System.Collections.Generic;

namespace CarAPI.Services
{
    public interface ICarRequestService
    {
        IEnumerable<CarRequestDto> GetAllCarRequests();
        Task AddCarRequest(CarRequestModel carRequest);
    }
}