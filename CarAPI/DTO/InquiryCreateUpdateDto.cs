using System.ComponentModel.DataAnnotations;

namespace CarAPI.DTOs
{
    public class InquiryCreateUpdateDto
    {
        [Required]
        public int CarId { get; set; }

        [Required]
        [EmailAddress]
        public string? UserEmail { get; set; }

        [Required]
        public string? UserName { get; set; }

        public string? Message { get; set; }
    }
}
