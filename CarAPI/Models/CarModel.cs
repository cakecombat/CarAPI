using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarAPI.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        public string? Make { get; set; }

        [Required]
        public string? Model { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public byte[]? Picture { get; set; } 

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
