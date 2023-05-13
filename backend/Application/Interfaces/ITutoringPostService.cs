using Application.Dtos.Common;
using Application.Dtos.TutoringPost;
using Application.Enums;

namespace Application.Interfaces
{
    public interface ITutoringPostService
    {
        public Task<ICollection<ResponseDto>> GetTutoringPostsAsync(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            RequestPaginationDto? paginationOptions = null,
            RequestSortDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ResponseDto> GetTutoringPostAsync(
            long id,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, ResponseDto? Created)> CreateTutoringPostAsync(
           RequestDto post);

        public Task<ICollection<ResponseDto>> GetAvailableTutoringPostsAsync(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            RequestPaginationDto? paginationOptions = null,
            RequestSortDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        internal Task<bool> TutoringPostExists(
            long tutoringPostId,
            CancellationToken cancellationToken = default);
    }
}
