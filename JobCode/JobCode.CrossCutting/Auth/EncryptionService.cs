using JobCode.Core.Services;
using JobCode.CrossCutting.Auth;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace JobCode.CrossCutting.Auth
{
    public class EncryptionService : IEncryptionService
    {
        public string EncryptingHash(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return GetHash(sha256, text);
            }
        }

        public string GetHash(HashAlgorithm sha256Hash, string text)
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
