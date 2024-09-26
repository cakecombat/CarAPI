using CarAPI.DTO;
using CarAPI.DTOs;
using CarAPI.Models;
using CarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        /// <summary>
        /// Submits a contact us form.
        /// </summary>
        [HttpPost]
        public IActionResult SubmitContactUs([FromBody] ContactUsDto contactUsDto)
        {
            var contactUs = new ContactUs
            {
                Name = contactUsDto.Name,
                Email = contactUsDto.Email,
                Message = contactUsDto.Message,
                SubmittedAt = DateTime.Now
            };

            _contactUsService.SubmitContactUs(contactUs);
            return Ok("Your message has been submitted.");
        }

        /// <summary>
        /// Retrieves all contact us messages.
        /// </summary>
        [HttpGet]
        public IActionResult GetAllMessages()
        {
            var messages = _contactUsService.GetAllMessages();
            return Ok(messages);
        }
    }
}
