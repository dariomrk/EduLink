namespace Data.Models
{
    public class AvailableTimeSpan : BaseModel
    {
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
    }
}
