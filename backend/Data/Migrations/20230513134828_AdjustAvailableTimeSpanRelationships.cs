using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AdjustAvailableTimeSpanRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutoringPost_User_UserId",
                table: "TutoringPost");

            migrationBuilder.DropColumn(
                name: "StartAt",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TutoringPost",
                newName: "TutorId");

            migrationBuilder.RenameIndex(
                name: "IX_TutoringPost_UserId",
                table: "TutoringPost",
                newName: "IX_TutoringPost_TutorId");

            migrationBuilder.AddColumn<long>(
                name: "TakenByStudentId",
                table: "AvailableTimeSpan",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTimeSpan_TakenByStudentId",
                table: "AvailableTimeSpan",
                column: "TakenByStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableTimeSpan_User_TakenByStudentId",
                table: "AvailableTimeSpan",
                column: "TakenByStudentId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TutoringPost_User_TutorId",
                table: "TutoringPost",
                column: "TutorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableTimeSpan_User_TakenByStudentId",
                table: "AvailableTimeSpan");

            migrationBuilder.DropForeignKey(
                name: "FK_TutoringPost_User_TutorId",
                table: "TutoringPost");

            migrationBuilder.DropIndex(
                name: "IX_AvailableTimeSpan_TakenByStudentId",
                table: "AvailableTimeSpan");

            migrationBuilder.DropColumn(
                name: "TakenByStudentId",
                table: "AvailableTimeSpan");

            migrationBuilder.RenameColumn(
                name: "TutorId",
                table: "TutoringPost",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TutoringPost_TutorId",
                table: "TutoringPost",
                newName: "IX_TutoringPost_UserId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartAt",
                table: "Appointment",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_TutoringPost_User_UserId",
                table: "TutoringPost",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
