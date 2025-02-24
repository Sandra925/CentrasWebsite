namespace Centras.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public User Client { get; set; }
        public int RoomNum { get; set; }
        public DateTime CheckInDay { get; set; }
        public DateTime CheckOutDay { get; set; }
        public List<RoomReservation> RoomReservations { get; set; }
     
    }
}
