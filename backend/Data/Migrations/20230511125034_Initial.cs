using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MobileNumberPrefix = table.Column<int>(type: "integer", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    AddedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    FileType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "StudentsReview",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    AddedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsReview", x => x.Id);
                    table.CheckConstraint("CK_\"StudentsReview\"_\"Stars\"", "\"Stars\" >= 1 AND \"Stars\" <= 5");
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TutorsReview",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PreviousKnowledge = table.Column<int>(type: "integer", nullable: false),
                    LearningRate = table.Column<int>(type: "integer", nullable: false),
                    Engagement = table.Column<int>(type: "integer", nullable: false),
                    Behaviour = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorsReview", x => x.Id);
                    table.CheckConstraint("CK_\"TutorsReview\"_\"Behaviour\"", "\"Behaviour\" >= 1 AND \"Behaviour\" <= 5");
                    table.CheckConstraint("CK_\"TutorsReview\"_\"Engagement\"", "\"Engagement\" >= 1 AND \"Engagement\" <= 5");
                    table.CheckConstraint("CK_\"TutorsReview\"_\"LearningRate\"", "\"LearningRate\" >= 1 AND \"LearningRate\" <= 5");
                    table.CheckConstraint("CK_\"TutorsReview\"_\"PreviousKnowledge\"", "\"PreviousKnowledge\" >= 1 AND \"PreviousKnowledge\" <= 5");
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SubjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    RegionId = table.Column<long>(type: "bigint", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    Salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHashingAlgorithmId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    ProfileImageId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    About = table.Column<string>(type: "text", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    MobileNumber = table.Column<string>(type: "text", nullable: false),
                    StripeCustomerId = table.Column<string>(type: "text", nullable: false),
                    StripeAccountId = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: true),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_File_ProfileImageId",
                        column: x => x.ProfileImageId,
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_PasswordHashingAlgorithm_PasswordHashingAlgorithmId",
                        column: x => x.PasswordHashingAlgorithmId,
                        principalTable: "PasswordHashingAlgorithm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginTimestamp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    AttemptedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    LockoutDuration = table.Column<TimeSpan>(type: "interval", nullable: true),
                    IsValidLogin = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginTimestamp", x => x.Id);
                    table.CheckConstraint("CK_\"LoginTimestamp\"_\"LockoutDuration\"_\"IsValidLogin\"", "(\"IsValidLogin\" AND \"LockoutDuration\" IS NULL) OR (NOT \"IsValidLogin\" AND \"LockoutDuration\" >= interval '5 seconds')");
                    table.ForeignKey(
                        name: "FK_LoginTimestamp_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    RecipientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_User_SenderId",
                        column: x => x.SenderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TutoringPost",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    IsPaidAd = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutoringPost", x => x.Id);
                    table.CheckConstraint("CK_\"TutoringPost\"_\"PricePerHour\"", "\"PricePerHour\" > 0");
                    table.ForeignKey(
                        name: "FK_TutoringPost_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    TutorId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    StartAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    IsCancelled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    AudioRecordingId = table.Column<long>(type: "bigint", nullable: true),
                    StudentsReviewId = table.Column<long>(type: "bigint", nullable: true),
                    TutorsReviewId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.CheckConstraint("CK_Appointment_DurationMinutes", "\"DurationMinutes\" > 0 AND \"DurationMinutes\" < 1440");
                    table.CheckConstraint("CK_Appointment_Price", "\"Price\" >= 0");
                    table.ForeignKey(
                        name: "FK_Appointment_File_AudioRecordingId",
                        column: x => x.AudioRecordingId,
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_StudentsReview_StudentsReviewId",
                        column: x => x.StudentsReviewId,
                        principalTable: "StudentsReview",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_TutoringPost_PostId",
                        column: x => x.PostId,
                        principalTable: "TutoringPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_TutorsReview_TutorsReviewId",
                        column: x => x.TutorsReviewId,
                        principalTable: "TutorsReview",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_User_TutorId",
                        column: x => x.TutorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableTimeSpan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TutoringPostId = table.Column<long>(type: "bigint", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "TutoringPostField",
                columns: table => new
                {
                    TutoringPostId = table.Column<long>(type: "bigint", nullable: false),
                    FieldId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutoringPostField", x => new { x.TutoringPostId, x.FieldId });
                    table.ForeignKey(
                        name: "FK_TutoringPostField_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutoringPostField_TutoringPost_TutoringPostId",
                        column: x => x.TutoringPostId,
                        principalTable: "TutoringPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AudioRecordingId",
                table: "Appointment",
                column: "AudioRecordingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PostId",
                table: "Appointment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_StudentId",
                table: "Appointment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_StudentsReviewId",
                table: "Appointment",
                column: "StudentsReviewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TutorId",
                table: "Appointment",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TutorsReviewId",
                table: "Appointment",
                column: "TutorsReviewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTimeSpan_TutoringPostId_Start_End",
                table: "AvailableTimeSpan",
                columns: new[] { "TutoringPostId", "Start", "End" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_RegionId_ZipCode",
                table: "City",
                columns: new[] { "RegionId", "ZipCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_MobileNumberPrefix",
                table: "Country",
                column: "MobileNumberPrefix",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                table: "Country",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Field_SubjectId",
                table: "Field",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginTimestamp_UserId",
                table: "LoginTimestamp",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                table: "Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordHashingAlgorithm_Name",
                table: "PasswordHashingAlgorithm",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Region_CountryId",
                table: "Region",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_Name_CountryId",
                table: "Region",
                columns: new[] { "Name", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TutoringPost_UserId",
                table: "TutoringPost",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringPostField_FieldId",
                table: "TutoringPostField",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CityId",
                table: "User",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PasswordHashingAlgorithmId",
                table: "User",
                column: "PasswordHashingAlgorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileImageId",
                table: "User",
                column: "ProfileImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "AvailableTimeSpan");

            migrationBuilder.DropTable(
                name: "LoginTimestamp");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "TutoringPostField");

            migrationBuilder.DropTable(
                name: "StudentsReview");

            migrationBuilder.DropTable(
                name: "TutorsReview");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "TutoringPost");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "PasswordHashingAlgorithm");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
