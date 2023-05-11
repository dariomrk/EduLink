namespace Application.Utils
{
    public static class StringUtils
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
