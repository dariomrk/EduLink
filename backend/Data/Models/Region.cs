namespace Data.Models
{
    public class Region : BaseModel
    {
        public string Name { get; set; } = null!;
        public long CountryId { get; set; }
    }
}
