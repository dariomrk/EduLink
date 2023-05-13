namespace Application.Dtos.AvailableTimeSpan
{
    public class AvailableTimeSpanResponseDto
    {
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public bool IsAvailable { get; set; }
    }
}
