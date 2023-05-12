using Application.Dtos.Location;
using Data.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Mappings
{
    [Mapper]
    internal static partial class LocationMappings
    {
        internal static partial CountryDto ToDto(this Country country);
        internal static partial RegionDto ToDto(this Region region);
        internal static partial CityDto ToDto(this City city);
    }
}
