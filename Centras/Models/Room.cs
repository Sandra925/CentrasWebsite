namespace Centras.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public List<RoomReservation> RoomReservations { get; set; }

    }
}
