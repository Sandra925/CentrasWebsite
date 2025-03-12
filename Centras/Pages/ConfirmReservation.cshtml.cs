using Centras.db;
using Centras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Centras.Pages
{
    public class ConfirmReservationModel(CentrasContext context) : PageModel
    {
        private readonly CentrasContext _centrasContext = context;
        [BindProperty]
        public RoomReservation Reservation { get; set; } = new RoomReservation();
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                ModelState.AddModelError("", "User not logged in.");
                return Page();
            }

            var user = _centrasContext.Users.FirstOrDefault(u => u.Id == int.Parse(userId));
            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return Page();
            }

            var room = _centrasContext.Rooms.FirstOrDefault(r => r.ID == Reservation.Room.ID);
            if (room == null)
            {
                ModelState.AddModelError("", "Selected room does not exist.");
                return Page();
            }

            Reservation.Client = user;
            Reservation.Room = room;

            _centrasContext.RoomReservations.Add(Reservation);
            _centrasContext.SaveChanges();

            return RedirectToPage("ReservationSuccess");
        }

    }
}
