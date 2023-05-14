using Application.Dtos.Common;
using Application.Dtos.User;
using Data.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<ICollection<UserResponseDto>> GetTutorsInCityAsync(
            string countryName,
            string regionName,
            string cityName,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortDto = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<UserResponseDto>> GetTutorsInRegionAsync(
            string countryName,
            string regionName,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<UserResponseDto>> GetStudentsAsync(
            string tutorUsername,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        public Task<UserResponseDto> GetTutorAsync(
            string tutorUsername,
            CancellationToken cancellationToken = default);

        public Task<UserResponseDto> GetStudentAsync(
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
        internal Task<bool> IsTutorAsync(string username, CancellationToken cancellationToken = default);
        internal Task<bool> UserExistsAsync(string username, CancellationToken cancellationToken = default);
        internal Task<bool> IsEligibleAsTutor(string username, CancellationToken cancellationToken = default);
    }
}
