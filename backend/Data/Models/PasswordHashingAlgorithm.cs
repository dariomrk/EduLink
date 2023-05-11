using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class PasswordHashingAlgorithm : BaseModel
    {
        public string Name { get; set; } = null!;
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigurePasswordHashingAlgorithm(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<PasswordHashingAlgorithm>();

            entity
                .HasIndex(x => x.Name)
                .IsUnique();

            entity
                .Property(x => x.Name)
                .IsRequired();

            return modelBuilder;
        }
    }
}
