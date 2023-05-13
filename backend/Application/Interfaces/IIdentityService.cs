using Application.Dtos.Indentity;
using Application.Dtos.User;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IIdentityService
    {
        public Task<(ServiceActionResult Result, UserResponseDto? Created, TokenRequestDto? Token)> RegisterAsync(
            RegisterRequestDto registerDto);

        public Task<(IdentityActionResult Result, TokenRequestDto Token)> LoginAsync(
            LoginRequestDto loginDto);
    }
}
