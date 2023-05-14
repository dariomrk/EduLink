namespace Application.Dtos.Review
{
    public class CreateReviewAsStudentRequestDto
    {
        public string Username { get; set; } = null!;
        public int Stars { get; set; }
        public string Comment { get; set; } = null!;
    }
}
