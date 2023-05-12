using Application.Dtos.Common;
using Application.Dtos.User;
using Data.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<ICollection<UserDto>> GetTutorsInCityAsync(
            string countryName,
            string regionName,
            string cityName,
            PaginationDto? paginationOptions = null,
            SortDto? sortDto = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<UserDto>> GetTutorsInRegionAsync(
            string countryName,
            string regionName,
            PaginationDto? paginationOptions = null,
            SortDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<UserDto>> GetStudentsAsync(
            string tutorUsername,
            PaginationDto? paginationOptions = null,
            SortDto? sortOptions = null,
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
        Task<bool> IsTutorAsync(string username, CancellationToken cancellationToken = default);
        Task<bool> UserExistsAsync(string username, CancellationToken cancellationToken = default);
        Task<bool> IsEligibleAsTutor(string username, CancellationToken cancellationToken = default);
    }
}
