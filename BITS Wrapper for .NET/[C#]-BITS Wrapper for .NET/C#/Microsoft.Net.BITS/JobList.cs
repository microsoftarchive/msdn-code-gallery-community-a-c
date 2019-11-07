using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Microsoft.Net.BITS
{
	using Interop;

	/// <summary>
    /// Manages the set of jobs for the background copy service (BITS).
    /// </summary>
    public class BackgroundCopyJobList : IEnumerable<BackgroundCopyJob>
    {
        internal BackgroundCopyJobList()
        {
        }

        /// <summary>
        /// Gets the number of jobs currently managed by BITS.
        /// </summary>
        public int Count
        {
            get
            {
                try
                {
                    uint cnt;
                    IEnumBackgroundCopyJobs ienum;
                    BackgroundCopyManager.IBackgroundCopyManager.EnumJobs(JobListRights, out ienum);
                    ienum.GetCount(out cnt);
                    return (int)cnt;
                }
                catch (COMException cex)
                {
                    throw new BackgroundCopyException(cex);
                }
            }
        }

        /// <summary>
        /// Gets the correct flag for enumerating jobs based on whether user has administrator rights.
        /// </summary>
        private uint JobListRights
        {
            get
            {
                return BackgroundCopyManager.IsCurrentUserAdministrator() ? 1u : 0u;
            }
        }

        /// <summary>
        /// Gets the <see cref="BackgroundCopyJob"/> object with the specified job identifier.
        /// </summary>
        /// <param name="jobId">Unique identifier of the job.</param>
        /// <returns>The referenced <see cref="BackgroundCopyJob"/> object if found, null if not.</returns>
        public BackgroundCopyJob this[Guid jobId]
        {
            get
            {
                try
                {
                    IBackgroundCopyJob ijob;
                    BackgroundCopyManager.IBackgroundCopyManager.GetJob(ref jobId, out ijob);
                    return new BackgroundCopyJob(ijob);
                }
                catch (COMException cex)
                {
                    if ((uint)cex.ErrorCode != 0x80200001)
                        throw new BackgroundCopyException(cex);
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the <see cref="BackgroundCopyJob"/> object with the specified display name.
        /// </summary>
        /// <param name="jobName">Display name of the job.</param>
        /// <returns>The first <see cref="BackgroundCopyJob"/> object with the specified name if found, null if not.</returns>
        public BackgroundCopyJob this[string jobName]
        {
            get
            {
                foreach (BackgroundCopyJob j in this)
                {
                    if (j.DisplayName == jobName)
                        return j;
                }
                return null;
            }
        }

        /// <summary>
        /// Returns an object that implements the <see cref="System.Collections.IEnumerator"/> interface and that can iterate through the <see cref="BackgroundCopyFileInfo"/> objects within the <see cref="BackgroundCopyFileSet"/> collection.
        /// </summary>
        /// <returns>Returns an object that implements the <see cref="System.Collections.IEnumerator"/> interface and that can iterate through the <see cref="BackgroundCopyFileInfo"/> objects within the <see cref="BackgroundCopyFileSet"/> collection.</returns>
        public System.Collections.IEnumerator GetEnumerator()
        {
            return ((IEnumerable<BackgroundCopyJob>)this).GetEnumerator();
        }

        /// <summary>
        /// Returns an object that implements the <see cref="System.Collections.IEnumerator"/> interface and that can iterate through the <see cref="BackgroundCopyFileInfo"/> objects within the <see cref="BackgroundCopyFileSet"/> collection.
        /// </summary>
        /// <returns>Returns an object that implements the <see cref="System.Collections.IEnumerator"/> interface and that can iterate through the <see cref="BackgroundCopyFileInfo"/> objects within the <see cref="BackgroundCopyFileSet"/> collection.</returns>
        IEnumerator<BackgroundCopyJob> IEnumerable<BackgroundCopyJob>.GetEnumerator()
        {
            IEnumBackgroundCopyJobs ienum;
            BackgroundCopyManager.IBackgroundCopyManager.EnumJobs(JobListRights, out ienum);
            return new Enumerator(ienum);
        }

        /// <summary>
        /// An implementation the <see cref="System.Collections.IEnumerator"/> interface that can iterate through the <see cref="BackgroundCopyJob"/> objects within the <see cref="BackgroundCopyJobList"/> collection.
        /// </summary>
        private sealed class Enumerator : IEnumerator<BackgroundCopyJob>
        {
            private IBackgroundCopyJob icurrentjob;
            private IEnumBackgroundCopyJobs ienum;

            internal Enumerator(IEnumBackgroundCopyJobs enumjobs)
            {
                ienum = enumjobs;
                ienum.Reset();
            }

            /// <summary>
            /// Gets the <see cref="BackgroundCopyJob"/> object in the <see cref="BackgroundCopyJobList"/> collection to which the enumerator is pointing.
            /// </summary>
            public BackgroundCopyJob Current
            {
                get
                {
                    if (icurrentjob == null)
                        throw new InvalidOperationException();
                    return new BackgroundCopyJob(icurrentjob);
                }
            }

            /// <summary>
            /// Gets the <see cref="BackgroundCopyJob"/> object in the <see cref="BackgroundCopyJobList"/> collection to which the enumerator is pointing.
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
                icurrentjob = null;
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
                    ienum.Next(1, out icurrentjob, ref cnt);
                }
                catch { }
                return (cnt == 1);
            }

            /// <summary>
            /// Resets the enumerator index to the beginning of the <see cref="BackgroundCopyJobList"/> collection.
            /// </summary>
            public void Reset()
            {
                icurrentjob = null;
                ienum.Reset();
            }
        }
    }
}