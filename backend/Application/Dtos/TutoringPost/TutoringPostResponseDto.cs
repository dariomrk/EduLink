using Application.Dtos.TimeFrame;

namespace Application.Dtos.TutoringPost
{
    public class TutoringPostResponseDto
    {
        public string TutorUsername { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public string Currency { get; set; } = null!;
        public ICollection<TimeFrameResponseDto> AvailableTimeFrames { get; set; } = new List<TimeFrameResponseDto>();
        public string SubjectName { get; set; } = null!;
        public ICollection<string> Fields { get; set; } = new List<string>();
    }
}
