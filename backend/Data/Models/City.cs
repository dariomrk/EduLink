namespace Data.Models
{
    public class City : BaseModel
    {
        public string Name { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public long RegionId { get; set; }
    }
}
