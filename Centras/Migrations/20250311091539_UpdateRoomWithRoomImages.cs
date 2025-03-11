using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomWithRoomImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "Capacity", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 5, 0, "Modern and spacious room with a cozy atmosphere.", "Room 5", 0 },
                    { 6, 0, "Elegant suite with a balcony and sea view.", "Room 6", 0 },
                    { 7, 0, "Luxury suite with a king-sized bed and mini-bar.", "Room 7", 0 },
                    { 8, 0, "Comfortable double room perfect for couples.", "Room 8", 0 },
                    { 9, 0, "Budget-friendly room with all essential amenities.", "Room 9", 0 }
                });

            migrationBuilder.InsertData(
                table: "RoomImages",
                columns: new[] { "Id", "ImagePath", "RoomId" },
                values: new object[,]
                {
                    { 1, "Images/Room 5/Room5_1.jfif", 5 },
                    { 2, "Images/Room 5/Room5.jfif", 5 },
                    { 3, "Images/Room 5/Room5_2.jfif", 5 },
                    { 4, "Images/Room 5/Room5_3.jfif", 5 },
                    { 5, "Images/Room 5/Room5_4.jfif", 5 },
                    { 6, "Images/Room 5/Room5_5.jfif", 5 },
                    { 7, "Images/Room 6/Room6_1.jfif", 6 },
                    { 8, "Images/Room 6/Room6_2.jfif", 6 },
                    { 9, "Images/Room 6/Room6_3.jfif", 6 },
                    { 10, "Images/Room 6/Room6_4.jfif", 6 },
                    { 11, "Images/Room 6/Room6_5.jfif", 6 },
                    { 12, "Images/Room 6/Room6_6.jfif", 6 },
                    { 13, "Images/Room 6/Room6_7.jfif", 6 },
                    { 14, "Images/Room 6/Room6_8.jfif", 6 },
                    { 15, "Images/Room 6/Room6_9.jfif", 6 },
                    { 16, "Images/Room 7/Room7_1.jfif", 7 },
                    { 17, "Images/Room 7/Room7.jfif", 7 },
                    { 18, "Images/Room 7/Room7_2.jfif", 7 },
                    { 19, "Images/Room 7/Room7_3.jfif", 7 },
                    { 20, "Images/Room 7/Room7_5.jfif", 7 },
                    { 21, "Images/Room 7/Room7_6.jfif", 7 },
                    { 22, "Images/Room 8/Room8_1.jfif", 8 },
                    { 23, "Images/Room 8/Room8.jpg", 8 },
                    { 24, "Images/Room 8/Room8_2.jfif", 8 },
                    { 25, "Images/Room 8/Room8_3.jfif", 8 },
                    { 26, "Images/Room 8/Room8_4.jfif", 8 },
                    { 27, "Images/Room 9/Room9_1.jfif", 9 },
                    { 28, "Images/Room 9/Room9_2.jfif", 9 },
                    { 29, "Images/Room 9/Room9_3.jfif", 9 },
                    { 30, "Images/Room 9/Room9_4.jfif", 9 },
                    { 31, "Images/Room 9/Room9_5.jfif", 9 },
                    { 32, "Images/Room 9/Room9_6.jfif", 9 },
                    { 33, "Images/Room 9/Room9_7.jfif", 9 },
                    { 34, "Images/Room 9/Room9_8.jfif", 9 },
                    { 35, "Images/Room 9/Room9_9.jfif", 9 },
                    { 36, "Images/Room 9/Room9_10.jfif", 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 9);
        }
    }
}
