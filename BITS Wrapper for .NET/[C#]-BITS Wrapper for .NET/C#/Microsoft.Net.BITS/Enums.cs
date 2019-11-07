using System;

namespace Microsoft.Net.BITS
{
    /// <summary>
    /// Flags for ACL information to maintain when using SMB to download or upload a file.
    /// </summary>
    [Flags]
    public enum BackgroundCopyACLFlags
    {
        /// <summary>
        /// If set exclusively, BITS uses the default ACL information of the destination folder.
        /// </summary>
        None = 0,
        /// <summary>
        /// If set, the file's owner information is maintained. Otherwise, the user who calls the <see cref="BackgroundCopyJob.Complete"/> method owns the file.
        /// </summary>
        Owner = 1,
        /// <summary>
        /// If set, the file's group information is maintained. Otherwise, BITS uses the job owner's primary group to assign the group information to the file.
        /// </summary>
        Group = 2,
        /// <summary>
        /// If set, BITS copies the explicit ACEs from the source file and inheritable ACEs from the destination folder. Otherwise, BITS copies the inheritable ACEs from the destination folder. If the destination folder does not contain inheritable ACEs, BITS uses the default DACL from the owner's account.
        /// </summary>
        Dacl = 4,
        /// <summary>
        /// If set, BITS copies the explicit ACEs from the source file and inheritable ACEs from the destination folder. Otherwise, BITS copies the inheritable ACEs from the destination folder.
        /// </summary>
        Sacl = 8,
        /// <summary>
        /// If set, BITS copies the owner and ACL information. This is the same as setting all the flags individually.
        /// </summary>
        All = 15
    }

    /// <summary>
    /// Defines the constant values that specify the context in which the error occurred.
    /// </summary>
    public enum BackgroundCopyErrorContext
    {
        /// <summary>
        /// An error has not occurred.
        /// </summary>
        None,
        /// <summary>
        /// The error context is unknown.
        /// </summary>
        Unknown,
        /// <summary>
        /// The transfer queue manager generated the error.
        /// </summary>
        GeneralQueueManager,
        /// <summary>
        /// The error was generated while the queue manager was notifying the client of an event.
        /// </summary>
        QueueManagerNotification,
        /// <summary>
        /// The error was related to the specified local file. For example, permission was denied or the volume was unavailable.
        /// </summary>
        LocalFile,
        /// <summary>
        /// The error was related to the specified remote file. For example, the URL was not accessible.
        /// </summary>
        RemoteFile,
        /// <summary>
        /// The transport layer generated the error. These errors are general transport failures (these errors are not specific to the remote file).
        /// </summary>
        GeneralTransport,
        /// <summary>
        /// The server application that BITS passed the upload file to generated an error while processing the upload file.
        /// </summary>
        RemoteApplication
    }

    /// <summary>
    /// Defines the constant values that specify the priority level of a job.
    /// </summary>
    public enum BackgroundCopyJobPriority
    {
        /// <summary>
        /// Transfers the job in the foreground. Foreground transfers compete for network bandwidth with other applications, which can impede the user's network experience. This is the highest priority level.
        /// </summary>
        Foreground,
        /// <summary>
        /// Transfers the job in the background with a high priority. Background transfers use idle network bandwidth of the client to transfer files. This is the highest background priority level.
        /// </summary>
        High,
        /// <summary>
        /// Transfers the job in the background with a normal priority. Background transfers use idle network bandwidth of the client to transfer files. This is the default priority level.
        /// </summary>
        Normal,
        /// <summary>
        /// Transfers the job in the background with a low priority. Background transfers use idle network bandwidth of the client to transfer files. This is the lowest background priority level.
        /// </summary>
        Low
    }

    /// <summary>
    /// Defines constant values for the different states of a job.
    /// </summary>
    public enum BackgroundCopyJobState
    {
        /// <summary>
        /// Specifies that the job is in the queue and waiting to run. If a user logs off while their job is transferring, the job transitions to the queued state.
        /// </summary>
        Queued,
        /// <summary>
        /// Specifies that BITS is trying to connect to the server. If the connection succeeds, the state of the job becomes Transferring; otherwise, the state becomes TransientError.
        /// </summary>
        Connecting,
        /// <summary>
        /// Specifies that BITS is transferring data for the job.
        /// </summary>
        Transferring,
        /// <summary>
        /// Specifies that the job is suspended (paused). To suspend a job, call the <see cref="BackgroundCopyJob.Suspend"/> method. BITS automatically suspends a job when it is created. The job remains suspended until you call the <see cref="BackgroundCopyJob.Resume"/>, <see cref="BackgroundCopyJob.Complete"/>, or <see cref="BackgroundCopyJob.Cancel"/> method.
        /// </summary>
        Suspended,
        /// <summary>
        /// Specifies that a non-recoverable error occurred (the service is unable to transfer the file). If the error, such as an access-denied error, can be corrected, call the <see cref="BackgroundCopyJob.Resume"/> method after the error is fixed. However, if the error cannot be corrected, call the <see cref="BackgroundCopyJob.Cancel"/> method to cancel the job, or call the <see cref="BackgroundCopyJob.Complete"/> method to accept the portion of a download job that transferred successfully.
        /// </summary>
        Error,
        /// <summary>
        /// Specifies that a recoverable error occurred. BITS will retry jobs in the transient error state based on the retry interval you specify (see <see cref="BackgroundCopyJob.MinimumRetryDelay"/>). The state of the job changes to <see cref="BackgroundCopyJobState.Error"/> if the job fails to make progress (see <see cref="BackgroundCopyJob.NoProgressTimeout"/>). BITS does not retry the job if a network disconnect or disk lock error occurred (for example, chkdsk is running) or the MaxInternetBandwidth Group Policy is zero.
        /// </summary>
        TransientError,
        /// <summary>
        /// Specifies that your job was successfully processed. You must call the <see cref="BackgroundCopyJob.Complete"/> method to acknowledge completion of the job and to make the files available to the client.
        /// </summary>
        Transferred,
        /// <summary>
        /// Specifies that you called the <see cref="BackgroundCopyJob.Complete"/> method to acknowledge that your job completed successfully.
        /// </summary>
        Acknowledged,
        /// <summary>
        /// Specifies that you called the <see cref="BackgroundCopyJob.Cancel"/> method to cancel the job (remove the job from the transfer queue).
        /// </summary>
        Cancelled
    }

    /// <summary>
    /// Defines constant values that specify the type of transfer job, such as download.
    /// </summary>
    public enum BackgroundCopyJobType
    {
        /// <summary>
        /// Specifies that the job downloads files to the client.
        /// </summary>
        Download,
        /// <summary>
        /// Specifies that the job uploads a file to the server.
        /// </summary>
        Upload,
        /// <summary>
        /// Specifies that the job uploads a file to the server and receives a reply file from the server application.
        /// </summary>
        UploadReply
    }
}