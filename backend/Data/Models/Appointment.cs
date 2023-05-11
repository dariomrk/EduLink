using Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Appointment : BaseModel
    {
        private const int IsNotCancelableHoursPrior = 24;

        public long PostId { get; set; }
        public long TutorId { get; set; }
        public long StudentId { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public int DurationMinutes { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsConfirmedByTutor { get; set; }
        public bool IsCancelable =>
            DateTime.UtcNow
                .Add(StartAt.Offset)
            > StartAt
                .AddHours(-IsNotCancelableHoursPrior);
        public bool IsCancelled { get; set; }
        public long? AudioRecordingId { get; set; }
        public long? StudentsReviewId { get; set; }
        public long? TutorsReviewId { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureAppointment(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Appointment>();

            modelBuilder.Entity<Appointment>()
                .ToTable(nameof(Appointment), table =>
                {
                    table.HasCheckConstraint(
                        $"CK_{nameof(Appointment)}_{nameof(Appointment.DurationMinutes)}",
                        $"{nameof(Appointment.DurationMinutes)} > 0 and {nameof(Appointment.DurationMinutes)} < 1440");

                    table.HasCheckConstraint(
                        $"CK_{nameof(Appointment)}_{nameof(Appointment.Price)}",
                        $"{nameof(Appointment.Price)} >= 0");
                });

            entity
                .Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql(RawSql.Timestamp);

            entity
                .Ignore(x => x.IsCancelable);

            entity
                .Property(x => x.StartAt)
                .IsRequired();

            entity
                .Property(x => x.DurationMinutes)
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
