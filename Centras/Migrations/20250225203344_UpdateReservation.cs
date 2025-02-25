using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_Reservations_ReservationId",
                table: "RoomReservations");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "RoomReservations",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomReservations_ReservationId",
                table: "RoomReservations",
                newName: "IX_RoomReservations_ClientId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "RoomReservations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "RoomReservations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_Users_ClientId",
                table: "RoomReservations",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_Users_ClientId",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "RoomReservations");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "RoomReservations",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomReservations_ClientId",
                table: "RoomReservations",
                newName: "IX_RoomReservations_ReservationId");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckInDay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckOutDay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RoomNum = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_Reservations_ReservationId",
                table: "RoomReservations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
