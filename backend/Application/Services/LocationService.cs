using Application.Dtos.Location;
using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Country, long> _countryRepository;
        private readonly IRepository<Region, long> _regionRepository;
        private readonly IRepository<City, long> _cityRepository;
        private readonly ILogger<LocationService> _logger;

        public LocationService(
            IRepository<Country, long> countryRepository,
            IRepository<Region, long> regionRepository,
            IRepository<City, long> cityRepository,
            ILogger<LocationService> logger)
        {
            _countryRepository = countryRepository;
            _regionRepository = regionRepository;
            _cityRepository = cityRepository;
            _logger = logger;
        }

        public async Task<CountryResponseDto> FindCountry(
            string countryName,
            CancellationToken cancellationToken)
        {
            var country = await _countryRepository.FindAsync(country =>
                country.Name == countryName.ToNormalizedLower(),
                cancellationToken);

            return country?.ToDto() ?? throw new NotFoundException<Country>(countryName);
        }

        public async Task<RegionResponseDto> FindRegion(
            string countryName,
            string regionName,
            CancellationToken cancellationToken)
        {
            var region = await _regionRepository.Query()
                .Where(region =>
                    region.Name == regionName.ToNormalizedLower()
                    && region.Country.Name == countryName.ToNormalizedLower())
                .FirstOrDefaultAsync(cancellationToken);

            return region?.ToDto() ?? throw new NotFoundException<Region>(regionName);
        }

        public async Task<CityResponseDto> FindCity(
            string countryName,
            string regionName,
            string cityName,
            CancellationToken cancellationToken)
        {
            var city = await _cityRepository.Query()
                .Where(city =>
                    city.Name == cityName.ToNormalizedLower()
                    && city.Region.Name == regionName.ToNormalizedLower()
                    && city.Region.Country.Name == countryName.ToNormalizedLower())
                .FirstOrDefaultAsync(cancellationToken);

            return city?.ToDto() ?? throw new NotFoundException<City>(cityName);
        }

        public async Task<bool> CityExists(
            string countryName,
            string regionName,
            string cityName,
            CancellationToken cancellationToken)
        {
            try
            {
                await FindCity(countryName, regionName, cityName, cancellationToken);
            }
            catch (NotFoundException)
            {
                return false;
            }

            return true;
        }
    }
}
