using CarAPI.DTOs;
using CarAPI.Models;
using CarAPI.Repositories;
using CarAPI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CarRequestService : ICarRequestService
{
    private readonly ICarRequestRepository _carRequestRepository;
    private readonly ICarRepository _carRepository;
    private readonly IEmailService _emailService;
    private readonly ILogger<CarRequestService> _logger;

    public CarRequestService(
        ICarRequestRepository carRequestRepository,
        ICarRepository carRepository,
        IEmailService emailService,
        ILogger<CarRequestService> logger)
    {
        _carRequestRepository = carRequestRepository;
        _carRepository = carRepository;
        _emailService = emailService;
        _logger = logger;
    }

    public IEnumerable<CarRequestDetailDto> GetAllCarRequests()
    {
        var requests = _carRequestRepository.GetAllRequests();
        return requests.Select(r => new CarRequestDetailDto
        {
            Id = r.Id,
            RequesterName = r.RequesterName,
            RequesterEmail = r.RequesterEmail,
            DateRequested = r.DateRequested,
            Car = new CarDetailDto
            {
                Id = r.Car.Id,
                Make = r.Car.Make,
                Model = r.Car.Model,
                Price = r.Car.Price
            }
        }).ToList();
    }

    public async Task<bool> AddCarRequest(CreateCarRequestDto requestDto)
    {
        try
        {
            var car = _carRepository.GetCarById(requestDto.CarId);
            if (car == null)
            {
                _logger.LogWarning($"Attempt to create request for non-existent car with ID {requestDto.CarId}");
                throw new ArgumentException("Invalid CarId provided");
            }

            var carRequest = new CarRequestModel
            {
                CarId = requestDto.CarId,
                RequesterName = requestDto.RequesterName,
                RequesterEmail = requestDto.RequesterEmail,
                DateRequested = DateTime.UtcNow
            };

            _carRequestRepository.AddRequest(carRequest);

            var subject = "Car Request Confirmation";
            var message = $@"Hi {carRequest.RequesterName},
Your request for the following car has been received:
Make: {car.Make}
Model: {car.Model}
Price: ${car.Price:N2}
We will get back to you soon.
Thanks!";

            var emailSent = await _emailService.SendEmailAsync(carRequest.RequesterEmail, subject, message);
            if (emailSent)
            {
                _logger.LogInformation($"Email sent successfully to {carRequest.RequesterEmail}");
            }
            else
            {
                _logger.LogWarning($"Failed to send email to {carRequest.RequesterEmail}");
            }

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while processing car request");
            return false;
        }
    }
}