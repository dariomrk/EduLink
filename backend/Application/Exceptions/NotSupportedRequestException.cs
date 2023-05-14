namespace Application.Exceptions
{
    public class NotSupportedRequestException : NotSupportedException
    {
        public NotSupportedRequestException() { }
        public NotSupportedRequestException(string? message) : base(message) { }
        public NotSupportedRequestException(string? message, Exception? innerException) : base(message, innerException) { }
    }

    public class NotSupportedRequestException<TEntity> : NotSupportedRequestException where TEntity : class
    {
        internal NotSupportedRequestException(string requestName, object? argument)
            : base($"Request '{requestName}' on '{nameof(TEntity)}' entity with argument " +
                  $"'{argument?.ToString() ?? "null"}' is not supported.")
        { }
    }
}
