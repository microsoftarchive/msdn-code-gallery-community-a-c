using System.Runtime.InteropServices;

namespace Microsoft.Net.BITS
{
	/// <summary>
	/// Provides job-related progress information, such as the number of bytes and files transferred. For upload jobs, the progress applies to the upload file, not the reply file.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct BackgroundCopyJobProgress
	{
		/// <summary>
		/// Total number of bytes to transfer for all files in the job. If the value is -1, the total size of all files in the job has not been determined. BITS does not set this value if it cannot determine the size of one of the files. For example, if the specified file or server does not exist, BITS cannot determine the size of the file. If you are downloading ranges from the file, BytesTotal includes the total number of bytes you want to download from the file.
		/// </summary>
		public ulong BytesTotal;
		/// <summary>
		/// Number of bytes transferred.
		/// </summary>
		public ulong BytesTransferred;
		/// <summary>
		/// Total number of files to transfer for this job.
		/// </summary>
		public uint FilesTotal;
		/// <summary>
		/// Number of files transferred.
		/// </summary>
		public uint FilesTransferred;
	}

	/// <summary>
	/// Provides progress information related to the reply portion of an upload-reply job.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct BackgroundCopyJobReplyProgress
	{
		/// <summary>
		/// Total number of bytes to transfer for all files in the job. If the value is -1, the total size of all files in the job has not been determined. BITS does not set this value if it cannot determine the size of one of the files. For example, if the specified file or server does not exist, BITS cannot determine the size of the file. If you are downloading ranges from the file, BytesTotal includes the total number of bytes you want to download from the file.
		/// </summary>
		public ulong BytesTotal;
		/// <summary>
		/// Number of bytes transferred.
		/// </summary>
		public ulong BytesTransferred;
	}
}
