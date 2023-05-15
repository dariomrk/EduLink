namespace Application.Dtos.Message
{
    public class MessageResponseDto
    {
        public string SenderUsername { get; set; } = null!;
        public string RecipientUsername { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
    }
}
