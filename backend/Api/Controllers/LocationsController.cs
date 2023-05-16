using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet(Endpoints.Locations.GetAllFromCountry)]
        public async Task<ActionResult<object>> GetAllFromCountry(
            [FromRoute] string country,
            CancellationToken cancellationToken)
        {
            var result = await _locationService.GetAllFromCountryAsync(
                country,
                cancellationToken);

            return Ok(result);
        }
    }
}
