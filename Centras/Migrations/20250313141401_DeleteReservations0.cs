using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class DeleteReservations0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Delete all data from RoomReservations before making changes
            migrationBuilder.Sql("DELETE FROM RoomReservations;");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_Rooms_RoomID",
                table: "RoomReservations");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "RoomReservations",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomReservations_RoomID",
                table: "RoomReservations",
                newName: "IX_RoomReservations_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_Rooms_RoomId",
                table: "RoomReservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_Rooms_RoomId",
                table: "RoomReservations");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "RoomReservations",
                newName: "RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_RoomReservations_RoomId",
                table: "RoomReservations",
                newName: "IX_RoomReservations_RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_Rooms_RoomID",
                table: "RoomReservations",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
