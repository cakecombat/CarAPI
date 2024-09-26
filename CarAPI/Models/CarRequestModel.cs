using System;
using System.ComponentModel.DataAnnotations;

namespace CarAPI.Models
{
    public class CarRequestModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public DateTime DateRequested { get; set; }
        public CarModel Car { get; set; }
    }
}