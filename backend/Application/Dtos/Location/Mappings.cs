﻿using Application.Dtos.Location;
using Data.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Mappings
{
    [Mapper]
    internal static partial class Mappings
    {
        internal static partial ResponseCountryDto ToDto(this Country country);
        internal static partial ResponseRegionDto ToDto(this Region region);
        internal static partial ResponseCityDto ToDto(this City city);
    }
}
