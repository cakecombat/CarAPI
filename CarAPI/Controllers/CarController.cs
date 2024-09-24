using CarAPI.DTOs;
using CarAPI.Models;
using CarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        private const string AdminUsername = "admin";
        private const string AdminPassword = "password123";

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

        public CarController(ICarService carService)
        {
            _carService = carService;
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
        public IActionResult AddCar([FromBody] CarCreateUpdateDto carDto)
        {
            var car = new Car
            {
                Make = carDto.Make,
                Model = carDto.Model,
                Price = carDto.Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

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
    }
}