using Centras.db;
using Centras.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Centras.Migrations;
using Microsoft.AspNetCore.Authorization;

namespace Centras.Pages
{
    [Authorize(Roles = "Administratorius")]

    public class ReservationListModel : PageModel
    {
        private readonly CentrasContext _context;

        public ReservationListModel(CentrasContext context)
        {
            _context = context;
        }

        public List<RoomReservation> Reservations { get; set; } = new();

        public void OnGet()
        {
            Reservations = _context.RoomReservations
                .Include(r => r.Room)
                .OrderByDescending(r => r.Id)
                .ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var reservation = _context.RoomReservations.Find(id);
            if (reservation != null)
            {
                _context.RoomReservations.Remove(reservation);
                _context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Reservation not found");
            }
            return RedirectToPage();
        }
    }
}
