namespace Application.Extensions
{
    public static class StringExtensions
    {
        public static string ToNormalizedLower(this string input)
        {
            return input
                .Trim()
                .Normalize()
                .ToLower();
        }
    }
}
