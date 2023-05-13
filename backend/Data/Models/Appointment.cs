using Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Appointment : BaseModel
    {
        private const int IsNotCancelableHoursPrior = 24; // TODO add configuration field to appsettings.json

        public long PostId { get; set; }
        public TutoringPost Post { get; set; } = null!;
        public long TutorId { get; set; }
        public User Tutor { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsCancelled { get; set; }
        public long? AudioRecordingId { get; set; }
        public File? AudioRecording { get; set; }
        public long? StudentsReviewId { get; set; }
        public StudentsReview? StudentsReview { get; set; }
        public long? TutorsReviewId { get; set; }
        public TutorsReview? TutorsReview { get; set; }
        public long AppointmentTimeSpanId { get; set; }
        public AvailableTimeSpan AppointmentTimeSpan { get; set; } = null!;
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureAppointment(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Appointment>();

            entity
                .Property(x => x.PostId)
                .IsRequired();

            entity
                .Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql(RawSql.Timestamp);

            entity
                .Property(x => x.TutorId)
                .IsRequired();

            entity
                .Property(x => x.IsCancelled)
                .HasDefaultValue(false);

            entity
                .Property(x => x.AppointmentTimeSpanId)
                .IsRequired();

            return modelBuilder;
        }
    }
}
