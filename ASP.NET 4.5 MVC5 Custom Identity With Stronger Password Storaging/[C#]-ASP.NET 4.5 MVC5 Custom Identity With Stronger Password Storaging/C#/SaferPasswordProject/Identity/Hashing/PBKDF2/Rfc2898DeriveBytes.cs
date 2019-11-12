using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace TM.Hashing
{
    /// <summary>
    /// Implementation of the Rfc2898DeriveBytes PBKDF2 specification located here http://www.ietf.org/rfc/rfc2898.txt using HMACSHA512 as the underlying PRF
    /// Created by Ian Harris
    /// harro84@yahoo.com.au
    /// v1.0.0.0
    /// </summary>
    public class Rfc2898DeriveBytes : DeriveBytes, IDisposable
    {
        #region Rfc2898DeriveBytes Attributes

        //I made the variable names match the definition in RFC2898 - PBKDF2 where possible, so you can trace the code functionality back to the specification
        private readonly HMACSHA512 _hmacsha512Obj;
        private readonly Int32 hLen;
        private readonly Byte[] P;
        public readonly Byte[] S;
        private readonly Int32 c;
        private Int32 dkLen;

        #endregion

        #region Rfc2898DeriveBytes Constants

        //Minimum rcommended itereations in Rfc2898DeriveBytes
        public const int CMinIterations = 1000;
        //Minimum recommended salt length in Rfc2898DeriveBytes
        public const int CMinSaltLength = 8;

        #endregion

        #region Rfc2898DeriveBytes Constructors

        /// <summary>
        /// Rfc2898DeriveBytes constructor to create Rfc2898DeriveBytes object ready to perform Rfc2898DeriveBytes functionality
        /// </summary>
        /// <param name="password">The Password to be hashed and is also the HMAC key</param>
        /// <param name="salt">Salt to be concatenated with the password</param>
        /// <param name="iterations">Number of iterations to perform HMACSHA Hashing for PBKDF2</param>
        public Rfc2898DeriveBytes(string password, int salt, int iterations)
            : this(new UTF8Encoding(false).GetBytes(password),  new byte[salt], iterations)
        {
            new RNGCryptoServiceProvider().GetBytes(S);
        }

        /// <summary>
        /// Rfc2898DeriveBytes constructor to create Rfc2898DeriveBytes object ready to perform Rfc2898DeriveBytes functionality
        /// </summary>
        /// <param name="password">The Password to be hashed and is also the HMAC key</param>
        /// <param name="salt">Salt to be concatenated with the password</param>
        /// <param name="iterations">Number of iterations to perform HMACSHA Hashing for PBKDF2</param>
        public Rfc2898DeriveBytes(Byte[] password, Byte[] salt, Int32 iterations)
        {
            if (iterations < CMinIterations)
            {
                throw new IterationsLessThanRecommended();
            }

            if (salt.Length < CMinSaltLength)
            {
                throw new SaltLessThanRecommended();
            }

            _hmacsha512Obj = new HMACSHA512(password);
            hLen = _hmacsha512Obj.HashSize / 8;
            P = password;
            S = salt;
            c = iterations;
        }

        /// <summary>
        /// Rfc2898DeriveBytes constructor to create Rfc2898DeriveBytes object ready to perform Rfc2898DeriveBytes functionality
        /// </summary>
        /// <param name="password">The Password to be hashed and is also the HMAC key</param>
        /// <param name="salt">Salt to be concatenated with the password</param>
        /// <param name="iterations">Number of iterations to perform HMACSHA Hashing for PBKDF2</param>
        public Rfc2898DeriveBytes(String password, Byte[] salt, Int32 iterations)
            : this(new UTF8Encoding(false).GetBytes(password), salt, iterations)
        {

        }

        /// <summary>
        /// Rfc2898DeriveBytes constructor to create Rfc2898DeriveBytes object ready to perform Rfc2898DeriveBytes functionality
        /// </summary>
        /// <param name="password">The Password to be hashed and is also the HMAC key</param>
        /// <param name="salt">Salt to be concatenated with the password</param>
        /// <param name="iterations">Number of iterations to perform HMACSHA Hashing for PBKDF2</param>
        public Rfc2898DeriveBytes(String password, String salt, Int32 iterations)
            : this(new UTF8Encoding(false).GetBytes(password), new UTF8Encoding(false).GetBytes(salt), iterations)
        {

        }

        #endregion

        #region Rfc2898DeriveBytes Public Members
        /// <summary>
        /// Derive Key Bytes using PBKDF2 specification listed in Rfc2898DeriveBytes and HMACSHA512 as the underlying PRF (Psuedo Random Function)
        /// </summary>
        /// <param name="keyLength">Length in Bytes of Derived Key</param>
        /// <returns>Derived Key</returns>
        public override Byte[] GetBytes(int keyLength)
        {
            //no need to throw exception for dkLen too long as per spec because dkLen cannot be larger than Int32.MaxValue so not worth the overhead to check
            dkLen = keyLength;

            Double l = Math.Ceiling((Double)dkLen / hLen);

            Byte[] finalBlock = new Byte[0];

            for (Int32 i = 1; i <= l; i++)
            {
                //Concatenate each block from F into the final block (T_1..T_l)
                finalBlock = pMergeByteArrays(finalBlock, F(P, S, c, i));
            }

            //returning DK note r not used as dkLen bytes of the final concatenated block returned rather than <0...r-1> substring of final intermediate block + prior blocks as per spec
            return finalBlock.Take(dkLen).ToArray();

        }

        /// <summary>
        /// A static publicly exposed version of GetDerivedKeyBytes_PBKDF2_HMACSHA512 which matches the exact specification in Rfc2898DeriveBytes PBKDF2 using HMACSHA512
        /// </summary>
        /// <param name="P">Password passed as a Byte Array</param>
        /// <param name="S">Salt passed as a Byte Array</param>
        /// <param name="c">Iterations to perform the underlying PRF over</param>
        /// <param name="dkLen">Length of Bytes to return, an AES 256 key wold require 32 Bytes</param>
        /// <returns>Derived Key in Byte Array form ready for use by chosen encryption function</returns>
        public static Byte[] PBKDF2(Byte[] P, Byte[] S, Int32 c, Int32 dkLen)
        {
            Rfc2898DeriveBytes rfcObj = new Rfc2898DeriveBytes(P, S, c);
            return rfcObj.GetBytes(dkLen);
        }

        #endregion

        #region Rfc2898DeriveBytes Private Members
        //Main Function F as defined in Rfc2898DeriveBytes PBKDF2 spec
        private Byte[] F(Byte[] P, Byte[] S, Int32 c, Int32 i)
        {

            //Salt and Block number Int(i) concatenated as per spec
            Byte[] Si = pMergeByteArrays(S, INT(i));

            //Initial hash (U_1) using password and salt concatenated with Int(i) as per spec
            Byte[] temp = PRF(P, Si);

            //Output block filled with initial hash value or U_1 as per spec
            Byte[] U_c = temp;

            for (Int32 C = 1; C < c; C++)
            {
                //rehashing the password using the previous hash value as salt as per spec
                temp = PRF(P, temp);

                for (Int32 j = 0; j < temp.Length; j++)
                {
                    //xor each byte of the each hash block with each byte of the output block as per spec
                    U_c[j] ^= temp[j];
                }
            }

            //return a T_i block for concatenation to create the final block as per spec
            return U_c;
        }

        //PRF function as defined in Rfc2898DeriveBytes PBKDF2 spec
        private Byte[] PRF(Byte[] P, Byte[] S)
        {
            //HMACSHA512 Hashing, better than the HMACSHA1 in Microsofts implementation ;)
            return _hmacsha512Obj.ComputeHash(pMergeByteArrays(P, S));
        }

        //This method returns the 4 octet encoded Int32 with most significant bit first as per spec
        private Byte[] INT(Int32 i)
        {
            Byte[] I = BitConverter.GetBytes(i);

            //Make sure most significant bit is first
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(I);
            }

            return I;
        }

        //Merge two arrays into a new array
        private Byte[] pMergeByteArrays(Byte[] source1, Byte[] source2)
        {
            //Most efficient way to merge two arrays this according to http://stackoverflow.com/questions/415291/best-way-to-combine-two-or-more-byte-arrays-in-c-sharp
            Byte[] buffer = new Byte[source1.Length + source2.Length];
            System.Buffer.BlockCopy(source1, 0, buffer, 0, source1.Length);
            System.Buffer.BlockCopy(source2, 0, buffer, source1.Length, source2.Length);

            return buffer;
        }

        #endregion

        public new void Dispose()
        {
            _hmacsha512Obj.Dispose();
        }

        public override void Reset()
        {
            return;
        }
    }

    #region Rfc2898DeriveBytes Custom Exceptions

    public class IterationsLessThanRecommended : Exception
    {
        public IterationsLessThanRecommended()
            : base("Iteration count is less than the 1000 recommended in Rfc2898DeriveBytes")
        {

        }
    }

    public class SaltLessThanRecommended : Exception
    {
        public SaltLessThanRecommended()
            : base("Salt is less than the 8 byte size recommended in Rfc2898DeriveBytes")
        {

        }
    }

    #endregion
}
