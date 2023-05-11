namespace Application.Exceptions
{
    public class NotFoundException : InvalidOperationException
    {
        public NotFoundException() { }
        public NotFoundException(string? message) : base(message) { }
        public NotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    }

    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException() { }
        public UserNotFoundException(string? message) : base(message) { }
        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
