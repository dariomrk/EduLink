using Application.Dtos.AvailableTimeSpan;

namespace Application.Dtos.TutoringPost
{
    public class CreateTutoringPostDto
    {
        public string TutorUsername { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public string Currency { get; set; } = null!;
        public ICollection<AvailableTimeSpanDto> AvailableTimeSpans { get; set; } = new List<AvailableTimeSpanDto>();
        public ICollection<string> Fields { get; set; } = new List<string>();
        public string SubjectName { get; set; } = null!;
    }
}
