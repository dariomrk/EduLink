using Application.Interfaces;
using System.Security.Cryptography;

namespace Application.Services
{
    public class PasswordService : IPasswordService
    {
        public (byte[] PasswordHash, byte[] Salt) GeneratePassword(string password, int iterations, int hashLength, int saltLength)
        {
            var salt = RandomNumberGenerator.GetBytes(saltLength);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512);
            var hash = pbkdf2.GetBytes(hashLength);

            pbkdf2.Dispose();

            return (hash, salt);
        }
    }
}
