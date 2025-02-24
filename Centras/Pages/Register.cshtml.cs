using Centras.db;
using Centras.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Centras.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly CentrasContext _centrasContext;
        private readonly PasswordHasher<User> _passwordHasher;
        public RegisterModel(CentrasContext centrasContext)
        {
            _centrasContext = centrasContext;
            _passwordHasher = new PasswordHasher<User>();
        }
        [BindProperty]
        public User? User { get; set; }

        [BindProperty]  
        public string ConfirmPassword { get; set; }
        public string? ErrorMessage { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid. Errors:");
                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            if (User == null)
            {
                ModelState.AddModelError(string.Empty, "User details are missing.");
                return Page();
            }
            if(_centrasContext.Users.Any(u => u.Email == User.Email)){
                ErrorMessage = "The user with this Email already exist";
                return Page();
            }
            User.Password = _passwordHasher.HashPassword(User, User.Password);
            Console.WriteLine("Saving User: " + User.Email);
            
            _centrasContext.Users.Add(User);
            _centrasContext.SaveChanges();

            return RedirectToPage("/Index");
        }


    }
}
