using Application.Dtos.Location;

namespace Application.Interfaces
{
    public interface ILocationService
    {
        internal Task<ResponseCountryDto> FindCountry(string countryName, CancellationToken cancellationToken = default);
        internal Task<ResponseRegionDto> FindRegion(string countryName, string regionName, CancellationToken cancellationToken = default);
        internal Task<ResponseCityDto> FindCity(string countryName, string regionName, string cityName, CancellationToken cancellationToken = default);
    }
}
