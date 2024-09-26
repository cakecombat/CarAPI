using System;
using System.ComponentModel.DataAnnotations;

namespace CarAPI.DTO
{
    public class CarRequestDto
    {
        public int CarId { get; set; }
        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public DateTime DateRequested { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public decimal CarPrice { get; set; }
    }
}
