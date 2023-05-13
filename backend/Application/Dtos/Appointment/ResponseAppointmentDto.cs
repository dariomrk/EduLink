namespace Application.Dtos.Appointment
{
    public class ResponseAppointmentDto
    {
        public long PostId { get; set; }
        public long TutorId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public long AppointmentTimeSpanId { get; set; }
    }
}
