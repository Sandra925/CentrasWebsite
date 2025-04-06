//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using Centras.db;
//using Microsoft.EntityFrameworkCore;
//using System.Net;
//namespace Centras.Pages
//{
//    public class ForgotPasswordModel : PageModel
//    {
//        private readonly CentrasContext _context;
//        private readonly IEmailService _emailService;

//        [BindProperty]
//        public string Email { get; set; }

//        public string Message { get; set; }

//        public ForgotPasswordModel(CentrasContext context, IEmailService emailService)
//        {
//            _context = context;
//            _emailService = emailService;
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            // Null check moved to model binding validation
//            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);

//            // Always show the same message regardless of user existence
//            Message = "If the email exists, we've sent a password reset link.";

//            if (user != null)
//            {
//                // Generate URL-safe token
//                var token = GenerateResetToken();

//                // Invalidate any existing tokens
//                user.ResetToken = token;
//                user.ResetTokenExpiration = DateTime.UtcNow.AddHours(1);

//                try
//                {
//                    await _context.SaveChangesAsync();

//                    // Create reset link WITHOUT manual encoding
//                    var resetLink = Url.Page(
//                        "/ResetPassword",
//                        pageHandler: null,
//                        values: new { email = Email, token },
//                        protocol: Request.Scheme
//                    );

//                    await _emailService.SendPasswordResetEmail(Email, resetLink);
//                }
//                catch (DbUpdateException ex)
//                {
//                    // Log database error
//                    _logger.LogError(ex, "Error saving reset token for {Email}", Email);
//                    ModelState.AddModelError("", "Error processing your request");
//                    return Page();
//                }
//                catch (Exception ex)
//                {
//                    // Log email sending error
//                    _logger.LogError(ex, "Error sending reset email to {Email}", Email);
//                    ModelState.AddModelError("", "Error sending reset email");
//                    return Page();
//                }
//            }

//            return Page();
//        }

//        private string GenerateResetToken()
//        {
//            return Convert.ToBase64String(Guid.NewGuid().ToByteArray())
//                .Replace('+', '-')  // Replace URL-unsafe characters
//                .Replace('/', '_')
//                .TrimEnd('=');      // Remove padding
//        }
//        public async Task<IActionResult> OnGetAsync(string email, string token)
//        {
//            // Decode URL-safe token
//            token = token.Replace('-', '+').Replace('_', '/');

//            var user = await _context.Users
//                .FirstOrDefaultAsync(u =>
//                    u.Email == email &&
//                    u.ResetToken == token &&
//                    u.ResetTokenExpiration > DateTime.UtcNow
//                );

//            if (user == null)
//            {
//                ModelState.AddModelError("", "Invalid or expired token.");
//                return RedirectToPage("/ForgotPassword");
//            }

//            return Page();
//        }
//    }
//}