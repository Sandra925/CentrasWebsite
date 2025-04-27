using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class localizeDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "desc5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "\r\n                    Jaukus kambarys su dvigule lova ir vaizdu į centrinę miesto aikštę su skambančiais varpais ir trykštančiu fontanu.\r\n                    <ul>\r\n                        <li><i class='fas fa-wifi'></i> Nemokamas Wi-Fi</li>\r\n                        <li><i class='fas fa-utensils'></i> Galimybė užsisakyti pusryčius vietoje</li>\r\n                        <li><i class='fas fa-snowflake'></i> Oro kondicionierius</li>\r\n                        <li><i class='fas fa-car'></i> Nemokama stovėjimo vieta</li>\r\n                        <li><i class='fas fa-mug-hot'></i> Arbata ir kava kambaryje</li>\r\n                        <li><i class='fas fa-shower'></i> Erdvus vonios kambarys su dušu</li>\r\n                        <li><i class='fas fa-tv'></i> Televizorius</li>\r\n                    </ul>\r\n                    <p><i class='fas fa-lock'></i> Seifas vertingiems daiktams prieinamas registratūroje</p>");
        }
    }
}
