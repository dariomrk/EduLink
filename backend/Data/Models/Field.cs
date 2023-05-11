using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Field : BaseModel
    {
        public string Name { get; set; } = null!;
        public long SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;
        public ICollection<TutoringPostField> TutoringPostsFields { get; set; } = new List<TutoringPostField>();
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureField(this ModelBuilder modelBuilder)
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
