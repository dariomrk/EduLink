using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class TutoringPostAvailability
    {
        public long TutoringPostId { get; set; }
        public long AvailableTimeSpanId { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureTutoringPostAvailability(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<TutoringPostAvailability>();

            entity
                .Property(x => x.TutoringPostId)
                .IsRequired();

            entity
                .Property(x => x.AvailableTimeSpanId)
                .IsRequired();

            return modelBuilder;
        }
    }
}
