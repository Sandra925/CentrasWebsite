namespace Centras.Models
{
    public class RoomReservation
    {
        public int Id { get; set; }
        public User Client { get; set; }
        public Room Room { get; set; }
        public int AdultsNum { get; set; }
        public int KidsNum { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

    }
}
