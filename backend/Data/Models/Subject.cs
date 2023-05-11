using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Subject : BaseModel
    {
        public string Name { get; set; } = null!;
        public ICollection<Field> Fields { get; set; } = new List<Field>();
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureSubject(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Subject>();

            entity
                .Property(x => x.Name)
                .IsRequired();

            return modelBuilder;
        }
    }
}
