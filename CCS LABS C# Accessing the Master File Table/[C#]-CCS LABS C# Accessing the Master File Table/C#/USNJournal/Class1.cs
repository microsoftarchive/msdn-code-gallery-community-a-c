// er's Blog        RSS Feed
/// -----
// Added Code To Get Path (StCroixSkipper's UsnJournalExplorer) NtfsUsnJournal.cs
// 02 May 2010
// Icon Leave Comment
// Posted by StCroixSkipper Icon
// I've added the code to calculate and display the path in the detail window. I had to change Win32Api.cs, NtfsUsnJournal.cs and UsnEntryDetail.cs.

// Note: I haven't dealt with the edge case where the UsnEntry I'm processing points to a directory that has already been deleted.

// Here is the new NtfsUsnJournal.cs file:

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.IO;
	 
//	using PInvoke;
	using System.ComponentModel;
	using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Win32;
	using Microsoft.Win32.SafeHandles;
using System.Security.Cryptography;
	 
	namespace UsnJournal
	{
		public class NtfsUsnJournal : IDisposable
		{
			#region enum(s)
			public enum UsnJournalReturnCode
			{
				INVALID_HANDLE_VALUE = -1,
				USN_JOURNAL_SUCCESS = 0,
				ERROR_INVALID_FUNCTION = 1,
				ERROR_FILE_NOT_FOUND = 2,
				ERROR_PATH_NOT_FOUND = 3,
				ERROR_TOO_MANY_OPEN_FILES = 4,
				ERROR_ACCESS_DENIED = 5,
				ERROR_INVALID_HANDLE = 6,
				ERROR_INVALID_DATA = 13,
				ERROR_HANDLE_EOF = 38,
				ERROR_NOT_SUPPORTED = 50,
				ERROR_INVALID_PARAMETER = 87,
				ERROR_JOURNAL_DELETE_IN_PROGRESS = 1178,
				USN_JOURNAL_NOT_ACTIVE = 1179,
				ERROR_JOURNAL_ENTRY_DELETED = 1181,
				ERROR_INVALID_USER_BUFFER = 1784,
				USN_JOURNAL_INVALID = 17001,
				VOLUME_NOT_NTFS = 17003,
				INVALID_FILE_REFERENCE_NUMBER = 17004,
				USN_JOURNAL_ERROR = 17005
			}
	 
			public enum UsnReasonCode
			{
				USN_REASON_DATA_OVERWRITE = 0x00000001,
				USN_REASON_DATA_EXTEND = 0x00000002,
				USN_REASON_DATA_TRUNCATION = 0x00000004,
				USN_REASON_NAMED_DATA_OVERWRITE = 0x00000010,
				USN_REASON_NAMED_DATA_EXTEND = 0x00000020,
				USN_REASON_NAMED_DATA_TRUNCATION = 0x00000040,
				USN_REASON_FILE_CREATE = 0x00000100,
				USN_REASON_FILE_DELETE = 0x00000200,
				USN_REASON_EA_CHANGE = 0x00000400,
				USN_REASON_SECURITY_CHANGE = 0x00000800,
				USN_REASON_RENAME_OLD_NAME = 0x00001000,
				USN_REASON_RENAME_NEW_NAME = 0x00002000,
				USN_REASON_INDEXABLE_CHANGE = 0x00004000,
				USN_REASON_BASIC_INFO_CHANGE = 0x00008000,
				USN_REASON_HARD_LINK_CHANGE = 0x00010000,
				USN_REASON_COMPRESSION_CHANGE = 0x00020000,
				USN_REASON_ENCRYPTION_CHANGE = 0x00040000,
				USN_REASON_OBJECT_ID_CHANGE = 0x00080000,
				USN_REASON_REPARSE_POINT_CHANGE = 0x00100000,
				USN_REASON_STREAM_CHANGE = 0x00200000,
				USN_REASON_CLOSE = -1
			}
	 
			#endregion

			public const UInt32 GENERIC_READ = 0x80000000;
			public const UInt32 GENERIC_WRITE = 0x40000000;
			public const UInt32 FILE_SHARE_READ = 0x00000001;
			public const UInt32 FILE_SHARE_WRITE = 0x00000002;
			public const UInt32 FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
			public const UInt32 OPEN_EXISTING = 3;
			public const UInt32 FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
			public const Int32 INVALID_HANDLE_VALUE = -1;
			public const UInt32 FSCTL_QUERY_USN_JOURNAL = 0x000900f4;
			public const UInt32 FSCTL_ENUM_USN_DATA = 0x000900b3;
			public const UInt32 FSCTL_CREATE_USN_JOURNAL = 0x000900e7;

			#region private member variables
	 
			private DriveInfo _driveInfo = null;
			private uint _volumeSerialNumber;
			private IntPtr _usnJournalRootHandle;
	 
			private bool bNtfsVolume;
	 
			#endregion
	 
			#region properties
	 
			private static TimeSpan _elapsedTime;
			public static TimeSpan ElapsedTime
			{
				get { return _elapsedTime; }
			}
	 
			public string VolumeName
			{
				get { return _driveInfo.Name; }
		}
	 
			public long AvailableFreeSpace
			{
				get { return _driveInfo.AvailableFreeSpace; }
			}
	 
			public long TotalFreeSpace
			{
				get { return _driveInfo.TotalFreeSpace; }
			}
	 
			public string Format
			{
				get { return _driveInfo.DriveFormat; }
			}
	 
			public DirectoryInfo RootDirectory
			{
				get { return _driveInfo.RootDirectory; }
			}
	 
			public long TotalSize
			{
				get { return _driveInfo.TotalSize; }
			}
	 
			public string VolumeLabel
			{
				get { return _driveInfo.VolumeLabel; }
			}
	 
			public uint VolumeSerialNumber
			{
				get { return _volumeSerialNumber; }
			}
	 
			#endregion
	 
			#region constructor(s)
	 
			/// <summary>
			/// Constructor for NtfsUsnJournal class.  If no exception is thrown, _usnJournalRootHandle and
			/// _volumeSerialNumber can be assumed to be good. If an exception is thrown, the NtfsUsnJournal
			/// object is not usable.
			/// </summary>
			/// <param name="driveInfo">DriveInfo object that provides access to information about a volume</param>
			/// <remarks>
			/// An exception thrown if the volume is not an 'NTFS' volume or
			/// if GetRootHandle() or GetVolumeSerialNumber() functions fail.
			/// Each public method checks to see if the volume is NTFS and if the _usnJournalRootHandle is
			/// valid.  If these two conditions aren't met, then the public function will return a UsnJournalReturnCode
			/// error.
			/// </remarks>
			public NtfsUsnJournal(DriveInfo driveInfo)
			{
				DateTime start = DateTime.Now;
				_driveInfo = driveInfo;
	 
				if (0 == string.Compare(_driveInfo.DriveFormat, "ntfs", true))
				{
					bNtfsVolume = true;
	 
					IntPtr rootHandle = IntPtr.Zero;
					UsnJournalReturnCode usnRtnCode = GetRootHandle(out rootHandle);
	 
					if (usnRtnCode == UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
					{
						_usnJournalRootHandle = rootHandle;
						usnRtnCode = GetVolumeSerialNumber(_driveInfo, out _volumeSerialNumber);
						if (usnRtnCode != UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
						{
							_elapsedTime = DateTime.Now - start;
							throw new Win32Exception((int)usnRtnCode);
						}
					}
					else
					{
						_elapsedTime = DateTime.Now - start;
						throw new Win32Exception((int)usnRtnCode);
					}
				}
				else
				{
					_elapsedTime = DateTime.Now - start;
					throw new Exception(string.Format("{0} is not an 'NTFS' volume.", _driveInfo.Name));
				}
				_elapsedTime = DateTime.Now - start;
			}
	 
			#endregion
	 
			#region public methods
	 
			/// <summary>
			/// CreateUsnJournal() creates a usn journal on the volume. If a journal already exists this function
			/// will adjust the MaximumSize and AllocationDelta parameters of the journal if the requested size
			/// is larger.
			/// </summary>
			/// <param name="maxSize">maximum size requested for the UsnJournal</param>
			/// <param name="allocationDelta">when space runs out, the amount of additional
			/// space to allocate</param>
			/// <param name="elapsedTime">The TimeSpan object indicating how much time this function
			/// took</param>
			/// <returns>a UsnJournalReturnCode
			/// USN_JOURNAL_SUCCESS                 CreateUsnJournal() function succeeded.
			/// VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			/// INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			/// USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
			/// ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			/// ERROR_INVALID_FUNCTION              error generated by DeviceIoControl() call.
			/// ERROR_FILE_NOT_FOUND                error generated by DeviceIoControl() call.
			/// ERROR_PATH_NOT_FOUND                error generated by DeviceIoControl() call.
			/// ERROR_TOO_MANY_OPEN_FILES           error generated by DeviceIoControl() call.
			/// ERROR_INVALID_HANDLE                error generated by DeviceIoControl() call.
			/// ERROR_INVALID_DATA                  error generated by DeviceIoControl() call.
			/// ERROR_NOT_SUPPORTED                 error generated by DeviceIoControl() call.
			/// ERROR_INVALID_PARAMETER             error generated by DeviceIoControl() call.
			/// ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			/// ERROR_INVALID_USER_BUFFER           error generated by DeviceIoControl() call.
			/// USN_JOURNAL_ERROR                   unspecified usn journal error.
			/// </returns>
			/// <remarks>
			/// If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			/// </remarks>
			public UsnJournalReturnCode
				CreateUsnJournal(ulong maxSize, ulong allocationDelta)
			{
				UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS;
				DateTime startTime = DateTime.Now;
	 
				if (bNtfsVolume)
				{
					if (_usnJournalRootHandle.ToInt32() != INVALID_HANDLE_VALUE)
					{
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
						UInt32 cb;
	 
						Win32Api.CREATE_USN_JOURNAL_DATA cujd = new Win32Api.CREATE_USN_JOURNAL_DATA();
						cujd.MaximumSize = maxSize;
						cujd.AllocationDelta = allocationDelta;
	 
						int sizeCujd = Marshal.SizeOf(cujd);
						IntPtr cujdBuffer = Marshal.AllocHGlobal(sizeCujd);
						Win32Api.ZeroMemory(cujdBuffer, sizeCujd);
						Marshal.StructureToPtr(cujd, cujdBuffer, true);
	 
						bool fOk = Win32Api.DeviceIoControl(
							_usnJournalRootHandle,
							Win32Api.FSCTL_CREATE_USN_JOURNAL,
							cujdBuffer,
							sizeCujd,
							IntPtr.Zero,
							0,
							out cb,
							IntPtr.Zero);
						if (!fOk)
						{
							usnRtnCode = ConvertWin32ErrorToUsnError((Win32Api.GetLastErrorEnum)Marshal.GetLastWin32Error());
						}
						Marshal.FreeHGlobal(cujdBuffer);
					}
					else
					{
						usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE;
					}
				}
	 
				_elapsedTime = DateTime.Now - startTime;
				return usnRtnCode;
			}
	 
			/// <summary>
			/// DeleteUsnJournal() deletes a usn journal on the volume. If no usn journal exists, this
			/// function simply returns success.
			/// </summary>
			/// <param name="journalState">USN_JOURNAL_DATA object for this volume</param>
			/// <param name="elapsedTime">The TimeSpan object indicating how much time this function
			/// took</param>
			/// <returns>a UsnJournalReturnCode
			/// USN_JOURNAL_SUCCESS                 DeleteUsnJournal() function succeeded.
			/// VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			/// INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			/// USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
		/// ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			/// ERROR_INVALID_FUNCTION              error generated by DeviceIoControl() call.
			/// ERROR_FILE_NOT_FOUND                error generated by DeviceIoControl() call.
			/// ERROR_PATH_NOT_FOUND                error generated by DeviceIoControl() call.
			/// ERROR_TOO_MANY_OPEN_FILES           error generated by DeviceIoControl() call.
			/// ERROR_INVALID_HANDLE                error generated by DeviceIoControl() call.
			/// ERROR_INVALID_DATA                  error generated by DeviceIoControl() call.
			/// ERROR_NOT_SUPPORTED                 error generated by DeviceIoControl() call.
			/// ERROR_INVALID_PARAMETER             error generated by DeviceIoControl() call.
			/// ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			/// ERROR_INVALID_USER_BUFFER           error generated by DeviceIoControl() call.
			/// USN_JOURNAL_ERROR                   unspecified usn journal error.
			/// </returns>
			/// <remarks>
			/// If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			/// </remarks>
			public UsnJournalReturnCode
			DeleteUsnJournal(Win32Api.USN_JOURNAL_DATA journalState)
			{
				UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS;
				DateTime startTime = DateTime.Now;
	 
				if (bNtfsVolume)
				{
					if (_usnJournalRootHandle.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
					{
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
						UInt32 cb;
	 
						Win32Api.DELETE_USN_JOURNAL_DATA dujd = new Win32Api.DELETE_USN_JOURNAL_DATA();
						dujd.UsnJournalID = journalState.UsnJournalID;
						dujd.DeleteFlags = (UInt32)Win32Api.UsnJournalDeleteFlags.USN_DELETE_FLAG_DELETE;
	 
						int sizeDujd = Marshal.SizeOf(dujd);
						IntPtr dujdBuffer = Marshal.AllocHGlobal(sizeDujd);
						Win32Api.ZeroMemory(dujdBuffer, sizeDujd);
						Marshal.StructureToPtr(dujd, dujdBuffer, true);
	 
						bool fOk = Win32Api.DeviceIoControl(
							_usnJournalRootHandle,
							Win32Api.FSCTL_DELETE_USN_JOURNAL,
							dujdBuffer,
							sizeDujd,
							IntPtr.Zero,
							0,
							out cb,
							IntPtr.Zero);
	 
						if (!fOk)
						{
							usnRtnCode = ConvertWin32ErrorToUsnError((Win32Api.GetLastErrorEnum)Marshal.GetLastWin32Error());
						}
						Marshal.FreeHGlobal(dujdBuffer);
					}
					else
					{
						usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE;
					}
				}
	 
				_elapsedTime = DateTime.Now - startTime;
				return usnRtnCode;
			}
	 
			/// <summary>
			/// GetNtfsVolumeFolders() reads the Master File Table to find all of the folders on a volume
			/// and returns them in a SortedList<UInt64, Win32Api.UsnEntry> folders out parameter.
			/// </summary>
			/// <param name="folders">A SortedList<string, UInt64> list where string is
			/// the filename and UInt64 is the parent folder's file reference number
			/// </param>
			/// <param name="elapsedTime">A TimeSpan object that on return holds the elapsed time
			/// </param>
			/// <returns>
			/// USN_JOURNAL_SUCCESS                 GetNtfsVolumeFolders() function succeeded.
			/// VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			/// INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			/// USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
			/// ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			/// ERROR_INVALID_FUNCTION              error generated by DeviceIoControl() call.
			/// ERROR_FILE_NOT_FOUND                error generated by DeviceIoControl() call.
			/// ERROR_PATH_NOT_FOUND                error generated by DeviceIoControl() call.
			/// ERROR_TOO_MANY_OPEN_FILES           error generated by DeviceIoControl() call.
			/// ERROR_INVALID_HANDLE                error generated by DeviceIoControl() call.
			/// ERROR_INVALID_DATA                  error generated by DeviceIoControl() call.
			/// ERROR_NOT_SUPPORTED                 error generated by DeviceIoControl() call.
			/// ERROR_INVALID_PARAMETER             error generated by DeviceIoControl() call.
			/// ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			/// ERROR_INVALID_USER_BUFFER           error generated by DeviceIoControl() call.
			/// USN_JOURNAL_ERROR                   unspecified usn journal error.
			/// </returns>
			/// <remarks>
			/// If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			/// </remarks>
			public UsnJournalReturnCode
				GetNtfsVolumeFolders(out List<Win32Api.UsnEntry> folders)
			{
				DateTime startTime = DateTime.Now;
				folders = new List<Win32Api.UsnEntry>();
				UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS;
	 
				if (bNtfsVolume)
				{
					if (_usnJournalRootHandle.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
					{
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
	 
						Win32Api.USN_JOURNAL_DATA usnState = new Win32Api.USN_JOURNAL_DATA();
						usnRtnCode = QueryUsnJournal(ref usnState);
	 
						if (usnRtnCode == UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
						{
							//
							// set up MFT_ENUM_DATA structure
							//
							Win32Api.MFT_ENUM_DATA med;
							med.StartFileReferenceNumber = 0;
							med.LowUsn = 0;
							med.HighUsn = usnState.NextUsn;
							Int32 sizeMftEnumData = Marshal.SizeOf(med);
							IntPtr medBuffer = Marshal.AllocHGlobal(sizeMftEnumData);
							Win32Api.ZeroMemory(medBuffer, sizeMftEnumData);
							Marshal.StructureToPtr(med, medBuffer, true);
	 
							//
							// set up the data buffer which receives the USN_RECORD data
							//
							int pDataSize = sizeof(UInt64) + 10000;
							IntPtr pData = Marshal.AllocHGlobal(pDataSize);
							Win32Api.ZeroMemory(pData, pDataSize);
							uint outBytesReturned = 0;
							Win32Api.UsnEntry usnEntry = null;
	 
							//
							// Gather up volume's directories
							//
							while (false != Win32Api.DeviceIoControl(
								_usnJournalRootHandle,
								Win32Api.FSCTL_ENUM_USN_DATA,
								medBuffer,
								sizeMftEnumData,
								pData,
								pDataSize,
								out outBytesReturned,
								IntPtr.Zero))
							{
								IntPtr pUsnRecord = new IntPtr(pData.ToInt32() + sizeof(Int64));
								while (outBytesReturned > 60)
								{
									usnEntry = new Win32Api.UsnEntry(pUsnRecord);
									//
									// check for directory entries
									//
									if (usnEntry.IsFolder)
									{
										folders.Add(usnEntry);
									}
									pUsnRecord = new IntPtr(pUsnRecord.ToInt32() + usnEntry.RecordLength);
									outBytesReturned -= usnEntry.RecordLength;
								}
								Marshal.WriteInt64(medBuffer, Marshal.ReadInt64(pData, 0));
							}
	 
							Marshal.FreeHGlobal(pData);
							usnRtnCode = ConvertWin32ErrorToUsnError((Win32Api.GetLastErrorEnum)Marshal.GetLastWin32Error());
							if (usnRtnCode == UsnJournalReturnCode.ERROR_HANDLE_EOF)
							{
								usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
							}
						}
					}
					else
					{
						usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE;
					}
				}
	 
				_elapsedTime = DateTime.Now - startTime;
				return usnRtnCode;
			}
	 
			/// <summary>
			/// Given a file reference number GetPathFromFrn() calculates the full path in the out parameter 'path'.
			/// </summary>
			/// <param name="frn">A 64-bit file reference number</param>
			/// <returns>
			/// USN_JOURNAL_SUCCESS                 GetPathFromFrn() function succeeded.
			/// VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			/// INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			/// ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			/// INVALID_FILE_REFERENCE_NUMBER       file reference number not found in Master File Table.
			/// ERROR_INVALID_FUNCTION              error generated by NtCreateFile() or NtQueryInformationFile() call.
			/// ERROR_FILE_NOT_FOUND                error generated by NtCreateFile() or NtQueryInformationFile() call.
			/// ERROR_PATH_NOT_FOUND                error generated by NtCreateFile() or NtQueryInformationFile() call.
			/// ERROR_TOO_MANY_OPEN_FILES           error generated by NtCreateFile() or NtQueryInformationFile() call.
			/// ERROR_INVALID_HANDLE                error generated by NtCreateFile() or NtQueryInformationFile() call.
			/// ERROR_INVALID_DATA                  error generated by NtCreateFile() or NtQueryInformationFile() call.
			/// ERROR_NOT_SUPPORTED                 error generated by NtCreateFile() or NtQueryInformationFile() call.
			/// ERROR_INVALID_PARAMETER             error generated by NtCreateFile() or NtQueryInformationFile() call.
			/// ERROR_INVALID_USER_BUFFER           error generated by NtCreateFile() or NtQueryInformationFile() call.
			/// USN_JOURNAL_ERROR                   unspecified usn journal error.
			/// </returns>
			/// <remarks>
			/// If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			/// </remarks>
	 
			public UsnJournalReturnCode
				GetPathFromFileReference(UInt64 frn, out string path)
			{
				DateTime startTime = DateTime.Now;
				path = "Unavailable"
					;
				UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS;
	 
				if (bNtfsVolume)
				{
					if (_usnJournalRootHandle.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
					{
						if (frn != 0)
						{
							usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
	 
							long allocSize = 0;
							Win32Api.UNICODE_STRING unicodeString;
							Win32Api.OBJECT_ATTRIBUTES objAttributes = new Win32Api.OBJECT_ATTRIBUTES();
							Win32Api.IO_STATUS_BLOCK ioStatusBlock = new Win32Api.IO_STATUS_BLOCK();
							IntPtr hFile = IntPtr.Zero;
	 
							IntPtr buffer = Marshal.AllocHGlobal(4096);
							IntPtr refPtr = Marshal.AllocHGlobal(8);
							IntPtr objAttIntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(objAttributes));
	 
							//
							// pointer >> fileid
							//
							Marshal.WriteInt64(refPtr, (long)frn);
	 
							unicodeString.Length = 8;
							unicodeString.MaximumLength = 8;
							unicodeString.Buffer = refPtr;
							//
							// copy unicode structure to pointer
							//
							Marshal.StructureToPtr(unicodeString, objAttIntPtr, true);
	 
							//
							//  InitializeObjectAttributes
							//
							objAttributes.Length = Marshal.SizeOf(objAttributes);
							objAttributes.ObjectName = objAttIntPtr;
							objAttributes.RootDirectory = _usnJournalRootHandle;
							objAttributes.Attributes = (int)Win32Api.OBJ_CASE_INSENSITIVE;
	 
							int fOk = Win32Api.NtCreateFile(
								ref hFile,
								FileAccess.Read,
								ref objAttributes,
								ref ioStatusBlock,
								ref allocSize,
								0,
								FileShare.ReadWrite,
								Win32Api.FILE_OPEN,
								Win32Api.FILE_OPEN_BY_FILE_ID | Win32Api.FILE_OPEN_FOR_BACKUP_INTENT,
								IntPtr.Zero, 0);
							if (fOk == 0)
							{
								fOk = Win32Api.NtQueryInformationFile(
									hFile,
									ref ioStatusBlock,
									buffer,
									4096,
									Win32Api.FILE_INFORMATION_CLASS.FileNameInformation);
								if (fOk == 0)
								{
									//
									// first 4 bytes are the name length
									//
									int nameLength = Marshal.ReadInt32(buffer, 0);
									//
									// next bytes are the name
									//
									path = Marshal.PtrToStringUni(new IntPtr(buffer.ToInt32() + 4), nameLength / 2);
								}
							}
							Win32Api.CloseHandle(hFile);
							Marshal.FreeHGlobal(buffer);
							Marshal.FreeHGlobal(objAttIntPtr);
							Marshal.FreeHGlobal(refPtr);
						}
					}
				}
				_elapsedTime = DateTime.Now - startTime;
				return usnRtnCode;
			}
	 
			/// <summary>
			/// GetUsnJournalState() gets the current state of the USN Journal if it is active.
			/// </summary>
			/// <param name="usnJournalState">
			/// Reference to usn journal data object filled with the current USN Journal state.
			/// </param>
			/// <param name="elapsedTime">The elapsed time for the GetUsnJournalState() function call.</param>
			/// <returns>
			/// USN_JOURNAL_SUCCESS                 GetUsnJournalState() function succeeded.
			/// VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			/// INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			/// USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
			/// ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			/// ERROR_INVALID_FUNCTION              error generated by DeviceIoControl() call.
			/// ERROR_FILE_NOT_FOUND                error generated by DeviceIoControl() call.
			/// ERROR_PATH_NOT_FOUND                error generated by DeviceIoControl() call.
			/// ERROR_TOO_MANY_OPEN_FILES           error generated by DeviceIoControl() call.
			/// ERROR_INVALID_HANDLE                error generated by DeviceIoControl() call.
			/// ERROR_INVALID_DATA                  error generated by DeviceIoControl() call.
			/// ERROR_NOT_SUPPORTED                 error generated by DeviceIoControl() call.
			/// ERROR_INVALID_PARAMETER             error generated by DeviceIoControl() call.
			/// ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			/// ERROR_INVALID_USER_BUFFER           error generated by DeviceIoControl() call.
			/// USN_JOURNAL_ERROR                   unspecified usn journal error.
			/// </returns>
			/// <remarks>
			/// If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			/// </remarks>
			public UsnJournalReturnCode
				GetUsnJournalState(ref Win32Api.USN_JOURNAL_DATA usnJournalState)
			{
				UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS;
				DateTime startTime = DateTime.Now;
	 
				if (bNtfsVolume)
				{
					if (_usnJournalRootHandle.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
					{
						usnRtnCode = QueryUsnJournal(ref usnJournalState);
					}
					else
					{
						usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE;
					}
				}
	 
				_elapsedTime = DateTime.Now - startTime;
				return usnRtnCode;
			}
	 
			/// <summary>
			/// Given a previous state, GetUsnJournalEntries() determines if the USN Journal is active and
			/// no USN Journal entries have been lost (i.e. USN Journal is valid), then
			/// it loads a SortedList<UInt64, Win32Api.UsnEntry> list and returns it as the out parameter 'usnEntries'.
			/// If GetUsnJournalChanges returns anything but USN_JOURNAL_SUCCESS, the usnEntries list will
			/// be empty.
			/// </summary>
			/// <param name="previousUsnState">The USN Journal state the last time volume
			/// changes were requested.</param>
			/// <param name="newFiles">List of the filenames of all new files.</param>
			/// <param name="changedFiles">List of the filenames of all changed files.</param>
			/// <param name="newFolders">List of the names of all new folders.</param>
			/// <param name="changedFolders">List of the names of all changed folders.</param>
			/// <param name="deletedFiles">List of the names of all deleted files</param>
			/// <param name="deletedFolders">List of the names of all deleted folders</param>
			/// <param name="currentState">Current state of the USN Journal</param>
			/// <returns>
			/// USN_JOURNAL_SUCCESS                 GetUsnJournalChanges() function succeeded.
			/// VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			/// INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			/// USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
			/// ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			/// ERROR_INVALID_FUNCTION              error generated by DeviceIoControl() call.
			/// ERROR_FILE_NOT_FOUND                error generated by DeviceIoControl() call.
			/// ERROR_PATH_NOT_FOUND                error generated by DeviceIoControl() call.
			/// ERROR_TOO_MANY_OPEN_FILES           error generated by DeviceIoControl() call.
			/// ERROR_INVALID_HANDLE                error generated by DeviceIoControl() call.
			/// ERROR_INVALID_DATA                  error generated by DeviceIoControl() call.
			/// ERROR_NOT_SUPPORTED                 error generated by DeviceIoControl() call.
			/// ERROR_INVALID_PARAMETER             error generated by DeviceIoControl() call.
			/// ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			/// ERROR_INVALID_USER_BUFFER           error generated by DeviceIoControl() call.
			/// USN_JOURNAL_ERROR                   unspecified usn journal error.
			/// </returns>
			/// <remarks>
			/// If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			/// </remarks>
			public UsnJournalReturnCode
				GetUsnJournalEntries(Win32Api.USN_JOURNAL_DATA previousUsnState,
				UInt32 reasonMask,
				out List<Win32Api.UsnEntry> usnEntries,
				out Win32Api.USN_JOURNAL_DATA newUsnState)
			{
				DateTime startTime = DateTime.Now;
				usnEntries = new List<Win32Api.UsnEntry>();
				newUsnState = new Win32Api.USN_JOURNAL_DATA();
				UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS;
	 
				if (bNtfsVolume)
				{
					if (_usnJournalRootHandle.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
					{
						//
						// get current usn journal state
						//
						usnRtnCode = QueryUsnJournal(ref newUsnState);
						if (usnRtnCode == UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
						{
							bool bReadMore = true;
							//
							// sequentially process the usn journal looking for image file entries
							//
							int pbDataSize = sizeof(UInt64) * 0x4000;
							IntPtr pbData = Marshal.AllocHGlobal(pbDataSize);
							Win32Api.ZeroMemory(pbData, pbDataSize);
							uint outBytesReturned = 0;
	 
							Win32Api.READ_USN_JOURNAL_DATA rujd = new Win32Api.READ_USN_JOURNAL_DATA();
							rujd.StartUsn = previousUsnState.NextUsn;
							rujd.ReasonMask = reasonMask;
							rujd.ReturnOnlyOnClose = 0;
							rujd.Timeout = 0;
							rujd.bytesToWaitFor = 0;
							rujd.UsnJournalId = previousUsnState.UsnJournalID;
							int sizeRujd = Marshal.SizeOf(rujd);
	 
							IntPtr rujdBuffer = Marshal.AllocHGlobal(sizeRujd);
							Win32Api.ZeroMemory(rujdBuffer, sizeRujd);
							Marshal.StructureToPtr(rujd, rujdBuffer, true);
	 
							Win32Api.UsnEntry usnEntry = null;
	 
							//
							// read usn journal entries
							//
							while (bReadMore)
							{
								bool bRtn = Win32Api.DeviceIoControl(
									_usnJournalRootHandle,
									Win32Api.FSCTL_READ_USN_JOURNAL,
									rujdBuffer,
									sizeRujd,
									pbData,
									pbDataSize,
									out outBytesReturned,
									IntPtr.Zero);
								if (bRtn)
								{
									IntPtr pUsnRecord = new IntPtr(pbData.ToInt32() + sizeof(UInt64));
									while (outBytesReturned > 60)   // while there are at least one entry in the usn journal
									{
										usnEntry = new Win32Api.UsnEntry(pUsnRecord);
										if (usnEntry.USN >= newUsnState.NextUsn)      // only read until the current usn points beyond the current state's usn
										{
											bReadMore = false;
											break;
										}
										usnEntries.Add(usnEntry);
	 
										pUsnRecord = new IntPtr(pUsnRecord.ToInt32() + usnEntry.RecordLength);
										outBytesReturned -= usnEntry.RecordLength;
	 
									}   // end while (outBytesReturned > 60) - closing bracket
	 
								}   // if (bRtn)- closing bracket
								else
								{
									Win32Api.GetLastErrorEnum lastWin32Error = (Win32Api.GetLastErrorEnum)Marshal.GetLastWin32Error();
									if (lastWin32Error == Win32Api.GetLastErrorEnum.ERROR_HANDLE_EOF)
									{
										usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
									}
									else
									{
										usnRtnCode = ConvertWin32ErrorToUsnError(lastWin32Error);
									}
									break;
								}
	 
								Int64 nextUsn = Marshal.ReadInt64(pbData, 0);
								if (nextUsn >= newUsnState.NextUsn)
								{
									break;
								}
								Marshal.WriteInt64(rujdBuffer, nextUsn);
	 
							}   // end while (bReadMore) - closing bracket
	 
							Marshal.FreeHGlobal(rujdBuffer);
							Marshal.FreeHGlobal(pbData);
	 
						}   // if (usnRtnCode == UsnJournalReturnCode.USN_JOURNAL_SUCCESS) - closing bracket
	 
					}   // if (_usnJournalRootHandle.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
					else
					{
						usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE;
					}
				}   // if (bNtfsVolume) - closing bracket
	 
				_elapsedTime = DateTime.Now - startTime;
				return usnRtnCode;
			}   // GetUsnJournalChanges() - closing bracket
	 
			/// <summary>
			/// tests to see if the USN Journal is active on the volume.
			/// </summary>
			/// <returns>true if USN Journal is active
			/// false if no USN Journal on volume</returns>
			public bool
				IsUsnJournalActive()
			{
				DateTime start = DateTime.Now;
				bool bRtnCode = false;
	 
				if (bNtfsVolume)
				{
					if (_usnJournalRootHandle.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
					{
						Win32Api.USN_JOURNAL_DATA usnJournalCurrentState = new Win32Api.USN_JOURNAL_DATA();
						UsnJournalReturnCode usnError = QueryUsnJournal(ref usnJournalCurrentState);
						if (usnError == UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
						{
							bRtnCode = true;
						}
					}
				}
				_elapsedTime = DateTime.Now - start;
				return bRtnCode;
			}
	 
			/// <summary>
			/// tests to see if there is a USN Journal on this volume and if there is
			/// determines whether any journal entries have been lost.
			/// </summary>
			/// <returns>true if the USN Journal is active and if the JournalId's are the same
			/// and if all the usn journal entries expected by the previous state are available
			/// from the current state.
			/// false if not</returns>
			public bool
				IsUsnJournalValid(Win32Api.USN_JOURNAL_DATA usnJournalPreviousState)
			{
				DateTime start = DateTime.Now;
				bool bRtnCode = false;
	 
				if (bNtfsVolume)
				{
					if (_usnJournalRootHandle.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
					{
						Win32Api.USN_JOURNAL_DATA usnJournalState = new Win32Api.USN_JOURNAL_DATA();
						UsnJournalReturnCode usnError = QueryUsnJournal(ref usnJournalState);
	 
						if (usnError == UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
						{
							if (usnJournalPreviousState.UsnJournalID == usnJournalState.UsnJournalID)
							{
								if (usnJournalPreviousState.NextUsn >= usnJournalState.NextUsn)
								{
									bRtnCode = true;
								}
							}
						}
					}
				}
				_elapsedTime = DateTime.Now - start;
				return bRtnCode;
			}
	 
			#endregion
	 
			#region private member functions
			/// <summary>
			/// Converts a Win32 Error to a UsnJournalReturnCode
			/// </summary>
			/// <param name="Win32LastError">The 'last' Win32 error.</param>
			/// <returns>
			/// INVALID_HANDLE_VALUE                error generated by Win32 Api calls.
			/// USN_JOURNAL_SUCCESS                 usn journal function succeeded.
			/// ERROR_INVALID_FUNCTION              error generated by Win32 Api calls.
			/// ERROR_FILE_NOT_FOUND                error generated by Win32 Api calls.
			/// ERROR_PATH_NOT_FOUND                error generated by Win32 Api calls.
			/// ERROR_TOO_MANY_OPEN_FILES           error generated by Win32 Api calls.
			/// ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights.
			/// ERROR_INVALID_HANDLE                error generated by Win32 Api calls.
		/// ERROR_INVALID_DATA                  error generated by Win32 Api calls.
			/// ERROR_HANDLE_EOF                    error generated by Win32 Api calls.
			/// ERROR_NOT_SUPPORTED                 error generated by Win32 Api calls.
			/// ERROR_INVALID_PARAMETER             error generated by Win32 Api calls.
			/// ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			/// ERROR_JOURNAL_ENTRY_DELETED         usn journal entry lost, no longer available.
			/// ERROR_INVALID_USER_BUFFER           error generated by Win32 Api calls.
			/// USN_JOURNAL_INVALID                 usn journal is invalid, id's don't match or required entries lost.
			/// USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
			/// VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			/// INVALID_FILE_REFERENCE_NUMBER       bad file reference number - see remarks.
			/// USN_JOURNAL_ERROR                   unspecified usn journal error.
			/// </returns>
			private UsnJournalReturnCode
				ConvertWin32ErrorToUsnError(Win32Api.GetLastErrorEnum Win32LastError)
			{
			   UsnJournalReturnCode usnRtnCode;
	 
			   switch (Win32LastError)
				{
					case Win32Api.GetLastErrorEnum.ERROR_JOURNAL_NOT_ACTIVE:
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_NOT_ACTIVE;
						break;
					case Win32Api.GetLastErrorEnum.ERROR_SUCCESS:
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
						break;
				   case Win32Api.GetLastErrorEnum.ERROR_HANDLE_EOF:
						usnRtnCode = UsnJournalReturnCode.ERROR_HANDLE_EOF;
						break;
					default:
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_ERROR;
						break;
				}
	 
			   return usnRtnCode;
			}
	 
			/// <summary>
			/// Gets a Volume Serial Number for the volume represented by driveInfo.
			/// </summary>
			/// <param name="driveInfo">DriveInfo object representing the volume in question.</param>
			/// <param name="volumeSerialNumber">out parameter to hold the volume serial number.</param>
			/// <returns></returns>
			private UsnJournalReturnCode
				GetVolumeSerialNumber(DriveInfo driveInfo, out uint volumeSerialNumber)
			{
				Console.WriteLine("GetVolumeSerialNumber() function entered for drive '{0}'", driveInfo.Name);
	 
				volumeSerialNumber = 0;
				UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
				string pathRoot = string.Concat("\\\\.\\", driveInfo.Name);
	 
				IntPtr hRoot = Win32Api.CreateFile(pathRoot,
					0,
					Win32Api.FILE_SHARE_READ | Win32Api.FILE_SHARE_WRITE,
					IntPtr.Zero,
					Win32Api.OPEN_EXISTING,
					Win32Api.FILE_FLAG_BACKUP_SEMANTICS,
				IntPtr.Zero);
	 
				if (hRoot.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
				{
					Win32Api.BY_HANDLE_FILE_INFORMATION fi = new Win32Api.BY_HANDLE_FILE_INFORMATION();
					bool bRtn = Win32Api.GetFileInformationByHandle(hRoot, out fi);
 
					if (bRtn)
					{
						UInt64 fileIndexHigh = (UInt64)fi.FileIndexHigh;
						UInt64 indexRoot = (fileIndexHigh << 32) | fi.FileIndexLow;
						volumeSerialNumber = fi.VolumeSerialNumber;
					}
					else
					{
						usnRtnCode = (UsnJournalReturnCode)Marshal.GetLastWin32Error();
					}
	 
					Win32Api.CloseHandle(hRoot);
				}
				else
				{
					usnRtnCode = (UsnJournalReturnCode)Marshal.GetLastWin32Error();
				}
	 
				return usnRtnCode;
			}
	 
			private UsnJournalReturnCode
				GetRootHandle(out IntPtr rootHandle)
			{
				//
				// private functions don't need to check for an NTFS volume or
				// a valid _usnJournalRootHandle handle
				//
				UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
				rootHandle = IntPtr.Zero;
				string vol = string.Concat("\\\\.\\", _driveInfo.Name.TrimEnd('\\'));
	 
				rootHandle = Win32Api.CreateFile(vol,
					 Win32Api.GENERIC_READ | Win32Api.GENERIC_WRITE,
					 Win32Api.FILE_SHARE_READ | Win32Api.FILE_SHARE_WRITE,
					 IntPtr.Zero,
					 Win32Api.OPEN_EXISTING,
					 0,
					 IntPtr.Zero);
	 
				if (rootHandle.ToInt32() == Win32Api.INVALID_HANDLE_VALUE)
				{
					usnRtnCode = (UsnJournalReturnCode)Marshal.GetLastWin32Error();
				}
	 
	 
				return usnRtnCode;
			}
			/// <summary>
			/// This function queries the usn journal on the volume.
			/// </summary>
			/// <param name="usnJournalState">the USN_JOURNAL_DATA object that is associated with this volume</param>
			/// <returns></returns>
			private UsnJournalReturnCode
				QueryUsnJournal(ref Win32Api.USN_JOURNAL_DATA usnJournalState)
			{
				//
				// private functions don't need to check for an NTFS volume or
				// a valid _usnJournalRootHandle handle
				//
				UsnJournalReturnCode usnReturnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
				int sizeUsnJournalState = Marshal.SizeOf(usnJournalState);
				UInt32 cb;
	 
				bool fOk = Win32Api.DeviceIoControl(
					_usnJournalRootHandle,
					Win32Api.FSCTL_QUERY_USN_JOURNAL,
					IntPtr.Zero,
					0,
					out usnJournalState,
					sizeUsnJournalState,
					out cb,
					IntPtr.Zero);
	 
				if (!fOk)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					usnReturnCode = ConvertWin32ErrorToUsnError((Win32Api.GetLastErrorEnum)Marshal.GetLastWin32Error());
				}
	 
			return usnReturnCode;
			}
	 
			#endregion
	 
			#region IDisposable Members
	 
			public void Dispose()
			{
				Win32Api.CloseHandle(_usnJournalRootHandle);
			}
	 
			#endregion
		}

		public class Win32Api
		{
			#region enums
			public enum GetLastErrorEnum
			{
				INVALID_HANDLE_VALUE = -1,
				ERROR_SUCCESS = 0,
				ERROR_INVALID_FUNCTION = 1,
				ERROR_FILE_NOT_FOUND = 2,
				ERROR_PATH_NOT_FOUND = 3,
				ERROR_TOO_MANY_OPEN_FILES = 4,
				ERROR_ACCESS_DENIED = 5,
				ERROR_INVALID_HANDLE = 6,
				ERROR_INVALID_DATA = 13,
				ERROR_HANDLE_EOF = 38,
				ERROR_NOT_SUPPORTED = 50,
				ERROR_INVALID_PARAMETER = 87,
				ERROR_JOURNAL_DELETE_IN_PROGRESS = 1178,
				ERROR_JOURNAL_NOT_ACTIVE = 1179,
				ERROR_JOURNAL_ENTRY_DELETED = 1181,
				ERROR_INVALID_USER_BUFFER = 1784
			}

			public enum UsnJournalDeleteFlags
			{
				USN_DELETE_FLAG_DELETE = 1,
				USN_DELETE_FLAG_NOTIFY = 2
			}

			public enum FILE_INFORMATION_CLASS
			{
				FileDirectoryInformation = 1,     // 1
				FileFullDirectoryInformation = 2,     // 2
				FileBothDirectoryInformation = 3,     // 3
				FileBasicInformation = 4,         // 4
				FileStandardInformation = 5,      // 5
				FileInternalInformation = 6,      // 6
				FileEaInformation = 7,        // 7
				FileAccessInformation = 8,        // 8
				FileNameInformation = 9,          // 9
				FileRenameInformation = 10,        // 10
				FileLinkInformation = 11,          // 11
				FileNamesInformation = 12,         // 12
				FileDispositionInformation = 13,       // 13
				FilePositionInformation = 14,      // 14
				FileFullEaInformation = 15,        // 15
				FileModeInformation = 16,     // 16
				FileAlignmentInformation = 17,     // 17
				FileAllInformation = 18,           // 18
				FileAllocationInformation = 19,    // 19
				FileEndOfFileInformation = 20,     // 20
				FileAlternateNameInformation = 21,     // 21
				FileStreamInformation = 22,        // 22
				FilePipeInformation = 23,          // 23
				FilePipeLocalInformation = 24,     // 24
				FilePipeRemoteInformation = 25,    // 25
				FileMailslotQueryInformation = 26,     // 26
				FileMailslotSetInformation = 27,       // 27
				FileCompressionInformation = 28,       // 28
				FileObjectIdInformation = 29,      // 29
				FileCompletionInformation = 30,    // 30
				FileMoveClusterInformation = 31,       // 31
				FileQuotaInformation = 32,         // 32
				FileReparsePointInformation = 33,      // 33
				FileNetworkOpenInformation = 34,       // 34
				FileAttributeTagInformation = 35,      // 35
				FileTrackingInformation = 36,      // 36
				FileIdBothDirectoryInformation = 37,   // 37
				FileIdFullDirectoryInformation = 38,   // 38
				FileValidDataLengthInformation = 39,   // 39
				FileShortNameInformation = 40,     // 40
				FileHardLinkInformation = 46    // 46    
			}

			#endregion

			#region constants
			public const Int32 INVALID_HANDLE_VALUE = -1;

			public const UInt32 GENERIC_READ = 0x80000000;
			public const UInt32 GENERIC_WRITE = 0x40000000;
			public const UInt32 FILE_SHARE_READ = 0x00000001;
			public const UInt32 FILE_SHARE_WRITE = 0x00000002;
			public const UInt32 FILE_ATTRIBUTE_DIRECTORY = 0x00000010;

			public const UInt32 CREATE_NEW = 1;
			public const UInt32 CREATE_ALWAYS = 2;
			public const UInt32 OPEN_EXISTING = 3;
			public const UInt32 OPEN_ALWAYS = 4;
			public const UInt32 TRUNCATE_EXISTING = 5;

			public const UInt32 FILE_ATTRIBUTE_NORMAL = 0x80;
			public const UInt32 FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
			public const UInt32 FileNameInformationClass = 9;
			public const UInt32 FILE_OPEN_FOR_BACKUP_INTENT = 0x4000;
			public const UInt32 FILE_OPEN_BY_FILE_ID = 0x2000;
			public const UInt32 FILE_OPEN = 0x1;
			public const UInt32 OBJ_CASE_INSENSITIVE = 0x40;
			//public const OBJ_KERNEL_HANDLE = 0x200;

			// CTL_CODE( DeviceType, Function, Method, Access ) (((DeviceType) << 16) | ((Access) << 14) | ((Function) << 2) | (Method))
			private const UInt32 FILE_DEVICE_FILE_SYSTEM = 0x00000009;
			private const UInt32 METHOD_NEITHER = 3;
			private const UInt32 METHOD_BUFFERED = 0;
			private const UInt32 FILE_ANY_ACCESS = 0;
			private const UInt32 FILE_SPECIAL_ACCESS = 0;
			private const UInt32 FILE_READ_ACCESS = 1;
			private const UInt32 FILE_WRITE_ACCESS = 2;

			public const UInt32 USN_REASON_DATA_OVERWRITE = 0x00000001;
			public const UInt32 USN_REASON_DATA_EXTEND = 0x00000002;
			public const UInt32 USN_REASON_DATA_TRUNCATION = 0x00000004;
			public const UInt32 USN_REASON_NAMED_DATA_OVERWRITE = 0x00000010;
			public const UInt32 USN_REASON_NAMED_DATA_EXTEND = 0x00000020;
			public const UInt32 USN_REASON_NAMED_DATA_TRUNCATION = 0x00000040;
			public const UInt32 USN_REASON_FILE_CREATE = 0x00000100;
			public const UInt32 USN_REASON_FILE_DELETE = 0x00000200;
			public const UInt32 USN_REASON_EA_CHANGE = 0x00000400;
			public const UInt32 USN_REASON_SECURITY_CHANGE = 0x00000800;
			public const UInt32 USN_REASON_RENAME_OLD_NAME = 0x00001000;
			public const UInt32 USN_REASON_RENAME_NEW_NAME = 0x00002000;
			public const UInt32 USN_REASON_INDEXABLE_CHANGE = 0x00004000;
			public const UInt32 USN_REASON_BASIC_INFO_CHANGE = 0x00008000;
			public const UInt32 USN_REASON_HARD_LINK_CHANGE = 0x00010000;
			public const UInt32 USN_REASON_COMPRESSION_CHANGE = 0x00020000;
			public const UInt32 USN_REASON_ENCRYPTION_CHANGE = 0x00040000;
			public const UInt32 USN_REASON_OBJECT_ID_CHANGE = 0x00080000;
			public const UInt32 USN_REASON_REPARSE_POINT_CHANGE = 0x00100000;
			public const UInt32 USN_REASON_STREAM_CHANGE = 0x00200000;
			public const UInt32 USN_REASON_CLOSE = 0x80000000;

			public static Int32 GWL_EXSTYLE = -20;
			public static Int32 WS_EX_LAYERED = 0x00080000;
			public static Int32 WS_EX_TRANSPARENT = 0x00000020;

			public const UInt32 FSCTL_GET_OBJECT_ID = 0x9009c;

			// FSCTL_ENUM_USN_DATA = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 44,  METHOD_NEITHER, FILE_ANY_ACCESS)
			public const UInt32 FSCTL_ENUM_USN_DATA = (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_ANY_ACCESS << 14) | (44 << 2) | METHOD_NEITHER;

			// FSCTL_READ_USN_JOURNAL = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 46,  METHOD_NEITHER, FILE_ANY_ACCESS)
			public const UInt32 FSCTL_READ_USN_JOURNAL = (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_ANY_ACCESS << 14) | (46 << 2) | METHOD_NEITHER;

			//  FSCTL_CREATE_USN_JOURNAL        CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 57,  METHOD_NEITHER, FILE_ANY_ACCESS)
			public const UInt32 FSCTL_CREATE_USN_JOURNAL = (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_ANY_ACCESS << 14) | (57 << 2) | METHOD_NEITHER;

			//  FSCTL_QUERY_USN_JOURNAL         CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 61, METHOD_BUFFERED, FILE_ANY_ACCESS)
			public const UInt32 FSCTL_QUERY_USN_JOURNAL = (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_ANY_ACCESS << 14) | (61 << 2) | METHOD_BUFFERED;

			// FSCTL_DELETE_USN_JOURNAL        CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 62, METHOD_BUFFERED, FILE_ANY_ACCESS)
			public const UInt32 FSCTL_DELETE_USN_JOURNAL = (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_ANY_ACCESS << 14) | (62 << 2) | METHOD_BUFFERED;

			#endregion

			#region dll imports

			/// <summary>
			/// Creates the file specified by 'lpFileName' with desired access, share mode, security attributes,
			/// creation disposition, flags and attributes.
			/// </summary>
			/// <param name="lpFileName">Fully qualified path to a file</param>
			/// <param name="dwDesiredAccess">Requested access (write, read, read/write, none)</param>
			/// <param name="dwShareMode">Share mode (read, write, read/write, delete, all, none)</param>
			/// <param name="lpSecurityAttributes">IntPtr to a 'SECURITY_ATTRIBUTES' structure</param>
			/// <param name="dwCreationDisposition">Action to take on file or device specified by 'lpFileName' (CREATE_NEW,
			/// CREATE_ALWAYS, OPEN_ALWAYS, OPEN_EXISTING, TRUNCATE_EXISTING)</param>
			/// <param name="dwFlagsAndAttributes">File or device attributes and flags (typically FILE_ATTRIBUTE_NORMAL)</param>
			/// <param name="hTemplateFile">IntPtr to a valid handle to a template file with 'GENERIC_READ' access right</param>
			/// <returns>IntPtr handle to the 'lpFileName' file or device or 'INVALID_HANDLE_VALUE'</returns>
			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern IntPtr
				CreateFile(string lpFileName,
				uint dwDesiredAccess,
				uint dwShareMode,
				IntPtr lpSecurityAttributes,
				uint dwCreationDisposition,
				uint dwFlagsAndAttributes,
				IntPtr hTemplateFile);

			/// <summary>
			/// Closes the file specified by the IntPtr 'hObject'.
			/// </summary>
			/// <param name="hObject">IntPtr handle to a file</param>
			/// <returns>'true' if successful, otherwise 'false'</returns>
			[DllImport("kernel32.dll", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool
				CloseHandle(
				IntPtr hObject);

			/// <summary>
			/// Fills the 'BY_HANDLE_FILE_INFORMATION' structure for the file specified by 'hFile'.
			/// </summary>
			/// <param name="hFile">Fully qualified name of a file</param>
			/// <param name="lpFileInformation">Out BY_HANDLE_FILE_INFORMATION argument</param>
			/// <returns>'true' if successful, otherwise 'false'</returns>
			[DllImport("kernel32.dll", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool
				GetFileInformationByHandle(
				IntPtr hFile,
				out BY_HANDLE_FILE_INFORMATION lpFileInformation);

			/// <summary>
			/// Deletes the file specified by 'fileName'.
			/// </summary>
			/// <param name="fileName">Fully qualified path to the file to delete</param>
			/// <returns>'true' if successful, otherwise 'false'</returns>
			[DllImport("kernel32.dll", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool DeleteFile(
				string fileName);

			/// <summary>
			/// Read data from the file specified by 'hFile'.
			/// </summary>
			/// <param name="hFile">IntPtr handle to the file to read</param>
			/// <param name="lpBuffer">IntPtr to a buffer of bytes to receive the bytes read from 'hFile'</param>
			/// <param name="nNumberOfBytesToRead">Number of bytes to read from 'hFile'</param>
			/// <param name="lpNumberOfBytesRead">Number of bytes read from 'hFile'</param>
			/// <param name="lpOverlapped">IntPtr to an 'OVERLAPPED' structure</param>
			/// <returns>'true' if successful, otherwise 'false'</returns>
			[DllImport("kernel32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool ReadFile(
				IntPtr hFile,
				IntPtr lpBuffer,
				uint nNumberOfBytesToRead,
				out uint lpNumberOfBytesRead,
				IntPtr lpOverlapped);

			/// <summary>
			/// Writes the 
			/// </summary>
			/// <param name="hFile">IntPtr handle to the file to write</param>
			/// <param name="bytes">IntPtr to a buffer of bytes to write to 'hFile'</param>
			/// <param name="nNumberOfBytesToWrite">Number of bytes in 'lpBuffer' to write to 'hFile'</param>
			/// <param name="lpNumberOfBytesWritten">Number of bytes written to 'hFile'</param>
			/// <param name="overlapped">IntPtr to an 'OVERLAPPED' structure</param>
			/// <returns>'true' if successful, otherwise 'false'</returns>
			[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool WriteFile(
				IntPtr hFile,
				IntPtr bytes,
				uint nNumberOfBytesToWrite,
				out uint lpNumberOfBytesWritten,
				int overlapped);

			/// <summary>
			/// Writes the data in 'lpBuffer' to the file specified by 'hFile'.
			/// </summary>
			/// <param name="hFile">IntPtr handle to file to write</param>
			/// <param name="lpBuffer">Buffer of bytes to write to file 'hFile'</param>
			/// <param name="nNumberOfBytesToWrite">Number of bytes in 'lpBuffer' to write to 'hFile'</param>
			/// <param name="lpNumberOfBytesWritten">Number of bytes written to 'hFile'</param>
			/// <param name="overlapped">IntPtr to an 'OVERLAPPED' structure</param>
			/// <returns>'true' if successful, otherwise 'false'</returns>
			[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool WriteFile(
				IntPtr hFile,
				byte[] lpBuffer,
				uint nNumberOfBytesToWrite,
				out uint lpNumberOfBytesWritten,
				int overlapped);

			/// <summary>
			/// Sends the 'dwIoControlCode' to the device specified by 'hDevice'.
			/// </summary>
			/// <param name="hDevice">IntPtr handle to the device to receive 'dwIoControlCode'</param>
			/// <param name="dwIoControlCode">Device IO Control Code to send</param>
			/// <param name="lpInBuffer">Input buffer if required</param>
			/// <param name="nInBufferSize">Size of input buffer</param>
			/// <param name="lpOutBuffer">Output buffer if required</param>
			/// <param name="nOutBufferSize">Size of output buffer</param>
			/// <param name="lpBytesReturned">Number of bytes returned in output buffer</param>
			/// <param name="lpOverlapped">IntPtr to an 'OVERLAPPED' structure</param>
			/// <returns>'true' if successful, otherwise 'false'</returns>
			[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool DeviceIoControl(
				IntPtr hDevice,
				UInt32 dwIoControlCode,
				IntPtr lpInBuffer,
				Int32 nInBufferSize,
				out USN_JOURNAL_DATA lpOutBuffer,
				Int32 nOutBufferSize,
				out uint lpBytesReturned,
				IntPtr lpOverlapped);

			/// <summary>
			/// Sends the control code 'dwIoControlCode' to the device driver specified by 'hDevice'.
			/// </summary>
			/// <param name="hDevice">IntPtr handle to the device to receive 'dwIoControlCode</param>
			/// <param name="dwIoControlCode">Device IO Control Code to send</param>
			/// <param name="lpInBuffer">Input buffer if required</param>
			/// <param name="nInBufferSize">Size of input buffer </param>
			/// <param name="lpOutBuffer">Output buffer if required</param>
			/// <param name="nOutBufferSize">Size of output buffer</param>
			/// <param name="lpBytesReturned">Number of bytes returned</param>
			/// <param name="lpOverlapped">Pointer to an 'OVERLAPPED' struture</param>
			/// <returns></returns>
			[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool DeviceIoControl(
				IntPtr hDevice,
				UInt32 dwIoControlCode,
				IntPtr lpInBuffer,
				Int32 nInBufferSize,
				IntPtr lpOutBuffer,
				Int32 nOutBufferSize,
				out uint lpBytesReturned,
				IntPtr lpOverlapped);

			/// <summary>
			/// Sets the number of bytes specified by 'size' of the memory associated with the argument 'ptr' 
			/// to zero.
			/// </summary>
			/// <param name="ptr"></param>
			/// <param name="size"></param>
			[DllImport("kernel32.dll")]
			public static extern void ZeroMemory(IntPtr ptr, int size);

			/// <summary>
			/// Retrieves the cursor's position, in screen coordinates.
			/// </summary>
			/// <param name="pt">Pointer to a POINT structure that receives the screen coordinates of the cursor</param>
			/// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool GetCursorPos(out POINT pt);

			/// <summary>
			/// retrieves information about the specified window. The function also retrieves the 32-bit (long) 
			/// value at the specified offset into the extra window memory.
			/// </summary>
			/// <param name="hWnd">Handle to the window and, indirectly, the class to which the window belongs</param>
			/// <param name="nIndex">the zero-based offset to the value to be retrieved</param>
			/// <returns>If the function succeeds, the return value is the requested 32-bit value.
			/// If the function fails, the return value is zero. To get extended error information, call GetLastError
			///</returns>
			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 nIndex);

			/// <summary>
			/// changes an attribute of the specified window. The function also sets the 32-bit (long) value at 
			/// the specified offset into the extra window memory
			/// </summary>
			/// <param name="hWnd">Handle to the window and, indirectly, the class to which the window belongs</param>
			/// <param name="nIndex">the zero-based offset to the value to be set</param>
			/// <param name="newVal">the replacement value</param>
			/// <returns>If the function succeeds, the return value is the previous value of the specified 32-bit 
			/// integer. If the function fails, the return value is zero. To get extended error information, call GetLastError.
			/// </returns>
			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			public static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 newVal);

			/// <summary>
			/// Creates a new file or directory, or opens an existing file, device, directory, or volume
			/// </summary>
			/// <param name="handle">A pointer to a variable that receives the file handle if the call is successful (out)</param>
			/// <param name="access">ACCESS_MASK value that expresses the type of access that the caller requires to the file or directory (in)</param>
			/// <param name="objectAttributes">A pointer to a structure already initialized with InitializeObjectAttributes (in)</param>
			/// <param name="ioStatus">A pointer to a variable that receives the final completion status and information about the requested operation (out)</param>
			/// <param name="allocSize">The initial allocation size in bytes for the file (in)(optional)</param>
			/// <param name="fileAttributes">file attributes (in)</param>
			/// <param name="share">type of share access that the caller would like to use in the file (in)</param>
			/// <param name="createDisposition">what to do, depending on whether the file already exists (in)</param>
			/// <param name="createOptions">options to be applied when creating or opening the file (in)</param>
			/// <param name="eaBuffer">Pointer to an EA buffer used to pass extended attributes (in)</param>
			/// <param name="eaLength">Length of the EA buffer</param>
			/// <returns>either STATUS_SUCCESS or an appropriate error status. If it returns an error status, the caller can find more information about the cause of the failure by checking the IoStatusBlock</returns>
			[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
			public static extern int NtCreateFile(
				ref IntPtr handle,
				FileAccess access,
				ref OBJECT_ATTRIBUTES objectAttributes,
				ref IO_STATUS_BLOCK ioStatus,
				ref long allocSize,
				uint fileAttributes,
				FileShare share,
				uint createDisposition,
				uint createOptions,
				IntPtr eaBuffer,
				uint eaLength);

			/// <summary>
			/// 
			/// </summary>
			/// <param name="fileHandle"></param>
			/// <param name="IoStatusBlock"></param>
			/// <param name="pInfoBlock"></param>
			/// <param name="length"></param>
			/// <param name="fileInformation"></param>
			/// <returns></returns>
			[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
			public static extern int NtQueryInformationFile(
				IntPtr fileHandle,
				ref IO_STATUS_BLOCK IoStatusBlock,
				IntPtr pInfoBlock,
				uint length,
				FILE_INFORMATION_CLASS fileInformation);

			#endregion

			#region structures

			/// <summary>
			/// By Handle File Information structure, contains File Attributes(32bits), Creation Time(FILETIME),
			/// Last Access Time(FILETIME), Last Write Time(FILETIME), Volume Serial Number(32bits),
			/// File Size High(32bits), File Size Low(32bits), Number of Links(32bits), File Index High(32bits),
			/// File Index Low(32bits).
			/// </summary>
			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct BY_HANDLE_FILE_INFORMATION
			{
				public uint FileAttributes;
				public System.Runtime.InteropServices.ComTypes.FILETIME CreationTime;
				public System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
				public System.Runtime.InteropServices.ComTypes.FILETIME LastWriteTime;
				public uint VolumeSerialNumber;
				public uint FileSizeHigh;
				public uint FileSizeLow;
				public uint NumberOfLinks;
				public uint FileIndexHigh;
				public uint FileIndexLow;
			}

			/// <summary>
			/// USN Journal Data structure, contains USN Journal ID(64bits), First USN(64bits), Next USN(64bits),
			/// Lowest Valid USN(64bits), Max USN(64bits), Maximum Size(64bits) and Allocation Delta(64bits).
			/// </summary>
			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct USN_JOURNAL_DATA
			{
				public UInt64 UsnJournalID;
				public Int64 FirstUsn;
				public Int64 NextUsn;
				public Int64 LowestValidUsn;
				public Int64 MaxUsn;
				public UInt64 MaximumSize;
				public UInt64 AllocationDelta;
			}

			/// <summary>
			/// MFT Enum Data structure, contains Start File Reference Number(64bits), Low USN(64bits),
			/// High USN(64bits).
			/// </summary>
			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct MFT_ENUM_DATA
			{
				public UInt64 StartFileReferenceNumber;
				public Int64 LowUsn;
				public Int64 HighUsn;
			}

			/// <summary>
			/// Create USN Journal Data structure, contains Maximum Size(64bits) and Allocation Delta(64(bits).
			/// </summary>
			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct CREATE_USN_JOURNAL_DATA
			{
				public UInt64 MaximumSize;
				public UInt64 AllocationDelta;
			}

			/// <summary>
			/// Create USN Journal Data structure, contains Maximum Size(64bits) and Allocation Delta(64(bits).
			/// </summary>
			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct DELETE_USN_JOURNAL_DATA
			{
				public UInt64 UsnJournalID;
				public UInt32 DeleteFlags;
				public UInt32 Reserved;
			}

			/// <summary>
			/// Contains the USN Record Length(32bits), USN(64bits), File Reference Number(64bits), 
			/// Parent File Reference Number(64bits), Reason Code(32bits), File Attributes(32bits),
			/// File Name Length(32bits), the File Name Offset(32bits) and the File Name.
			/// </summary>
			public class UsnEntry : IComparable<UsnEntry>
			{
				private const int FR_OFFSET = 8;
				private const int PFR_OFFSET = 16;
				private const int USN_OFFSET = 24;
				private const int REASON_OFFSET = 40;
				public const int FA_OFFSET = 52;
				private const int FNL_OFFSET = 56;
				private const int FN_OFFSET = 58;

				private UInt32 _recordLength;
				public UInt32 RecordLength
				{
					get { return _recordLength; }
				}

				private Int64 _usn;
				public Int64 USN
				{
					get { return _usn; }
				}

				private UInt64 _frn;
				public UInt64 FileReferenceNumber
				{
					get { return _frn; }
				}

				private UInt64 _pfrn;
				public UInt64 ParentFileReferenceNumber
				{
					get { return _pfrn; }
				}

				private UInt32 _reason;
				public UInt32 Reason
				{
					get { return _reason; }
				}

				private string _name;
				public string Name
				{
					get
					{
						return _name;
					}
				}

				private string _oldName;
				public string OldName
				{
					get
					{
						if (0 != (_fileAttributes & USN_REASON_RENAME_OLD_NAME))
						{
							return _oldName;
						}
						else
						{
							return null;
						}
					}
					set { _oldName = value; }
				}

				private UInt32 _fileAttributes;
				public bool IsFolder
				{
					get
					{
						bool bRtn = false;
						if (0 != (_fileAttributes & Win32Api.FILE_ATTRIBUTE_DIRECTORY))
						{
							bRtn = true;
						}
						return bRtn;
					}
				}

				public bool IsFile
				{
					get
					{
						bool bRtn = false;
						if (0 == (_fileAttributes & Win32Api.FILE_ATTRIBUTE_DIRECTORY))
						{
							bRtn = true;
						}
						return bRtn;
					}
				}

				/// <summary>
				/// USN Record Constructor
				/// </summary>
				/// <param name="p">Buffer pointer to first byte of the USN Record</param>
				public UsnEntry(IntPtr ptrToUsnRecord)
				{
					_recordLength = (UInt32)Marshal.ReadInt32(ptrToUsnRecord);
					_frn = (UInt64)Marshal.ReadInt64(ptrToUsnRecord, FR_OFFSET);
					_pfrn = (UInt64)Marshal.ReadInt64(ptrToUsnRecord, PFR_OFFSET);
					_usn = (Int64)Marshal.ReadInt64(ptrToUsnRecord, USN_OFFSET);
					_reason = (UInt32)Marshal.ReadInt32(ptrToUsnRecord, REASON_OFFSET);
					_fileAttributes = (UInt32)Marshal.ReadInt32(ptrToUsnRecord, FA_OFFSET);
					short fileNameLength = Marshal.ReadInt16(ptrToUsnRecord, FNL_OFFSET);
					short fileNameOffset = Marshal.ReadInt16(ptrToUsnRecord, FN_OFFSET);
					_name = Marshal.PtrToStringUni(new IntPtr(ptrToUsnRecord.ToInt32() + fileNameOffset), fileNameLength / sizeof(char));
				}



				#region IComparable<UsnEntry> Members

				public int CompareTo(UsnEntry other)
				{
					return string.Compare(this.Name, other.Name, true);
				}

				#endregion
			}

			/// <summary>
			/// Contains the Start USN(64bits), Reason Mask(32bits), Return Only on Close flag(32bits),
			/// Time Out(64bits), Bytes To Wait For(64bits), and USN Journal ID(64bits).
			/// </summary>
			/// <remarks> possible reason bits are from Win32Api
			/// USN_REASON_DATA_OVERWRITE
			/// USN_REASON_DATA_EXTEND
			/// USN_REASON_DATA_TRUNCATION
			/// USN_REASON_NAMED_DATA_OVERWRITE
			/// USN_REASON_NAMED_DATA_EXTEND
			/// USN_REASON_NAMED_DATA_TRUNCATION
			/// USN_REASON_FILE_CREATE
			/// USN_REASON_FILE_DELETE
			/// USN_REASON_EA_CHANGE
			/// USN_REASON_SECURITY_CHANGE
			/// USN_REASON_RENAME_OLD_NAME
			/// USN_REASON_RENAME_NEW_NAME
			/// USN_REASON_INDEXABLE_CHANGE
			/// USN_REASON_BASIC_INFO_CHANGE
			/// USN_REASON_HARD_LINK_CHANGE
			/// USN_REASON_COMPRESSION_CHANGE
			/// USN_REASON_ENCRYPTION_CHANGE
			/// USN_REASON_OBJECT_ID_CHANGE
			/// USN_REASON_REPARSE_POINT_CHANGE
			/// USN_REASON_STREAM_CHANGE
			/// USN_REASON_CLOSE
			/// </remarks>
			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct READ_USN_JOURNAL_DATA
			{
				public Int64 StartUsn;
				public UInt32 ReasonMask;
				public UInt32 ReturnOnlyOnClose;
				public UInt64 Timeout;
				public UInt64 bytesToWaitFor;
				public UInt64 UsnJournalId;
			}

			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct POINT
			{
				public int X;
				public int Y;

				public POINT(int x, int y)
				{
					this.X = x;
					this.Y = y;
				}
			}

			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct IO_STATUS_BLOCK
			{
				public uint status;
				public ulong information;
			}

			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct OBJECT_ATTRIBUTES
			{
				public Int32 Length;
				public IntPtr RootDirectory;
				public IntPtr ObjectName;
				public Int32 Attributes;
				public Int32 SecurityDescriptor;
				public Int32 SecurityQualityOfService;
			}

			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct UNICODE_STRING
			{
				public Int16 Length;
				public Int16 MaximumLength;
				public IntPtr Buffer;
			}

			#endregion

			#region functions

			/*
		public static string GetPathFromFileReference(IntPtr rootIntPtr, UInt64 frn)
		{
			string name = string.Empty;

			long allocSize = 0;
			UNICODE_STRING unicodeString;
			OBJECT_ATTRIBUTES objAttributes = new OBJECT_ATTRIBUTES();
			IO_STATUS_BLOCK ioStatusBlock = new IO_STATUS_BLOCK();
			IntPtr hFile;

			IntPtr buffer = Marshal.AllocHGlobal(4096);
			IntPtr refPtr = Marshal.AllocHGlobal(8);
			IntPtr objAttIntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(objAttributes));

			//
			// pointer >> fileid
			//
			Marshal.WriteInt64(refPtr, (long)frn);

			unicodeString.Length = 8;
			unicodeString.MaximumLength = 8;
			unicodeString.Buffer = refPtr;
			//
			// copy unicode structure to pointer
			//
			Marshal.StructureToPtr(unicodeString, objAttIntPtr, true);

			//
			//  InitializeObjectAttributes 
			//
			objAttributes.Length = Marshal.SizeOf(objAttributes);
			objAttributes.ObjectName = objAttIntPtr;
			objAttributes.RootDirectory = rootIntPtr;
			objAttributes.Attributes = (int)OBJ_CASE_INSENSITIVE;

			int fOk = NtCreateFile(out hFile, 0, ref objAttributes, ref ioStatusBlock, ref allocSize, 0,
				FileShare.ReadWrite,
				FILE_OPEN, FILE_OPEN_BY_FILE_ID | FILE_OPEN_FOR_BACKUP_INTENT, IntPtr.Zero, 0);
			if (fOk.ToInt32() == 0)
			{
				fOk = NtQueryInformationFile(hFile, ref ioStatusBlock, buffer, 4096, FILE_INFORMATION_CLASS.FileNameInformation);
				if (fOk.ToInt32() == 0)
				{
					//
					// first 4 bytes are the name length
					//
					int nameLength = Marshal.ReadInt32(buffer, 0);
					//
					// next bytes are the name
					//
					name = Marshal.PtrToStringUni(new IntPtr(buffer.ToInt32() + 4), nameLength / 2);
				}
			}
			hFile.Close();
			Marshal.FreeHGlobal(buffer);
			Marshal.FreeHGlobal(objAttIntPtr);
			Marshal.FreeHGlobal(refPtr);
			return name;
		}
		*/

			/// <summary>
			/// Writes the data in 'text' to the alternate stream ':Description' of the file 'currentFile.
			/// </summary>
			/// <param name="currentfile">Fully qualified path to a file</param>
			/// <param name="text">Data to write to the ':Description' stream</param>
			public static void WriteAlternateStream(string currentfile, string text)
			{
				string AltStreamDesc = currentfile + ":Description";
				IntPtr txtBuffer = IntPtr.Zero;
				IntPtr hFile = IntPtr.Zero;
				DeleteFile(AltStreamDesc);
				string descText = text.TrimEnd(' ');

				try
				{
					hFile = CreateFile(AltStreamDesc, GENERIC_WRITE, 0, IntPtr.Zero,
										   CREATE_ALWAYS, 0, IntPtr.Zero);
					if (-1 != hFile.ToInt32())
					{
						txtBuffer = Marshal.StringToHGlobalUni(descText);
						uint nBytes, count;
						nBytes = (uint)descText.Length;
						bool bRtn = WriteFile(hFile, txtBuffer, sizeof(char) * nBytes, out count, 0);
						if (!bRtn)
						{
							if ((sizeof(char) * nBytes) != count)
							{
								throw new Exception(string.Format("Bytes written {0} should be {1} for file {2}.",
									count, sizeof(char) * nBytes, AltStreamDesc));
							}
							else
							{
								throw new Exception("WriteFile() returned false");
							}
						}
					}
					else
					{
						throw new Win32Exception(Marshal.GetLastWin32Error());
					}
				}
				catch (Exception exception)
				{
					string msg = string.Format("Exception caught in WriteAlternateStream()\n  '{0}'\n  for file '{1}'.",
						exception.Message, AltStreamDesc);
					Console.WriteLine(msg);
				}
				finally
				{
					CloseHandle(hFile);
					hFile = IntPtr.Zero;
					Marshal.FreeHGlobal(txtBuffer);
					GC.Collect();
				}
			}

			/// <summary>
			/// Adds the ':Description' alternate stream name to the argument 'currentFile'.
			/// </summary>
			/// <param name="currentfile">The file whose alternate stream is to be read</param>
			/// <returns>A string value representing the value of the alternate stream</returns>
			public static string ReadAlternateStream(string currentfile)
			{
				string AltStreamDesc = currentfile + ":Description";
				string returnstring = ReadAlternateStreamEx(AltStreamDesc);
				return returnstring;
			}

			/// <summary>
			/// Reads the stream represented by 'currentFile'.
			/// </summary>
			/// <param name="currentfile">Fully qualified path including stream</param>
			/// <returns>Value of the alternate stream as a string</returns>
			public static string ReadAlternateStreamEx(string currentfile)
			{
				string returnstring = string.Empty;
				IntPtr hFile = IntPtr.Zero;
				IntPtr buffer = IntPtr.Zero;
				try
				{
					hFile = CreateFile(currentfile, GENERIC_READ, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
					if (-1 != hFile.ToInt32())
					{
						buffer = Marshal.AllocHGlobal(1000 * sizeof(char));
						ZeroMemory(buffer, 1000 * sizeof(char));
						uint nBytes;
						bool bRtn = ReadFile(hFile, buffer, 1000 * sizeof(char), out nBytes, IntPtr.Zero);
						if (bRtn)
						{
							if (nBytes > 0)
							{
								returnstring = Marshal.PtrToStringAuto(buffer);
								//byte[] byteBuffer = new byte[nBytes];
								//for (int i = 0; i < nBytes; i++)
								//{
								//    byteBuffer[i] = Marshal.ReadByte(buffer, i);
								//}
								//returnstring = Encoding.Unicode.GetString(byteBuffer, 0, (int)nBytes);
							}
							else
							{
								throw new Exception("ReadFile() returned true but read zero bytes");
							}
						}
						else
						{
							if (nBytes <= 0)
							{
								throw new Exception("ReadFile() read zero bytes.");
							}
							else
							{
								throw new Exception("ReadFile() returned false");
							}
						}
					}
					else
					{
						Exception excptn = new Win32Exception(Marshal.GetLastWin32Error());
						if (!excptn.Message.Contains("cannot find the file"))
						{
							throw excptn;
						}
					}
				}
				catch (Exception exception)
				{
					string msg = string.Format("Exception caught in ReadAlternateStream(), '{0}'\n  for file '{1}'.",
						exception.Message, currentfile);
					Console.WriteLine(msg);
					Console.WriteLine(exception.Message);
				}
				finally
				{
					CloseHandle(hFile);
					hFile = IntPtr.Zero;
					if (buffer != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(buffer);
					}
					GC.Collect();
				}
				return returnstring;
			}

			/// <summary>
			/// Read the encrypted alternate stream specified by 'currentFile'.
			/// </summary>
			/// <param name="currentfile">Fully qualified path to encrypted alternate stream</param>
			/// <returns>The un-encrypted value of the alternate stream as a string</returns>
			public static string ReadAlternateStreamEncrypted(string currentfile)
			{
				string returnstring = string.Empty;
				IntPtr buffer = IntPtr.Zero;
				IntPtr hFile = IntPtr.Zero;
				try
				{
					hFile = CreateFile(currentfile, GENERIC_READ, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
					if (-1 != hFile.ToInt32())
					{
						buffer = Marshal.AllocHGlobal(1000 * sizeof(char));
						ZeroMemory(buffer, 1000 * sizeof(char));
						uint nBytes;
						bool bRtn = ReadFile(hFile, buffer, 1000 * sizeof(char), out nBytes, IntPtr.Zero);
						if (0 != nBytes)
						{
							returnstring = DecryptLicenseString(buffer, nBytes);
						}
					}
					else
					{
						Exception excptn = new Win32Exception(Marshal.GetLastWin32Error());
						if (!excptn.Message.Contains("cannot find the file"))
						{
							throw excptn;
						}
					}
				}
				catch (Exception exception)
				{
					Console.WriteLine("Exception caught in ReadAlternateStreamEncrypted()");
					Console.WriteLine(exception.Message);
				}
				finally
				{
					CloseHandle(hFile);
					hFile = IntPtr.Zero;
					if (buffer != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(buffer);
					}
					GC.Collect();
				}
				return returnstring;
			}

			/// <summary>
			/// Writes the value of 'LicenseString' as an encrypted stream to the file:stream specified
			/// by 'currentFile'.
			/// </summary>
			/// <param name="currentFile">Fully qualified path to the alternate stream</param>
			/// <param name="LicenseString">The string value to encrypt and write to the alternate stream</param>
			public static void WriteAlternateStreamEncrypted(string currentFile, string LicenseString)
			{
				RC2CryptoServiceProvider rc2 = null;
				CryptoStream cs = null;
				MemoryStream ms = null;
				uint count = 0;
				IntPtr buffer = IntPtr.Zero;
				IntPtr hFile = IntPtr.Zero;
				try
				{
					Encoding enc = Encoding.Unicode;

					byte[] ba = enc.GetBytes(LicenseString);
					ms = new MemoryStream();

					rc2 = new RC2CryptoServiceProvider();
					rc2.Key = GetBytesFromHexString("7a6823a42a3a3ae27057c647db812d0");
					rc2.IV = GetBytesFromHexString("827d961224d99b2d");

					cs = new CryptoStream(ms, rc2.CreateEncryptor(), CryptoStreamMode.Write);
					cs.Write(ba, 0, ba.Length);
					cs.FlushFinalBlock();

					buffer = Marshal.AllocHGlobal(1000 * sizeof(char));
					ZeroMemory(buffer, 1000 * sizeof(char));
					uint nBytes = (uint)ms.Length;
					Marshal.Copy(ms.GetBuffer(), 0, buffer, (int)nBytes);

					DeleteFile(currentFile);
					hFile = CreateFile(currentFile, GENERIC_WRITE, 0, IntPtr.Zero,
										   CREATE_ALWAYS, 0, IntPtr.Zero);
					if (-1 != hFile.ToInt32())
					{
						bool bRtn = WriteFile(hFile, buffer, nBytes, out count, 0);
					}
					else
					{
						Exception excptn = new Win32Exception(Marshal.GetLastWin32Error());
						if (!excptn.Message.Contains("cannot find the file"))
						{
							throw excptn;
						}
					}
				}
				catch (Exception exception)
				{
					Console.WriteLine("WriteAlternateStreamEncrypted()");
					Console.WriteLine(exception.Message);
				}
				finally
				{
					CloseHandle(hFile);
					hFile = IntPtr.Zero;
					if (cs != null)
					{
						cs.Close();
						cs.Dispose();
					}

					rc2 = null;
					if (ms != null)
					{
						ms.Close();
						ms.Dispose();
					}
					if (buffer != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(buffer);
					}
				}
			}

			/// <summary>
			/// Encrypt the string 'LicenseString' argument and return as a MemoryStream.
			/// </summary>
			/// <param name="LicenseString">The string value to encrypt</param>
			/// <returns>A MemoryStream which contains the encrypted value of 'LicenseString'</returns>
			private static MemoryStream EncryptLicenseString(string LicenseString)
			{
				Encoding enc = Encoding.Unicode;

				byte[] ba = enc.GetBytes(LicenseString);
				MemoryStream ms = new MemoryStream();

				RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();
				rc2.Key = GetBytesFromHexString("7a6823a42a3a3ae27057c647db812d0");
				rc2.IV = GetBytesFromHexString("827d961224d99b2d");

				CryptoStream cs = new CryptoStream(ms, rc2.CreateEncryptor(), CryptoStreamMode.Write);
				cs.Write(ba, 0, ba.Length);

				cs.Close();
				cs.Dispose();
				rc2 = null;
				return ms;
			}

			/// <summary>
			/// Given an IntPtr to a bufer and the number of bytes, decrypt the buffer and return an 
			/// unencrypted text string.
			/// </summary>
			/// <param name="buffer">An IntPtr to the 'buffer' containing the encrypted string</param>
			/// <param name="nBytes">The number of bytes in 'buffer' to decrypt</param>
			/// <returns></returns>
			private static string DecryptLicenseString(IntPtr buffer, uint nBytes)
			{
				byte[] ba = new byte[nBytes];
				for (int i = 0; i < nBytes; i++)
				{
					ba[i] = Marshal.ReadByte(buffer, i);
				}
				MemoryStream ms = new MemoryStream(ba);

				RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();
				rc2.Key = GetBytesFromHexString("7a6823a42a3a3ae27057c647db812d0");
				rc2.IV = GetBytesFromHexString("827d961224d99b2d");

				CryptoStream cs = new CryptoStream(ms, rc2.CreateDecryptor(), CryptoStreamMode.Read);
				string licenseString = string.Empty;
				byte[] ba1 = new byte[4096];
				int irtn = cs.Read(ba1, 0, 4096);
				Encoding enc = Encoding.Unicode;
				licenseString = enc.GetString(ba1, 0, irtn);

				cs.Close();
				cs.Dispose();
				ms.Close();
				ms.Dispose();
				rc2 = null;
				return licenseString;
			}

			/// <summary>
			/// Gets the byte array generated from the value of 'hexString'.
			/// </summary>
			/// <param name="hexString">Hexadecimal string</param>
			/// <returns>Array of bytes generated from 'hexString'.</returns>
			public static byte[] GetBytesFromHexString(string hexString)
			{
				int numHexChars = hexString.Length / 2;
				byte[] ba = new byte[numHexChars];
				int j = 0;
				for (int i = 0; i < ba.Length; i++)
				{
					string hex = new string(new char[] { hexString[j], hexString[j + 1] });
					ba[i] = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
					j = j + 2;
				}
				return ba;
			}

			#endregion
		}

	}