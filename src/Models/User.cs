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
        
    }
}
