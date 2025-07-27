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
        public List<Room> AllRooms { get; set; }
        public List<Room> RoomsUnavailable { get; set; }

        [BindProperty]
        public List<RoomImage> AllRoomImages { get; set; }
        public String? ErrorMessage { get; set; }
        private readonly CentrasContext _context;
        public RoomsModel(CentrasContext context)
        {
            _context = context;
            AllRooms = new List<Room>();

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
        [BindProperty]
    public decimal TotalPrice { get; set; }

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
                return Partial("_RoomsPartial", AllRooms);
            }

            CheckInDate = Convert.ToDateTime(Request.Form["CheckInDate"]);
            CheckOutDate = Convert.ToDateTime(Request.Form["CheckOutDate"]);
            AdultsNum = int.Parse(Request.Form["AdultsNum"].ToString().Split(',')[0]);
            KidsNum = int.Parse(Request.Form["KidsNum"].ToString().Split(',')[0]);

            // Store search parameters
            TempData["CheckInDate"] = CheckInDate.ToString("yyyy-MM-dd");
            TempData["CheckOutDate"] = CheckOutDate.ToString("yyyy-MM-dd");
            TempData["AdultsNum"] = AdultsNum;
            TempData["KidsNum"] = KidsNum;
            TempData.Keep();

            
            // Get available rooms
            AllRooms = _context.Rooms
                .Include(r => r.RoomImages)
                .Include(r => r.RoomReservations)
                .ToList();
            /*AllRooms = _context.Rooms
                .Include(r => r.RoomImages)
                .Include(r => r.RoomReservations)
                .Where(r => !r.RoomReservations.Any(reservation =>
                      (CheckInDate < reservation.CheckOut) &&
                      (CheckOutDate > reservation.CheckIn)))
                .ToList();*/

            foreach (var room in AllRooms)
            {
                room.CalculatedPrice = room.CalculateTotalPrice(AdultsNum, KidsNum);
            }

            if (!AllRooms.Any())
            {
                ErrorMessage = "Deja, nėra laisvų kambarių pasirinktam laikotarpiui.";
            }


            return Partial("_RoomsPartial", AllRooms);
        }
        public IActionResult OnPostBookRoom(int RoomId, DateTime CheckInDate, DateTime CheckOutDate, int AdultsNum, int KidsNum)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var room = _context.Rooms.FirstOrDefault(r => r.ID == RoomId);
            if (room == null)
            {
                Console.WriteLine("Room not found in database!");
                ModelState.AddModelError(string.Empty, "Room not found.");
                return Page();
            }
            string RoomName = room.Name;
            decimal finalPrice = room.CalculateTotalPrice(AdultsNum, KidsNum);
            return RedirectToPage("ConfirmReservation", new
            {
                roomId = RoomId,
                roomName = RoomName,
                roomImages = room.RoomImages,
                checkInDate = CheckInDate.ToString("yyyy-MM-dd"),
                checkOutDate = CheckOutDate.ToString("yyyy-MM-dd"),
                adultsNum = AdultsNum,
                kidsNum = KidsNum,
                totalPrice = finalPrice
            });
        }
        public void OnGet()
        {

            AllRooms = _context.Rooms
        .Include(r => r.RoomImages)
        .Include(r => r.RoomReservations)
        .ToList();
            AllRoomImages = _context.RoomImages.ToList();
        }
        public static class LocalizationHelper
        {
            public static string GetLocalizationContent(string culture, string contentLT, string contentEng)
            {
                return culture.StartsWith("lt") ? contentLT : contentEng;
            }
        }
    }

}