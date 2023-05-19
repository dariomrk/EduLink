namespace Application.Dtos.Subject
{
    public class SubjectResponseDto
    {
        public string SubjectName { get; set; } = null!;
        public ICollection<string> Fields = new List<string>();
    }
}
