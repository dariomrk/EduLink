namespace Data.Models
{
    public class User : BaseModel
    {
        private const int TutoringEligibilityYears = 16;

        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] Salt { get; set; } = null!;
        public long PasswordHashingAlgorithmId { get; set; }
        public int DerivedKeyLength { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public long ProfileImageId { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool IsEligibleAsTutor =>
            DateOnly
                .FromDateTime(DateTime.UtcNow)
                .AddYears(-TutoringEligibilityYears)
            > DateOfBirth;
        public string? About { get; set; }
        public long CityId { get; set; }
        public string MobileNumber { get; set; } = null!;
        public string StripeCustomerId { get; set; } = null!;
        public string? StripeAccountId { get; set; } = null!;
    }
}
