using Centras.db;
using Centras.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Centras.Pages
{
    public class LoginModel : PageModel
    {
        private readonly CentrasContext _centrasContext;
        public LoginModel(CentrasContext centrasContext)
        {
            _centrasContext = centrasContext;
        }
        [BindProperty]
        public User? User { get; set; }
        public string? ErrorMessage { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (User == null || string.IsNullOrWhiteSpace(User.Email) || string.IsNullOrWhiteSpace(User.Password))
            {
                ErrorMessage = "Email and password are required";
                return Page();
            }
            var existingUser = _centrasContext.Users.FirstOrDefault(u => u.Email == User.Email);
            if (existingUser == null || !VerifyPassword(User.Password, existingUser.Password))
            {
                ErrorMessage = "Invalid email or password";
                return Page();
            }
            HttpContext.Session.SetString("Name", existingUser.Name);
            return RedirectToPage("/Index");
        }
        private bool VerifyPassword(string password, string storedHash)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.VerifyHashedPassword(User, storedHash, password) == PasswordVerificationResult.Success;

        }
    }
}
