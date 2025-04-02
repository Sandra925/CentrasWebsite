using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Centras.Models;
using Microsoft.EntityFrameworkCore;
using Centras.db;

namespace Centras.Pages
{
    public class EditReservationModel : PageModel
    {
        private readonly CentrasContext _context;

        public EditReservationModel(CentrasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoomReservation RoomReservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoomReservation = await _context.RoomReservations
                .Include(r => r.Room)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (RoomReservation == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RoomReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(RoomReservation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ReservationList");
        }

        private bool ReservationExists(int id)
        {
            return _context.RoomReservations.Any(e => e.Id == id);
        }
    }
}