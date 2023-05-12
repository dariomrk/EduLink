using Application.Dtos.AvailableTimeSpan;
using Data.Enums;

namespace Application.Dtos.TutoringPost
{
    public class TutoringPostDto
    {
        public string TutorUsername { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public Currency Currency { get; set; }
        public ICollection<AvailableTimeSpanDto> AvailableTimeSpans { get; set; } = new List<AvailableTimeSpanDto>();
        public ICollection<string> Fields { get; set; } = new List<string>();
        public string SubjectName { get; set; } = null!;
    }
}
