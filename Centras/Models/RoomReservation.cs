using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Centras.Models
{
    public class RoomReservation
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[+]?[\s]?[(]?[0-9]{1,4}[)]?[-\s.]?[0-9]{1,4}[-\s.]?[0-9]{2,6}[-\s.]?[0-9]{2,6}$",
        ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }
        public string Address { get; set; } 
        public string? City { get; set; } 
        public string? Zip { get; set; } 
        public string? Country { get; set; } 
        public string? Comment { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public int AdultsNum { get; set; }
        public int KidsNum { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
