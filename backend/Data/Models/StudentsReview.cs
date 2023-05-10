namespace Data.Models
{
    public class StudentsReview : BaseModel
    {
        public int Stars { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTimeOffset AddedAt { get; set; }
    }
}
