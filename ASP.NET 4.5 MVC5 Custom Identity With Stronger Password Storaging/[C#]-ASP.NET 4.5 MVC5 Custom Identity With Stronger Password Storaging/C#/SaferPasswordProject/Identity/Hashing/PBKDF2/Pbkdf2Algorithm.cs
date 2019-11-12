using System;
using System.Security.Cryptography;
using System.Text;

namespace TM.Hashing
{
    public static class Pbkdf2Algorithm
    {
        private static string ClearTextPassword { get; set; }
        private static byte[] Salt { get; set; }
        private static int Iterations { get; set; }

        private const int _saltSize = 16;
        private const int _hashSize = 47;
        private const int _finalHashSize = _saltSize + _hashSize + 1;
        private const int _iterationCount = 10000;
        private const char _splitter = '/';

        public static string HashPassword(string password, int iterations)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, _saltSize, iterations))
            {
                salt = bytes.S;
                buffer2 = bytes.GetBytes(_hashSize);
            }
            byte[] dst = new byte[_saltSize + _hashSize + 1];
            Buffer.BlockCopy(salt, 0, dst, 1, _saltSize);
            Buffer.BlockCopy(buffer2, 0, dst, _saltSize + 1, _hashSize);
            return string.Format("{0}{2}{1}", iterations, Convert.ToBase64String(dst), _splitter);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] inputPwHash;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            int splitter = hashedPassword.IndexOf(_splitter);

            //Iterations
            int i;
            if (!int.TryParse(hashedPassword.Substring(0, splitter), out i))
                i = _iterationCount;
            //Hash
            string h = hashedPassword.Substring(splitter + 1);

            byte[] src = Convert.FromBase64String(h);
            if ((src.Length != _finalHashSize) || (src[0] != 0))
            {
                return false;
            }
            byte[] extractedSalt = new byte[_saltSize];
            Buffer.BlockCopy(src, 1, extractedSalt, 0, _saltSize);
            byte[] storedPwHash = new byte[_hashSize];
            Buffer.BlockCopy(src, _saltSize + 1, storedPwHash, 0, _hashSize);

            

            using (TM.Hashing.Rfc2898DeriveBytes bytes = new TM.Hashing.Rfc2898DeriveBytes(password, extractedSalt, i))
            {
                inputPwHash = bytes.GetBytes(_hashSize);
            }

            return SlowEquals(storedPwHash, inputPwHash);
        }

        /// <summary>
        /// Compares two byte arrays in length-constant time. This comparison
        /// method is used so that password hashes cannot be extracted from
        /// on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first byte array.</param>
        /// <param name="b">The second byte array.</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }
}
