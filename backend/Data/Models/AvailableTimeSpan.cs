using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class AvailableTimeSpan : BaseModel
    {
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
                .Property(x => x.Start)
                .IsRequired();

            entity
                .Property(x => x.End)
                .IsRequired();

            return modelBuilder;
        }
    }
}
