using System.ComponentModel.DataAnnotations.Schema;

namespace Centras.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }  
        public List<RoomImage> RoomImages { get; set; } = new();
        public List<RoomReservation> RoomReservations { get; set; } = new();

        public decimal BasePrice { get; set; }
        public decimal PriceForSecondPerson { get; set; }
        public decimal PriceForAdditionalBed { get; set; }

        [NotMapped]
        public decimal CalculatedPrice { get; set; } 

        public decimal CalculateTotalPrice(int adults, int children)
        {
            decimal childPrice = 0;
            decimal adultPrice = BasePrice + ((adults == 2) ? PriceForSecondPerson : 0);
            decimal additionalBed = ((adults == 3) ? PriceForAdditionalBed : 0);
            //decimal childPrice = children * (BasePrice * 0.3m); // Assuming 30% of base price per child
            return adultPrice + childPrice + additionalBed;
        }

    }
    public class RoomImage
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string ImagePath { get; set; }
    }

}
