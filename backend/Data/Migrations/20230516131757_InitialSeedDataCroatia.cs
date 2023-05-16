using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedDataCroatia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MobileNumberPrefix",
                table: "Country",
                type: "character varying(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 3);

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "MobileNumberPrefix", "Name" },
                values: new object[] { 1L, "+385", "Hrvatska" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Matematika" },
                    { 2L, "Fizika" },
                    { 3L, "Kemija" },
                    { 4L, "Biologija" }
                });

            migrationBuilder.InsertData(
                table: "Field",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[,]
                {
                    { 1L, "Trigonometrija", 1L },
                    { 2L, "Algebra", 1L },
                    { 3L, "Geometrija", 1L },
                    { 4L, "Mehanika", 2L },
                    { 5L, "Elektromagnetizam", 2L },
                    { 6L, "Termodinamika", 2L },
                    { 7L, "Organska kemija", 3L },
                    { 8L, "Anorganska kemija", 3L },
                    { 9L, "Fizikalna kemija", 3L },
                    { 10L, "Botanika", 4L },
                    { 11L, "Zoologija", 4L },
                    { 12L, "Genetika", 4L }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, "Bjelovarsko-Bilogorska" },
                    { 2L, 1L, "Brodsko-Posavska" },
                    { 3L, 1L, "Dubrovačko-Neretvanska" },
                    { 4L, 1L, "Istarska" },
                    { 5L, 1L, "Karlovačka" },
                    { 6L, 1L, "Koprivničko-Križevačka" },
                    { 7L, 1L, "Krapinsko-Zagorska" },
                    { 8L, 1L, "Ličko-Senjska" },
                    { 9L, 1L, "Međimurska" },
                    { 10L, 1L, "Osijekčko-Baranjska" },
                    { 11L, 1L, "Požeško-Slavonska" },
                    { 12L, 1L, "Primorsko-Gorski Kotar" },
                    { 13L, 1L, "Šibensko-Kninska" },
                    { 14L, 1L, "Sisak-Moslavina" },
                    { 15L, 1L, "Splitsko-Dalmatinska" },
                    { 16L, 1L, "Varaždinska" },
                    { 17L, 1L, "Virovitičko-Podravska" },
                    { 18L, 1L, "Vukovarsko-Srijemska" },
                    { 19L, 1L, "Zadarska" },
                    { 20L, 1L, "Zagrebačka" },
                    { 21L, 1L, "Zagreb" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Coordinates", "Name", "RegionId", "ZipCode" },
                values: new object[,]
                {
                    { 1L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (15.9819 45.815)"), "Zagreb", 21L, "10000" },
                    { 2L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (16.4402 43.5089)"), "Split", 15L, "21000" },
                    { 3L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (14.4378 45.3431)"), "Rijeka", 12L, "51000" },
                    { 4L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (18.6955 45.5511)"), "Osijek", 10L, "31000" },
                    { 5L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (15.2306 44.1194)"), "Zadar", 19L, "23000" },
                    { 6L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (13.8481 44.8738)"), "Pula", 4L, "52100" },
                    { 7L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (18.016 45.1603)"), "Slavonski Brod", 2L, "35000" },
                    { 8L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (15.5481 45.4929)"), "Karlovac", 5L, "47000" },
                    { 9L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (16.3366 46.3044)"), "Varazdin", 16L, "42000" },
                    { 10L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (15.8958 43.735)"), "Sibenik", 13L, "22000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AlterColumn<int>(
                name: "MobileNumberPrefix",
                table: "Country",
                type: "integer",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(4)",
                oldMaxLength: 4);
        }
    }
}
