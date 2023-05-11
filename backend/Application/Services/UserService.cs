using Application.Dtos.Common;
using Application.Dtos.User;
using Application.Enums;
using Application.Exceptions;
using Application.Interfaces;
using Application.Mappings;
using Application.Utils;
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
        private readonly ILogger<UserService> _logger;

        public UserService(
            IRepository<User, long> userRepository,
            IRepository<Appointment, long> appointmentRepository,
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _appointmentRepository = appointmentRepository;
            _logger = logger;
        }

        private async Task<User?> GetByUsernameOrDefault(
            string username,
            CancellationToken cancellationToken = default)
        {
            return await _userRepository
                .FindAsync(user => user.Username == username.ToNormalizedLower(), cancellationToken);
        }

        private async Task<User> GetByUsername(
            string username,
            CancellationToken cancellationToken = default)
        {
            return await GetByUsernameOrDefault(username, cancellationToken)
                ?? throw new UserNotFoundException();
        }

        private async Task<User?> GetByEmailOrDefault(
            string email,
            CancellationToken cancellationToken = default)
        {
            return await _userRepository
                .FindAsync(user => user.Email == email.ToNormalizedLower(), cancellationToken);
        }

        private async Task<User> GetByEmail(
            string email,
            CancellationToken cancellationToken = default)
        {
            return await GetByEmailOrDefault(email, cancellationToken)
                ?? throw new UserNotFoundException(email);
        }

        public async Task<UserDto> GetStudentAsync(
            string myUsername,
            long id,
            CancellationToken cancellationToken = default)
        {
            var tutor = await GetByUsername(myUsername, cancellationToken);

            var student = await _appointmentRepository.Query()
                .Where(appointment => appointment.StudentId == id)
                .Select(appointment => appointment.Student)
                .FirstOrDefaultAsync(cancellationToken);

            return student?.ToDto() ?? throw new UserNotFoundException();
        }

        public Task<ICollection<UserDto>> GetStudentsAsync(
            string myUsername,
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            PaginationDto? paginationOptions = null,
            SortOrder sortOrder = SortOrder.Ascending,
            SortProperties orderBy = SortProperties.Rating,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetTutorAsync(
            long id,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserDto>> GetTutorsAsync(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            PaginationDto? paginationOptions = null,
            SortOrder sortOrder = SortOrder.Ascending,
            SortProperties orderBy = SortProperties.Rating,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
