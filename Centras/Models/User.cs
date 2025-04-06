using System.ComponentModel.DataAnnotations;

namespace Centras.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name {  get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; } = "Customer";
        //[StringLength(256)]
        //public string? ResetToken { get; set; }
        //public DateTime? ResetTokenExpiration { get; set; }

    }
}
