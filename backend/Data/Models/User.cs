using Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class User : BaseModel
    {
        private const int TutoringEligibilityYears = 16;

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] Salt { get; set; } = null!;
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
        /// <summary>
        /// <inheritdoc cref="City.Coordinates"/>
        /// </summary>
        public NetTopologySuite.Geometries.Point? Coordinates { get; set; }
        public ICollection<TimeFrame> StudyAppointments { get; set; } = new List<TimeFrame>();
        public ICollection<Appointment> TutoringAppointments { get; set; } = new List<Appointment>();
        public ICollection<TutoringPost> TutoringPosts { get; set; } = new List<TutoringPost>();
        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<Message> RecievedMessages { get; set; } = new List<Message>();
        public ICollection<LoginTimestamp> LoginTimestamps { get; set; } = new List<LoginTimestamp>();
        public ICollection<TimeFrame> AssignedStudyAppointmentTimeFrames = new List<TimeFrame>();
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureUser(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<User>();

            entity
                .HasMany(x => x.TutoringAppointments)
                .WithOne(x => x.Tutor)
                .HasPrincipalKey(x => x.Id);

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
