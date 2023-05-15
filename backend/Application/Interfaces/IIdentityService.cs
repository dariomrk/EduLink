using Application.Dtos.Indentity;
using Application.Dtos.User;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IIdentityService
    {
        public Task<(ServiceActionResult Result, UserResponseDto? Created, TokenResponseDto? Token)> RegisterAsync(
            RegisterRequestDto registerDto);

        public Task<(IdentityActionResult Result, TokenResponseDto Token)> LoginAsync(
            LoginRequestDto loginDto);
        internal string GenerateUserJwt(long userId, string username, string email);
    }
}
