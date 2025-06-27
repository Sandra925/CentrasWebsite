using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centras.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDBWitRoomDescriptionsLTEng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rooms",
                newName: "NameLT");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Rooms",
                newName: "DescriptionLT");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEng",
                table: "Rooms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEng",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "DescriptionEng", "NameEng" },
                values: new object[] { "\r\n                     Cozy room with a double bed and a view of the central city square with ringing bells and a splashing fountain.\r\n                     <ul>\r\n                         <li><i class='fas fa-wifi'></i> Free Wi-Fi</li>\r\n                         <li><i class='fas fa-utensils'></i> Breakfast available on-site</li>\r\n                         <li><i class='fas fa-snowflake'></i> Air conditioning</li>\r\n                         <li><i class='fas fa-car'></i> Free parking</li>\r\n                         <li><i class='fas fa-mug-hot'></i> Tea and coffee in the room</li>\r\n                         <li><i class='fas fa-shower'></i> Spacious bathroom with shower</li>\r\n                         <li><i class='fas fa-tv'></i> Television</li>\r\n                     </ul>\r\n                     <p><i class='fas fa-lock'></i> Safe for valuables available at the reception</p>", "Double Room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "DescriptionEng", "DescriptionLT", "NameEng" },
                values: new object[] { "\r\n                    Spacious room with a classic interior and a view of the city square with ringing bells and a splashing fountain.\r\n                     <ul>\r\n                        <li><i class='fas fa-wifi'></i> Free Wi-Fi</li>\r\n                        <li><i class='fas fa-utensils'></i> Breakfast available on-site</li>\r\n                        <li><i class='fas fa-snowflake'></i> Air conditioning</li>\r\n                        <li><i class='fas fa-car'></i> Free parking</li>\r\n                        <li><i class='fas fa-mug-hot'></i> Tea and coffee in the room</li>\r\n                        <li><i class='fas fa-shower'></i> Spacious bathroom with shower</li>\r\n                        <li><i class='fas fa-tv'></i> Television</li>\r\n                    </ul>\r\n                    <p><i class='fas fa-lock'></i> Safe for valuables available at the reception</p>", "\r\n                    Erdvus kambarys su klasikiniu interjeru ir vaizdu į miesto aikštę su skambančiais varpais ir trykštančiu fontanu.\r\n                     <ul>\r\n                        <li><i class='fas fa-wifi'></i> Nemokamas Wi-Fi</li>\r\n                        <li><i class='fas fa-utensils'></i> Galimybė užsisakyti pusryčius vietoje</li>\r\n                        <li><i class='fas fa-snowflake'></i> Oro kondicionierius</li>\r\n                        <li><i class='fas fa-car'></i> Nemokama stovėjimo vieta</li>\r\n                        <li><i class='fas fa-mug-hot'></i> Arbata ir kava kambaryje</li>\r\n                        <li><i class='fas fa-shower'></i> Erdvus vonios kambarys su dušu</li>\r\n                        <li><i class='fas fa-tv'></i> Televizorius</li>\r\n                    </ul>\r\n                    <p><i class='fas fa-lock'></i> Seifas vertingiems daiktams prieinamas registratūroje</p>", "Luxury Room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "DescriptionEng", "NameEng" },
                values: new object[] { "\r\n                    Comfortable and bright room with two single beds (double bed available on request).\r\n                    <ul>\r\n                        <li><i class='fas fa-wifi'></i> Free Wi-Fi</li>\r\n                        <li><i class='fas fa-snowflake'></i> Air conditioning</li>\r\n                        <li><i class='fas fa-utensils'></i> Breakfast available on-site</li>\r\n                        <li><i class='fas fa-car'></i> Free parking</li>\r\n                        <li><i class='fas fa-mug-hot'></i> Tea and coffee in the room</li>\r\n                        <li><i class='fas fa-shower'></i> Spacious bathroom with shower</li>\r\n                        <li><i class='fas fa-tv'></i> Television</li>\r\n                    </ul>\r\n                    <p><i class='fas fa-lock'></i> Safe for valuables available at the reception</p>", "Twin Room (2 beds)" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "DescriptionEng", "NameEng" },
                values: new object[] { "\r\n                    Luxurious and spacious room with top-class amenities.\r\n                    <ul>\r\n                        <li><i class='fas fa-wifi'></i> Free Wi-Fi</li>\r\n                        <li><i class='fas fa-utensils'></i> Breakfast available on-site</li>\r\n                        <li><i class='fas fa-car'></i> Free parking</li>\r\n                        <li><i class='fas fa-mug-hot'></i> Tea and coffee in the room</li>\r\n                        <li><i class='fas fa-shower'></i> Spacious bathroom with bathtub</li>\r\n                        <li><i class='fas fa-tv'></i> Television</li>\r\n                    </ul>\r\n                    <p><i class='fas fa-lock'></i> Safe for valuables available at the reception</p>", "Luxury Room" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "DescriptionEng", "NameEng" },
                values: new object[] { "\r\n                    Room with a stunning lake view – a perfect choice for a peaceful getaway.\r\n                    <ul>\r\n                        <li><i class='fas fa-eye'></i> Lake view</li>\r\n                        <li><i class='fas fa-wifi'></i> Free Wi-Fi</li>\r\n                        <li><i class='fas fa-utensils'></i> Breakfast available on-site</li>\r\n                        <li><i class='fas fa-car'></i> Free parking</li>\r\n                        <li><i class='fas fa-mug-hot'></i> Tea and coffee in the room</li>\r\n                        <li><i class='fas fa-shower'></i> Spacious bathroom with shower</li>\r\n                        <li><i class='fas fa-tv'></i> Television</li>\r\n                    </ul>", "Double Room" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEng",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "NameEng",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "NameLT",
                table: "Rooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DescriptionLT",
                table: "Rooms",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6,
                column: "Description",
                value: "\r\n                Erdvus kambarys su klasikiniu interjeru ir vaizdu į miesto aikštę su skambančiais varpais ir trykštančiu fontanu.\r\n                     <ul>\r\n                        <li><i class='fas fa-wifi'></i> Nemokamas Wi-Fi</li>\r\n                        <li><i class='fas fa-utensils'></i> Galimybė užsisakyti pusryčius vietoje</li>\r\n                        <li><i class='fas fa-snowflake'></i> Oro kondicionierius</li>\r\n                        <li><i class='fas fa-car'></i> Nemokama stovėjimo vieta</li>\r\n                        <li><i class='fas fa-mug-hot'></i> Arbata ir kava kambaryje</li>\r\n                        <li><i class='fas fa-shower'></i> Erdvus vonios kambarys su dušu</li>\r\n                        <li><i class='fas fa-tv'></i> Televizorius</li>\r\n                    </ul>\r\n                    <p><i class='fas fa-lock'></i> Seifas vertingiems daiktams prieinamas registratūroje</p>");
        }
    }
}
