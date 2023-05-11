namespace Application.Exceptions
{
    public class InvalidRequestException : InvalidOperationException
    {
        public InvalidRequestException() { }
        public InvalidRequestException(string? message) : base(message) { }
        public InvalidRequestException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
