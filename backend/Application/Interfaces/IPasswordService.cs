namespace Application.Interfaces
{
    public interface IPasswordService
    {
        internal bool ComparePassword(string password, byte[] hash, byte[] salt, int iterations);
        internal (byte[] PasswordHash, byte[] Salt) GeneratePassword(string password, int iterations, int hashLength, int saltLength);
    }
}
