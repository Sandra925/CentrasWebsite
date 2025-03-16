using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class betatestofroomnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Kambarys #5", 65 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Kambarys 6", 80 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Dvivietis Kambarys", 65 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Kambarys 8", 80 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Kambarys 9", 65 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Room 5", 50 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Room 6", 0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Room 7", 0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Room 8", 0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Room 9", 0 });
        }
    }
}
