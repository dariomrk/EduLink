using Application.Constants;
using Application.Dtos.Common;
using Application.Dtos.User;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Policy = Roles.User)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet(Endpoints.Users.GetAllTutorsInRegion)]
        public async Task<ActionResult<ICollection<UserResponseDto>>> GetAllTutorsInRegion(
            [FromRoute] string countryName,
            [FromRoute] string regionName,
            [FromQuery] SortRequestDto sortOptions,
            [FromQuery] PaginationRequestDto paginationOptions,
            CancellationToken cancellationToken)
        {
            var tutors = await _userService.GetTutorsInRegionAsync(
                countryName,
                regionName,
                paginationOptions,
                sortOptions,
                cancellationToken);

            return Ok(tutors);
        }

        [AllowAnonymous]
        [HttpGet(Endpoints.Users.GetAllTutorsInCity)]
        public async Task<ActionResult<ICollection<UserResponseDto>>> GetAllTutorsInCity(
            [FromRoute] string countryName,
            [FromRoute] string regionName,
            [FromRoute] string cityName,
            [FromQuery] SortRequestDto sortOptions,
            [FromQuery] PaginationRequestDto paginationOptions,
            CancellationToken cancellationToken)
        {
            var tutors = await _userService.GetTutorsInCityAsync(
                countryName,
                regionName,
                cityName,
                paginationOptions,
                sortOptions,
                cancellationToken);

            return Ok(tutors);
        }

        [HttpGet(Endpoints.Users.GetAllStudents)]
        public async Task<ActionResult<ICollection<UserResponseDto>>> GetAllStudents(
            [FromQuery] SortRequestDto sortOptions,
            [FromQuery] PaginationRequestDto paginationOptions,
            CancellationToken cancellationToken)
        {
            var headers = Request.Headers;

            throw new NotImplementedException();
        }
    }
}
