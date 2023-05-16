namespace Application.Exceptions
{
    public class InvalidRequestException : InvalidOperationException
    {
        internal InvalidRequestException() { }
        public InvalidRequestException(string? message) : base(message) { }
        internal InvalidRequestException(string? message, Exception? innerException) : base(message, innerException) { }
    }

    public class InvalidRequestException<TEntity> : InvalidRequestException where TEntity : class
    {
        internal InvalidRequestException(string requestName, object? argument)
            : base($"Request '{requestName}' on '{nameof(TEntity)}' entity with argument " +
                  $"'{argument?.ToString() ?? "null"}' could not processed.")
        { }
    }
}
