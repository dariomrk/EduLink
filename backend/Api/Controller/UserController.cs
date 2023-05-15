using Application.Dtos.Common;
using Application.Dtos.User;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet(Routes.Users.GetTutorsInCity)]
        public async Task<ActionResult<UserResponseDto>> GetTutorsInCity(
           [FromRoute] string countryName,
           [FromRoute] string regionName,
           [FromRoute] string cityName,
           PaginationRequestDto? paginationDto,
            SortRequestDto? sortOptions,
            CancellationToken cancellationToken = default)
        {
            var result = await _userService.GetTutorsInCityAsync(countryName, regionName, cityName, paginationDto, sortOptions, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result.ToDto());
        }

        [HttpGet(Routes.Users.GetTutorsInRegion)]
        public async Task<ActionResult<UserResponseDto>> GetTutorsInRegion(
           [FromRoute] string countryName,
           [FromRoute] string regionName,
           PaginationRequestDto? paginationDto,
            SortRequestDto? sortOptions,
            CancellationToken cancellationToken = default)
        {
            var result = await _userService.GetTutorsInRegionAsync(countryName, regionName, paginationDto, sortOptions, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result.ToDto());
        }

        [HttpGet(Routes.Users.GetStudents)]
        public async Task<ActionResult<UserResponseDto>> GetAllStudents(
           string tutorUsername, //jwt
           PaginationRequestDto? paginationDto,
            SortRequestDto? sortOptions,
            CancellationToken cancellationToken = default)
        {
            var result = await _userService.GetStudentsAsync(tutorUsername, paginationDto, sortOptions, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result.ToDto());
        }

        [HttpGet(Routes.Users.GetStudents)]
        public async Task<ActionResult<UserResponseDto>> GetStudents(
            [FromRoute] string tutorUsername,
           PaginationRequestDto? paginationDto,
            SortRequestDto? sortOptions,
            CancellationToken cancellationToken)
        {
            var result = await _userService.GetStudentsAsync(tutorUsername, paginationDto, sortOptions, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result.ToDto());
        }

        [HttpGet(Routes.Users.GetTutor)]
        public async Task<ActionResult<UserResponseDto>> FindTutor(
            [FromRoute] string tutorUsername,
            CancellationToken cancellationToken)
        {
            var result = await _userService.GetTutorAsync(tutorUsername, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result.ToDto());
        }

        [HttpGet(Routes.Users.GetStudent)]
        public async Task<ActionResult<UserResponseDto>> FindStudent(
            string tutorUsername, //jwt
            [FromRoute] long studentId,
            CancellationToken cancellationToken)
        {
            var result = await _userService.GetStudentAsync(tutorUsername, studentId, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result.ToDto());
        }        
    }
}
