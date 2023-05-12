namespace Application.Extensions
{
    internal static class StringExtensions
    {
        internal static string ToNormalizedLower(this string input)
        {
            return input
                .Trim()
                .Normalize()
                .ToLower();
        }
    }
}
