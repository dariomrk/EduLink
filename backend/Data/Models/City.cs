using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class City : BaseModel
    {
        public string Name { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public long RegionId { get; set; }
        public Region Region { get; set; } = null!;
        public NetTopologySuite.Geometries.Point Coordinates { get; set; } = null!;
        public ICollection<User> Users { get; set; } = new List<User>();
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
                .Property(x => x.Coordinates)
                .IsRequired();

            return modelBuilder;
        }
    }
}
