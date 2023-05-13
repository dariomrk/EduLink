﻿using Application.Dtos.Common;
using Application.Dtos.TutoringPost;
using Application.Enums;

namespace Application.Interfaces
{
    public interface ITutoringPostService
    {
        public Task<ICollection<TutoringPostResponseDto>> GetTutoringPostsAsync(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        public Task<TutoringPostResponseDto> GetTutoringPostAsync(
            long id,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, TutoringPostResponseDto? Created)> CreateTutoringPostAsync(
           TutoringPostRequestDto post);

        public Task<ICollection<TutoringPostResponseDto>> GetAvailableTutoringPostsAsync(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        internal Task<bool> TutoringPostExistsAsync(
            long tutoringPostId,
            CancellationToken cancellationToken = default);
    }
}
