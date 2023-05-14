using Data.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Dtos.Location
{
    [Mapper]
    internal static partial class Mappings
    {
        internal static partial CountryResponseDto ToDto(this Country country);
        internal static partial RegionResponseDto ToDto(this Region region);
        internal static partial CityResponseDto ToDto(this City city);
    }
}
