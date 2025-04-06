using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class AddedBedPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceForAdditionalBed",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5,
                column: "PriceForAdditionalBed",
                value: 15m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6,
                column: "PriceForAdditionalBed",
                value: 15m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 7,
                column: "PriceForAdditionalBed",
                value: 15m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 8,
                column: "PriceForAdditionalBed",
                value: 15m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 9,
                column: "PriceForAdditionalBed",
                value: 15m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceForAdditionalBed",
                table: "Rooms");
        }
    }
}
