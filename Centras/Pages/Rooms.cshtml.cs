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
                return Page();
            }

            // Retrieve values from the form
            CheckInDate = Convert.ToDateTime(Request.Form["CheckInDate"]);
            CheckOutDate = Convert.ToDateTime(Request.Form["CheckOutDate"]);
            AdultsNum = int.Parse(Request.Form["AdultsNum"]);
            KidsNum = int.Parse(Request.Form["KidsNum"]);

            // Store search parameters for persistence
            TempData["CheckInDate"] = CheckInDate.ToString("yyyy-MM-dd");
            TempData["CheckOutDate"] = CheckOutDate.ToString("yyyy-MM-dd");
            TempData["AdultsNum"] = AdultsNum;
            TempData["KidsNum"] = KidsNum;

            // Fetch all rooms with their reservations
            var allRooms = _context.Rooms.Include(r => r.RoomImages).Include(r => r.RoomReservations);

            // Filter available rooms
            Rooms = _context.Rooms
            .Include(r => r.RoomImages)
            .Include(r => r.RoomReservations)
            .Where(r => !r.RoomReservations.Any(reservation =>
                (CheckInDate < reservation.CheckOut) &&
                (CheckOutDate > reservation.CheckIn)))
            .ToList();

            if (!Rooms.Any())
            {
                ErrorMessage = "Deja, nėra laisvų kambarių pasirinktam laikotarpiui.";
            }

            return Page();
        }


        public IActionResult OnPostBookRoom(int RoomId, DateTime CheckInDate, DateTime CheckOutDate, int AdultsNum, int KidsNum)
        {
            Console.WriteLine($"Booking Room ID: {RoomId}"); // Debugging Log

            var room = _context.Rooms.FirstOrDefault(r => r.ID == RoomId);

            if (room == null)
            {
                Console.WriteLine("Room not found in database!");
                ModelState.AddModelError(string.Empty, "Room not found.");
                return Page(); 
            }

            Console.WriteLine($"Redirecting to Confirmation Page for Room ID: {RoomId}");

            return RedirectToPage("ConfirmReservation", new { roomId = RoomId });
        }


        public void OnGet()
        {
            Rooms = _context.Rooms
        .Include(r => r.RoomImages)
        .Include(r => r.RoomReservations) // Ensure reservations are loaded
        .ToList();
        }
        public IActionResult OnGetFindRooms(DateTime checkIn, DateTime checkOut, int adults, int kids)
        {
            var availableRooms = _context.Rooms
                .Include(r => r.RoomImages)
                .Include(r => r.RoomReservations)
                .Where(r => !r.RoomReservations.Any(reservation =>
                    (checkIn < reservation.CheckOut) && (checkOut > reservation.CheckIn)))
                .ToList();

            if (!availableRooms.Any())
            {
                return Content(""); // Return empty content if no rooms are found
            }
            Console.WriteLine($"Found {availableRooms.Count} available rooms."); // Debugging

            return Partial("_RoomsPartial", availableRooms);
        }
    }

}