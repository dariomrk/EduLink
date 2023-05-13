using Application.Dtos.Indentity;
using Application.Dtos.User;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IIdentityService
    {
        public Task<(ServiceActionResult Result, UserDto? Created, ResponseTokenDto? Token)> RegisterAsync(
            RequestRegisterDto registerDto);

        public Task<(IdentityActionResult Result, ResponseTokenDto Token)> LoginAsync(
            RequestLoginDto loginDto);
    }
}
