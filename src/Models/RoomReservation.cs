namespace Centras.Models
{
    public class RoomReservation
    {
        public int Id { get; set; }
        public Room Room { get; set; }
        public Reservation Reservation { get; set; }
        public int AdultsNum { get; set; }
        public int KidsNum { get; set; }
    }
}
