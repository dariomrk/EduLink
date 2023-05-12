using Application.Dtos.Location;

namespace Application.Interfaces
{
    public interface ILocationService
    {
        internal Task<CountryDto> FindCountry(string countryName, CancellationToken cancellationToken = default);
        internal Task<RegionDto> FindRegion(string countryName, string regionName, CancellationToken cancellationToken = default);
        internal Task<CityDto> FindCity(string countryName, string regionName, string cityName, CancellationToken cancellationToken = default);

    }
}
