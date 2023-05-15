using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHashingAlgorithmTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_PasswordHashingAlgorithm_PasswordHashingAlgorithmId",
                table: "User");

            migrationBuilder.DropTable(
                name: "PasswordHashingAlgorithm");

            migrationBuilder.DropIndex(
                name: "IX_User_PasswordHashingAlgorithmId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordHashingAlgorithmId",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PasswordHashingAlgorithmId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "PasswordHashingAlgorithm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordHashingAlgorithm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_PasswordHashingAlgorithmId",
                table: "User",
                column: "PasswordHashingAlgorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordHashingAlgorithm_Name",
                table: "PasswordHashingAlgorithm",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_PasswordHashingAlgorithm_PasswordHashingAlgorithmId",
                table: "User",
                column: "PasswordHashingAlgorithmId",
                principalTable: "PasswordHashingAlgorithm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
