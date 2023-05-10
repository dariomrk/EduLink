namespace Data.Models
{
    public class Field : BaseModel
    {
        public string Name { get; set; } = null!;
        public long SubjectId { get; set; }
    }
}
