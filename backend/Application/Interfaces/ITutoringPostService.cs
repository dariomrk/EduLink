using Application.Dtos.Common;
using Application.Dtos.TutoringPost;
using Application.Enums;

namespace Application.Interfaces
{
    public interface ITutoringPostService
    {
        public Task<TutoringPostDto> GetTutoringPostsAsync(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            PaginationDto? paginationOptions = null,
            SortOrder sortOrder = SortOrder.Ascending,
            SortProperties orderBy = SortProperties.Rating,
            CancellationToken cancellationToken = default);

        public Task<TutoringPostDto> GetTutoringPostAsync(
            long id,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, TutoringPostDto? Created)> CreateTutoringPostAsync(
           CreateDto post);
    }
}
