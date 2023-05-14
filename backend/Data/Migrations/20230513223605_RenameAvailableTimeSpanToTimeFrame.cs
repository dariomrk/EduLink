using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameAvailableTimeSpanToTimeFrame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AvailableTimeSpan_AppointmentTimeSpanId",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "AvailableTimeSpan");

            migrationBuilder.RenameColumn(
                name: "AppointmentTimeSpanId",
                table: "Appointment",
                newName: "AppointmentTimeFrameId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_AppointmentTimeSpanId",
                table: "Appointment",
                newName: "IX_Appointment_AppointmentTimeFrameId");

            migrationBuilder.CreateTable(
                name: "TimeFrame",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TutoringPostId = table.Column<long>(type: "bigint", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    TakenByStudentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeFrame", x => x.Id);
                    table.CheckConstraint("CK_\"TimeFrame\"_\"Start\"", "\"Start\" < \"End\"");
                    table.ForeignKey(
                        name: "FK_TimeFrame_TutoringPost_TutoringPostId",
                        column: x => x.TutoringPostId,
                        principalTable: "TutoringPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeFrame_User_TakenByStudentId",
                        column: x => x.TakenByStudentId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeFrame_TakenByStudentId",
                table: "TimeFrame",
                column: "TakenByStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeFrame_TutoringPostId_Start_End",
                table: "TimeFrame",
                columns: new[] { "TutoringPostId", "Start", "End" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_TimeFrame_AppointmentTimeFrameId",
                table: "Appointment",
                column: "AppointmentTimeFrameId",
                principalTable: "TimeFrame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_TimeFrame_AppointmentTimeFrameId",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "TimeFrame");

            migrationBuilder.RenameColumn(
                name: "AppointmentTimeFrameId",
                table: "Appointment",
                newName: "AppointmentTimeSpanId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_AppointmentTimeFrameId",
                table: "Appointment",
                newName: "IX_Appointment_AppointmentTimeSpanId");

            migrationBuilder.CreateTable(
                name: "AvailableTimeSpan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TakenByStudentId = table.Column<long>(type: "bigint", nullable: true),
                    TutoringPostId = table.Column<long>(type: "bigint", nullable: false),
                    End = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTimeSpan", x => x.Id);
                    table.CheckConstraint("CK_\"AvailableTimeSpan\"_\"Start\"", "\"Start\" < \"End\"");
                    table.ForeignKey(
                        name: "FK_AvailableTimeSpan_TutoringPost_TutoringPostId",
                        column: x => x.TutoringPostId,
                        principalTable: "TutoringPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableTimeSpan_User_TakenByStudentId",
                        column: x => x.TakenByStudentId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTimeSpan_TakenByStudentId",
                table: "AvailableTimeSpan",
                column: "TakenByStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTimeSpan_TutoringPostId_Start_End",
                table: "AvailableTimeSpan",
                columns: new[] { "TutoringPostId", "Start", "End" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AvailableTimeSpan_AppointmentTimeSpanId",
                table: "Appointment",
                column: "AppointmentTimeSpanId",
                principalTable: "AvailableTimeSpan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
