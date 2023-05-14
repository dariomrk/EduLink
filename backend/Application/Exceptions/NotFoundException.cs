namespace Application.Exceptions
{
    public class NotFoundException : InvalidOperationException
    {
        internal NotFoundException() { }
        internal NotFoundException(string? message) : base(message) { }
        internal NotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    }

    public class NotFoundException<TEntity> : NotFoundException where TEntity : class
    {
        internal NotFoundException(object? searchArgument)
            : base($"'{nameof(TEntity)}' entity with identifier '{searchArgument?.ToString() ?? "null"}' could not be found.") { }
    }
}
