using Data.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Dtos.Location
{
    [Mapper]
    internal static partial class Mappings
    {
        internal static partial CountryResponseDto ToDto(this Country country);
        internal static partial RegionIdResponseDto ToDto(this Region region);
        internal static partial CityIdResponseDto ToDto(this City city);
    }
}
