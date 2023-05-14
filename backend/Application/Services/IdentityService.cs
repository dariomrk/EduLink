using Application.Dtos.Indentity;
using Application.Dtos.User;
using Application.Enums;
using Application.Interfaces;

namespace Application.Services
{
    public class IdentityService : IIdentityService
    {
        public Task<(IdentityActionResult Result, TokenResponseDto Token)> LoginAsync(LoginRequestDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<(ServiceActionResult Result, UserResponseDto? Created, TokenResponseDto? Token)> RegisterAsync(RegisterRequestDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
