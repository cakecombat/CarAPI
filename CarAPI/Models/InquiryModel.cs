using System.Text.Json.Serialization;

namespace CarAPI.Models
{
    public class InquiryModel
    {

        public int Id { get; set; }

        public int CarId { get; set; }

        public string? UserName { get; set; }

        public string? UserEmail { get; set; }

        public string? Message { get; set; }

        public string Status { get; set; } = "pending";
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
