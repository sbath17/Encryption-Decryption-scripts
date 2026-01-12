using System.Security.Cryptography;

namespace SecureNotesCLI.Services
{
    public class KeyService
    {
        public byte[] DeriveKey(string password, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            return pbkdf2.GetBytes(32); // AES-256
        }
    }
}