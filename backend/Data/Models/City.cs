using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class City : BaseModel
    {
        public string Name { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public long RegionId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureCity(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<City>();

            entity
                .HasIndex(x => new { x.RegionId, x.ZipCode })
                .IsUnique();

            entity
                .Property(x => x.Name)
                .IsRequired();

            entity
                .Property(x => x.ZipCode)
                .IsRequired();

            entity
                .Property(x => x.RegionId)
                .IsRequired();

            entity
                .Property(x => x.Latitude)
                .IsRequired();

            entity
                .Property(x => x.Longitude)
                .IsRequired();

            return modelBuilder;
        }
    }
}
