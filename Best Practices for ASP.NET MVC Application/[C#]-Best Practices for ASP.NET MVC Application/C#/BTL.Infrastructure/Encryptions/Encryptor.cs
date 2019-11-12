#region

using System;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace BTL.Infrastructure.Encryptions
{
    public class Encryptor : IEncryptor
    {
        public string Encode(string source)
        {
            var hashBytes = new SHA1Managed().ComputeHash(Encoding.ASCII.GetBytes(source));
            return BitConverter.ToString(hashBytes);
        }
    }
}