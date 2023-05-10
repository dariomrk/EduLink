namespace Data.Models
{
    public class Message : BaseModel
    {
        public string Content { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public long SenderId { get; set; }
        public long RecipientId { get; set; }
    }
}
