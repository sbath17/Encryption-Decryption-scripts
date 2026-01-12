using System.Security.Cryptography;
using System.Text;

namespace SecureNotesCLI.Services
{
    public class EncryptionService
    {
        public byte[] Encrypt(string plainText, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using var encryptor = aes.CreateEncryptor();
            byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
            return encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
        }

        public string Decrypt(byte[] cipherBytes, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            byte[] decrypted = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return Encoding.UTF8.GetString(decrypted);
        }
    }
}