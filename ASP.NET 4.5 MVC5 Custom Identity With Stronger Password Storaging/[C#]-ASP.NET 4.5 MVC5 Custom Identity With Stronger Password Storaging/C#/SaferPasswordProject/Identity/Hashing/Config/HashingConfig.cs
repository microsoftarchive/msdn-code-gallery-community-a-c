using Replicon.Cryptography.SCrypt;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TM.Hashing
{
    public static class HashingConfig
    {
        public static bool VerifyPassword(string password, string hash)
        {
            try
            {
                //Add any other hashing algorithm you implement here
                switch (HashingAlgorithmType)
                {
                    case HashingAlgorithmTypeEnum.BCRYPT:
                        return BCrypt.VerifyPassword(password, hash);
                    case HashingAlgorithmTypeEnum.PBKDF2:
                        return Pbkdf2.VerifyPassword(password, hash);
                    case HashingAlgorithmTypeEnum.SCRYPT:
                        return SCrypt.VerifyPassword(password, hash);
                    default: return false;
                }
            }
            catch
            {
                ////Treat the exception here
                //throw new Exception("Error verifying the password!");

                //The most common reason for an error to occur here is to 
                //use a different algorithm type of the one used to hash
                //the password you are now comparing it to.

                //For now I'm just going to return false
                return false;
            }
        }

        public static string HashPassword(string password)
        {
            try
            {
                //Add any other hashing algorithm you implement here
                switch (HashingAlgorithmType)
                {
                    case HashingAlgorithmTypeEnum.BCRYPT:
                        return BCrypt.HashPassword(password, BCryptRounds);
                    case HashingAlgorithmTypeEnum.PBKDF2:
                        return Pbkdf2.HashPassword(password, PBKDF2Rounds);
                    case HashingAlgorithmTypeEnum.SCRYPT:
                        return SCrypt.HashPassword(password, SCryptRounds);
                    default: return string.Empty;
                }
            }
            catch
            {
                ////Treat the exception here
                //throw new Exception("Error hashing the password!");

                //For now I'm just going to return an empty string
                return string.Empty;
            }
        }

        private static HashingAlgorithmTypeEnum HashingAlgorithmType
        {
            get
            {
                switch ((ConfigurationManager.AppSettings["HashingAlgorithmType"] + "").ToUpperInvariant())
                {
                    case "PBKDF2": return HashingAlgorithmTypeEnum.PBKDF2;
                    case "SCRYPT": return HashingAlgorithmTypeEnum.SCRYPT;
                    default: return HashingAlgorithmTypeEnum.BCRYPT;
                };
            }
        }
        private static int PBKDF2Rounds
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["PBKDF2Rounds"] ?? "10000");
            }
        }
        private static uint BCryptRounds
        {
            get
            {
                return uint.Parse(ConfigurationManager.AppSettings["BCryptRounds"] ?? "13");
            }
        }
        private static uint SCryptRounds
        {
            get
            {
                return uint.Parse(ConfigurationManager.AppSettings["SCryptRounds"] ?? "16");
            }
        }
    }
    public enum HashingAlgorithmTypeEnum
    {
        BCRYPT,
        PBKDF2,
        SCRYPT
    }
}