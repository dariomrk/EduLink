using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class TimeFrame : BaseModel
    {
        public long TutoringPostId { get; set; }
        public TutoringPost TutoringPost { get; set; } = null!;
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public long? TakenByStudentId { get; set; }
        public User? TakenByStudent { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureAvailableTimeFrame(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<TimeFrame>();

            entity
                .ToTable(nameof(TimeFrame), table =>
                {
                    table.HasCheckConstraint(
                        $"CK_\"{nameof(TimeFrame)}\"_\"{nameof(TimeFrame.Start)}\"",
                        $"\"{nameof(TimeFrame.Start)}\" < \"{nameof(TimeFrame.End)}\"");
                });

            entity
                .HasIndex(x => new { x.TutoringPostId, x.Start, x.End })
                .IsUnique();

            entity
                .Property(x => x.TutoringPostId)
                .IsRequired();

            entity
                .Property(x => x.Start)
                .IsRequired();

            entity
                .Property(x => x.End)
                .IsRequired();

            return modelBuilder;
        }
    }
}
