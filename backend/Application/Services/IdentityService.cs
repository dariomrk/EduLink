using Application.Constants;
using Application.Dtos.Indentity;
using Application.Dtos.User;
using Application.Enums;
using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Data.Interfaces;
using Data.Models;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User, long> _userRepository;
        private readonly IUserService _userService;
        private readonly IValidator<RegisterRequestDto> _registerRequestValidator;
        private readonly IPasswordService _passwordService;
        private readonly ILocationService _locationService;
        private readonly ILogger<IdentityService> _logger;

        public IdentityService(
            IConfiguration configuration,
            IRepository<User, long> userRepository,
            IUserService userService,
            IValidator<RegisterRequestDto> registerRequestValidator,
            IPasswordService passwordService,
            ILocationService locationService,
            ILogger<IdentityService> logger)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _userService = userService;
            _registerRequestValidator = registerRequestValidator;
            _passwordService = passwordService;
            _locationService = locationService;
            _logger = logger;
        }

        public async Task<(IdentityActionResult Result, TokenResponseDto? Token)> LoginAsync(LoginRequestDto loginDto)
        {
            User user;

            if (loginDto.Email is not null)
                user = await _userService.GetByEmailAsync(loginDto.Email.ToNormalizedLower());

            else if (loginDto.Username is not null)
                user = await _userService.GetByUsernameAsync(loginDto.Username.ToNormalizedLower());

            else
                throw new InvalidRequestException<User>(nameof(LoginAsync), null);

            var comparasionResult = _passwordService.ComparePassword(
                loginDto.Password,
                user.PasswordHash,
                user.PasswordHash,
                _configuration.GetValue<int>("Security:PasswordHashIterations"));

            if (comparasionResult is false)
                return (IdentityActionResult.Rejected, null);

            return (
                IdentityActionResult.Authenticated,
                new TokenResponseDto
                {
                    Jwt = GenerateUserJwt(
                        user.Id,
                        user.Username,
                        user.Email),
                });
        }

        public async Task<(ServiceActionResult Result, UserResponseDto? Created, TokenResponseDto? Token)> RegisterAsync(RegisterRequestDto registerDto)
        {
            await _registerRequestValidator.ValidateAndThrowAsync(registerDto);

            var iterations = _configuration.GetValue<int>("Security:PasswordHashIterations");
            var hashLenght = _configuration.GetValue<int>("Security:HashLengthBytes");
            var saltLength = _configuration.GetValue<int>("Security:SaltLengthBytes");

            var (passwordHash, salt) = _passwordService.GeneratePassword(
                registerDto.Password,
                iterations,
                hashLenght,
                saltLength);

            var city = await _locationService.FindCity(
                registerDto.CountryName,
                registerDto.RegionName,
                registerDto.CityName);

            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email.ToNormalizedLower(),
                Username = registerDto.Username.ToNormalizedLower(),
                PasswordHash = passwordHash,
                Salt = salt,
                DateOfBirth = registerDto.DateOfBirth,
                CityId = city.Id,
                MobileNumber = registerDto.MobileNumber,
                // TODO: Generate Stripe related information during registration
            };

            var (result, created) = await _userRepository.CreateAsync(user);

            if (result is not Data.Enums.RepositoryActionResult.Success)
                return (ServiceActionResult.Failed, null, null);

            return (
                ServiceActionResult.Created,
                created!.ToDto(),
                new TokenResponseDto
                {
                    Jwt = GenerateUserJwt(
                        created!.Id,
                        created!.Username,
                        created!.Email),
                });
        }

        public string GenerateUserJwt(
            long userId,
            string username,
            string email,
            string role = Roles.User)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Identity:TokenSecret")!);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new(ClaimTypes.Role, role),
                new(ClaimTypes.NameIdentifier, username),
                new(ClaimTypes.Email, email),
            };

            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Identity:JwtLifetimeMinutes")),
                Issuer = _configuration.GetValue<string>("Identity:Issuer")!,
                Audience = _configuration.GetValue<string>("Identity:Audience")!,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptior);
            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }

        // TODO: Implement Refresh Token generation and consumption
    }
}
