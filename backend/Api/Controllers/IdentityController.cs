﻿using Application.Dtos.Indentity;
using Application.Enums;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(Endpoints.Identity.Register)]
        public async Task<ActionResult<TokenResponseDto>> Register(
            [FromBody] RegisterRequestDto registerRequest,
            CancellationToken cancellationToken)
        {
            var (result, _, token) = await _identityService.RegisterAsync(registerRequest);

            if (result is not ServiceActionResult.Created)
                return BadRequest();
            return Ok(token);
        }

        [HttpPost(Endpoints.Identity.Login)]
        public async Task<ActionResult<TokenResponseDto>> Login(
            [FromBody] LoginRequestDto loginRequest,
            CancellationToken cancellationToken)
        {
            var (result, token) = await _identityService.LoginAsync(loginRequest);

            if (result is not IdentityActionResult.Authenticated)
                return Unauthorized();
            return Ok(token);
        }
    }
}
