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
            long id,
            CancellationToken cancellationToken = default);

        public Task<UserDto> GetStudentAsync(
            string tutorUsername,
            long id,
            CancellationToken cancellationToken = default);

        Task<User?> GetByUsernameOrDefault(
            string username,
            CancellationToken cancellationToken = default);

        Task<User> GetByUsername(
            string username,
            CancellationToken cancellationToken = default);

        Task<User?> GetByEmailOrDefault(
            string email,
            CancellationToken cancellationToken = default);

        Task<User> GetByEmail(
            string email,
            CancellationToken cancellationToken = default);
    }
}
