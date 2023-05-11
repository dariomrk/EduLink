using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class AvailableTimeSpan : BaseModel
    {
        public long TutoringPostId { get; set; }
        public TutoringPost TutoringPost { get; set; } = null!;
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureAvailableTimeSpan(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<AvailableTimeSpan>();

            entity
                .ToTable(nameof(AvailableTimeSpan), table =>
                {
                    table.HasCheckConstraint(
                        $"CK_\"{nameof(AvailableTimeSpan)}\"_\"{nameof(AvailableTimeSpan.Start)}\"",
                        $"\"{nameof(AvailableTimeSpan.Start)}\" < \"{nameof(AvailableTimeSpan.End)}\"");
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
