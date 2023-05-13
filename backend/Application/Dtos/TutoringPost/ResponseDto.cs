using Application.Dtos.AvailableTimeSpan;

namespace Application.Dtos.TutoringPost
{
    public class ResponseDto
    {
        public string TutorUsername { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public string Currency { get; set; } = null!;
        public ICollection<TimeSpanDto> AvailableTimeSpans { get; set; } = new List<TimeSpanDto>();
        public ICollection<string> Fields { get; set; } = new List<string>();
        public string SubjectName { get; set; } = null!;
    }
}
