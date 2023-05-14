using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRedundantAppointmentStudentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_User_StudentId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_StudentId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Appointment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "Appointment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_StudentId",
                table: "Appointment",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_User_StudentId",
                table: "Appointment",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
