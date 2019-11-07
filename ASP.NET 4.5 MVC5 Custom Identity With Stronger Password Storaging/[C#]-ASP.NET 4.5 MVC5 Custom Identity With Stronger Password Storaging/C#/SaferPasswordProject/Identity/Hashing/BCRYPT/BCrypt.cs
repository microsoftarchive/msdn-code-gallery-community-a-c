using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace TM.Hashing
{
    public static class BCrypt
    {
        public static string HashPassword(string password)
        {
            return HashPassword(password, BCryptAlgorithm.GenerateSalt());
        }
        private static string HashPassword(string password, string salt)
        {
            return BCryptAlgorithm.HashPassword(password, salt);
        }
        public static string HashPassword(string password, uint rounds)
        {
            return BCryptAlgorithm.HashPassword(password, BCryptAlgorithm.GenerateSalt(rounds));
        }
        public static bool VerifyPassword(string password, string hashed)
        {
            return BCryptAlgorithm.VerifyPassword(password, hashed);
        }
    }
}
