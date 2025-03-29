using Centras.db;
using Centras.Models;
using Centras.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using Microsoft.AspNetCore.Hosting;


namespace Centras.Pages
{
    public class ConfirmReservationModel : PageModel
    {
        private readonly CentrasContext _context;
        private readonly SmtpEmailService _emailService;
        private readonly IWebHostEnvironment _env;

        [BindProperty]
        public RoomReservation Reservation { get; set; } = new RoomReservation();

        public ConfirmReservationModel(CentrasContext context, SmtpEmailService emailService, IWebHostEnvironment env)
        {
            _context = context;
            _emailService = emailService;
            _env = env; // Inject IWebHostEnvironment
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
            Reservation.Room.Price = room.Price;
            Reservation.CheckIn = DateTime.Parse(checkInDate);
            Reservation.CheckOut = DateTime.Parse(checkOutDate);
            Reservation.AdultsNum = adultsNum;
            Reservation.KidsNum = kidsNum;
        }
        private string LoadEmailTemplate(string templatePath, Dictionary<string, string> placeholders)
        {
            var fullPath = Path.Combine(_env.WebRootPath, templatePath); // Combine wwwroot path with template path
            var template = System.IO.File.ReadAllText(fullPath);

            foreach (var placeholder in placeholders)
            {
                template = template.Replace("{{" + placeholder.Key + "}}", placeholder.Value);
            }
            return template;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
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
                ModelState.AddModelError("", "The room is no longer available for the selected dates.");
                return Page();
            }

            // Save the reservation
            _context.RoomReservations.Add(Reservation);
            await _context.SaveChangesAsync();

            // Send email to the owner
            var ownerEmail = "mika925d@gmail.com"; // Replace with the owner's email address
            var customerEmail = Reservation.Email;
            var subject = "Rezervacijos patvirtinimas!";
            var content = $"Nauja rezervacija buvo atlikta:\n\n" +
                          $"Sveèio vardas: {Reservation.Name}\n" +
                          $"Sveèio pavardë: {Reservation.LastName}\n" +
                          $"Atvykimas: {Reservation.CheckIn.ToShortDateString()}\n" +
                          $"Iðvykimas: {Reservation.CheckOut.ToShortDateString()}\n" +
                          $"Kambarys: {Reservation.RoomId}\n" +
                          $"Suaugusiø: {Reservation.AdultsNum}\n" +
                          $"Vaikø: {Reservation.KidsNum}\n"+
                          $"Paðto Kodas: {Reservation.Zip}\n";

            var guestEmailData = new Dictionary<string, string>
            {
                { "ReservationDate", DateTime.Now.ToString("yyyy/MM/dd") },
                { "GuestName", $"{Reservation.Name}" },
                { "CheckIn", Reservation.CheckIn.ToString("yyyy/MM/dd") },
                { "CheckOut", Reservation.CheckOut.ToString("yyyy/MM/dd") },
                { "Nights", (Reservation.CheckOut - Reservation.CheckIn).Days.ToString() },
                { "RoomName", $"{room.Name}" },
                { "RoomPrice", $"{room.Price}" },
                { "NumberOfPeople", (Reservation.AdultsNum + Reservation.KidsNum).ToString() }
            };

            var guestEmailBody = LoadEmailTemplate("Templates/GuestEmailTemplate.html", guestEmailData);

            // Send email to the guest
            await _emailService.SendEmailAsync(Reservation.Email, "REZERVACIJOS PATVIRTINIMAS", guestEmailBody, true);

            // Send email to the owner
            await _emailService.SendEmailAsync(ownerEmail, subject, content);


            return RedirectToPage("ReservationSuccess");
        }
    }
}