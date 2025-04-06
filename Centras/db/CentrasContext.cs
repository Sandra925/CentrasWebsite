using Centras.Models;
using Microsoft.EntityFrameworkCore;

namespace Centras.db
{
    public class CentrasContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public CentrasContext(DbContextOptions<CentrasContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=./db/centras.db");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
        .Property(r => r.Capacity)
        .HasDefaultValue(3);

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 5,
                    Name = "Dvivietis Kambarys",
                    Description = @"
Jaukus kambarys su dvigule lova, puikiai tinkantis poroms ar draugams.
<ul>
    <li><i class='fas fa-wifi'></i> Nemokamas Wi-Fi</li>
    <li><i class='fas fa-utensils'></i> Pusryčiai įskaičiuoti</li>
    <li><i class='fas fa-car'></i> Nemokama automobilių stovėjimo aikštelė</li>
    <li><i class='fas fa-snowflake'></i> Oro kondicionierius</li>
    <li><i class='fas fa-tv'></i> Plokščiaekranis televizorius</li>
</ul>",
                    BasePrice = 55,
                    PriceForSecondPerson = 10,  // 55 + 10 = 65 for two
                    PriceForAdditionalBed = 15
                },
                new Room
                {
                    ID = 6,
                    Name = "Liukso Kambarys",
                    Description = @"
        Erdvus kambarys su moderniu interjeru ir papildomais patogumais prabangiam poilsiui.
        <ul>
            <li><i class='fas fa-wifi'></i> Greitas Wi-Fi</li>
            <li><i class='fas fa-utensils'></i> Įskaičiuoti pusryčiai</li>
            <li><i class='fas fa-spa'></i> Nemokama prieiga prie SPA zonos</li>
            <li><i class='fas fa-snowflake'></i> Klimato kontrolė</li>
            <li><i class='fas fa-tv'></i> Smart televizorius</li>
        </ul>",
                    BasePrice = 70,            // Price for one
                    PriceForSecondPerson = 10,
                    PriceForAdditionalBed = 15
                },
                new Room
                {
                    ID = 7,
                    Name = "Dvivietis Kambarys (2 lovos)",
                    Description = @"
        Patogus kambarys su dviem viengulėmis lovomis – idealiai tinka draugams ar verslo kelionėms.
        <ul>
            <li><i class='fas fa-wifi'></i> Nemokamas Wi-Fi</li>
            <li><i class='fas fa-utensils'></i> Įskaičiuoti pusryčiai</li>
            <li><i class='fas fa-car'></i> Nemokama stovėjimo aikštelė</li>
            <li><i class='fas fa-snowflake'></i> Oro kondicionierius</li>
            <li><i class='fas fa-lock'></i> Seifas vertingiems daiktams</li>
        </ul>",
                    BasePrice = 55,
                    PriceForSecondPerson = 10,
                    PriceForAdditionalBed = 15
                },
                new Room
                {
                    ID = 8,
                    Name = "Liukso Kambarys",
                    Description = @"
        Prabangus kambarys su vaizdu į gamtą ir aukščiausios klasės patogumais.
        <ul>
            <li><i class='fas fa-wifi'></i> Greitas Wi-Fi</li>
            <li><i class='fas fa-utensils'></i> Įskaičiuoti pusryčiai</li>
            <li><i class='fas fa-bath'></i> Prabangus vonios kambarys su vonia</li>
            <li><i class='fas fa-snowflake'></i> Klimato kontrolė</li>
            <li><i class='fas fa-tv'></i> Didelis Smart TV</li>
        </ul>",
                    BasePrice = 70,
                    PriceForSecondPerson = 10,
                    PriceForAdditionalBed = 15
                },
                new Room
                {
                    ID = 9,
                    Name = "Dvivietis Kambarys",
                    Description = @"
        Kambarys su nuostabiu vaizdu į ežerą – puikus pasirinkimas ramiam poilsiui.
        <ul>
            <li><i class='fas fa-eye'></i> Vaizdas į ežerą</li>
            <li><i class='fas fa-wifi'></i> Nemokamas Wi-Fi</li>
            <li><i class='fas fa-utensils'></i> Pusryčiai įskaičiuoti</li>
            <li><i class='fas fa-car'></i> Nemokama automobilių stovėjimo aikštelė</li>
            <li><i class='fas fa-snowflake'></i> Oro kondicionierius</li>
        </ul>",
                    BasePrice = 55,
                    PriceForSecondPerson = 10,
                    PriceForAdditionalBed = 15
                }
            );

            modelBuilder.Entity<RoomImage>().HasData(
                // Room 5 Images
                new RoomImage { Id = 1, RoomId = 5, ImagePath = "Images/Room 5/Room5_1.jfif" },
                new RoomImage { Id = 2, RoomId = 5, ImagePath = "Images/Room 5/Room5.jfif" },
                new RoomImage { Id = 3, RoomId = 5, ImagePath = "Images/Room 5/Room5_2.jfif" },
                new RoomImage { Id = 4, RoomId = 5, ImagePath = "Images/Room 5/Room5_3.jfif" },
                new RoomImage { Id = 5, RoomId = 5, ImagePath = "Images/Room 5/Room5_4.jfif" },
                new RoomImage { Id = 6, RoomId = 5, ImagePath = "Images/Room 5/Room5_5.jfif" },

                // Room 6 Images
                new RoomImage { Id = 7, RoomId = 6, ImagePath = "Images/Room 6/Room6_1.jfif" },
                new RoomImage { Id = 8, RoomId = 6, ImagePath = "Images/Room 6/Room6_2.jfif" },
                new RoomImage { Id = 9, RoomId = 6, ImagePath = "Images/Room 6/Room6_3.jfif" },
                new RoomImage { Id = 10, RoomId = 6, ImagePath = "Images/Room 6/Room6_4.jfif" },
                new RoomImage { Id = 11, RoomId = 6, ImagePath = "Images/Room 6/Room6_5.jfif" },
                new RoomImage { Id = 12, RoomId = 6, ImagePath = "Images/Room 6/Room6_6.jfif" },
                new RoomImage { Id = 13, RoomId = 6, ImagePath = "Images/Room 6/Room6_7.jfif" },
                new RoomImage { Id = 14, RoomId = 6, ImagePath = "Images/Room 6/Room6_8.jfif" },
                new RoomImage { Id = 15, RoomId = 6, ImagePath = "Images/Room 6/Room6_9.jfif" },

                // Room 7 Images
                new RoomImage { Id = 16, RoomId = 7, ImagePath = "Images/Room 7/Room7_1.jfif" },
                new RoomImage { Id = 17, RoomId = 7, ImagePath = "Images/Room 7/Room7.jfif" },
                new RoomImage { Id = 18, RoomId = 7, ImagePath = "Images/Room 7/Room7_2.jfif" },
                new RoomImage { Id = 19, RoomId = 7, ImagePath = "Images/Room 7/Room7_3.jfif" },
                new RoomImage { Id = 20, RoomId = 7, ImagePath = "Images/Room 7/Room7_5.jfif" },
                new RoomImage { Id = 21, RoomId = 7, ImagePath = "Images/Room 7/Room7_6.jfif" },

                // Room 8 Images
                new RoomImage { Id = 22, RoomId = 8, ImagePath = "Images/Room 8/Room8_1.jfif" },
                new RoomImage { Id = 23, RoomId = 8, ImagePath = "Images/Room 8/Room8.jpg" },
                new RoomImage { Id = 24, RoomId = 8, ImagePath = "Images/Room 8/Room8_2.jfif" },
                new RoomImage { Id = 25, RoomId = 8, ImagePath = "Images/Room 8/Room8_3.jfif" },
                new RoomImage { Id = 26, RoomId = 8, ImagePath = "Images/Room 8/Room8_4.jfif" },

                // Room 9 Images
                new RoomImage { Id = 27, RoomId = 9, ImagePath = "Images/Room 9/Room9_1.jfif" },
                new RoomImage { Id = 28, RoomId = 9, ImagePath = "Images/Room 9/Room9_2.jfif" },
                new RoomImage { Id = 29, RoomId = 9, ImagePath = "Images/Room 9/Room9_3.jfif" },
                new RoomImage { Id = 30, RoomId = 9, ImagePath = "Images/Room 9/Room9_4.jfif" },
                new RoomImage { Id = 31, RoomId = 9, ImagePath = "Images/Room 9/Room9_5.jfif" },
                new RoomImage { Id = 32, RoomId = 9, ImagePath = "Images/Room 9/Room9_6.jfif" },
                new RoomImage { Id = 33, RoomId = 9, ImagePath = "Images/Room 9/Room9_7.jfif" },
                new RoomImage { Id = 34, RoomId = 9, ImagePath = "Images/Room 9/Room9_8.jfif" },
                new RoomImage { Id = 35, RoomId = 9, ImagePath = "Images/Room 9/Room9_9.jfif" },
                new RoomImage { Id = 36, RoomId = 9, ImagePath = "Images/Room 9/Room9_10.jfif" }
            );
        }

    }
}
