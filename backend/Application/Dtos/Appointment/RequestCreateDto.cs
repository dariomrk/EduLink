namespace Application.Dtos.Appointment
{
    public class RequestCreateDto
    {
        public long PostId { get; set; }
        public string StudentUsername { get; set; } = null!;

    }
}
