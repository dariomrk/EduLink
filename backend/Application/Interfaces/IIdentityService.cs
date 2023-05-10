using Application.Dtos.Indentity;
using Application.Dtos.User;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IIdentityService
    {
        public Task<(ServiceActionResult Result, UserDto? Created, TokenDto? Token)> RegisterAsync(
            RegisterDto registerDto);

        public Task<(IdentityActionResult Result, TokenDto Token)> LoginAsync(
            LoginDto loginDto);
    }
}
