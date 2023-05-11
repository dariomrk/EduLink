using Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class User : BaseModel
    {
        private const int TutoringEligibilityYears = 16; // TODO add configuration field to appsettings.json

        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] Salt { get; set; } = null!;
        public long PasswordHashingAlgorithmId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public long ProfileImageId { get; set; }
        public File ProfileImage { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public bool IsEligibleAsTutor =>
            DateOnly
                .FromDateTime(DateTime.UtcNow)
                .AddYears(-TutoringEligibilityYears)
            > DateOfBirth;
        public string? About { get; set; }
        public long CityId { get; set; }
        public City City { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public string StripeCustomerId { get; set; } = null!;
        public string? StripeAccountId { get; set; } = null!;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<TutoringPost> TutoringPosts { get; set; } = new List<TutoringPost>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<LoginTimestamp> LoginTimestamps { get; set; } = new List<LoginTimestamp>();
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
