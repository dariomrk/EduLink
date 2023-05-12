namespace Application.Exceptions
{
    public class NotFoundException : InvalidOperationException
    {
        public NotFoundException() { }
        public NotFoundException(string? message) : base(message) { }
        public NotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    }

    public class NotFoundException<TEntity> : NotFoundException where TEntity : class
    {
        public NotFoundException(object searchArgument)
            : base($"'{nameof(TEntity)}' entity with identifier '{searchArgument?.ToString() ?? "null"}' could not be found.") { }
    }
}
