﻿using Application.Constants;
using Application.Dtos.Common;
using Application.Dtos.TutoringPost;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = Roles.User)]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ITutoringPostService _postService;

        public PostsController(ITutoringPostService postService)
        {
            _postService = postService;
        }

        [AllowAnonymous]
        [HttpGet(Endpoints.Posts.GetAllPostsFromCountry)]
        public async Task<ActionResult<ICollection<TutoringPostResponseDto>>> GetAllPostsFromCountry(
            [FromRoute] string countryName,
            [FromQuery] SortRequestDto sortOptions,
            [FromQuery] PaginationRequestDto paginationOptions,
            CancellationToken cancellationToken)
        {
            var posts = await _postService.GetTutoringPostsFromCountryAsync(
                countryName,
                paginationOptions,
                sortOptions,
                cancellationToken);

            return Ok(posts);
        }

        [AllowAnonymous]
        [HttpGet(Endpoints.Posts.GetAllPostsFromRegion)]
        public async Task<ActionResult<ICollection<TutoringPostResponseDto>>> GetAllPostsFromRegion(
            [FromRoute] string countryName,
            [FromRoute] string regionName,
            [FromQuery] SortRequestDto sortOptions,
            [FromQuery] PaginationRequestDto paginationOptions,
            CancellationToken cancellationToken)
        {
            var posts = await _postService.GetTutoringPostsFromRegionAsync(
                countryName,
                regionName,
                paginationOptions,
                sortOptions,
                cancellationToken);

            return Ok(posts);
        }

        [AllowAnonymous]
        [HttpGet(Endpoints.Posts.GetAllPostsFromSubject)]
        public async Task<ActionResult<ICollection<TutoringPostResponseDto>>> GetAllPosts(
            [FromRoute] string countryName,
            [FromRoute] string regionName,
            [FromRoute] string subjectName,
            [FromQuery] SortRequestDto sortOptions,
            [FromQuery] PaginationRequestDto paginationOptions,
            CancellationToken cancellationToken)
        {
            var posts = await _postService.GetTutoringPostsFromSubjectAsync(
                countryName,
                regionName,
                subjectName,
                paginationOptions,
                sortOptions,
                cancellationToken);

            return Ok(posts);
        }

        [AllowAnonymous]
        [HttpGet(Endpoints.Posts.GetPost)]
        public async Task<ActionResult<ICollection<TutoringPostResponseDto>>> GetPost(
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            var post = await _postService.GetTutoringPostAsync(
                id,
                cancellationToken);

            return Ok(post);
        }

        [HttpPost(Endpoints.Posts.CreatePost)]
        public async Task<ActionResult<TutoringPostResponseDto>> CreatePost([FromBody] TutoringPostRequestDto postRequest)
        {
            var (result, created) = await _postService.CreateTutoringPostAsync(postRequest);

            if (result is not Application.Enums.ServiceActionResult.Created)
                return BadRequest();
            return Ok(created);
        }
    }
}
