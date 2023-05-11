using Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class LoginTimestamp : BaseModel
    {
        public long UserId { get; set; }
        public DateTimeOffset AttemptedAt { get; set; }
        public TimeSpan? LockoutDuration { get; set; }
        public bool IsValidLogin { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureLoginTimestamp(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<LoginTimestamp>();

            entity
                .ToTable(nameof(LoginTimestamp), table =>
                {
                    table.HasCheckConstraint(
                        $"CK_\"{nameof(LoginTimestamp)}\"_\"{nameof(LoginTimestamp.LockoutDuration)}\"_\"{nameof(LoginTimestamp.IsValidLogin)}\"",
                        $"(\"{nameof(LoginTimestamp.IsValidLogin)}\" AND \"{nameof(LoginTimestamp.LockoutDuration)}\" IS NULL) OR " +
                        $"(NOT \"{nameof(LoginTimestamp.IsValidLogin)}\" AND \"{nameof(LoginTimestamp.LockoutDuration)}\" >= interval '5 seconds')");
                });

            entity
                .Property(x => x.AttemptedAt)
                .IsRequired()
                .HasDefaultValueSql(RawSql.Timestamp);

            entity
                .Property(x => x.LockoutDuration);

            entity
                .Property(x => x.IsValidLogin)
                .IsRequired()
                .HasDefaultValue(false);

            return modelBuilder;
        }
    }
}
