using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Country : BaseModel
    {
        public string Name { get; set; } = null!;
        public string MobileNumberPrefix { get; set; } = null!;
        public ICollection<Region> Regions { get; set; } = new List<Region>();
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
                .HasMaxLength(4)
                .IsRequired();

            entity.HasData(new List<Country>
            {
                new Country
                {
                    Id = 1,
                    MobileNumberPrefix = "+385",
                    Name = "hrvatska",
                }
            });

            return modelBuilder;
        }
    }
}
