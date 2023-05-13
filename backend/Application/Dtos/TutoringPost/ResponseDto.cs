namespace Application.Dtos.TutoringPost
{
    public class ResponseDto
    {
        public string TutorUsername { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public string Currency { get; set; } = null!;
        public ICollection<AvailableTimeSpan.ResponseDto> AvailableTimeSpans { get; set; } = new List<AvailableTimeSpan.ResponseDto>();
        public string SubjectName { get; set; } = null!;
        public ICollection<string> Fields { get; set; } = new List<string>();
    }
}
