using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CarAPI.Models
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

        public IFormFile? Picture { get; set; } // File upload for image
    }
}
