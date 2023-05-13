using Application.Dtos.Common;
using Application.Dtos.TutoringPost;
using Application.Enums;
using Application.Interfaces;

namespace Application.Services
{
    public class TutoringPostService : ITutoringPostService
    {
        public Task<(ServiceActionResult Result, ResponseDto? Created)> CreateTutoringPostAsync(CreateTutoringPostDto post)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetTutoringPostAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetTutoringPostsAsync(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            RequestPaginationDto? paginationOptions = null,
            RequestSortDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
