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
}
