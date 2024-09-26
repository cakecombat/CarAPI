namespace CarAPI.DTOs
{
    public class CarRequestDto
    {
        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public DateTime DateRequested { get; set; }

        // Car details
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public decimal CarPrice { get; set; }
    }
    // DTOs/CreateCarRequestDto.cs
    public class CreateCarRequestDto
    {
        public int CarId { get; set; }
        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
    }

    // DTOs/CarRequestDetailDto.cs
    public class CarRequestDetailDto
    {
        public int Id { get; set; }
        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public DateTime DateRequested { get; set; }
        public CarDetailDto Car { get; set; }
    }

    // DTOs/CarDetailDto.cs
    public class CarDetailDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
    }
}