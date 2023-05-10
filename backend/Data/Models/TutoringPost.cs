using Data.Enums;

namespace Data.Models
{
    public class TutoringPost : BaseModel
    {
        public long UserId { get; set; }
        public decimal PricePerHour { get; set; }
        public Currency Currency { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsPaidAd { get; set; }
        public bool IsActive { get; set; }
    }
}
