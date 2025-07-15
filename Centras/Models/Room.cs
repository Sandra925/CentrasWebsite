using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Centras.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string NameLT { get; set; }
        public string NameEng { get; set; }
        public string? DescriptionLT { get; set; }
        public string? DescriptionEng { get; set; }
        public int Capacity { get; set; }  
        public List<RoomImage> RoomImages { get; set; } = new();
        public List<RoomReservation> RoomReservations { get; set; } = new();

        public decimal BasePrice { get; set; }
        public decimal PriceForSecondPerson { get; set; }
        public decimal PriceForAdditionalBed { get; set; }

        [NotMapped]
        public decimal CalculatedPrice { get; set; }
        [NotMapped]
        public string Name => CultureInfo.CurrentCulture.Name.StartsWith("lt") ? NameLT : NameEng;
        [NotMapped]
        public string Description => CultureInfo.CurrentCulture.Name.StartsWith("lt") ? DescriptionLT : DescriptionEng;

        public decimal CalculateTotalPrice(int adults, int children)
        {
            //decimal childPrice = 0;
            decimal people = adults + children;
            decimal adultPrice = BasePrice + (people >=2 ? PriceForSecondPerson : 0);
            decimal additionalBed = ((people == 3) ? PriceForAdditionalBed : 0);
            return adultPrice + additionalBed;
        }

    }
    public class RoomImage
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string ImagePath { get; set; }
    }

}
