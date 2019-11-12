using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Microsoft.Net.BITS
{
    /// <summary>
    /// Information about a file in a background copy job.
    /// </summary>
    public class BackgroundCopyFileInfo
    {
        internal Interop.BackgroundCopyFileInfo fi;

        private Interop.IBackgroundCopyFile iFile;

        internal BackgroundCopyFileInfo(Interop.IBackgroundCopyFile ibgfile)
        {
            iFile = ibgfile;
        }

        internal BackgroundCopyFileInfo(Interop.BackgroundCopyFileInfo bgfi)
        {
            fi = bgfi;
        }

        /// <summary>
        /// Gets the number of bytes transferred.
        /// </summary>
        public long BytesTransferred
        {
            get { return (long)CopyProgress.BytesTransferred; }
        }

        /// <summary>
        /// Size of the file in bytes. If the value is -1, the total size of the file has not been determined. BITS does not set this value if it cannot determine the size of the file. For example, if the specified file or server does not exist, BITS cannot determine the size of the file. If you are downloading ranges from a file, BytesTotal reflects the total number of bytes you want to download from the file.
        /// </summary>
        public long Length
        {
            get { return (long)CopyProgress.BytesTotal; }
        }

        /// <summary>
        /// Retrieves the local name of the file.
        /// </summary>
        public string LocalFilePath
        {
            get
            {
                if (iFile == null)
                    return fi.LocalName;
                else
                {
                    string s;
                    iFile.GetLocalName(out s);
                    return s;
                }
            }
            set
            {
                if (iFile != null)
                    throw new InvalidOperationException("You cannot change the LocalFilePath property on CurrentFileSet results.");
                fi.LocalName = value;
            }
        }

        /// <summary>
        /// Gets the percentage of the transfer that has completed.
        /// </summary>
        public float PercentComplete
        {
            get
            {
                Interop.BackgroundCopyFileProgress p = CopyProgress;
                if (p.Completed != 0 || p.BytesTotal == 0)
                    return 100.0F;
                return (float)p.BytesTransferred * 100.0F / (float)p.BytesTotal;
            }
        }

        /// <summary>
        /// Retrieves the remote name of the file.
        /// </summary>
        public string RemoteFilePath
        {
            get
            {
                if (iFile == null)
                    return fi.RemoteName;
                else
                {
                    string s;
                    iFile.GetRemoteName(out s);
                    return s;
                }
            }
            set
            {
                if (iFile != null)
                    throw new InvalidOperationException("You cannot change the RemoteUrl property on CurrentFileSet results.");
                fi.RemoteName = value;
            }
        }

        /// <summary>
        /// For downloads, the value is TRUE if the file is available to the user; otherwise, the value is FALSE. Files are available to the user after calling the <see cref="BackgroundCopyJob.Complete"/> method. If the <see cref="BackgroundCopyJob.Complete"/> method generates a transient error, those files processed before the error occurred are available to the user; the others are not. Use the Completed property to determine if the file is available to the user when Complete fails. For uploads, the value is TRUE when the file upload is complete; otherwise, the value is FALSE.
        /// </summary>
        public bool TransferCompleted
        {
            get { return CopyProgress.Completed != 0; }
        }

        /// <summary>
        /// Retrieves the progress of the file transfer.
        /// </summary>
        internal Interop.BackgroundCopyFileProgress CopyProgress
        {
            get
            {
                if (iFile == null)
                    throw new InvalidOperationException("You can only get the CopyProgress on CurrentFileSet results.");
                else
                {
                    Interop.BackgroundCopyFileProgress fp;
                    iFile.GetProgress(out fp);
                    return fp;
                }
            }
        }
    }

    /// <summary>
    /// Manages the set of files for a background copy job.
    /// </summary>
    public class BackgroundCopyFileSet : IEnumerable<BackgroundCopyFileInfo>, IDisposable
    {
        private Interop.IBackgroundCopyJob m_ijob;

        internal BackgroundCopyFileSet(Interop.IBackgroundCopyJob ijob)
        {
            m_ijob = ijob;
        }

        internal BackgroundCopyFileSet()
        {
        }

        /// <summary>
        /// Gets the number of files in the current job.
        /// </summary>
        public int Count
        {
            get
            {
                try
                {
                    uint cnt;
                    Interop.IEnumBackgroundCopyFiles ienum;
                    m_ijob.EnumFiles(out ienum);
                    ienum.GetCount(out cnt);
                    return (int)cnt;
                }
                catch (COMException cex)
                {
                    HandleCOMException(cex);
                }
                return 0;
            }
        }

        /// <summary>
        /// Add a file to a download or an upload job. Only one file can be added to upload jobs.
        /// </summary>
        /// <param name="remoteFilePath">
        /// Contains the name of the file on the server (for example, http://[server]/[path]/file.ext). The format of the name must conform to the transfer protocol you use. You cannot use wildcards in the path or file name. The URL must contain only legal URL characters; no escape processing is performed. The URL is limited to 2,200 characters, not including the null terminator. You can use SMB to express the remote name of the file to download or upload; there is no SMB support for upload-reply jobs. You can specify the remote name as a UNC path, full path with a network drive, or use the "file://" prefix.
        /// </param>
        /// <param name="localFilePath">
        /// Contains the name of the file on the client. The file name must include the full path (for example, d:\myapp\updates\file.ext). You cannot use wildcards in the path or file name, and directories in the path must exist. The user must have permission to write to the local directory for downloads and the reply portion of an upload-reply job. BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths.
        /// </param>
        public void Add(string remoteFilePath, string localFilePath)
        {
            try
            {
                m_ijob.AddFile(remoteFilePath, localFilePath);
            }
            catch (COMException cex)
            {
                HandleCOMException(cex);
            }
        }

        /// <summary>
        /// Add a file to a download job starting from an initial offset in the file.
        /// </summary>
        /// <param name="remoteFilePath">
        /// Contains the name of the file on the server (for example, http://[server]/[path]/file.ext). The format of the name must conform to the transfer protocol you use. You cannot use wildcards in the path or file name. The URL must contain only legal URL characters; no escape processing is performed. The URL is limited to 2,200 characters, not including the null terminator. You can use SMB to express the remote name of the file to download or upload; there is no SMB support for upload-reply jobs. You can specify the remote name as a UNC path, full path with a network drive, or use the "file://" prefix.
        /// </param>
        /// <param name="localFilePath">
        /// Contains the name of the file on the client. The file name must include the full path (for example, d:\myapp\updates\file.ext). You cannot use wildcards in the path or file name, and directories in the path must exist. The user must have permission to write to the local directory for downloads and the reply portion of an upload-reply job. BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths.
        /// </param>
        /// <param name="initialOffset">Zero-based offset to the beginning of the range of bytes to download from a file.</param>
        public void Add(string remoteFilePath, string localFilePath, long initialOffset)
        {
            try
            {
                Add(remoteFilePath, localFilePath, initialOffset, -1);
            }
            catch (COMException cex)
            {
                HandleCOMException(cex);
            }
        }

        /// <summary>
        /// Add a file to a download job and specify the ranges of the file you want to download.
        /// </summary>
        /// <param name="remoteFilePath">
        /// Contains the name of the file on the server (for example, http://[server]/[path]/file.ext). The format of the name must conform to the transfer protocol you use. You cannot use wildcards in the path or file name. The URL must contain only legal URL characters; no escape processing is performed. The URL is limited to 2,200 characters, not including the null terminator. You can use SMB to express the remote name of the file to download or upload; there is no SMB support for upload-reply jobs. You can specify the remote name as a UNC path, full path with a network drive, or use the "file://" prefix.
        /// </param>
        /// <param name="localFilePath">
        /// Contains the name of the file on the client. The file name must include the full path (for example, d:\myapp\updates\file.ext). You cannot use wildcards in the path or file name, and directories in the path must exist. The user must have permission to write to the local directory for downloads and the reply portion of an upload-reply job. BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths.
        /// </param>
        /// <param name="initialOffset">Zero-based offset to the beginning of the range of bytes to download from a file.</param>
        /// <param name="length">Number of bytes in the range.</param>
        public void Add(string remoteFilePath, string localFilePath, long initialOffset, long length)
        {
            Interop.IBackgroundCopyJob3 ijob3 = null;
            try
            {
                ijob3 = (Interop.IBackgroundCopyJob3)m_ijob;
            }
            catch
            {
                throw new NotSupportedException();
            }
            Interop.BG_FILE_RANGE rng;
            rng.InitialOffset = (ulong)initialOffset;
            if (length == -1)
                rng.Length = ulong.MaxValue;
            else
                rng.Length = (ulong)length;
            try
            {
                ijob3.AddFileWithRanges(remoteFilePath, localFilePath, 1, rng);
            }
            catch (COMException cex)
            {
                HandleCOMException(cex);
            }
        }

        /// <summary>
        /// Add a list of files to download from a URL.
        /// </summary>
        /// <param name="remoteUrlRoot">
        /// Contains the name of the directory on the server (for example, http://[server]/[path]/). The format of the name must conform to the transfer protocol you use. You cannot use wildcards in the path or file name. The URL must contain only legal URL characters; no escape processing is performed. The URL is limited to 2,200 characters, not including the null terminator. You can use SMB to express the remote name of the file to download or upload; there is no SMB support for upload-reply jobs. You can specify the remote name as a UNC path, full path with a network drive, or use the "file://" prefix.
        /// </param>
        /// <param name="localDirectory">
        /// Contains the name of the directory on the client. The directory must exist. The user must have permission to write to the directory for downloads. BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths.
        /// </param>
        /// <param name="files">List of file names to retrieve. Filename will be appended to both the remoteUrlRoot and the localDirectory.</param>
        public void Add(Uri remoteUrlRoot, string localDirectory, string[] files)
        {
            foreach (string s in files)
                Add(new Uri(remoteUrlRoot, s).AbsoluteUri, System.IO.Path.Combine(localDirectory, s));
        }

        /// <summary>
        /// Disposes of the BackgroundCopyFileSet object.
        /// </summary>
        public void Dispose()
        {
            m_ijob = null;
        }

        /// <summary>
        /// Returns an object that implements the <see cref="System.Collections.IEnumerator"/> interface and that can iterate through the <see cref="BackgroundCopyFileInfo"/> objects within the <see cref="BackgroundCopyFileSet"/> collection.
        /// </summary>
        /// <returns>Returns an object that implements the <see cref="System.Collections.IEnumerator"/> interface and that can iterate through the <see cref="BackgroundCopyFileInfo"/> objects within the <see cref="BackgroundCopyFileSet"/> collection.</returns>
        public System.Collections.IEnumerator GetEnumerator()
        {
            return ((IEnumerable<BackgroundCopyFileInfo>)this).GetEnumerator();
        }

        /// <summary>
        /// Returns an object that implements the <see cref="System.Collections.IEnumerator"/> interface and that can iterate through the <see cref="BackgroundCopyFileInfo"/> objects within the <see cref="BackgroundCopyFileSet"/> collection.
        /// </summary>
        /// <returns>Returns an object that implements the <see cref="System.Collections.IEnumerator"/> interface and that can iterate through the <see cref="BackgroundCopyFileInfo"/> objects within the <see cref="BackgroundCopyFileSet"/> collection.</returns>
        IEnumerator<BackgroundCopyFileInfo> IEnumerable<BackgroundCopyFileInfo>.GetEnumerator()
        {
            Interop.IEnumBackgroundCopyFiles ienum;
            m_ijob.EnumFiles(out ienum);
            return new Enumerator(ienum);
        }

        internal Interop.BackgroundCopyFileInfo[] GetBCFIArray()
        {
            Interop.BackgroundCopyFileInfo[] ret = new Microsoft.Net.BITS.Interop.BackgroundCopyFileInfo[this.Count];
            int i = 0;
            foreach (BackgroundCopyFileInfo fi in this)
                ret[i++] = new Interop.BackgroundCopyFileInfo(fi.RemoteFilePath, fi.LocalFilePath);
            return ret;
        }

        private void HandleCOMException(COMException cex)
        {
            BackgroundCopyJobState state = BackgroundCopyJob.GetState(m_ijob);
            if (state == BackgroundCopyJobState.Error ||
                state == BackgroundCopyJobState.TransientError)
            {
                Interop.IBackgroundCopyError pErr;
                m_ijob.GetError(out pErr);
                throw new BackgroundCopyException(pErr);
            }
            else
                throw new BackgroundCopyException(cex);
        }

        /// <summary>
        /// An implementation the <see cref="System.Collections.IEnumerator"/> interface that can iterate through the <see cref="BackgroundCopyFileInfo"/> objects within the <see cref="BackgroundCopyFileSet"/> collection.
        /// </summary>
        private sealed class Enumerator : IEnumerator<BackgroundCopyFileInfo>
        {
            private Interop.IBackgroundCopyFile icurrentfile;
            private Interop.IEnumBackgroundCopyFiles ienum;

            internal Enumerator(Interop.IEnumBackgroundCopyFiles enumfiles)
            {
                ienum = enumfiles;
                ienum.Reset();
            }

            /// <summary>
            /// Gets the <see cref="BackgroundCopyFileInfo"/> object in the <see cref="BackgroundCopyFileSet"/> collection to which the enumerator is pointing.
            /// </summary>
            public BackgroundCopyFileInfo Current
            {
                get
                {
                    if (icurrentfile == null)
                        throw new InvalidOperationException();
                    return new BackgroundCopyFileInfo(icurrentfile);
                }
            }

            /// <summary>
            /// Gets the <see cref="BackgroundCopyFileInfo"/> object in the <see cref="BackgroundCopyFileSet"/> collection to which the enumerator is pointing.
            /// </summary>
            object System.Collections.IEnumerator.Current
            {
                get { return this.Current; }
            }

            /// <summary>
            /// Disposes of the Enumerator object.
            /// </summary>
            public void Dispose()
            {
                ienum = null;
                icurrentfile = null;
            }

            /// <summary>
            /// Moves the enumerator index to the next object in the collection.
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                uint cnt = 0;
                try
                {
                    ienum.Next(1, out icurrentfile, ref cnt);
                }
                catch { }
                return (cnt == 1);
            }

            /// <summary>
            /// Resets the enumerator index to the beginning of the <see cref="BackgroundCopyFileSet"/> collection.
            /// </summary>
            public void Reset()
            {
                icurrentfile = null;
                ienum.Reset();
            }
        }
    }
}