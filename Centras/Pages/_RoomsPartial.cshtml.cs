using Centras.db;
using Centras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Centras.Pages
{
    public class _RoomsPartialModel : PageModel
    {
        private readonly CentrasContext _context;
        public List<Room> Rooms { get; set; } = new List<Room>();
        public void OnGet()
        {
            var rooms = _context.Rooms
            .Include(r => r.RoomImages)
            .ToList();
        }
    }
}
