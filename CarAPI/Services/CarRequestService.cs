using CarAPI.DTOs;
using CarAPI.Models;
using CarAPI.Repositories;
using CarAPI.Services;

public class CarRequestService : ICarRequestService
{
    private readonly ICarRequestRepository _carRequestRepository;
    private readonly ICarRepository _carRepository;
    private readonly IEmailService _emailService;

    public CarRequestService(
        ICarRequestRepository carRequestRepository,
        ICarRepository carRepository,
        IEmailService emailService)
    {
        _carRequestRepository = carRequestRepository;
        _carRepository = carRepository;
        _emailService = emailService;
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

    public async Task AddCarRequest(CreateCarRequestDto requestDto)
    {
        var car = _carRepository.GetCarById(requestDto.CarId);
        if (car == null)
        {
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

        await _emailService.SendEmailAsync(carRequest.RequesterEmail, subject, message);
    }
}