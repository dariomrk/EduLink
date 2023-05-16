using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class LowercaseAllSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "zagreb");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "split");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "rijeka");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "osijek");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "zadar");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "pula");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "slavonski Brod");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "karlovac");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "varazdin");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "sibenik");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "hrvatska");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "trigonometrija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "algebra");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "geometrija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "mehanika");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "elektromagnetizam");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "termodinamika");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "organska kemija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "anorganska kemija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "fizikalna kemija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "botanika");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Name",
                value: "zoologija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Name",
                value: "genetika");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "bjelovarsko-bilogorska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "brodsko-posavska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "dubrovačko-neretvanska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "istarska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "karlovačka");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "koprivničko-križevačka");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "krapinsko-zagorska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "ličko-senjska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "međimurska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "osijekčko-baranjska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Name",
                value: "požeško-slavonska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Name",
                value: "primorsko-gorski kotar");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Name",
                value: "šibensko-kninska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Name",
                value: "sisačko-moslačka");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Name",
                value: "splitsko-dalmatinska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Name",
                value: "varaždinska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Name",
                value: "virovitičko-podravska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Name",
                value: "vukovarsko-srijemska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Name",
                value: "zadarska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Name",
                value: "zagrebačka");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Name",
                value: "zagreb");

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "matematika");

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "fizika");

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "kemija");

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "biologija");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "Zagreb");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Split");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "Rijeka");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "Osijek");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "Zadar");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "Pula");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "Slavonski Brod");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "Karlovac");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "Varazdin");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "Sibenik");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "Hrvatska");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "Trigonometrija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Algebra");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "Geometrija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "Mehanika");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "Elektromagnetizam");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "Termodinamika");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "Organska kemija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "Anorganska kemija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "Fizikalna kemija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "Botanika");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Name",
                value: "Zoologija");

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Name",
                value: "Genetika");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "Bjelovarsko-Bilogorska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Brodsko-Posavska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "Dubrovačko-Neretvanska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "Istarska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "Karlovačka");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "Koprivničko-Križevačka");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "Krapinsko-Zagorska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "Ličko-Senjska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "Međimurska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "Osijekčko-Baranjska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Name",
                value: "Požeško-Slavonska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Name",
                value: "Primorsko-Gorski Kotar");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Name",
                value: "Šibensko-Kninska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Name",
                value: "Sisak-Moslavina");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Name",
                value: "Splitsko-Dalmatinska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Name",
                value: "Varaždinska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Name",
                value: "Virovitičko-Podravska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Name",
                value: "Vukovarsko-Srijemska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Name",
                value: "Zadarska");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Name",
                value: "Zagrebačka");

            migrationBuilder.UpdateData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Name",
                value: "Zagreb");

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "Matematika");

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Fizika");

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "Kemija");

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "Biologija");
        }
    }
}
