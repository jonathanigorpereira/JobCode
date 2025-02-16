using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JobCode.Core.Services
{
    public interface IEncryptionService
    {
        string EncryptingHash(string text);
        string GetHash(HashAlgorithm sha256Hash, string text);
    }
}
