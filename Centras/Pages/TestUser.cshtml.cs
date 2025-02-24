using Centras.db;
using Centras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Centras.Pages
{
    public class TestUserModel : PageModel
    {
        private readonly CentrasContext _centrasContext;
        public TestUserModel(CentrasContext centrasContext)
        {
            _centrasContext = centrasContext;
            
        }
        [BindProperty]
        public User? User { get; set; }
        public void OnPost()
        {
            var john = _centrasContext.Users.Where(u => u.Name == "John").First();


            _centrasContext.Add(User);
            _centrasContext.SaveChanges();
        }
        
    }
}
