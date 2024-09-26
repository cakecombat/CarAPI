using CarAPI.DTOs;
using CarAPI.Models;
using CarAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ICarRequestService _carRequestService;
        private const string AdminUsername = "admin";
        private const string AdminPassword = "password123";


        public CarController(ICarService carService, ICarRequestService carRequestService)
        {
            _carService = carService;
            _carRequestService = carRequestService;
        }
        /// <summary>
        /// Admin login with username and password.
        /// </summary>
        [HttpPost("login")]
        public IActionResult AdminLogin([FromBody] AdminLoginModel loginModel)
        {
            if (loginModel.Username == AdminUsername && loginModel.Password == AdminPassword)
            {
                // Dummy success message
                return Ok(new { Message = "Login successful", IsAuthenticated = true });
            }

            return Unauthorized(new { Message = "Invalid credentials" });
        }

        /// <summary>
        /// Retrieves all cars.
        /// </summary>
        /// <returns>A list of cars.</returns>
        [HttpGet]
        public IActionResult GetAllCars()
        {
            var cars = _carService.GetAllCars();
            return Ok(cars); // Return full car details including timestamps and picture
        }

        /// <summary>
        /// Retrieves a specific car by its ID.
        /// </summary>
        /// <param name="id">The ID of the car to retrieve.</param>
        /// <returns>The requested car.</returns>
        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null) return NotFound();
            return Ok(car); // Return full car details
        }

        /// <summary>
        /// Adds a new car.
        /// </summary>
        /// <param name="carDto">The car data to add.</param>
        /// <returns>The created car.</returns>
        [HttpPost]
        [Consumes("multipart/form-data")] // Specify that this endpoint accepts multipart/form-data
        public IActionResult AddCar([FromForm] CarCreateUpdateDto carDto)
        {
            var car = new CarModel
            {
                Make = carDto.Make,
                Model = carDto.Model,
                Price = carDto.Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            // Handle image file upload
            if (carDto.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    carDto.Picture.CopyTo(memoryStream);
                    car.Picture = memoryStream.ToArray(); // Save the file as byte[]
                }
            }

            _carService.AddCar(car);
            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        /// <summary>
        /// Deletes a car by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var existingCar = _carService.GetCarById(id);
            if (existingCar == null)
            {
                return NotFound();
            }

            _carService.DeleteCar(id);
            return NoContent();
        }

        /// <summary>
        /// Retrieves all car requests along with the requester details and date.
        /// </summary>
        [HttpGet("car-requests")]
        public IActionResult GetAllCarRequests()
        {
            var requests = _carRequestService.GetAllCarRequests();
            return Ok(requests);
        }

        /// <summary>
        /// Adds a new car request and sends an email to the requester.
        /// </summary>
        [HttpPost("car-requests")]
        public async Task<IActionResult> AddCarRequest([FromBody] CarRequestModel request)
        {
            await _carRequestService.AddCarRequest(request);
            return Ok(new { message = "Car request added and email sent." });
        }
    }
}