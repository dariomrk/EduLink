using Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Appointment : BaseModel
    {
        private const int IsNotCancelableHoursPrior = 24;

        public long PostId { get; set; }
        public TutoringPost Post { get; set; } = null!;
        public long TutorId { get; set; }
        public User Tutor { get; set; } = null!;
        public long StudentId { get; set; }
        public User Student { get; set; } = null!;
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsCancelled { get; set; }
        public long? AudioRecordingId { get; set; }
        public File? AudioRecording { get; set; }
        public long? StudentsReviewId { get; set; }
        public StudentsReview? StudentsReview { get; set; }
        public long? TutorsReviewId { get; set; }
        public TutorsReview? TutorsReview { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureAppointment(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Appointment>();

            entity
                .ToTable(nameof(Appointment), table =>
                {
                    table.HasCheckConstraint(
                        $"CK_{nameof(Appointment)}_{nameof(Appointment.DurationMinutes)}",
                        $"\"{nameof(Appointment.DurationMinutes)}\" > 0 AND \"{nameof(Appointment.DurationMinutes)}\" < 1440");

                    table.HasCheckConstraint(
                        $"CK_{nameof(Appointment)}_{nameof(Appointment.Price)}",
                        $"\"{nameof(Appointment.Price)}\" >= 0");
                });

            entity
                .Property(x => x.PostId)
                .IsRequired();

            entity
                .Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql(RawSql.Timestamp);

            entity
                .Property(x => x.DurationMinutes)
                .IsRequired();

            entity
                .Property(x => x.TutorId)
                .IsRequired();

            entity
                .Property(x => x.StudentId)
                .IsRequired();

            entity
                .Property(x => x.IsCancelled)
                .HasDefaultValue(false);

            entity
                .Property(x => x.Price)
                .IsRequired();

            return modelBuilder;
        }
    }
}
