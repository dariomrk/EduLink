namespace Application.Exceptions
{
    public class IdentityException : InvalidOperationException
    {
        internal IdentityException(string identity, string request)
            : base($"Request `{request}` cannot be performed by the entity `{identity}`.")
        { }
    }
}
