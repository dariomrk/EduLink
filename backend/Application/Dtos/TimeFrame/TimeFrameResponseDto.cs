namespace Application.Dtos.TimeFrame
{
    public class TimeFrameResponseDto
    {
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public bool IsAvailable { get; set; }
    }
}
