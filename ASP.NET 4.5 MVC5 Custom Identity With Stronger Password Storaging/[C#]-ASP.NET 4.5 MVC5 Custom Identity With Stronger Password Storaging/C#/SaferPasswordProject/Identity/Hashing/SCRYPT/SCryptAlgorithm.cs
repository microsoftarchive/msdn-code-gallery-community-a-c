using Replicon.Cryptography.SCrypt.MMA;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
namespace Replicon.Cryptography.SCrypt
{
    public static class SCryptAlgorithm
    {
        private static object hookupLock = new object();
        private static bool hookupComplete = false;
        private static string tempPath = null;
        private static bool expensiveCrtInitialization = false;
        private static RandomNumberGenerator randomGenerator;
        private static object randomGeneratorLock = new object();
        public static readonly uint DefaultSaltLengthBytes = 16u;
        public static readonly ulong Default_N = 16384uL;
        public static readonly uint Default_r = 8u;
        public static readonly uint Default_p = 1u;
        public static readonly uint DefaultHashLengthBytes = 32u;
        private static RandomNumberGenerator RandomGenerator
        {
            get
            {
                if (SCryptAlgorithm.randomGenerator != null)
                {
                    return SCryptAlgorithm.randomGenerator;
                }
                RandomNumberGenerator result;
                lock (SCryptAlgorithm.randomGeneratorLock)
                {
                    if (SCryptAlgorithm.randomGenerator != null)
                    {
                        result = SCryptAlgorithm.randomGenerator;
                    }
                    else
                    {
                        result = (SCryptAlgorithm.randomGenerator = RandomNumberGenerator.Create());
                    }
                }
                return result;
            }
        }
        private static void HookupAssemblyLoader()
        {
            if (SCryptAlgorithm.hookupComplete)
            {
                return;
            }
            lock (SCryptAlgorithm.hookupLock)
            {
                if (!SCryptAlgorithm.hookupComplete)
                {
                    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(SCryptAlgorithm.CurrentDomain_AssemblyResolve);
                    AppDomain.CurrentDomain.DomainUnload += new EventHandler(SCryptAlgorithm.CurrentDomain_ProcessExit);
                    AppDomain.CurrentDomain.ProcessExit += new EventHandler(SCryptAlgorithm.CurrentDomain_ProcessExit);
                    SCryptAlgorithm.hookupComplete = true;
                }
            }
        }
        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            if (SCryptAlgorithm.tempPath != null)
            {
                try
                {
                    Directory.Delete(SCryptAlgorithm.tempPath, true);
                    SCryptAlgorithm.tempPath = null;
                }
                catch
                {
                }
            }
        }
        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[16384];
            while (true)
            {
                int read = input.Read(buffer, 0, buffer.Length);
                if (read == 0)
                {
                    break;
                }
                output.Write(buffer, 0, read);
            }
        }
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("Replicon.Cryptography.SCrypt.MMA,"))
            {
                lock (SCryptAlgorithm.hookupLock)
                {
                    if (SCryptAlgorithm.tempPath == null)
                    {
                        string root = Path.GetTempPath();
                        SCryptAlgorithm.tempPath = Path.Combine(root, Path.GetRandomFileName());
                        Directory.CreateDirectory(SCryptAlgorithm.tempPath);
                        string dll;
                        string pdb;
                        if (IntPtr.Size == 8)
                        {
                            dll = "Replicon.Cryptography.SCrypt.Replicon.Cryptography.SCrypt.MMA-x64.dll";
                            pdb = "Replicon.Cryptography.SCrypt.Replicon.Cryptography.SCrypt.MMA-x64.pdb";
                        }
                        else
                        {
                            dll = "Replicon.Cryptography.SCrypt.Replicon.Cryptography.SCrypt.MMA-win32.dll";
                            pdb = "Replicon.Cryptography.SCrypt.Replicon.Cryptography.SCrypt.MMA-win32.pdb";
                        }
                        using (Stream input = Assembly.GetExecutingAssembly().GetManifestResourceStream(dll))
                        {
                            using (Stream output = new FileStream(Path.Combine(SCryptAlgorithm.tempPath, "Replicon.Cryptography.SCrypt.MMA.dll"), FileMode.CreateNew))
                            {
                                SCryptAlgorithm.CopyStream(input, output);
                            }
                        }
                        using (Stream input2 = Assembly.GetExecutingAssembly().GetManifestResourceStream(pdb))
                        {
                            using (Stream output2 = new FileStream(Path.Combine(SCryptAlgorithm.tempPath, "Replicon.Cryptography.SCrypt.MMA.pdb"), FileMode.CreateNew))
                            {
                                SCryptAlgorithm.CopyStream(input2, output2);
                            }
                        }
                    }
                    return Assembly.LoadFile(Path.Combine(SCryptAlgorithm.tempPath, "Replicon.Cryptography.SCrypt.MMA.dll"));
                }
            }
            return null;
        }
        private static void EnsureCrtInitialized()
        {
            if (!SCryptAlgorithm.expensiveCrtInitialization)
            {
                SCryptAlgorithm.EscapeExecutionContext<bool>(delegate
                {
                    Replicon.Cryptography.SCrypt.MMA.SCrypt.ExpensiveCrtInitialization();
                    //SCrypt.ExpensiveCrtInitialization();
                    return false;
                });
                SCryptAlgorithm.expensiveCrtInitialization = true;
            }
        }
        private static void SafeSetPrincipal(IPrincipal principal)
        {
            SecurityPermission controlPrincipalPermission = new SecurityPermission(SecurityPermissionFlag.ControlPrincipal);
            controlPrincipalPermission.Assert();
            Thread.CurrentPrincipal = principal;
        }
        private static T EscapeExecutionContext<T>(Func<T> callback)
        {
            AsyncFlowControl suppressExecutionContextFlow = ExecutionContext.SuppressFlow();
            T retval2;
            try
            {
                T retval = default(T);
                Exception threadException = null;
                Thread thread = new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        try
                        {
                            SCryptAlgorithm.SafeSetPrincipal(null);
                            retval = callback();
                        }
                        catch (Exception e)
                        {
                            threadException = e;
                        }
                    }
                    catch
                    {
                    }
                }));
                thread.Start();
                thread.Join();
                if (threadException != null)
                {
                    throw new TargetInvocationException(threadException);
                }
                retval2 = retval;
            }
            finally
            {
                suppressExecutionContextFlow.Undo();
            }
            return retval2;
        }
        public static string GenerateSalt()
        {
            return SCryptAlgorithm.GenerateSalt(SCryptAlgorithm.DefaultSaltLengthBytes, SCryptAlgorithm.Default_N, SCryptAlgorithm.Default_r, SCryptAlgorithm.Default_p, SCryptAlgorithm.DefaultHashLengthBytes);
        }
        public static string GenerateSalt(ulong iterations)
        {
            return SCryptAlgorithm.GenerateSalt(SCryptAlgorithm.DefaultSaltLengthBytes, iterations, SCryptAlgorithm.Default_r, SCryptAlgorithm.Default_p, SCryptAlgorithm.DefaultHashLengthBytes);
        }
        public static string GenerateSalt(uint saltLengthBytes, ulong N, uint r, uint p, uint hashLengthBytes)
        {
            byte[] salt = new byte[saltLengthBytes];
            SCryptAlgorithm.RandomGenerator.GetBytes(salt);
            StringBuilder builder = new StringBuilder();
            builder.Append("$scrypt$");
            builder.Append(N);
            builder.Append("$");
            builder.Append(r);
            builder.Append("$");
            builder.Append(p);
            builder.Append("$");
            builder.Append(hashLengthBytes);
            builder.Append("$");
            builder.Append(Convert.ToBase64String(salt));
            builder.Append("$");
            return builder.ToString();
        }
        public static string HashPassword(string password, ulong iterations)
        {
            return SCryptAlgorithm.HashPassword(password, SCryptAlgorithm.GenerateSalt(iterations));
        }
        public static string HashPassword(string password)
        {
            return SCryptAlgorithm.HashPassword(password, SCryptAlgorithm.GenerateSalt());
        }
        private static Exception InternalTryParseSalt(string salt, out byte[] saltBytes, out ulong N, out uint r, out uint p, out uint hashLengthBytes)
        {
            saltBytes = null;
            N = 0uL;
            r = (p = 0u);
            hashLengthBytes = 0u;
            string[] saltComponents = salt.Split(new char[]
			{
				'$'
			});
            if (saltComponents.Length != 8)
            {
                return new Exception("Expected 8 dollar-sign ($) delimited salt components");
            }
            if (saltComponents[0] != "" || saltComponents[1] != "scrypt")
            {
                return new Exception("Expected $scrypt$");
            }
            if (!ulong.TryParse(saltComponents[2], out N))
            {
                return new Exception("Failed to parse N parameter");
            }
            if (!uint.TryParse(saltComponents[3], out r))
            {
                return new Exception("Failed to parse r parameter");
            }
            if (!uint.TryParse(saltComponents[4], out p))
            {
                return new Exception("Failed to parse p parameter");
            }
            if (!uint.TryParse(saltComponents[5], out hashLengthBytes))
            {
                return new Exception("Failed to parse hashLengthBytes parameter");
            }
            saltBytes = Convert.FromBase64String(saltComponents[6]);
            return null;
        }
        public static bool TryParseSalt(string salt, out byte[] saltBytes, out ulong N, out uint r, out uint p, out uint hashLengthBytes)
        {
            Exception error = SCryptAlgorithm.InternalTryParseSalt(salt, out saltBytes, out N, out r, out p, out hashLengthBytes);
            return error == null;
        }
        public static void ParseSalt(string salt, out byte[] saltBytes, out ulong N, out uint r, out uint p, out uint hashLengthBytes)
        {
            Exception error = SCryptAlgorithm.InternalTryParseSalt(salt, out saltBytes, out N, out r, out p, out hashLengthBytes);
            if (error != null)
            {
                throw error;
            }
        }
        public static string HashPassword(string password, string salt)
        {
            byte[] salt_data;
            ulong N;
            uint r;
            uint p;
            uint hashLengthBytes;
            SCryptAlgorithm.ParseSalt(salt, out salt_data, out N, out r, out p, out hashLengthBytes);
            byte[] password_data = Encoding.UTF8.GetBytes(password);
            byte[] hash_data = SCryptAlgorithm.DeriveKey(password_data, salt_data, N, r, p, hashLengthBytes);
            return salt.Substring(0, salt.LastIndexOf('$') + 1) + Convert.ToBase64String(hash_data);
        }
        public static bool Verify(string password, string hash)
        {
            return hash == SCryptAlgorithm.HashPassword(password, hash);
        }
        public static byte[] DeriveKey(byte[] password, byte[] salt, ulong N, uint r, uint p, uint derivedKeyLengthBytes)
        {
            SCryptAlgorithm.HookupAssemblyLoader();
            SCryptAlgorithm.EnsureCrtInitialized();
            return SCryptAlgorithm.WrappedDeriveKey(password, salt, N, r, p, derivedKeyLengthBytes);
        }
        private static byte[] WrappedDeriveKey(byte[] password, byte[] salt, ulong N, uint r, uint p, uint derivedKeyLengthBytes)
        {
            return Replicon.Cryptography.SCrypt.MMA.SCrypt.DeriveKey(password, salt, N, r, p, derivedKeyLengthBytes);
        }
    }
}
