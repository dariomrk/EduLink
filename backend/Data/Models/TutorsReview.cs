namespace Data.Models
{
    public class TutorsReview : BaseModel
    {
        public int PreviousKnowledge { get; set; }
        public int LearningRate { get; set; }
        public int Engagement { get; set; }
        public int Behaviour { get; set; }
        public DateTimeOffset AddedAt { get; set; }
    }
}
