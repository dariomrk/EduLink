using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class TutoringPostField
    {
        public long TutoringPostId { get; set; }
        public TutoringPost TutoringPost { get; set; } = null!;
        public long FieldId { get; set; }
        public Field Field { get; set; } = null!;
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureTutoringPostField(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<TutoringPostField>();

            entity
                .HasKey(x => new { x.TutoringPostId, x.FieldId });

            entity
                .Property(x => x.TutoringPostId)
                .IsRequired();

            entity
                .Property(x => x.FieldId)
                .IsRequired();

            return modelBuilder;
        }
    }
}
