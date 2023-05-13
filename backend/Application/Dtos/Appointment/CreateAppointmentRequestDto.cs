namespace Application.Dtos.Appointment
{
    public class CreateAppointmentRequestDto
    {
        public long PostId { get; set; }
        public string StudentUsername { get; set; } = null!;
        public long AppointmentTimeFrameId { get; set; }
    }
}
