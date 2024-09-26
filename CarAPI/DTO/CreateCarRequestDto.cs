using System.ComponentModel.DataAnnotations;

namespace CarAPI.DTO
{
    public class CreateCarRequestDto
    {
        [Required]
        public int CarId { get; set; }  // Only the CarId is required for linking to a car

        [Required]
        public string RequesterName { get; set; }

        [Required]
        [EmailAddress]
        public string RequesterEmail { get; set; }

        public DateTime DateRequested { get; set; } = DateTime.Now;  // Automatically set when the request is created
    }
}
