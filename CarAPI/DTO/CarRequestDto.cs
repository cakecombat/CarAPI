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
}
