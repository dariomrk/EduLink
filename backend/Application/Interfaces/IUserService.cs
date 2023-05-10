using Application.Dtos.Common;
using Application.Dtos.User;
using Application.Enums;

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
            long id,
            CancellationToken cancellationToken = default);
    }
}
