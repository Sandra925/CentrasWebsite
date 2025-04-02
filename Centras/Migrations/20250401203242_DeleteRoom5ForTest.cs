using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRoom5ForTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "BasePrice", "Description", "Name", "PriceForSecondPerson" },
                values: new object[] { 5, 55m, "", "Dvivietis Kambarys", 10m });

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
                    { 6, "Images/Room 5/Room5_5.jfif", 5 }
                });
        }
    }
}
