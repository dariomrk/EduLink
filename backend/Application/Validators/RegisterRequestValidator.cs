using Application.Dtos.Indentity;
using Application.Extensions;
using Application.Interfaces;
using FluentValidation;

namespace Application.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
    {
        private readonly IUserService _userService;
        private readonly ILocationService _locationService;

        public RegisterRequestValidator(
            IUserService userService,
            ILocationService locationService)
        {
            _userService = userService;
            _locationService = locationService;

            RuleFor(register => register.Username)
                .NotEmpty()
                .MinimumLength(4)
                .MustAsync(async (username, cancellationToken) =>
                {
                    var result = await _userService.GetByUsernameOrDefaultAsync(username.ToNormalizedLower());

                    return result is null;
                })
                .WithMessage(username => $"Username `{username}` is already taken.");

            RuleFor(register => register.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Minimum password length is 8 characters.");

            RuleFor(register => register.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(register => register.FirstName)
                .NotEmpty();

            RuleFor(register => register.LastName)
                .NotEmpty();

            RuleFor(register => register.DateOfBirth)
                .NotEmpty()
                .LessThan(DateOnly.FromDateTime(DateTime.UtcNow));

            RuleFor(register => register.CountryName)
                .NotEmpty();

            RuleFor(register => register.RegionName)
                .NotEmpty();

            RuleFor(register => register.CityName)
                .NotEmpty();

            RuleFor(register => register.CityName)
                .MustAsync(async (register, cityName, cancellationToken) =>
                    await _locationService.CityExists(
                        register.CountryName,
                        register.RegionName,
                        register.CityName,
                        cancellationToken))
                .WithMessage((register, cityName) => $"City `{cityName}` does not exist in `{register.CountryName} - {register.RegionName}`.");

            // TODO: Improve mobile number validation during registration
            // - Send verification code
            RuleFor(register => register.MobileNumber)
                .NotEmpty()
                .Length(10);
        }
    }
}
