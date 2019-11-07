using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Net.BITS
{
	using Interop;

	#region Delegates

    /// <summary>
    /// Event handler for a background copy job.
    /// </summary>
    public delegate void BackgroundCopyJobEventHandler(object sender, BackgroundCopyJobEventArgs args);

    #endregion Delegates

    /// <summary>
    /// A job in the Backgroup Copy Service (BITS)
    /// </summary>
    public class BackgroundCopyJob : IDisposable
    {
        internal static readonly int DEFAULT_RETRY_DELAY = 600; //10 minutes (600 seconds)
        internal static readonly int DEFAULT_RETRY_PERIOD = 1209600; //20160 minutes (1209600 seconds)

        private BackgroundCopyJobEventHandler CompletedHandler;
        private System.IO.ErrorEventHandler ErrorHandler;
        private BackgroundCopyJobEventHandler ModifiedHandler;
        private BackgroundCopyFileSet m_files;
        private IBackgroundCopyJob m_ijob;
        private IBackgroundCopyJob2 m_ijob2;
        private IBackgroundCopyJob3 m_ijob3;
        private Notifier m_notifier;

        internal BackgroundCopyJob(IBackgroundCopyJob ijob)
        {
            if (ijob == null)
                throw new ArgumentNullException("IBackgroundCopyJob");
            m_ijob = ijob;
            m_files = new BackgroundCopyFileSet(ijob);
        }

        /// <summary>
        /// Destructor for BackgroundCopyJob.
        /// </summary>
        ~BackgroundCopyJob()
        {
            Dispose();
        }

        /// <summary>
        /// Occurs when the job has been modified. For example, a property value changed, the state of the job changed, or progress is made transferring the files.
        /// </summary>
        public event BackgroundCopyJobEventHandler Changed
        {
            add
            {
                CheckNotifier();
                ModifiedHandler += value;
                this.NotifyFlags |= BackgroundCopyJobNotifyFlags.Modification;
            }
            remove
            {
                this.NotifyFlags &= ~BackgroundCopyJobNotifyFlags.Modification;
                ModifiedHandler -= value;
            }
        }

        /// <summary>
        /// Occurs when all of the files in the job have been transferred.
        /// </summary>
        public event BackgroundCopyJobEventHandler Completed
        {
            add
            {
                CheckNotifier();
                CompletedHandler += value;
                this.NotifyFlags |= BackgroundCopyJobNotifyFlags.Transferred;
            }
            remove
            {
                this.NotifyFlags &= ~BackgroundCopyJobNotifyFlags.Transferred;
                CompletedHandler -= value;
            }
        }

        /// <summary>
        /// Fires when an error occurs.
        /// </summary>
        public event System.IO.ErrorEventHandler Error
        {
            add
            {
                CheckNotifier();
                ErrorHandler += value;
                this.NotifyFlags |= BackgroundCopyJobNotifyFlags.Error;
            }
            remove
            {
                this.NotifyFlags &= ~BackgroundCopyJobNotifyFlags.Error;
                ErrorHandler -= value;
            }
        }

        /// <summary>
        /// Gets or sets the flags that identify the owner and ACL information to maintain when transferring a file using SMB.
        /// </summary>
        public BackgroundCopyACLFlags ACLFlags
        {
            get
            {
                try
                {
                    ReqJob3();
                    uint f;
                    m_ijob3.GetFileACLFlags(out f);
                    return (BackgroundCopyACLFlags)f;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return BackgroundCopyACLFlags.None;
            }
            set
            {
                try
                {
                    ReqJob3();
                    m_ijob3.SetFileACLFlags((uint)value);
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
            }
        }

        /// <summary>
        /// Gets the time the job was created.
        /// </summary>
        public DateTime CreationTime
        {
            get { return FT2DateTime(this.Times.CreationTime); }
        }

        /// <summary>
        /// Gets or sets the description of the job.
        /// </summary>
        public string Description
        {
            get
            {
                try
                {
                    string o; m_ijob.GetDescription(out o); return o;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return string.Empty;
            }
            set
            {
                try
                {
                    m_ijob.SetDescription(value);
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
            }
        }

        /// <summary>
        /// Gets or sets the display name of the job.
        /// </summary>
        public string DisplayName
        {
            get
            {
                try
                {
                    string o; m_ijob.GetDisplayName(out o); return o;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return string.Empty;
            }
            set
            {
                try
                {
                    m_ijob.SetDisplayName(value);
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
            }
        }

        /// <summary>
        /// Gets the number of errors that have occured in this job.
        /// </summary>
        public int ErrorCount
        {
            get
            {
                try
                {
                    uint o; m_ijob.GetErrorCount(out o); return (int)o;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return 0;
            }
        }

        /// <summary>
        /// Manages the files that are a part of this job.
        /// </summary>
        public BackgroundCopyFileSet Files
        {
            get
            {
                return m_files;
            }
        }

        /// <summary>
        /// Gets the job identifier.
        /// </summary>
        public Guid ID
        {
            get
            {
                try
                {
                    Guid o; m_ijob.GetId(out o); return o;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return Guid.Empty;
            }
        }

        /// <summary>
        /// Gets the type of job, such as download.
        /// </summary>
        public BackgroundCopyJobType JobType
        {
            get
            {
                try
                {
                    BackgroundCopyJobType o; m_ijob.GetType(out o); return o;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return BackgroundCopyJobType.Download;
            }
        }

        /// <summary>
        /// Gets the last exeception that occured in the job.
        /// </summary>
        public BackgroundCopyException LastError
        {
            get
            {
                IBackgroundCopyError iError = null;
                try
                {
                    m_ijob.GetError(out iError);
                    return new BackgroundCopyException(iError);
                }
                catch {}
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the minimum length of time, in seconds, that BITS waits after encountering a transient error before trying to transfer the file. The default retry delay is 600 seconds (10 minutes). The minimum retry delay that you can specify is 60 seconds. If you specify a value less than 60 seconds, BITS changes the value to 60 seconds.
        /// </summary>
        public int MinimumRetryDelay
        {
            get
            {
                try
                {
                    uint o; m_ijob.GetMinimumRetryDelay(out o); return (int)o;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return DEFAULT_RETRY_DELAY;
            }
            set
            {
                try
                {
                    m_ijob.SetMinimumRetryDelay((uint)value);
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
            }
        }

        /// <summary>
        /// Gets the time the job was last modified or bytes were transferred.
        /// </summary>
        public DateTime ModificationTime
        {
            get { return FT2DateTime(this.Times.ModificationTime); }
        }

        /// <summary>
        /// Gets or sets the length of time, in seconds, that BITS tries to transfer the file after the first transient error occurs. The default retry period is 1,209,600 seconds (14 days). Set the retry period to 0 to prevent retries and to force the job into the Error state for all errors.
        /// </summary>
        public int NoProgressTimeout
        {
            get
            {
                try
                {
                    uint o; m_ijob.GetNoProgressTimeout(out o); return (int)o;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return DEFAULT_RETRY_PERIOD;
            }
            set
            {
                try
                {
                    m_ijob.SetNoProgressTimeout((uint)value);
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
            }
        }

        /// <summary>
        /// Gets or sets the program to execute if the job enters the Error or Transferred state. BITS executes the program in the context of the user who called this method.
        /// </summary>
        public string NotifyProgram
        {
            get
            {
                ReqJob2();
                string p, a;
                try
                {
                    m_ijob2.GetNotifyCmdLine(out p, out a);
                }
                catch
                {
                    return string.Empty;
                }
                if (string.IsNullOrEmpty(a))
                {
                    if (p == null)
                        return string.Empty;
                    else
                        return p;
                }
                return string.Format("\"{0}\" {1}", p, a);
            }
            set
            {
                ReqJob2();
                string p = value, a = string.Empty;
                if (string.IsNullOrEmpty(value))
                    p = a = null;
                else
                {
                    if (value[0] == '"')
                    {
                        int i = p.IndexOf('"', 1);
                        if (i + 3 <= p.Length)
                            a = p.Substring(i + 2);
                        p = p.Substring(1, i - 1);
                    }
                    else
                    {
                        int i = p.IndexOf(' ');
                        if (i + 2 <= p.Length)
                            a = p.Substring(i + 1);
                        p = p.Substring(0, i);
                    }
                }
                try
                {
                    m_ijob2.SetNotifyCmdLine(p, a);
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
            }
        }

        /// <summary>
        /// Retrieve the identity of the job's owner.
        /// </summary>
        public string Owner
        {
            get
            {
                try
                {
                    string o; m_ijob.GetOwner(out o); return UserFromSSID(o);
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the priority level for the job. The priority level determines when the job is processed relative to other jobs in the transfer queue.
        /// </summary>
        public BackgroundCopyJobPriority Priority
        {
            get
            {
                try
                {
                    BackgroundCopyJobPriority o; m_ijob.GetPriority(out o); return o;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return BackgroundCopyJobPriority.Normal;
            }
            set
            {
                try
                {
                    m_ijob.SetPriority(value);
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
            }
        }

        /// <summary>
        /// Gets the job-related progress information, such as the number of bytes and files transferred.
        /// </summary>
        public BackgroundCopyJobProgress Progress
        {
            get
            {
                try
                {
                    BackgroundCopyJobProgress p; m_ijob.GetProgress(out p); return p;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return new BackgroundCopyJobProgress();
            }
        }

        /// <summary>
        /// Gets or sets the proxy information that the job uses to transfer the files. A <c>null</c> value represents the system default proxy settings.
        /// </summary>
        public System.Net.WebProxy Proxy
        {
            get
            {
                try
                {
                    BackgroundCopyJobProxyUsage pUse;
                    string pList, byList;
                    m_ijob.GetProxySettings(out pUse, out pList, out byList);
                    if (pUse == BackgroundCopyJobProxyUsage.Override)
                        return new System.Net.WebProxy(pList.Split(' ')[0], true, byList.Split(' '));
                    else if (pUse == BackgroundCopyJobProxyUsage.NoProxy)
                        return new System.Net.WebProxy();
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return null;
            }
            set
            {
                try
                {
                    if (value == null)
                        m_ijob.SetProxySettings(BackgroundCopyJobProxyUsage.Preconfig, null, null);
                    else if (string.IsNullOrEmpty(value.Address.AbsoluteUri))
                        m_ijob.SetProxySettings(BackgroundCopyJobProxyUsage.NoProxy, null, null);
                    else
                        m_ijob.SetProxySettings(BackgroundCopyJobProxyUsage.Override, value.Address.AbsoluteUri, string.Join(" ", value.BypassList));
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
            }
        }

        /// <summary>
        /// Gets an in-memory copy of the reply data from the server application.
        /// </summary>
        public byte[] ReplyData
        {
            get
            {
                ReqJob2();
                byte[] ret = new byte[0];
                try
                {
                    ulong cRet;
                    IntPtr pdata;
                    m_ijob2.GetReplyData(out pdata, out cRet);
                    if (cRet > 0)
                    {
                        ret = new byte[cRet];
                        Marshal.Copy(pdata, ret, 0, (int)cRet);
                        return ret;
                    }
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                catch (NotImplementedException) { }
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the name of the file that contains the reply data from the server application.
        /// </summary>
        public string ReplyFileName
        {
            get
            {
                ReqJob2();
                try
                {
                    string f;
                    m_ijob2.GetReplyFileName(out f);
                    return f;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                catch (NotImplementedException) { }
                return string.Empty;
            }
            set
            {
                ReqJob2();
                try
                {
                    m_ijob2.SetReplyFileName(value);
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
            }
        }

        /// <summary>
        /// Gets progress information related to the transfer of the reply data from an upload-reply job.
        /// </summary>
        public BackgroundCopyJobReplyProgress ReplyProgress
        {
            get
            {
                ReqJob2();
                try
                {
                    BackgroundCopyJobReplyProgress ret;
                    m_ijob2.GetReplyProgress(out ret);
                    return ret;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                catch (NotImplementedException) { }
                return new BackgroundCopyJobReplyProgress();
            }
        }

        /// <summary>
        /// Gets the current state of the job.
        /// </summary>
        public BackgroundCopyJobState State
        {
            get
            {
                try
                {
                    return GetState(m_ijob);
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return BackgroundCopyJobState.Error;
            }
        }

        /// <summary>
        /// Gets the time the job entered the Transferred state.
        /// </summary>
        public DateTime TransferCompletionTime
        {
            get { return FT2DateTime(this.Times.TransferCompletionTime); }
        }

        private BackgroundCopyJobNotifyFlags NotifyFlags
        {
            get
            {
                try
                {
                    uint o; m_ijob.GetNotifyFlags(out o); return (BackgroundCopyJobNotifyFlags)o;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return BackgroundCopyJobNotifyFlags.None;
            }
            set
            {
                try
                {
                    BackgroundCopyJobState st = this.State;
                    if (st != BackgroundCopyJobState.Acknowledged && st != BackgroundCopyJobState.Cancelled)
                        m_ijob.SetNotifyFlags((uint)value);
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
            }
        }

        private BackgroundCopyJobTimes Times
        {
            get
            {
                try
                {
                    BackgroundCopyJobTimes o; m_ijob.GetTimes(out o); return o;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return new BackgroundCopyJobTimes();
            }
        }

        /// <summary>
        /// Use the Cancel method to delete the job from the transfer queue and to remove related temporary files from the client (downloads) and server (uploads). You can cancel a job at any time; however, the job cannot be recovered after it is canceled.
        /// </summary>
        public void Cancel()
        {
            try
            {
                m_ijob.Cancel();
            }
            catch (COMException cex)
            {
                HandleCOMException(cex);
            }
        }

        /// <summary>
        /// Use the RemoveCredentials method to remove credentials from use. The credentials must match an existing target and scheme pair that you specified using the IBackgroundCopyJob2::SetCredentials method. There is no method to retrieve the credentials you have set.
        /// </summary>
        public void ClearCredentials()
        {
            ReqJob2();
            try { m_ijob2.RemoveCredentials(BG_AUTH_TARGET.BG_AUTH_TARGET_SERVER, BG_AUTH_SCHEME.BG_AUTH_SCHEME_BASIC); }
            catch (COMException) { }
            try { m_ijob2.RemoveCredentials(BG_AUTH_TARGET.BG_AUTH_TARGET_SERVER, BG_AUTH_SCHEME.BG_AUTH_SCHEME_NTLM); }
            catch (COMException) { }
        }

        /// <summary>
        /// Use the Complete method to end the job and save the transferred files on the client.
        /// </summary>
        public void Complete()
        {
            try
            {
                m_ijob.Complete();
            }
            catch (COMException cex)
            {
                HandleCOMException(cex);
            }
        }

        /// <summary>
        /// Disposes of the BackgroundCopyJob object.
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.NotifyFlags = 0;
                m_ijob.SetNotifyInterface(null);
            }
            catch { }
            m_files = null;  m_ijob = null; m_ijob2 = null; m_ijob3 = null; m_notifier = null;
        }

        /// <summary>
        /// Use the ReplaceRemotePrefix method to replace the beginning text of all remote names in the download job with the given string.
        /// </summary>
        /// <param name="oldPrefix">String that identifies the text to replace in the remote name. The text must start at the beginning of the remote name.</param>
        /// <param name="newPrefix">String that contains the replacement text.</param>
        public void ReplaceRemotePrefix(string oldPrefix, string newPrefix)
        {
            try
            {
                ReqJob3();
                m_ijob3.ReplaceRemotePrefix(oldPrefix, newPrefix);
            }
            catch (COMException cex)
            {
                HandleCOMException(cex);
            }
        }

        /// <summary>
        /// Use the Resume method to activate a new job or restart a job that has been suspended.
        /// </summary>
        public void Resume()
        {
            try
            {
                m_ijob.Resume();
            }
            catch (COMException cex)
            {
                HandleCOMException(cex);
            }
        }

        /// <summary>
        /// Use the SetCredentials method to specify the credentials to use for a proxy or remote server user authentication request.
        /// </summary>
        /// <param name="cred">Identifies the user's credentials to use for user authentication.</param>
        public void SetCredentials(System.Net.NetworkCredential cred)
        {
            ReqJob2();
            BG_AUTH_CREDENTIALS ac = new BG_AUTH_CREDENTIALS();
            ac.Target = BG_AUTH_TARGET.BG_AUTH_TARGET_SERVER;
            if (string.IsNullOrEmpty(cred.Domain))
            {
                if (!string.IsNullOrEmpty(cred.UserName))
                {
                    ac.Scheme = BG_AUTH_SCHEME.BG_AUTH_SCHEME_BASIC;
                    ac.Credentials.Basic.UserName = cred.UserName;
                    ac.Credentials.Basic.Password = cred.Password;
                }
                else
                    ac.Scheme = BG_AUTH_SCHEME.BG_AUTH_SCHEME_NTLM;
            }
            else
            {
                ac.Scheme = BG_AUTH_SCHEME.BG_AUTH_SCHEME_NTLM;
                ac.Credentials.Basic.UserName = string.Concat(cred.Domain, '\\', cred.UserName);
                ac.Credentials.Basic.Password = cred.Password;
            }
            try
            {
                m_ijob2.SetCredentials(ref ac);
            }
            catch (COMException cex)
            {
                HandleCOMException(cex);
            }
        }

        /// <summary>
        /// Use the Suspend method to suspend a job. New jobs, jobs that are in error, and jobs that have finished transferring files are automatically suspended.
        /// </summary>
        public void Suspend()
        {
            try
            {
                m_ijob.Suspend();
            }
            catch (COMException cex)
            {
                HandleCOMException(cex);
            }
        }

        /// <summary>
        /// Use the TakeOwnership method to change ownership of the job to the current user. To take ownership of the job, the user must have administrator privileges on the client.
        /// </summary>
        public void TakeOwnership()
        {
            try
            {
                m_ijob.TakeOwnership();
            }
            catch (COMException cex)
            {
                HandleCOMException(cex);
            }
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool ConvertStringSidToSid(string StringSid, ref IntPtr ptrSid);

        internal static DateTime FT2DateTime(System.Runtime.InteropServices.ComTypes.FILETIME ft)
        {
            byte[] ft2 = new byte[sizeof(long)];
            BitConverter.GetBytes(ft.dwLowDateTime).CopyTo(ft2, 0);
            BitConverter.GetBytes(ft.dwHighDateTime).CopyTo(ft2, 4);
            return DateTime.FromFileTime(BitConverter.ToInt64(ft2, 0));
        }

        internal static BackgroundCopyJobState GetState(IBackgroundCopyJob ijob)
        {
            BackgroundCopyJobState o;
            ijob.GetState(out o);
            return o;
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool LookupAccountSid(string lpSystemName, IntPtr Sid, System.Text.StringBuilder lpName, ref uint cchName, System.Text.StringBuilder ReferencedDomainName, ref uint cchReferencedDomainName, out uint peUse);

        internal static string UserFromSSID(string ssid)
        {
            try
            {
                IntPtr pSid = new IntPtr(0);
                if (ConvertStringSidToSid(ssid, ref pSid))
                {
                    const int szBuf = 255;
                    uint cbName = szBuf, cbDom = szBuf, snu;
                    StringBuilder name = new StringBuilder(szBuf);
                    StringBuilder dom = new StringBuilder(szBuf);
                    if (LookupAccountSid(string.Empty, pSid, name, ref cbName, dom, ref cbDom, out snu))
                    {
                        return string.Concat(dom, '\\', name);
                    }
                }
            }
            catch { }
            return string.Empty;
        }

        internal void OnError(IBackgroundCopyError err)
        {
            System.IO.ErrorEventHandler temp = ErrorHandler;
            if (temp != null)
                temp(this, new System.IO.ErrorEventArgs(new BackgroundCopyException(err)));
        }

        /// <summary>
        /// Called when the job has completed.
        /// </summary>
        protected void OnCompleted()
        {
            BackgroundCopyJobEventHandler temp = CompletedHandler;
            if (temp != null)
                temp(this, new BackgroundCopyJobEventArgs(this));
        }

        /// <summary>
        /// Called when the job has been modified.
        /// </summary>
        protected void OnModified()
        {
            BackgroundCopyJobEventHandler temp = ModifiedHandler;
            if (temp != null)
                temp(this, new BackgroundCopyJobEventArgs(this));
        }

        private void CheckNotifier()
        {
            if (m_notifier == null)
            {
                this.NotifyFlags = 0;
                m_notifier = new Notifier(this);
            }
            BackgroundCopyJobState st = this.State;
            if (st != BackgroundCopyJobState.Acknowledged && st != BackgroundCopyJobState.Cancelled)
                m_ijob.SetNotifyInterface(m_notifier);
        }

        private void HandleCOMException(COMException cex)
        {
            if (this.State == BackgroundCopyJobState.Error ||
                this.State == BackgroundCopyJobState.TransientError)
            {
                IBackgroundCopyError pErr;
                m_ijob.GetError(out pErr);
                OnError(pErr);
            }
            else
                throw new BackgroundCopyException(cex);
        }

        private void ReqJob2()
        {
            try
            {
                m_ijob2 = (IBackgroundCopyJob2)m_ijob;
            }
            catch
            {
                throw new NotSupportedException();
            }
        }

        private void ReqJob3()
        {
            try
            {
                m_ijob3 = (IBackgroundCopyJob3)m_ijob;
            }
            catch
            {
                throw new NotSupportedException();
            }
        }

        [ComVisible(true)]
        internal class Notifier : IBackgroundCopyCallback
        {
            private BackgroundCopyJob parent;

            public Notifier()
            {
            }

            public Notifier(BackgroundCopyJob job)
            {
                parent = job;
            }

            void IBackgroundCopyCallback.JobError(IBackgroundCopyJob pJob, IBackgroundCopyError pError)
            {
                parent.OnError(pError);
            }

            void IBackgroundCopyCallback.JobModification(IBackgroundCopyJob pJob, uint dwReserved)
            {
                parent.OnModified();
            }

            void IBackgroundCopyCallback.JobTransferred(IBackgroundCopyJob pJob)
            {
                parent.OnCompleted();
            }
        }
    }

    /// <summary>
    /// Event argument for background copy job.
    /// </summary>
    public class BackgroundCopyJobEventArgs : EventArgs
    {
        internal BackgroundCopyJobEventArgs(BackgroundCopyJob j)
        {
            Job = j;
        }

        private BackgroundCopyJobEventArgs()
        {
        }

        /// <summary>
        /// Gets the job being processed.
        /// </summary>
        /// <value>The job.</value>
        public BackgroundCopyJob Job
        {
            get;
            private set;
        }
    }
}