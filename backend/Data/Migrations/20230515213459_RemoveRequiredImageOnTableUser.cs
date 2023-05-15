using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRequiredImageOnTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_File_ProfileImageId",
                table: "User");

            migrationBuilder.AlterColumn<long>(
                name: "ProfileImageId",
                table: "User",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_User_File_ProfileImageId",
                table: "User",
                column: "ProfileImageId",
                principalTable: "File",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_File_ProfileImageId",
                table: "User");

            migrationBuilder.AlterColumn<long>(
                name: "ProfileImageId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_File_ProfileImageId",
                table: "User",
                column: "ProfileImageId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
