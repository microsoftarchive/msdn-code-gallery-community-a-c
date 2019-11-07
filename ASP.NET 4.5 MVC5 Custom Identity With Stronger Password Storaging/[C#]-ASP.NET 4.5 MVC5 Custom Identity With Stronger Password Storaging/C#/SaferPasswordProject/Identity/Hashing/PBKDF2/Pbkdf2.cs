using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace TM.Hashing
{
    public static class Pbkdf2
    {
        public static string HashPassword(string password, int iterations)
        {
            return Pbkdf2Algorithm.HashPassword(password, iterations);
        }

        public static bool VerifyPassword(string plaintext, string hashed)
        {
            return Pbkdf2Algorithm.VerifyPassword(plaintext, hashed);
        }
    }
}
