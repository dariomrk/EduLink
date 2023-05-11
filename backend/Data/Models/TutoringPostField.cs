using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class TutoringPostField
    {
        public long TutoringPostId { get; set; }
        public long FieldId { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureTutoringPostField(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<TutoringPostField>();

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
