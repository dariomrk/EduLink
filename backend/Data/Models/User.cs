using Data.Constants;
using Microsoft.EntityFrameworkCore;

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
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureUser(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<User>();

            entity
                .HasIndex(x => x.Username)
                .IsUnique();

            entity
                .HasIndex(x => x.Email)
                .IsUnique();

            entity
                .Property(x => x.Username)
                .IsRequired();

            entity
                .Property(x => x.Email)
                .IsRequired();

            entity
                .Property(x => x.PasswordHash)
                .IsRequired();

            entity
                .Property(x => x.Salt)
                .IsRequired();

            entity
                .Property(x => x.PasswordHashingAlgorithmId)
                .IsRequired();

            entity
                .Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql(RawSql.Timestamp);

            entity
                .Property(x => x.DateOfBirth)
                .IsRequired();

            entity
                .Ignore(x => x.IsEligibleAsTutor);

            entity
                .Property(x => x.CityId)
                .IsRequired();

            entity
                .Property(x => x.MobileNumber)
                .IsRequired();

            entity
                .Property(x => x.StripeCustomerId)
                .IsRequired();

            return modelBuilder;
        }
    }
}
