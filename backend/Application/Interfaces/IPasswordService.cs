namespace Application.Interfaces
{
    public interface IPasswordService
    {
        internal (byte[] PasswordHash, byte[] Salt) GeneratePassword(string password, int iterations, int hashLength, int saltLength);
    }
}
