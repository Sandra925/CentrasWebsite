using Centras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Centras.Pages
{
    public class _RoomsPartialModel : PageModel
    {
        public List<Room> Rooms { get; set; } = new List<Room>();
        public void OnGet()
        {
        }
    }
}
