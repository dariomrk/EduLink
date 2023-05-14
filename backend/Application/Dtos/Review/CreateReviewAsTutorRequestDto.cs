namespace Application.Dtos.Review
{
    public class CreateReviewAsTutorRequestDto
    {
        public string Username { get; set; } = null!;
        public int PreviousKnowledge { get; set; }
        public int LearningRate { get; set; }
        public int Engagement { get; set; }
        public int Behaviour { get; set; }
    }
}
