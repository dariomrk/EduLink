using Application.Enums;
using Application.Models;
using Data.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<ICollection<User>> GetTutors(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            PaginationDto? paginationOptions = null,
            SortOrder sortOrder = SortOrder.Ascending,
            UserSortProperties orderBy = UserSortProperties.Rating,
            CancellationToken cancellationToken = default);

        public Task<ICollection<User>> GetStudents(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            PaginationDto? paginationOptions = null,
            SortOrder sortOrder = SortOrder.Ascending,
            UserSortProperties orderBy = UserSortProperties.Rating,
            CancellationToken cancellationToken = default);

        public Task<User> GetTutorAsync(
            long id,
            CancellationToken cancellationToken = default);

        public Task<User> GetStudentAsync(
            long id,
            CancellationToken cancellationToken = default);

    }
}
