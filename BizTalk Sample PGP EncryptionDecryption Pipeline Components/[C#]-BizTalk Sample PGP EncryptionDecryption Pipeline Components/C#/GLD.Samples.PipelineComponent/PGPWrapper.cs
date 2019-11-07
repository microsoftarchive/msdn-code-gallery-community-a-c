using System.Data;
using System.Configuration;
using System.Net;
using System.Xml;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Utilities.IO;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;

namespace GLD.Samples.PipelineComponents
{
    public class PGPWrapper
    {

        #region PGP Algorythms

        private static PgpPublicKey ReadPublicKey(Stream inputStream)
        {
            inputStream = PgpUtilities.GetDecoderStream(inputStream);
            PgpPublicKeyRingBundle pgpPub = new PgpPublicKeyRingBundle(inputStream);

            // we just loop through the collection till we find a key suitable for encryption, in the real
            // world you would probably want to be a bit smarter about this.

            // iterate through the key rings.
            foreach (PgpPublicKeyRing kRing in pgpPub.GetKeyRings())
            {
                foreach (PgpPublicKey k in kRing.GetPublicKeys())
                {

                    if (k.IsEncryptionKey)
                        return k;
                }
            }

            throw new ArgumentException("Can't find encryption key in key ring.");
        }

  
        private static Stream DecryptFileAsStream(
                 Stream inputStream,
                 Stream keyIn,
                 char[] passwd)
        {
            inputStream = PgpUtilities.GetDecoderStream(inputStream);
            MemoryStream outputStream = new MemoryStream();

            try
            {
                PgpObjectFactory pgpF = new PgpObjectFactory(inputStream);
                PgpEncryptedDataList enc;

                PgpObject o = pgpF.NextPgpObject();

                // the first object might be a PGP marker packet.
                if (o is PgpEncryptedDataList)
                    enc = (PgpEncryptedDataList)o;
                else
                    enc = (PgpEncryptedDataList)pgpF.NextPgpObject();

                // find the secret key
                PgpPrivateKey sKey = null;
                PgpPublicKeyEncryptedData pbe = null;

                foreach (PgpPublicKeyEncryptedData pked in enc.GetEncryptedDataObjects())
                {
                    sKey = FindSecretKey(keyIn, pked.KeyId, passwd);

                    if (sKey != null)
                    {
                        pbe = pked;
                        break;
                    }
                }

                //                Iterator                    it = enc.GetEncryptedDataObjects();
                //
                //                while (sKey == null && it.hasNext())
                //                {
                //                    pbe = (PgpPublicKeyEncryptedData)it.next();
                //
                //                    sKey = FindSecretKey(keyIn, pbe.KeyID, passwd);
                //                }

                if (sKey == null)
                    throw new ArgumentException("secret key for message not found.");

                Stream clear = pbe.GetDataStream(sKey);
                PgpObjectFactory plainFact = new PgpObjectFactory(clear);
                PgpObject message = plainFact.NextPgpObject();

                if (message is PgpCompressedData)
                {
                    PgpCompressedData cData = (PgpCompressedData)message;
                    PgpObjectFactory pgpFact = new PgpObjectFactory(cData.GetDataStream());

                    message = pgpFact.NextPgpObject();

                    if (message is PgpOnePassSignatureList)
                    {
                        //throw new PgpException("encrypted message contains a signed message - not literal data.");
                        // file is signed!

                        // verify signature here if you want.
                        PgpOnePassSignatureList p1 = (PgpOnePassSignatureList)message;
                        PgpOnePassSignature ops = p1[0];
                        // etc…

                        message = pgpFact.NextPgpObject();
                    }
                }
                if (message is PgpLiteralData)
                {
                    PgpLiteralData ld = (PgpLiteralData)message;
                    Stream unc = ld.GetInputStream();

                    int ch;
                    while ((ch = unc.ReadByte()) >= 0)
                    {
                        outputStream.WriteByte((byte)ch);
                    }

                    outputStream.Seek(0, SeekOrigin.Begin);
                }
                else
                {
                    throw new PgpException("message is not a simple encrypted file - type unknown.");
                }

                if (pbe.IsIntegrityProtected())
                {
                    if (!pbe.Verify())
                        Console.Error.WriteLine("message failed integrity check");
                    else
                        Console.Error.WriteLine("message integrity check passed");
                }
                else
                {
                    Console.Error.WriteLine("no message integrity check");
                }

                return outputStream;
            }
            catch (PgpException e)
            {
                Console.Error.WriteLine(e);

                Exception underlyingException = e.InnerException;
                if (underlyingException != null)
                {
                    Console.Error.WriteLine(underlyingException.Message);
                    Console.Error.WriteLine(underlyingException.StackTrace);
                }

                throw;
            }
        }

        private static PgpPrivateKey FindSecretKey(Stream keyIn, long keyId, char[] pass)
        {
            PgpSecretKeyRingBundle pgpSec = new PgpSecretKeyRingBundle(
                PgpUtilities.GetDecoderStream(keyIn));

            PgpSecretKey pgpSecKey = pgpSec.GetSecretKey(keyId);

            if (pgpSecKey == null)
                return null;

            return pgpSecKey.ExtractPrivateKey(pass);
        }

        private static void EncryptFile(Stream outputStream, string fileName, PgpPublicKey encKey, bool armor, bool withIntegrityCheck)
        {
            if (armor)
                outputStream = new ArmoredOutputStream(outputStream);

            try
            {
                MemoryStream bOut = new MemoryStream();
                PgpCompressedDataGenerator comData = new PgpCompressedDataGenerator(CompressionAlgorithmTag.Zip);
                PgpUtilities.WriteFileToLiteralData(
                    comData.Open(bOut),
                    PgpLiteralData.Binary,
                    new FileInfo(fileName));

                comData.Close();

                PgpEncryptedDataGenerator cPk = new PgpEncryptedDataGenerator(SymmetricKeyAlgorithmTag.Cast5, withIntegrityCheck, new SecureRandom());
                cPk.AddMethod(encKey);

                byte[] bytes = bOut.ToArray();

                Stream cOut = cPk.Open(outputStream, bytes.Length);
                cOut.Write(bytes, 0, bytes.Length);
                cOut.Close();

                if (armor)
                    outputStream.Close();
            }

            catch (PgpException e)
            {
                Console.WriteLine(e);

                Exception underlyingException = e.InnerException;

                if (underlyingException != null)
                {
                    Console.WriteLine(underlyingException.Message);
                    Console.WriteLine(underlyingException.StackTrace);
                }
            }
        }

        #endregion PGP Algorythms

         public static Stream EncryptStream(Stream inStream, string pubKeyFile, string sourceFilename, string extension, bool armorFlag, bool integrityCheckFlag)
        {
            string tmpEncryptedFile = sourceFilename + "." + extension;

            try
            {
                using (StreamWriter sourceStream = new StreamWriter(sourceFilename))
                {
                    using (StreamReader sr = new StreamReader(inStream))
                    {
                        sourceStream.Write(sr.ReadToEnd());
                    }
                }

                using (FileStream encryptedStream = File.Create(tmpEncryptedFile))
                {
                    PgpPublicKey publicKey = ReadPublicKey(File.OpenRead(pubKeyFile));
                    EncryptFile(encryptedStream, sourceFilename, publicKey, armorFlag, integrityCheckFlag);

                    encryptedStream.Seek(0, SeekOrigin.Begin);
                    int myCapacity = Int32.Parse(encryptedStream.Length.ToString());
                    Byte[] byteArray = new Byte[myCapacity];

                    MemoryStream memStream = new MemoryStream();

                    encryptedStream.Read(byteArray, 0, myCapacity);
                    memStream.Write(byteArray, 0, myCapacity);

                    encryptedStream.Close();

                    memStream.Seek(0, SeekOrigin.Begin);
                    return memStream;
                }
            }
            catch (Exception ex)
            {
                //System.Diagnostics.EventLog.WriteEntry("PGPWrapper[Encrypt] Error", ex.ToString());
                throw ;
            }
            finally
            {
                // Clean-up temp files
                if (File.Exists(sourceFilename)) { File.Delete(sourceFilename); }
                if (File.Exists(tmpEncryptedFile)) { File.Delete(tmpEncryptedFile); }

                //FileInfo fileInfo = new FileInfo(sourceFilename);
                //System.Diagnostics.EventLog.WriteEntry("PGP_Debug", fileInfo.FullName + " was deleted");

                //fileInfo = new FileInfo(tmpEncryptedFile);
                //System.Diagnostics.EventLog.WriteEntry("PGP_Debug", fileInfo.FullName + " was deleted");
            }
        }

        public static Stream DecryptStream(Stream inStream, string privKeyFile, string passphrase, string encryptedFilename, string tempDir)
        {
            // Remove last extension from encrypted filename.  Could be PGP, ASC, etc
            string tmpDecryptedFile = encryptedFilename.Substring(0, encryptedFilename.LastIndexOf("."));

            try
            {
                using (FileStream keyIn = File.OpenRead(privKeyFile))
                {
                    //   private static void DecryptFile(Stream inputStream, Stream keyIn, char[] passwd, string pathToSaveFile)

                    Stream decryptedStream = DecryptFileAsStream(inStream, keyIn, passphrase.ToCharArray());
                    decryptedStream.Seek(0, SeekOrigin.Begin);
                    return decryptedStream;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // Clean-up temp files
            }
        }
    }
}
