using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Centras.Services
{
    public class SmtpEmailService
    {
        private readonly IConfiguration _configuration;

        public SmtpEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");
                var password = _configuration["SmtpSettings:Password"];
                if (string.IsNullOrEmpty(password))
                {
                    throw new Exception("SMTP password is missing.");
                }
                using (var client = new SmtpClient(smtpSettings["Server"], int.Parse(smtpSettings["Port"])))
                {
                    client.Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(smtpSettings["Username"]),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false
                    };
                    mailMessage.To.Add(toEmail);

                    await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Email sending failed because {ex.Message}", ex);
            }
           
        }
    }
}