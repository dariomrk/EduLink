using Application.Dtos.Common;
using Application.Dtos.TutoringPost;
using Application.Enums;
using Application.Interfaces;

namespace Application.Services
{
    public class TutoringPostService : ITutoringPostService
    {
        public Task<(ServiceActionResult Result, TutoringPostDto? Created)> CreateTutoringPostAsync(CreateTutoringPostDto post)
        {
            throw new NotImplementedException();
        }

        public Task<TutoringPostDto> GetTutoringPostAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TutoringPostDto> GetTutoringPostsAsync(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            PaginationDto? paginationOptions = null,
            SortDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
