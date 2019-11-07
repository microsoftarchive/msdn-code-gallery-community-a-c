using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Microsoft.Net.BITS
{
	using Interop;

	/// <summary>
    /// Use the BackgroundCopyManager to create transfer jobs, retrieve an enumerator object that contains the jobs in the queue, and to retrieve individual jobs from the queue.
    /// </summary>
    public static class BackgroundCopyManager
    {
        private static BackgroundCopyJobList jobs;
        private static BackgroundCopyManager2_0Class mgr;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundCopyManager"/> class.
        /// </summary>
        static BackgroundCopyManager()
        {
            CoInitializeSecurity(IntPtr.Zero, -1, IntPtr.Zero, IntPtr.Zero, 2 /*RPC_C_AUTHN_LEVEL_CONNECT*/, 3 /*RPC_C_IMP_LEVEL_IMPERSONATE*/, IntPtr.Zero, 0, IntPtr.Zero);
            mgr = new BackgroundCopyManager2_0Class();
            jobs = new BackgroundCopyJobList();
        }

        /// <summary>
        /// Gets the list of currently queued jobs for all users.
        /// </summary>
        public static BackgroundCopyJobList Jobs
        {
            get
            {
                return jobs;
            }
        }

        /// <summary>
        /// Retrieves the running version of BITS.
        /// </summary>
        public static Version Version
        {
            get
            {
                System.Diagnostics.FileVersionInfo fi = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.System), "QMgr.dll"));
                if (fi.FileMinorPart == 6)
                    return new Version(2, 0);
                return new Version(1, fi.FileMinorPart);
            }
        }

        internal static IBackgroundCopyManager IBackgroundCopyManager
        {
            get { return mgr; }
        }

        /// <summary>
        /// Creates a new download transfer job.
        /// </summary>
        /// <param name="displayName">Name of the job.</param>
        /// <returns>The new <see cref="BackgroundCopyJob"/>.</returns>
        public static BackgroundCopyJob CreateJob(string displayName)
        {
            return CreateJob(displayName, string.Empty, BackgroundCopyJobType.Download);
        }

        /// <summary>
        /// Creates a new download transfer job.
        /// </summary>
        /// <param name="displayName">Name of the job.</param>
        /// <param name="description">Description of the job.</param>
        /// <returns>The new <see cref="BackgroundCopyJob"/>.</returns>
        public static BackgroundCopyJob CreateJob(string displayName, string description)
        {
            return CreateJob(displayName, description, BackgroundCopyJobType.Download);
        }

        /// <summary>
        /// Creates a new upload or download transfer job.
        /// </summary>
        /// <param name="displayName">Name of the job.</param>
        /// <param name="description">Description of t he job.</param>
        /// <param name="jobType">Type (upload or download) of the job.</param>
        /// <returns>The new <see cref="BackgroundCopyJob"/>.</returns>
        public static BackgroundCopyJob CreateJob(string displayName, string description, BackgroundCopyJobType jobType)
        {
            try
            {
                IBackgroundCopyJob newJob;
                Guid newJobID;

                mgr.CreateJob(displayName, jobType, out newJobID, out newJob);
                BackgroundCopyJob job = new BackgroundCopyJob(newJob);

                if (!string.IsNullOrEmpty(description))
                    job.Description = description;
                return job;
            }
            catch (COMException cex)
            {
                HandleCOMException(cex);
            }

            return null;
        }

        /// <summary>
        /// Checks if the current user has administrator rights.
        /// </summary>
        public static bool IsCurrentUserAdministrator()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal wp = (WindowsPrincipal)System.Threading.Thread.CurrentPrincipal;
            return wp.IsInRole(WindowsBuiltInRole.Administrator);
        }

        [DllImport("ole32.dll")]
        internal static extern int CoInitializeSecurity(IntPtr secDesc, int cAuthSvc, IntPtr asAuthSvc, IntPtr reserved1, int authnLevel, int impLevel, IntPtr authList, int capabilities, IntPtr reserved3);

        internal static string GetErrorMessage(int hResult)
        {
            //const uint lang = 0x1; // LANG_NEUTRAL, SUBLANG_DEFAULT
            string msg;
            int lcid = System.Globalization.CultureInfo.CurrentCulture.LCID;
            uint lang = (uint)((short)lcid);
            try
            {
                mgr.GetErrorDescription(hResult, lang, out msg);
            }
            catch (COMException)
            {
                return null;
            }
            return msg;
        }

        private static void HandleCOMException(COMException cex)
        {
            throw new BackgroundCopyException(cex);
        }
    }
}