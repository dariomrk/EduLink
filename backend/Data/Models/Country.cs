using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Country : BaseModel
    {
        public string Name { get; set; } = null!;
        public int MobileNumberPrefix { get; set; }
    }

    public partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureCountry(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Country>();

            entity
                .HasIndex(x => x.Name)
                .IsUnique();

            entity
                .HasIndex(x => x.MobileNumberPrefix)
                .IsUnique();

            entity
                .Property(x => x.Name)
                .IsRequired();

            entity
                .Property(x => x.MobileNumberPrefix)
                .HasMaxLength(3)
                .IsRequired();

            return modelBuilder;
        }
    }
}
