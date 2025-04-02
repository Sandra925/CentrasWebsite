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
            _env = env;
        }

        public IActionResult OnGet(int roomId, string CheckInDate, string CheckOutDate, int AdultsNum, int KidsNum)
        {
            try
            {
                var room = _context.Rooms.FirstOrDefault(r => r.ID == roomId);
                if (room == null)
                {
                    return RedirectToPage("Error");
                }

                Reservation.RoomId = room.ID;
                Reservation.Room = room;
                Reservation.CheckIn = DateTime.Parse(CheckInDate);
                Reservation.CheckOut = DateTime.Parse(CheckOutDate);
                Reservation.AdultsNum = AdultsNum;
                Reservation.KidsNum = KidsNum;
                Reservation.TotalPrice = room.CalculateTotalPrice(AdultsNum, KidsNum);
            }
            catch (FormatException)
            {
                ModelState.AddModelError("", "Invalid date format.");
                return RedirectToPage("Error");
            }
            return Page();
        }
        private string LoadEmailTemplate(string templatePath, Dictionary<string, string> placeholders)
        {
            var fullPath = Path.Combine(_env.WebRootPath, templatePath);
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
                          $"Sve�io vardas: {Reservation.Name}\n" +
                          $"Sve�io pavard�: {Reservation.LastName}\n" +
                          $"Atvykimas: {Reservation.CheckIn.ToShortDateString()}\n" +
                          $"I�vykimas: {Reservation.CheckOut.ToShortDateString()}\n" +
                          $"Kambarys: {Reservation.RoomId}\n" +
                          $"Suaugusi�: {Reservation.AdultsNum}\n" +
                          $"Vaik�: {Reservation.KidsNum}\n"+
                          $"Pa�to Kodas: {Reservation.Zip}\n";

            Reservation.TotalPrice = room.CalculateTotalPrice(Reservation.AdultsNum, Reservation.KidsNum);
            var guestEmailData = new Dictionary<string, string>
            {
                { "ReservationDate", DateTime.Now.ToString("yyyy/MM/dd") },
                { "GuestName", $"{Reservation.Name}" },
                { "CheckIn", Reservation.CheckIn.ToString("yyyy/MM/dd") },
                { "CheckOut", Reservation.CheckOut.ToString("yyyy/MM/dd") },
                { "Nights", (Reservation.CheckOut - Reservation.CheckIn).Days.ToString() },
                { "RoomName", $"{room.Name}" },
                { "RoomPrice", $"{Reservation.TotalPrice:0.00}" },
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