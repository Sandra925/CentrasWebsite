using Centras.Models;
using Centras.db;
using Centras.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Centras.Pages
{
    public class RoomsModel : PageModel
    {
        public List<Room> Rooms { get; set; }
        
        public Dictionary<string, List<string>> RoomImages { get; set; } = new();
        [BindProperty]
        public Models.User User { get; set; }
        public String? ErrorMessage { get; set; }
        private readonly CentrasContext _context;
        public RoomsModel(CentrasContext context)
        {
            _context = context;
            Rooms = new List<Room>();
        }
        [BindProperty]
        public int RoomId { get; set; }
        [BindProperty]
        public DateTime CheckInDate { get; set; }
        [BindProperty]
        public DateTime CheckOutDate { get; set; }
        [BindProperty]
        public int AdultsNum { get; set; }
        [BindProperty]
        public int KidsNum { get; set; }   
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                foreach(var key in ModelState.Keys)
                {
                    if (ModelState[key]?.Errors.Count > 0)
                    {
                        Console.WriteLine("The validation failed for:"+key);
                    }
                }
                return Page();
            }
            return Page();
        }
        public IActionResult OnPostBookRoom(int RoomId, DateTime CheckInDate, DateTime CheckOutDate, int AdultsNum, int KidsNum)
        {
            Console.WriteLine($"Booking Room ID: {RoomId}"); // Debugging Log

            var room = _context.Rooms.FirstOrDefault(r => r.ID == RoomId);

            if (room == null)
            {
                Console.WriteLine("Room not found in database!"); // Debugging Log
                ModelState.AddModelError(string.Empty, "Room not found.");
                return Page(); // Stay on the same page and show the error
            }

            // ✅ Process booking logic here (save to database, etc.)
            Console.WriteLine($"Redirecting to Confirmation Page for Room ID: {RoomId}");

            return RedirectToPage("ConfirmReservation", new { roomId = RoomId });
        }


        public void OnGet()
        {
            Rooms = _context.Rooms.Include(r => r.RoomImages).ToList();

            Console.WriteLine($"Rooms fetched: {Rooms.Count}"); // Debugging log
        }

    }

}