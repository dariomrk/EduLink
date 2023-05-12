using Application.Dtos.Location;
using Data.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Mappings
{
    [Mapper]
    public static partial class LocationMappings
    {
        public static partial CountryDto ToDto(this Country country);
        public static partial RegionDto ToDto(this Region region);
        public static partial CityDto ToDto(this City city);
    }
}
