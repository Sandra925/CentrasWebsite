using Centras.Models;
using Microsoft.EntityFrameworkCore;

namespace Centras.db
{
    public class CentrasContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public CentrasContext(DbContextOptions<CentrasContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=./db/centras.db");
            }
        }
    }
}
