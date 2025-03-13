using Centras.db;
using Centras.Models;
using Centras.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Centras.Pages
{
    public class ConfirmReservationModel : PageModel
    {
        private readonly CentrasContext _context;
        private readonly SmtpEmailService _emailService;

        [BindProperty]
        public RoomReservation Reservation { get; set; } = new RoomReservation();

        public ConfirmReservationModel(CentrasContext context, SmtpEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
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

        public async Task<IActionResult> OnPost()
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
            await _context.SaveChangesAsync();

            // Send email to the owner
            var ownerEmail = "mika925d@gmail.com"; // Replace with the owner's email address
            var subject = "New Reservation Confirmation";
            var content = $"A new reservation has been made:\n\n" +
                          $"Guest Name: {Reservation.Name}\n" +
                          $"Check-In: {Reservation.CheckIn.ToShortDateString()}\n" +
                          $"Check-Out: {Reservation.CheckOut.ToShortDateString()}\n" +
                          $"Room: {Reservation.RoomId}\n" +
                          $"Adults: {Reservation.AdultsNum}\n" +
                          $"Kids: {Reservation.KidsNum}\n";

            await _emailService.SendEmailAsync(ownerEmail, subject, content);

            return RedirectToPage("ReservationSuccess");
        }
    }
}