using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Replicon.Cryptography.SCrypt;

namespace TM.Hashing
{
    public static class SCrypt
    {
        public static string HashPassword(string password)
        {
            return SCryptAlgorithm.HashPassword(password);
        }
        public static string HashPassword(string password, ulong iterations)
        {
            iterations = (ulong)Math.Pow(2, iterations);
            return SCryptAlgorithm.HashPassword(password, iterations);
        }

        public static bool VerifyPassword(string plaintext, string hashed)
        {
            return SCryptAlgorithm.Verify(plaintext, hashed);
        }
    }
}
