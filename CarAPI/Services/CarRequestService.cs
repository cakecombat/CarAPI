using CarAPI.DTO;
using CarAPI.DTOs;
using CarAPI.Models;
using CarAPI.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAPI.Services
{
    public class CarRequestService : ICarRequestService
    {
        private readonly ICarRequestRepository _carRequestRepository;
        private readonly IEmailService _emailService;

        public CarRequestService(ICarRequestRepository carRequestRepository, IEmailService emailService)
        {
            _carRequestRepository = carRequestRepository;
            _emailService = emailService;
        }

        public IEnumerable<CarRequestDto> GetAllCarRequests()
        {
            var requests = _carRequestRepository.GetAllRequests();

            return requests.Select(r => new CarRequestDto
            {
                RequesterName = r.RequesterName,
                RequesterEmail = r.RequesterEmail,
                DateRequested = r.DateRequested,
                CarMake = r.Car.Make,
                CarModel = r.Car.Model,
                CarPrice = r.Car.Price
            }).ToList();
        }

        public async Task AddCarRequest(CarRequestModel request)
        {
            // Add request with the associated car (already handled in the controller)
            _carRequestRepository.AddRequest(request);

            // Send an email after adding the car request
            var subject = "Car Request Confirmation";
            var message = $"Hi {request.RequesterName},\n\nYour request for {request.Car.Picture} \n{request.Car.Make} {request.Car.Model} has been received.\nWe will get back to you soon.\n\nThanks!";

            await _emailService.SendEmailAsync(request.RequesterEmail, subject, message);
        }

    }
}