using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Centras.db;
using Centras.Models;
using Microsoft.EntityFrameworkCore;
using Centras.Migrations;

namespace Centras.Pages
{
    [Authorize(Roles = "Administratorius")]
    public class AdminReservationModel : PageModel
    {
        private readonly CentrasContext _context;
        public AdminReservationModel(CentrasContext context)
        {
            _context = context;
        }
        public List<RoomReservation> Reservations { get; set; } = new();
        [BindProperty]
        public RoomReservation Reservation { get; set; } = new RoomReservation();

        public void OnGet()
        {
            Reservations = _context.RoomReservations
                .Include(r => r.Room)
                .ToList();
        }
        public async Task<IActionResult> OnPost()
        {
            Reservation.Email = string.IsNullOrWhiteSpace(Reservation.Email) ? "hotelcentras@gmail.com" : Reservation.Email;
            Reservation.Phone = string.IsNullOrWhiteSpace(Reservation.Phone) ? "+37065598889" : Reservation.Phone;
            Reservation.Address = string.IsNullOrWhiteSpace(Reservation.Address) ? " " : Reservation.Address;
            Reservation.City = string.IsNullOrWhiteSpace(Reservation.City) ? " " : Reservation.City;
            Reservation.Zip = string.IsNullOrWhiteSpace(Reservation.Zip) ? " " : Reservation.Zip;
            Reservation.Country = string.IsNullOrWhiteSpace(Reservation.Country) ? " " : Reservation.Country;
            Reservation.Comment = string.IsNullOrWhiteSpace(Reservation.Comment) ? " " : Reservation.Comment;
            Reservation.AdultsNum = Reservation.AdultsNum == 0 ? 1 : Reservation.AdultsNum;
            ModelState.Remove("Reservation.Email");
            ModelState.Remove("Reservation.Phone");
            ModelState.Remove("Reservation.Address");
            ModelState.Remove("Reservation.City");
            ModelState.Remove("Reservation.Zip");
            ModelState.Remove("Reservation.Country");
            ModelState.Remove("Reservation.Comment");
            ModelState.Remove("Reservation.AdultsNum");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var room = _context.Rooms.FirstOrDefault(r => r.ID == Reservation.RoomId);
            if (room == null)
            {
                ModelState.AddModelError("", "The room is no longer available.");
                return Page();
            }

            Reservation.Room = room;
            // Check if the room is still available
            var isRoomAvailable = !_context.RoomReservations.Any(r =>
                r.Room.ID == Reservation.RoomId &&
                ((Reservation.CheckIn < r.CheckOut) && (Reservation.CheckOut > r.CheckIn)));

            if (!isRoomAvailable)
            {
                ModelState.AddModelError("", "Kambarys sia diena yra uzimtas");
                return Page();
            }
            Reservation.Room = room;
            _context.RoomReservations.Add(Reservation);
            await _context.SaveChangesAsync();
            return RedirectToPage("ReservationSuccess");
        }
    }

}

