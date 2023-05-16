using System.Security.Claims;

namespace Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetUsername(this ClaimsPrincipal principal) =>
            principal.FindFirstValue(ClaimTypes.Name);

        public static string? GetEmail(this ClaimsPrincipal principal) =>
            principal.FindFirstValue(ClaimTypes.Email);
    }
}
