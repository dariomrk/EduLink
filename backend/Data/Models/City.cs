using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class City : BaseModel
    {
        public string Name { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public long RegionId { get; set; }
        public Region Region { get; set; } = null!;
        /// <summary>
        /// Coordinates.X: longitude<br/>
        /// Coordinates.Y: latitude<br/>
        /// Simple example:
        /// <code>
        /// var point = new NetTopologySuite.Geometries.Point(longitude, latitude)
        /// {
        ///     SRID = 4326 // Spatial Reference ID for WGS 84 spatial reference system
        /// }
        /// </code>
        /// Distance calculation snippet:
        /// <code>
        /// var referencePoint = new NetTopologySuite.Geometries.Point(longitude, latitude) { SRID = 4326 };
        ///
        /// var closestLocations = await dbContext.Locations
        ///    .OrderBy(location => location.Coordinates.Distance(referencePoint))
        ///    .ToListAsync();
        /// </code>
        /// </summary>
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

            entity.HasData(new List<City>
            {
                new City
                {
                    Id = 1,
                    Name = "Zagreb",
                    RegionId = 21,
                    ZipCode = "10000",
                    Coordinates = new NetTopologySuite.Geometries.Point(15.9819, 45.8150)
                    {
                        SRID = 4326
                    },
                },
                new City
                {
                    Id = 2,
                    Name = "Split",
                    RegionId = 15,
                    ZipCode = "21000",
                    Coordinates = new NetTopologySuite.Geometries.Point(16.4402, 43.5089)
                    {
                        SRID = 4326
                    },
                },
                new City
                {
                    Id = 3,
                    Name = "Rijeka",
                    RegionId = 12,
                    ZipCode = "51000",
                    Coordinates = new NetTopologySuite.Geometries.Point(14.4378, 45.3431)
                    {
                        SRID = 4326
                    },
                },
                new City
                {
                    Id = 4,
                    Name = "Osijek",
                    RegionId = 10,
                    ZipCode = "31000",
                    Coordinates = new NetTopologySuite.Geometries.Point(18.6955, 45.5511)
                    {
                        SRID = 4326
                    },
                },
                new City
                {
                    Id = 5,
                    Name = "Zadar",
                    RegionId = 19,
                    ZipCode = "23000",
                    Coordinates = new NetTopologySuite.Geometries.Point(15.2306, 44.1194)
                    {
                        SRID = 4326
                    },
                },
                new City
                {
                    Id = 6,
                    Name = "Pula",
                    RegionId = 4,
                    ZipCode = "52100",
                    Coordinates = new NetTopologySuite.Geometries.Point(13.8481, 44.8738)
                    {
                        SRID = 4326
                    },
                },
                new City
                {
                    Id = 7,
                    Name = "Slavonski Brod",
                    RegionId = 2,
                    ZipCode = "35000",
                    Coordinates = new NetTopologySuite.Geometries.Point(18.0160, 45.1603)
                    {
                        SRID = 4326
                    },
                },
                new City
                {
                    Id = 8,
                    Name = "Karlovac",
                    RegionId = 5,
                    ZipCode = "47000",
                    Coordinates = new NetTopologySuite.Geometries.Point(15.5481, 45.4929)
                    {
                        SRID = 4326
                    },
                },
                new City
                {
                    Id = 9,
                    Name = "Varazdin",
                    RegionId = 16,
                    ZipCode = "42000",
                    Coordinates = new NetTopologySuite.Geometries.Point(16.3366, 46.3044)
                    {
                        SRID = 4326
                    },
                },
                new City
                {
                    Id = 10,
                    Name = "Sibenik",
                    RegionId = 13,
                    ZipCode = "22000",
                    Coordinates = new NetTopologySuite.Geometries.Point(15.8958, 43.7350)
                    {
                        SRID = 4326
                    },
                },
            });

            return modelBuilder;
        }
    }
}
