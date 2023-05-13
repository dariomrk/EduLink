using Application.Dtos.Common;
using Application.Dtos.Location;
using Application.Dtos.User;
using Application.Enums;
using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
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

        public async Task<UserResponseDto> GetStudentAsync(
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

        public async Task<ICollection<UserResponseDto>> GetStudentsAsync(
            string tutorUsername,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            var tutor = await GetTutorAsync(tutorUsername, cancellationToken);

            return await _userRepository.Query()
                .Where(user => user.IsStudentOfTutor(tutorUsername))
                .ProjectToDto()
                .ToListAsync(cancellationToken);
        }

        public async Task<UserResponseDto> GetTutorAsync(
            string tutorUsername,
            CancellationToken cancellationToken = default)
        {
            var tutor = await _userRepository.Query()
                .Where(user => user.IsTutor())
                .ProjectTutorToDto()
                .FirstOrDefaultAsync(tutor =>
                    tutor.Username == tutorUsername.ToNormalizedLower(),
                    cancellationToken);

            return tutor ?? throw new NotFoundException<User>(tutorUsername);
        }

        public async Task<bool> UserExistsAsync(
            string username,
            CancellationToken cancellationToken = default) =>
            await _userRepository
                .AnyAsync(user =>
                    user.Username == username.ToNormalizedLower(),
                    cancellationToken);

        public async Task<bool> IsTutorAsync(
            string username,
            CancellationToken cancellationToken = default) =>
            await _userRepository
                .AnyAsync(user =>
                    user.Username == username.ToNormalizedLower()
                    && user.IsTutor());

        public async Task<bool> IsEligibleAsTutor(
            string username,
            CancellationToken cancellationToken = default)
        {
            var result = await GetByUsernameAsync(username, cancellationToken);

            return result.IsEligibleAsTutor;
        }

        public async Task<ICollection<UserResponseDto>> GetTutorsInCityAsync(
            string countryName,
            string regionName,
            string cityName,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            var city = await _locationService.FindCity(countryName, regionName, cityName);

            var tutors = await _userRepository.Query()
                .Where(user => user.IsTutor())
                .Where(tutor => tutor.CityId == city.Id)
                .SortTutors(sortOptions ?? new SortRequestDto { SortByProperty = SortByProperty.Rating, SortOrder = SortOrder.Descending })
                .Paginate(paginationOptions ?? new PaginationRequestDto { Skip = 0, Take = 25 })
                .ProjectTutorToDto()
                .ToListAsync(cancellationToken);

            return tutors;
        }

        public async Task<ICollection<UserResponseDto>> GetTutorsInRegionAsync(
            string countryName,
            string regionName,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            var region = await _locationService.FindRegion(countryName, regionName);

            var tutors = await _userRepository.Query()
                .Where(user => user.IsTutor())
                .Where(tutor => tutor.City.RegionId == region.Id)
                .SortTutors(sortOptions ?? new SortRequestDto { SortByProperty = SortByProperty.Rating, SortOrder = SortOrder.Descending })
                .Paginate(paginationOptions ?? new PaginationRequestDto { Skip = 0, Take = 25 })
                .ProjectTutorToDto()
                .ToListAsync(cancellationToken);

            return tutors;
        }
    }
}
