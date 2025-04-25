using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Centras.Services
{
    public class SmtpEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string? _password;

        public SmtpEmailService(IConfiguration configuration,string? password)
        {
            _configuration = configuration;
            _password = password;
        }
        public SmtpEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml = false)
        {
            IConfigurationSection? smtpSettings = null;
            string? password = null;
            try
            {
                smtpSettings = _configuration.GetSection("SmtpSettings");
                password = _password ?? smtpSettings["Password"];
                if (string.IsNullOrEmpty(password))
                {
                    throw new Exception("SMTP password is missing.");
                }

                using (var client = new SmtpClient(smtpSettings["Server"], int.Parse(smtpSettings["Port"])))
                {
                    client.Credentials = new NetworkCredential(smtpSettings["Username"], password);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(smtpSettings["Username"]),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = isBodyHtml // Set to true for HTML emails
                    };
                    mailMessage.To.Add(toEmail);

                    await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Username: {smtpSettings?["Username"]} Password:{password}\n Email sending failed because {ex.Message}", ex);
            }
        }
    }
}