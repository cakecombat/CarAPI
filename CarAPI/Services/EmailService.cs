using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace CarAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _sendGridApiKey;

        public EmailService(IConfiguration configuration)
        {
            _sendGridApiKey = configuration["SendGrid:ApiKey"];
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("your-email@example.com", "Car Request Service");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
