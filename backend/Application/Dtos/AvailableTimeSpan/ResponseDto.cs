namespace Application.Dtos.AvailableTimeSpan
{
    public class ResponseDto
    {
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public bool IsAvailable { get; set; }
    }
}
