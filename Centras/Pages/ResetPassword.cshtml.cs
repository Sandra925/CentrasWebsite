//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc;
//using Centras.db;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
//using Centras.Models;

//namespace Centras.Pages
//{
//    public class ResetPasswordModel : PageModel
//    {
//        private readonly CentrasContext _context;
//        private readonly PasswordHasher<User> _passwordHasher;

//        [BindProperty]
//        public string Email { get; set; }

//        [BindProperty]
//        public string Token { get; set; }

//        [BindProperty]
//        public string NewPassword { get; set; }

//        public string Message { get; set; }

//        public ResetPasswordModel(CentrasContext context)
//        {
//            _context = context;
//        }

//        public async Task<IActionResult> OnGetAsync(string email, string token)
//        {
//            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
//            {
//                return RedirectToPage("/Error");
//            }

//            var user = await _context.Users.FirstOrDefaultAsync(u =>
//                u.Email == email &&
//                u.ResetToken == token &&
//                u.ResetTokenExpiration > DateTime.UtcNow
//            );

//            if (user == null)
//            {
//                TempData["Error"] = "Invalid or expired reset token";
//                return RedirectToPage("/ForgotPassword");
//            }

//            return Page();
//        }
//    }
//}
