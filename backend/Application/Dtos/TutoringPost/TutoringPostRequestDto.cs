using Application.Dtos.TimeFrame;

namespace Application.Dtos.TutoringPost
{
    public class TutoringPostRequestDto
    {
        public string TutorUsername { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public string Currency { get; set; } = null!;
        public ICollection<TimeFrameRequestDto> AvailableTimeFrames { get; set; } = new List<TimeFrameRequestDto>();
        public string SubjectName { get; set; } = null!;
        public ICollection<string> Fields { get; set; } = new List<string>();
    }
}
