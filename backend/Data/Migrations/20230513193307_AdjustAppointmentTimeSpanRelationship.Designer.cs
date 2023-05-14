﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(EduLinkDbContext))]
    [Migration("20230513193307_AdjustAppointmentTimeSpanRelationship")]
    partial class AdjustAppointmentTimeSpanRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.Appointment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AppointmentTimeSpanId")
                        .HasColumnType("bigint");

                    b.Property<long?>("AudioRecordingId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("IsCancelled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<long>("PostId")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StudentsReviewId")
                        .HasColumnType("bigint");

                    b.Property<long>("TutorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TutorsReviewId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentTimeSpanId");

                    b.HasIndex("AudioRecordingId")
                        .IsUnique();

                    b.HasIndex("PostId");

                    b.HasIndex("StudentId");

                    b.HasIndex("StudentsReviewId")
                        .IsUnique();

                    b.HasIndex("TutorId");

                    b.HasIndex("TutorsReviewId")
                        .IsUnique();

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Data.Models.AvailableTimeSpan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("TakenByStudentId")
                        .HasColumnType("bigint");

                    b.Property<long>("TutoringPostId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TakenByStudentId");

                    b.HasIndex("TutoringPostId", "Start", "End")
                        .IsUnique();

                    b.ToTable("AvailableTimeSpan", null, t =>
                        {
                            t.HasCheckConstraint("CK_\"AvailableTimeSpan\"_\"Start\"", "\"Start\" < \"End\"");
                        });
                });

            modelBuilder.Entity("Data.Models.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Point>("Coordinates")
                        .IsRequired()
                        .HasColumnType("geometry");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("RegionId")
                        .HasColumnType("bigint");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RegionId", "ZipCode")
                        .IsUnique();

                    b.ToTable("City");
                });

            modelBuilder.Entity("Data.Models.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("MobileNumberPrefix")
                        .HasMaxLength(3)
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MobileNumberPrefix")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Data.Models.Field", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("SubjectId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Field");
                });

            modelBuilder.Entity("Data.Models.File", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("AddedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FileType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("File");
                });

            modelBuilder.Entity("Data.Models.LoginTimestamp", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("AttemptedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("IsValidLogin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<TimeSpan?>("LockoutDuration")
                        .HasColumnType("interval");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LoginTimestamp", null, t =>
                        {
                            t.HasCheckConstraint("CK_\"LoginTimestamp\"_\"LockoutDuration\"_\"IsValidLogin\"", "(\"IsValidLogin\" AND \"LockoutDuration\" IS NULL) OR (NOT \"IsValidLogin\" AND \"LockoutDuration\" >= interval '5 seconds')");
                        });
                });

            modelBuilder.Entity("Data.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<long>("RecipientId")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Data.Models.PasswordHashingAlgorithm", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("PasswordHashingAlgorithm");
                });

            modelBuilder.Entity("Data.Models.Region", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Name", "CountryId")
                        .IsUnique();

                    b.ToTable("Region");
                });

            modelBuilder.Entity("Data.Models.StudentsReview", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("AddedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasDefaultValue("");

                    b.Property<int>("Stars")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("StudentsReview", null, t =>
                        {
                            t.HasCheckConstraint("CK_\"StudentsReview\"_\"Stars\"", "\"Stars\" >= 1 AND \"Stars\" <= 5");
                        });
                });

            modelBuilder.Entity("Data.Models.Subject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Data.Models.TutoringPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("Currency")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPaidAd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("numeric");

                    b.Property<long>("TutorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("TutoringPost", null, t =>
                        {
                            t.HasCheckConstraint("CK_\"TutoringPost\"_\"PricePerHour\"", "\"PricePerHour\" > 0");
                        });
                });

            modelBuilder.Entity("Data.Models.TutoringPostField", b =>
                {
                    b.Property<long>("TutoringPostId")
                        .HasColumnType("bigint");

                    b.Property<long>("FieldId")
                        .HasColumnType("bigint");

                    b.HasKey("TutoringPostId", "FieldId");

                    b.HasIndex("FieldId");

                    b.ToTable("TutoringPostField");
                });

            modelBuilder.Entity("Data.Models.TutorsReview", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("AddedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("Behaviour")
                        .HasColumnType("integer");

                    b.Property<int>("Engagement")
                        .HasColumnType("integer");

                    b.Property<int>("LearningRate")
                        .HasColumnType("integer");

                    b.Property<int>("PreviousKnowledge")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TutorsReview", null, t =>
                        {
                            t.HasCheckConstraint("CK_\"TutorsReview\"_\"Behaviour\"", "\"Behaviour\" >= 1 AND \"Behaviour\" <= 5");

                            t.HasCheckConstraint("CK_\"TutorsReview\"_\"Engagement\"", "\"Engagement\" >= 1 AND \"Engagement\" <= 5");

                            t.HasCheckConstraint("CK_\"TutorsReview\"_\"LearningRate\"", "\"LearningRate\" >= 1 AND \"LearningRate\" <= 5");

                            t.HasCheckConstraint("CK_\"TutorsReview\"_\"PreviousKnowledge\"", "\"PreviousKnowledge\" >= 1 AND \"PreviousKnowledge\" <= 5");
                        });
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("About")
                        .HasColumnType("text");

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<Point>("Coordinates")
                        .HasColumnType("geometry");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<long>("PasswordHashingAlgorithmId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProfileImageId")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("StripeAccountId")
                        .HasColumnType("text");

                    b.Property<string>("StripeCustomerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PasswordHashingAlgorithmId");

                    b.HasIndex("ProfileImageId")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Data.Models.Appointment", b =>
                {
                    b.HasOne("Data.Models.AvailableTimeSpan", "AppointmentTimeSpan")
                        .WithMany()
                        .HasForeignKey("AppointmentTimeSpanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.File", "AudioRecording")
                        .WithOne("Appointment")
                        .HasForeignKey("Data.Models.Appointment", "AudioRecordingId");

                    b.HasOne("Data.Models.TutoringPost", "Post")
                        .WithMany("Appointments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.User", "Student")
                        .WithMany("StudyAppointments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.StudentsReview", "StudentsReview")
                        .WithOne("Appointment")
                        .HasForeignKey("Data.Models.Appointment", "StudentsReviewId");

                    b.HasOne("Data.Models.User", "Tutor")
                        .WithMany("TutoringAppointments")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.TutorsReview", "TutorsReview")
                        .WithOne("Appointment")
                        .HasForeignKey("Data.Models.Appointment", "TutorsReviewId");

                    b.Navigation("AppointmentTimeSpan");

                    b.Navigation("AudioRecording");

                    b.Navigation("Post");

                    b.Navigation("Student");

                    b.Navigation("StudentsReview");

                    b.Navigation("Tutor");

                    b.Navigation("TutorsReview");
                });

            modelBuilder.Entity("Data.Models.AvailableTimeSpan", b =>
                {
                    b.HasOne("Data.Models.User", "TakenByStudent")
                        .WithMany()
                        .HasForeignKey("TakenByStudentId");

                    b.HasOne("Data.Models.TutoringPost", "TutoringPost")
                        .WithMany("AvailableTimeSpans")
                        .HasForeignKey("TutoringPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TakenByStudent");

                    b.Navigation("TutoringPost");
                });

            modelBuilder.Entity("Data.Models.City", b =>
                {
                    b.HasOne("Data.Models.Region", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Data.Models.Field", b =>
                {
                    b.HasOne("Data.Models.Subject", "Subject")
                        .WithMany("Fields")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Data.Models.LoginTimestamp", b =>
                {
                    b.HasOne("Data.Models.User", "User")
                        .WithMany("LoginTimestamps")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Models.Message", b =>
                {
                    b.HasOne("Data.Models.User", "Recipient")
                        .WithMany("RecievedMessages")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.User", "Sender")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Data.Models.Region", b =>
                {
                    b.HasOne("Data.Models.Country", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Data.Models.TutoringPost", b =>
                {
                    b.HasOne("Data.Models.User", "Tutor")
                        .WithMany("TutoringPosts")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("Data.Models.TutoringPostField", b =>
                {
                    b.HasOne("Data.Models.Field", "Field")
                        .WithMany("TutoringPostsFields")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.TutoringPost", "TutoringPost")
                        .WithMany("Fields")
                        .HasForeignKey("TutoringPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("TutoringPost");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.HasOne("Data.Models.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.PasswordHashingAlgorithm", null)
                        .WithMany("Users")
                        .HasForeignKey("PasswordHashingAlgorithmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.File", "ProfileImage")
                        .WithOne("User")
                        .HasForeignKey("Data.Models.User", "ProfileImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("ProfileImage");
                });

            modelBuilder.Entity("Data.Models.City", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Data.Models.Country", b =>
                {
                    b.Navigation("Regions");
                });

            modelBuilder.Entity("Data.Models.Field", b =>
                {
                    b.Navigation("TutoringPostsFields");
                });

            modelBuilder.Entity("Data.Models.File", b =>
                {
                    b.Navigation("Appointment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Models.PasswordHashingAlgorithm", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Data.Models.Region", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Data.Models.StudentsReview", b =>
                {
                    b.Navigation("Appointment")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.Subject", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("Data.Models.TutoringPost", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("AvailableTimeSpans");

                    b.Navigation("Fields");
                });

            modelBuilder.Entity("Data.Models.TutorsReview", b =>
                {
                    b.Navigation("Appointment")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Navigation("LoginTimestamps");

                    b.Navigation("RecievedMessages");

                    b.Navigation("SentMessages");

                    b.Navigation("StudyAppointments");

                    b.Navigation("TutoringAppointments");

                    b.Navigation("TutoringPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
