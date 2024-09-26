using System;
using System.ComponentModel.DataAnnotations;

namespace CarAPI.Models
{
    public class CarRequestModel
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public string RequesterName { get; set; }

        [Required]
        [EmailAddress]
        public string RequesterEmail { get; set; }

        public DateTime DateRequested { get; set; }

       
        public CarModel Car { get; set; }
    }
}
