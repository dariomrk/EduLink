namespace Data.Models
{
    public class Country : BaseModel
    {
        public string Name { get; set; } = null!;
        public int MobileNumberPrefix { get; set; }
    }
}
