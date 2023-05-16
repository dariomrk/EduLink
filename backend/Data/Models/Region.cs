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

            entity.HasData(new List<Region>
            {
                new Region
                {
                    Id = 1,
                    CountryId = 1,
                    Name = "Bjelovarsko-Bilogorska",
                },
                new Region
                {
                    Id = 2,
                    CountryId = 1,
                    Name = "Brodsko-Posavska",
                },
                new Region
                {
                    Id = 3,
                    CountryId = 1,
                    Name = "Dubrovačko-Neretvanska",
                },
                new Region
                {
                    Id = 4,
                    CountryId = 1,
                    Name = "Istarska",
                },
                new Region
                {
                    Id = 5,
                    CountryId = 1,
                    Name = "Karlovačka",
                },
                new Region
                {
                    Id = 6,
                    CountryId = 1,
                    Name = "Koprivničko-Križevačka",
                },
                new Region
                {
                    Id = 7,
                    CountryId = 1,
                    Name = "Krapinsko-Zagorska",
                },
                new Region
                {
                    Id = 8,
                    CountryId = 1,
                    Name = "Ličko-Senjska",
                },
                new Region
                {
                    Id = 9,
                    CountryId = 1,
                    Name = "Međimurska",
                },
                new Region
                {
                    Id = 10,
                    CountryId = 1,
                    Name = "Osijekčko-Baranjska",
                },
                new Region
                {
                    Id = 11,
                    CountryId = 1,
                    Name = "Požeško-Slavonska",
                },
                new Region
                {
                    Id = 12,
                    CountryId = 1,
                    Name = "Primorsko-Gorski Kotar",
                },
                new Region
                {
                    Id = 13,
                    CountryId = 1,
                    Name = "Šibensko-Kninska",
                },
                new Region
                {
                    Id = 14,
                    CountryId = 1,
                    Name = "Sisak-Moslavina",
                },
                new Region
                {
                    Id = 15,
                    CountryId = 1,
                    Name = "Splitsko-Dalmatinska",
                },
                new Region
                {
                    Id = 16,
                    CountryId = 1,
                    Name = "Varaždinska",
                },
                new Region
                {
                    Id = 17,
                    CountryId = 1,
                    Name = "Virovitičko-Podravska",
                },
                new Region
                {
                    Id = 18,
                    CountryId = 1,
                    Name = "Vukovarsko-Srijemska",
                },
                new Region
                {
                    Id = 19,
                    CountryId = 1,
                    Name = "Zadarska",
                },
                new Region
                {
                    Id = 20,
                    CountryId = 1,
                    Name = "Zagrebačka",
                },
                new Region
                {
                    Id = 21,
                    CountryId = 1,
                    Name = "Zagreb",
                }
            });

            return modelBuilder;
        }
    }
}
