using Application.Dtos.Common;
using Application.Dtos.User;
using Application.Enums;
using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Application.Mappings;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Appointment, long> _appointmentRepository;
        private readonly ILocationService _locationService;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IRepository<User, long> userRepository,
            IRepository<Appointment, long> appointmentRepository,
            ILocationService locationService,
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _appointmentRepository = appointmentRepository;
            _locationService = locationService;
            _logger = logger;
        }

        public async Task<User?> GetByUsernameOrDefaultAsync(
            string username,
            CancellationToken cancellationToken = default)
        {
            return await _userRepository
                .FindAsync(user =>
                    user.Username == username.ToNormalizedLower(),
                    cancellationToken);
        }

        public async Task<User> GetByUsernameAsync(
            string username,
            CancellationToken cancellationToken = default)
        {
            return await GetByUsernameOrDefaultAsync(username, cancellationToken)
                ?? throw new NotFoundException<User>(username);
        }

        public async Task<User?> GetByEmailOrDefaultAsync(
            string email,
            CancellationToken cancellationToken = default)
        {
            return await _userRepository
                .FindAsync(user =>
                    user.Email == email.ToNormalizedLower(),
                    cancellationToken);
        }

        public async Task<User> GetByEmailAsync(
            string email,
            CancellationToken cancellationToken = default)
        {
            return await GetByEmailOrDefaultAsync(email, cancellationToken)
                ?? throw new NotFoundException<User>(email);
        }

        public async Task<UserDto> GetStudentAsync(
            string tutorUsername,
            long studentId,
            CancellationToken cancellationToken = default)
        {
            var tutor = await GetTutorAsync(tutorUsername, cancellationToken);

            var student = await _userRepository.Query()
                .Where(user => user.IsStudentOfTutor(tutorUsername))
                .FirstOrDefaultAsync(student => student.Id == studentId);

            return student?.ToDto() ?? throw new NotFoundException<User>(studentId);
        }

        public async Task<ICollection<UserDto>> GetStudentsAsync(
            string tutorUsername,
            PaginationDto? paginationOptions = null,
            SortDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            var tutor = await GetTutorAsync(tutorUsername, cancellationToken);

            return await _userRepository.Query()
                .Where(user => user.IsStudentOfTutor(tutorUsername))
                .ProjectToDto()
                .ToListAsync(cancellationToken);
        }

        public async Task<UserDto> GetTutorAsync(
            string tutorUsername,
            CancellationToken cancellationToken = default)
        {
            var tutor = await _userRepository.Query()
                .Where(user => user.IsTutor())
                .FirstOrDefaultAsync(tutor =>
                    tutor.Username == tutorUsername.ToNormalizedLower(),
                    cancellationToken);

            return tutor?.ToDto() ?? throw new NotFoundException<User>(tutorUsername);
        }

        public async Task<ICollection<UserDto>> GetTutorsInCityAsync(
            string countryName,
            string regionName,
            string cityName,
            PaginationDto? paginationOptions = null,
            SortDto? sortDto = null,
            CancellationToken cancellationToken = default)
        {
            var city = await _locationService.FindCity(countryName, regionName, cityName);

            var tutors = await _userRepository.Query()
                .Where(user => user.IsTutor())
                .Where(tutor => tutor.CityId == city.Id) // TODO add sorting and pagination
                .ProjectToDto()
                .ToListAsync(cancellationToken);

            return tutors;
        }

        public async Task<ICollection<UserDto>> GetTutorsInRegionAsync(
            string countryName,
            string regionName,
            PaginationDto? paginationOptions = null,
            SortDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            var region = await _locationService.FindRegion(countryName, regionName);

            var tutors = await _userRepository.Query()
                .Where(user => user.IsTutor())
                .Where(tutor => tutor.City.RegionId == region.Id)
                .SortTutors(sortOptions ?? new SortDto { SortByProperty = SortByProperty.Rating, SortOrder = SortOrder.Descending })
                .Paginate(paginationOptions ?? new PaginationDto { Skip = 0, Take = 25 })
                .ProjectToDto()
                .ToListAsync(cancellationToken);

            return tutors;
        }
    }
}
