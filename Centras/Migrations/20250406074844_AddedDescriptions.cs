using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "\r\nJaukus kambarys su dvigule lova, puikiai tinkantis poroms ar draugams.\r\n<ul>\r\n    <li><i class='fas fa-wifi'></i> Nemokamas Wi-Fi</li>\r\n    <li><i class='fas fa-utensils'></i> Pusryčiai įskaičiuoti</li>\r\n    <li><i class='fas fa-car'></i> Nemokama automobilių stovėjimo aikštelė</li>\r\n    <li><i class='fas fa-snowflake'></i> Oro kondicionierius</li>\r\n    <li><i class='fas fa-tv'></i> Plokščiaekranis televizorius</li>\r\n</ul>");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6,
                column: "Description",
                value: "\r\n        Erdvus kambarys su moderniu interjeru ir papildomais patogumais prabangiam poilsiui.\r\n        <ul>\r\n            <li><i class='fas fa-wifi'></i> Greitas Wi-Fi</li>\r\n            <li><i class='fas fa-utensils'></i> Įskaičiuoti pusryčiai</li>\r\n            <li><i class='fas fa-spa'></i> Nemokama prieiga prie SPA zonos</li>\r\n            <li><i class='fas fa-snowflake'></i> Klimato kontrolė</li>\r\n            <li><i class='fas fa-tv'></i> Smart televizorius</li>\r\n        </ul>");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 7,
                column: "Description",
                value: "\r\n        Patogus kambarys su dviem viengulėmis lovomis – idealiai tinka draugams ar verslo kelionėms.\r\n        <ul>\r\n            <li><i class='fas fa-wifi'></i> Nemokamas Wi-Fi</li>\r\n            <li><i class='fas fa-utensils'></i> Įskaičiuoti pusryčiai</li>\r\n            <li><i class='fas fa-car'></i> Nemokama stovėjimo aikštelė</li>\r\n            <li><i class='fas fa-snowflake'></i> Oro kondicionierius</li>\r\n            <li><i class='fas fa-lock'></i> Seifas vertingiems daiktams</li>\r\n        </ul>");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 8,
                column: "Description",
                value: "\r\n        Prabangus kambarys su vaizdu į gamtą ir aukščiausios klasės patogumais.\r\n        <ul>\r\n            <li><i class='fas fa-wifi'></i> Greitas Wi-Fi</li>\r\n            <li><i class='fas fa-utensils'></i> Įskaičiuoti pusryčiai</li>\r\n            <li><i class='fas fa-bath'></i> Prabangus vonios kambarys su vonia</li>\r\n            <li><i class='fas fa-snowflake'></i> Klimato kontrolė</li>\r\n            <li><i class='fas fa-tv'></i> Didelis Smart TV</li>\r\n        </ul>");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 9,
                column: "Description",
                value: "\r\n        Kambarys su nuostabiu vaizdu į ežerą – puikus pasirinkimas ramiam poilsiui.\r\n        <ul>\r\n            <li><i class='fas fa-eye'></i> Vaizdas į ežerą</li>\r\n            <li><i class='fas fa-wifi'></i> Nemokamas Wi-Fi</li>\r\n            <li><i class='fas fa-utensils'></i> Pusryčiai įskaičiuoti</li>\r\n            <li><i class='fas fa-car'></i> Nemokama automobilių stovėjimo aikštelė</li>\r\n            <li><i class='fas fa-snowflake'></i> Oro kondicionierius</li>\r\n        </ul>");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 7,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 8,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 9,
                column: "Description",
                value: "Vaizdas į ežerą");
        }
    }
}
