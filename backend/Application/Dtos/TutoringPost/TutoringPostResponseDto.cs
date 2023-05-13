namespace Application.Dtos.TutoringPost
{
    public class TutoringPostResponseDto
    {
        public string TutorUsername { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public string Currency { get; set; } = null!;
        public ICollection<AvailableTimeSpan.AvailableTimeSpanResponseDto> AvailableTimeSpans { get; set; } = new List<AvailableTimeSpan.AvailableTimeSpanResponseDto>();
        public string SubjectName { get; set; } = null!;
        public ICollection<string> Fields { get; set; } = new List<string>();
    }
}
