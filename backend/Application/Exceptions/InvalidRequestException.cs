namespace Application.Exceptions
{
    public class InvalidRequestException : InvalidOperationException
    {
        public InvalidRequestException() { }
        public InvalidRequestException(string? message) : base(message) { }
        public InvalidRequestException(string? message, Exception? innerException) : base(message, innerException) { }
    }

    public class InvalidRequestException<TEntity> : InvalidRequestException where TEntity : class
    {
        public InvalidRequestException(string requestName, object argument)
            : base($"Request '{requestName}' on '{nameof(TEntity)}' entity with argument " +
                  $"'{argument?.ToString() ?? "null"}' could not processed.")
        { }
    }
}
