using CarAPI.DTOs;
using CarAPI.Models;
using System.Collections.Generic;

namespace CarAPI.Services
{
    public interface ICarRequestService
    {
        IEnumerable<CarRequestDetailDto> GetAllCarRequests();
        Task AddCarRequest(CreateCarRequestDto carRequest);
    }
}