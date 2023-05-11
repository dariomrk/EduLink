using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Region : BaseModel
    {
        public string Name { get; set; } = null!;
        public long CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public ICollection<City> Cities { get; set; } = new List<City>();
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureRegion(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Region>();

            entity
                .HasIndex(x => new { x.Name, x.CountryId })
                .IsUnique();

            entity
                .Property(x => x.Name)
                .IsRequired();

            entity
                .Property(x => x.CountryId)
                .IsRequired();

            return modelBuilder;
        }
    }
}
