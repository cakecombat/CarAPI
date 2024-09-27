using CarAPI.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

public class EmailService : IEmailService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiToken;
    private readonly string _fromEmail;
    private readonly string _fromName;

    public EmailService(IConfiguration configuration, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _apiToken = configuration["MailerSend:ApiToken"];
        _fromEmail = configuration["MailerSend:FromEmail"];
        _fromName = configuration["MailerSend:FromName"];
        _httpClient.BaseAddress = new Uri("https://api.mailersend.com/v1/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiToken}");
    }

    public async Task<bool> SendEmailAsync(string toEmail, string subject, string message)
    {
        try
        {
            var emailData = new
            {
                from = new { email = _fromEmail, name = _fromName },
                to = new[] { new { email = toEmail } },
                subject = subject,
                html = message,
                text = StripHtml(message)
            };

            var json = JsonConvert.SerializeObject(emailData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("email", content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(responseBody);
                var messageId = responseObject["message_id"]?.ToString();
                Console.WriteLine($"Email sent successfully. Message ID: {messageId}");
                return true;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to send email. Status code: {response.StatusCode}. Error: {errorResponse}");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occurred while sending email: {ex.Message}");
            return false;
        }
    }

    private string StripHtml(string html)
    {
        return System.Text.RegularExpressions.Regex.Replace(html, "<.*?>", String.Empty);
    }
}