using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class Addbreakfast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreakfastCount",
                table: "RoomReservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Dvivietis Kambarys");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6,
                column: "Name",
                value: "Liukso Kambarys");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 7,
                column: "Name",
                value: "Dvivietis Kambarys (2 lovos)");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 8,
                column: "Name",
                value: "Liukso Kambarys");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Vaizdas į ežerą", "Dvivietis Kambarys" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakfastCount",
                table: "RoomReservations");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Kambarys #5");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6,
                column: "Name",
                value: "Kambarys 6");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 7,
                column: "Name",
                value: "Dvivietis Kambarys");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 8,
                column: "Name",
                value: "Kambarys 8");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Kambarys 9" });
        }
    }
}
