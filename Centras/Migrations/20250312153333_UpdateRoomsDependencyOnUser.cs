using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomsDependencyOnUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_Users_ClientId",
                table: "RoomReservations");

            migrationBuilder.DropIndex(
                name: "IX_RoomReservations_ClientId",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "RoomReservations");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "RoomReservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "RoomReservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "RoomReservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "RoomReservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "RoomReservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RoomReservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "RoomReservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "RoomReservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "City",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "RoomReservations");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "RoomReservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_ClientId",
                table: "RoomReservations",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_Users_ClientId",
                table: "RoomReservations",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
