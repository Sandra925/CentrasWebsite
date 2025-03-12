using Centras.db;
using Centras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Centras.Pages
{
    public class ConfirmReservationModel : PageModel
    {
        private readonly CentrasContext _context;

        [BindProperty]
        public RoomReservation Reservation { get; set; } = new RoomReservation();

        public ConfirmReservationModel(CentrasContext context)
        {
            _context = context;
        }

        public void OnGet(int roomId, string checkInDate, string checkOutDate, int adultsNum, int kidsNum)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.ID == roomId);
            if (room == null)
            {
                RedirectToPage("Error");
                return;
            }
            Reservation.RoomId = room.ID;
            Reservation.Room = room;
            Reservation.Room.Name = room.Name;
            Reservation.CheckIn = DateTime.Parse(checkInDate);
            Reservation.CheckOut = DateTime.Parse(checkOutDate);
            Reservation.AdultsNum = adultsNum;
            Reservation.KidsNum = kidsNum;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check if the room is still available
            var isRoomAvailable = !_context.RoomReservations.Any(r =>
                r.Room.ID == Reservation.RoomId &&
                ((Reservation.CheckIn < r.CheckOut) && (Reservation.CheckOut > r.CheckIn)));

            if (!isRoomAvailable)
            {
                ModelState.AddModelError("", "The room is no longer available for the selected dates.");
                return Page();
            }

            // Save the reservation
            _context.RoomReservations.Add(Reservation);
            _context.SaveChanges();

            return RedirectToPage("ReservationSuccess");
        }
    }
}