using Application.Dtos.Common;
using Application.Dtos.User;
using Application.Enums;
using Application.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        public Task<UserDto> GetStudentAsync(string myUsername, long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserDto>> GetStudentsAsync(string myUsername, string? countryName = null, string? regionName = null, string? cityName = null, PaginationDto? paginationOptions = null, SortOrder sortOrder = SortOrder.Ascending, SortProperties orderBy = SortProperties.Rating, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetTutorAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserDto>> GetTutorsAsync(string? countryName = null, string? regionName = null, string? cityName = null, PaginationDto? paginationOptions = null, SortOrder sortOrder = SortOrder.Ascending, SortProperties orderBy = SortProperties.Rating, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
