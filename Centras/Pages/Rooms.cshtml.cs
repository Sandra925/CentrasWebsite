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

        [BindProperty]
        public List<RoomImage> AllRoomImages { get; set; }
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

        public IActionResult OnPostDelete()
        {
            var reservations = _context.RoomReservations.ToList();
            foreach (var res in reservations)
            {
                _context.RoomReservations.Remove(res);
            }
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please fill in all required fields.";
                return Partial("_RoomsPartial", Rooms);
            }

            // Retrieve values from the form
            CheckInDate = Convert.ToDateTime(Request.Form["CheckInDate"]);
            CheckOutDate = Convert.ToDateTime(Request.Form["CheckOutDate"]);
            AdultsNum = int.Parse(Request.Form["AdultNum"]);
            KidsNum = int.Parse(Request.Form["KidsNum"]);

            // Store search parameters for persistence
            TempData["CheckInDate"] = CheckInDate.ToString("yyyy-MM-dd");
            TempData["CheckOutDate"] = CheckOutDate.ToString("yyyy-MM-dd");
            TempData["AdultsNum"] = AdultsNum;
            TempData["KidsNum"] = KidsNum;
            TempData.Keep();

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

            return Partial("_RoomsPartial", Rooms); // Pass the Rooms list instead of `this`
        }


        public IActionResult OnPostBookRoom(int RoomId, DateTime CheckInDate, DateTime CheckOutDate, int AdultsNum, int KidsNum, string RoomName)
        {

            var room = _context.Rooms.FirstOrDefault(r => r.ID == RoomId);
            var roomName = _context.Rooms.FirstOrDefault(r => r.Name == RoomName);
            if (room == null)
            {
                Console.WriteLine("Room not found in database!");
                ModelState.AddModelError(string.Empty, "Room not found.");
                return Page();
            }

            return RedirectToPage("ConfirmReservation", new
            {
                roomId = RoomId,
                roomName = RoomName,
                roomImages = room.RoomImages,
                checkInDate = CheckInDate.ToString("yyyy-MM-dd"),
                checkOutDate = CheckOutDate.ToString("yyyy-MM-dd"),
                adultsNum = AdultsNum,
                kidsNum = KidsNum
            });
        }


        public void OnGet()
        {
            Rooms = _context.Rooms
        .Include(r => r.RoomImages)
        .Include(r => r.RoomReservations)
        .ToList();
            AllRoomImages = _context.RoomImages.ToList();
        }
    }

}