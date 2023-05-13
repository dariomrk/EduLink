using Application.Dtos.AvailableTimeSpan;

namespace Application.Dtos.TutoringPost
{
    public class TutoringPostRequestDto
    {
        public string TutorUsername { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public string Currency { get; set; } = null!;
        public ICollection<AvailableTimeSpan.AvailableTimeSpanRequestDto> AvailableTimeSpans { get; set; } = new List<AvailableTimeSpan.AvailableTimeSpanRequestDto>();
        public string SubjectName { get; set; } = null!;
        public ICollection<string> Fields { get; set; } = new List<string>();
    }
}
