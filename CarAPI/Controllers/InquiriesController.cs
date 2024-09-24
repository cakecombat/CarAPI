using CarAPI.DTOs;
using CarAPI.Models;
using CarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InquiriesController : ControllerBase
    {
        private readonly IInquiryService _inquiryService;

        public InquiriesController(IInquiryService inquiryService)
        {
            _inquiryService = inquiryService;
        }

        /// <summary>
        /// Retrieves all inquiries.
        /// </summary>
        /// <returns>A list of inquiries.</returns>
        [HttpGet]
        public IActionResult GetAllInquiries()
        {
            var inquiries = _inquiryService.GetAllInquiries();
            return Ok(inquiries); // Full inquiry details, including timestamps
        }

        /// <summary>
        /// Submits a new inquiry.
        /// </summary>
        /// <param name="inquiryDto">The inquiry data to submit.</param>
        /// <returns>The created inquiry.</returns>
        [HttpPost]
        public IActionResult SubmitInquiry([FromBody] InquiryCreateUpdateDto inquiryDto)
        {
            var inquiry = new Inquiry
            {
                CarId = inquiryDto.CarId,
                UserName = inquiryDto.UserName,
                UserEmail = inquiryDto.UserEmail,
                Message = inquiryDto.Message,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _inquiryService.SubmitInquiry(inquiry);
            return CreatedAtAction(nameof(GetAllInquiries), inquiry);
        }

        /// <summary>
        /// Updates the status of a specific inquiry.
        /// </summary>
        /// <param name="id">The ID of the inquiry to update.</param>
        /// <param name="status">The new status to set for the inquiry (ongoing, resolved, not feasible).</param>
        /// <returns>No content if successful.</returns>
        [HttpPut("{id}/status")]
        public IActionResult UpdateInquiryStatus(int id, [FromBody] string status)
        {
            var inquiry = _inquiryService.GetInquiryById(id);
            if (inquiry == null)
            {
                return NotFound();
            }

            if (status != "ongoing" && status != "resolved" && status != "not feasible")
            {
                return BadRequest("Invalid status.");
            }

            _inquiryService.UpdateInquiryStatus(id, status);
            return NoContent();
        }
    }
}
