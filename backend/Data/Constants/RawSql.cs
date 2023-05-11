namespace Data.Constants
{
    public static class RawSql
    {
        public const string Timestamp = "now()";
        public const string TimestampUtc = "timezone('utc', now())";
    }
}
