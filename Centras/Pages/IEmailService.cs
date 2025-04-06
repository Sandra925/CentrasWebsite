namespace Centras.Pages
{
    public interface IEmailService
    {
        Task SendPasswordResetEmail(string email, string resetLink);
        Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml = false);
    }
}