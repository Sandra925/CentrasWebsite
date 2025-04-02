using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class EditTotalPriceRoomReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BreakfastCount",
                table: "RoomReservations");

            migrationBuilder.AddColumn<decimal>(
                name: "BasePrice",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceForSecondPerson",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "RoomReservations",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "BasePrice", "Description", "PriceForSecondPerson" },
                values: new object[] { 55m, "Nemokamas bevielis internetas (Wi-Fi);Pusryčiai;Nemokama automobilių stovėjimo aikštelė;Oro Kondicionierius", 10m });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "BasePrice", "PriceForSecondPerson" },
                values: new object[] { 70m, 10m });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "BasePrice", "PriceForSecondPerson" },
                values: new object[] { 55m, 10m });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "BasePrice", "PriceForSecondPerson" },
                values: new object[] { 70m, 10m });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "BasePrice", "PriceForSecondPerson" },
                values: new object[] { 55m, 10m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PriceForSecondPerson",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "RoomReservations");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "Description", "Price" },
                values: new object[] { "", 65 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6,
                column: "Price",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 7,
                column: "Price",
                value: 65);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 8,
                column: "Price",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 9,
                column: "Price",
                value: 65);
        }
    }
}
