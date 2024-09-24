using System.ComponentModel.DataAnnotations;

namespace CarAPI.DTOs
{
    public class CarCreateUpdateDto
    {
        [Required]
        public string? Make { get; set; }

        [Required]
        public string? Model { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
