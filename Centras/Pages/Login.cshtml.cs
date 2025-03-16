using Centras.db;
using Centras.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;

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
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.User.Identity is  null || !HttpContext.User.Identity.IsAuthenticated)
            {
                return Page();
            }
            // Get the name identifier claim (e.g., email or user ID)
            var nameIdentifierClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (nameIdentifierClaim != null)
            {
                var nameIdentifier = nameIdentifierClaim.Value;
                var user = await _centrasContext.Users.FindAsync(int.Parse(nameIdentifier));
                if(user is not null)
                {
                    User = user;
                    HttpContext.Session.SetString("Name", User.Name);

                    // Redirect to the home page or another page
                    return RedirectToPage("/Index");
                }
                
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
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
            // Create a list of claims for the user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
                new Claim(ClaimTypes.Role, existingUser.Role) ,
                new Claim(ClaimTypes.Name, existingUser.Name),
                
            };

            // Create a claims identity
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Create authentication properties (optional)
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };
            // Sign in the user
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            // Store the user's name in the session (optional)
            HttpContext.Session.SetString("Name", existingUser.Name);

            // Redirect to the home page or another page
            return RedirectToPage("/Index");
        }
        private bool VerifyPassword(string password, string storedHash)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.VerifyHashedPassword(User, storedHash, password) == PasswordVerificationResult.Success;

        }
    }
}
