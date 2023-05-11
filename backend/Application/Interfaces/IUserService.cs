using Application.Dtos.Common;
using Application.Dtos.User;
using Application.Enums;
using Data.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<ICollection<UserDto>> GetTutorsAsync(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            PaginationDto? paginationOptions = null,
            SortOrder sortOrder = SortOrder.Ascending,
            SortProperties orderBy = SortProperties.Rating,
            CancellationToken cancellationToken = default);

        public Task<ICollection<UserDto>> GetStudentsAsync(
            string tutorUsername,
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            PaginationDto? paginationOptions = null,
            SortOrder sortOrder = SortOrder.Ascending,
            SortProperties orderBy = SortProperties.Rating,
            CancellationToken cancellationToken = default);

        public Task<UserDto> GetTutorAsync(
            string tutorUsername,
            CancellationToken cancellationToken = default);

        public Task<UserDto> GetStudentAsync(
            string tutorUsername,
            long studentId,
            CancellationToken cancellationToken = default);

        internal Task<User?> GetByUsernameOrDefaultAsync(
            string username,
            CancellationToken cancellationToken = default);

        internal Task<User> GetByUsernameAsync(
            string username,
            CancellationToken cancellationToken = default);

        internal Task<User?> GetByEmailOrDefaultAsync(
            string email,
            CancellationToken cancellationToken = default);

        internal Task<User> GetByEmailAsync(
            string email,
            CancellationToken cancellationToken = default);
    }
}
