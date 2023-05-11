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
                ?? throw new UserNotFoundException();
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
                ?? throw new UserNotFoundException(email);
        }

        public async Task<UserDto> GetStudentAsync(
            string tutorUsername,
            long studentId,
            CancellationToken cancellationToken = default)
        {
            var tutor = await GetByUsernameAsync(tutorUsername, cancellationToken);

            var student = await _appointmentRepository.Query()
                .Where(appointment => appointment.StudentId == studentId)
                .Select(appointment => appointment.Student)
                .FirstOrDefaultAsync(cancellationToken);

            return student?.ToDto() ?? throw new UserNotFoundException();
        }

        public async Task<ICollection<UserDto>> GetStudentsAsync(
            string tutorUsername,
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            PaginationDto? paginationOptions = null,
            SortOrder sortOrder = SortOrder.Ascending,
            SortProperties orderBy = SortProperties.Rating,
            CancellationToken cancellationToken = default)
        {
            var tutor = await GetByUsernameAsync(tutorUsername, cancellationToken);

            return await _appointmentRepository.Query()
                .Where(appointment => appointment.TutorId == tutor.Id)
                .Select(appointment => appointment.Student.ToDto())
                .ToListAsync(cancellationToken);
        }

        public async Task<UserDto> GetTutorAsync(
            string tutorUsername,
            CancellationToken cancellationToken = default)
        {
            var tutor = await _userRepository.Query()
                .Where(user => user.TutoringPosts.Any())
                .FirstOrDefaultAsync(user =>
                    user.Username == tutorUsername.ToNormalizedLower(),
                    cancellationToken);

            return tutor?.ToDto() ?? throw new UserNotFoundException();
        }

        public async Task<ICollection<UserDto>> GetTutorsAsync(
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
