using Application.Dtos.Location;

namespace Application.Interfaces
{
    public interface ILocationService
    {
        internal Task<CountryResponseDto> FindCountry(string countryName, CancellationToken cancellationToken = default);
        internal Task<RegionIdResponseDto> FindRegion(string countryName, string regionName, CancellationToken cancellationToken = default);
        internal Task<CityIdResponseDto> FindCity(string countryName, string regionName, string cityName, CancellationToken cancellationToken = default);
        internal Task<bool> CityExists(string countryName, string regionName, string cityName, CancellationToken cancellationToken);
        public Task<ICollection<RegionResponseDto>> GetAllFromCountryAsync(string countryName, CancellationToken cancellationToken = default);
    }
}
