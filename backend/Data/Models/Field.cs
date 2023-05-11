using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Field : BaseModel
    {
        public string Name { get; set; } = null!;
        public long SubjectId { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder FieldConfiguration(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Field>();

            entity
                .Property(x => x.Name)
                .IsRequired();

            entity
                .Property(x => x.SubjectId)
                .IsRequired();

            return modelBuilder;
        }
    }
}
