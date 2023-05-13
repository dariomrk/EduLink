using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AdjustAppointmentTimeSpanRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Appointment_DurationMinutes",
                table: "Appointment");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Appointment_Price",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "DurationMinutes",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Appointment");

            migrationBuilder.AddColumn<long>(
                name: "AppointmentTimeSpanId",
                table: "Appointment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentTimeSpanId",
                table: "Appointment",
                column: "AppointmentTimeSpanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AvailableTimeSpan_AppointmentTimeSpanId",
                table: "Appointment",
                column: "AppointmentTimeSpanId",
                principalTable: "AvailableTimeSpan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AvailableTimeSpan_AppointmentTimeSpanId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_AppointmentTimeSpanId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "AppointmentTimeSpanId",
                table: "Appointment");

            migrationBuilder.AddColumn<int>(
                name: "DurationMinutes",
                table: "Appointment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Appointment",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Appointment_DurationMinutes",
                table: "Appointment",
                sql: "\"DurationMinutes\" > 0 AND \"DurationMinutes\" < 1440");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Appointment_Price",
                table: "Appointment",
                sql: "\"Price\" >= 0");
        }
    }
}
