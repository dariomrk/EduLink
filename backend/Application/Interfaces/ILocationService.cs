using Application.Dtos.Location;

namespace Application.Interfaces
{
    public interface ILocationService
    {
        internal Task<CountryResponseDto> FindCountry(string countryName, CancellationToken cancellationToken = default);
        internal Task<RegionResponseDto> FindRegion(string countryName, string regionName, CancellationToken cancellationToken = default);
        internal Task<CityResponseDto> FindCity(string countryName, string regionName, string cityName, CancellationToken cancellationToken = default);
    }
}
