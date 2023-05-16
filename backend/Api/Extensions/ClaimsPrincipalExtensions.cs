using Application.Exceptions;
using System.Security.Claims;

namespace Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUsername(this ClaimsPrincipal principal) =>
            principal.FindFirstValue(ClaimTypes.Name)
            ?? throw new InvalidRequestException(
                $"Request does not include the ´{ClaimTypes.Name}´ claim in the bearer token.");

        public static string GetEmail(this ClaimsPrincipal principal) =>
            principal.FindFirstValue(ClaimTypes.Email)
            ?? throw new InvalidRequestException(
                $"Request does not include the ´{ClaimTypes.Email}´ claim in the bearer token.");
    }
}
