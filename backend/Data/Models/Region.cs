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
                    Name = "bjelovarsko-bilogorska",
                },
                new Region
                {
                    Id = 2,
                    CountryId = 1,
                    Name = "brodsko-posavska",
                },
                new Region
                {
                    Id = 3,
                    CountryId = 1,
                    Name = "dubrovačko-neretvanska",
                },
                new Region
                {
                    Id = 4,
                    CountryId = 1,
                    Name = "istarska",
                },
                new Region
                {
                    Id = 5,
                    CountryId = 1,
                    Name = "karlovačka",
                },
                new Region
                {
                    Id = 6,
                    CountryId = 1,
                    Name = "koprivničko-križevačka",
                },
                new Region
                {
                    Id = 7,
                    CountryId = 1,
                    Name = "krapinsko-zagorska",
                },
                new Region
                {
                    Id = 8,
                    CountryId = 1,
                    Name = "ličko-senjska",
                },
                new Region
                {
                    Id = 9,
                    CountryId = 1,
                    Name = "međimurska",
                },
                new Region
                {
                    Id = 10,
                    CountryId = 1,
                    Name = "osijekčko-baranjska",
                },
                new Region
                {
                    Id = 11,
                    CountryId = 1,
                    Name = "požeško-slavonska",
                },
                new Region
                {
                    Id = 12,
                    CountryId = 1,
                    Name = "primorsko-gorski kotar",
                },
                new Region
                {
                    Id = 13,
                    CountryId = 1,
                    Name = "šibensko-kninska",
                },
                new Region
                {
                    Id = 14,
                    CountryId = 1,
                    Name = "sisačko-moslačka",
                },
                new Region
                {
                    Id = 15,
                    CountryId = 1,
                    Name = "splitsko-dalmatinska",
                },
                new Region
                {
                    Id = 16,
                    CountryId = 1,
                    Name = "varaždinska",
                },
                new Region
                {
                    Id = 17,
                    CountryId = 1,
                    Name = "virovitičko-podravska",
                },
                new Region
                {
                    Id = 18,
                    CountryId = 1,
                    Name = "vukovarsko-srijemska",
                },
                new Region
                {
                    Id = 19,
                    CountryId = 1,
                    Name = "zadarska",
                },
                new Region
                {
                    Id = 20,
                    CountryId = 1,
                    Name = "zagrebačka",
                },
                new Region
                {
                    Id = 21,
                    CountryId = 1,
                    Name = "zagreb",
                }
            });

            return modelBuilder;
        }
    }
}
