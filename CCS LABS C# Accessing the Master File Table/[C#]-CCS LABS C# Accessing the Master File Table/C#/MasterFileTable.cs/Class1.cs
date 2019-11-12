using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;

//http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/c1550294-d121-4511-ac32-31551497f64e/
namespace EnumerateVolume
{
	public class PInvokeWin32
	{

		private Dictionary<ulong, FileNameAndFrn> _directories = new Dictionary<ulong, FileNameAndFrn>();

		public Dictionary<ulong, FileNameAndFrn> Directories
		{
			get { return _directories; }
			set { _directories = value; }
		}


		private IntPtr _changeJournalRootHandle;
		private string _drive;

		public string Drive
		{
			get { return _drive; }
			set { _drive = value; }
		}

		#region DllImports and Constants

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

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess,
												  uint dwShareMode, IntPtr lpSecurityAttributes,
												  uint dwCreationDisposition, uint dwFlagsAndAttributes,
												  IntPtr hTemplateFile);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetFileInformationByHandle(IntPtr hFile,
																	 out BY_HANDLE_FILE_INFORMATION lpFileInformation);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeviceIoControl(IntPtr hDevice,
													  UInt32 dwIoControlCode,
													  IntPtr lpInBuffer, Int32 nInBufferSize,
													  out USN_JOURNAL_DATA lpOutBuffer, Int32 nOutBufferSize,
													  out uint lpBytesReturned, IntPtr lpOverlapped);

		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeviceIoControl(IntPtr hDevice,
													  UInt32 dwIoControlCode,
													  IntPtr lpInBuffer, Int32 nInBufferSize,
													  IntPtr lpOutBuffer, Int32 nOutBufferSize,
													  out uint lpBytesReturned, IntPtr lpOverlapped);

		[DllImport("kernel32.dll")]
		public static extern void ZeroMemory(IntPtr ptr, Int32 size);

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct BY_HANDLE_FILE_INFORMATION
		{
			public uint FileAttributes;
			public FILETIME CreationTime;
			public FILETIME LastAccessTime;
			public FILETIME LastWriteTime;
			public uint VolumeSerialNumber;
			public uint FileSizeHigh;
			public uint FileSizeLow;
			public uint NumberOfLinks;
			public uint FileIndexHigh;
			public uint FileIndexLow;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct FILETIME
		{
			public uint DateTimeLow;
			public uint DateTimeHigh;
		}


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

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct MFT_ENUM_DATA
		{
			public UInt64 StartFileReferenceNumber;
			public Int64 LowUsn;
			public Int64 HighUsn;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct CREATE_USN_JOURNAL_DATA
		{
			public UInt64 MaximumSize;
			public UInt64 AllocationDelta;
		}

		public class USN_RECORD
		{
			public UInt32 RecordLength;
			public UInt64 FileReferenceNumber;
			public UInt64 ParentFileReferenceNumber;
			public UInt32 FileAttributes;
			public Int32 FileNameLength;
			public Int32 FileNameOffset;
			public string FileName = string.Empty;

			private const int FR_OFFSET = 8;
			private const int PFR_OFFSET = 16;
			private const int FA_OFFSET = 52;
			private const int FNL_OFFSET = 56;
			private const int FN_OFFSET = 58;

			public USN_RECORD(IntPtr p)
			{
				this.RecordLength = (UInt32)Marshal.ReadInt32(p);
				this.FileReferenceNumber = (UInt64)Marshal.ReadInt64(p, FR_OFFSET);
				this.ParentFileReferenceNumber = (UInt64)Marshal.ReadInt64(p, PFR_OFFSET);
				this.FileAttributes = (UInt32)Marshal.ReadInt32(p, FA_OFFSET);
				this.FileNameLength = Marshal.ReadInt16(p, FNL_OFFSET);
				this.FileNameOffset = Marshal.ReadInt16(p, FN_OFFSET);
				FileName = Marshal.PtrToStringUni(new IntPtr(p.ToInt32() + this.FileNameOffset), this.FileNameLength / sizeof(char));
			}
		}

		#endregion

		public void EnumerateVolume(
		   out Dictionary<UInt64, FileNameAndFrn> files, string[] fileExtensions)
		{
			files = new Dictionary<ulong, FileNameAndFrn>();
			IntPtr medBuffer = IntPtr.Zero;
			try
			{
				GetRootFrnEntry();
				GetRootHandle();

				CreateChangeJournal();

				SetupMFT_Enum_DataBuffer(ref medBuffer);
				EnumerateFiles(medBuffer, ref files, fileExtensions);
			}
			catch (Exception e)
			{
				//	Log.Info(e.Message, e);
				Exception innerException = e.InnerException;
				while (innerException != null)
				{
					//		Log.Info(innerException.Message, innerException);
					innerException = innerException.InnerException;
				}
				throw new ApplicationException("Error in EnumerateVolume()", e);
			}
			finally
			{
				if (_changeJournalRootHandle.ToInt32() != PInvokeWin32.INVALID_HANDLE_VALUE)
				{
					PInvokeWin32.CloseHandle(_changeJournalRootHandle);
				}
				if (medBuffer != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(medBuffer);
				}
			}
		}

		private void GetRootFrnEntry()
		{
			string driveRoot = string.Concat("\\\\.\\", _drive);
			driveRoot = string.Concat(driveRoot, Path.DirectorySeparatorChar);
			IntPtr hRoot = PInvokeWin32.CreateFile(driveRoot,
				0,
				PInvokeWin32.FILE_SHARE_READ | PInvokeWin32.FILE_SHARE_WRITE,
				IntPtr.Zero,
				PInvokeWin32.OPEN_EXISTING,
				PInvokeWin32.FILE_FLAG_BACKUP_SEMANTICS,
				IntPtr.Zero);

			if (hRoot.ToInt32() != PInvokeWin32.INVALID_HANDLE_VALUE)
			{
				PInvokeWin32.BY_HANDLE_FILE_INFORMATION fi = new PInvokeWin32.BY_HANDLE_FILE_INFORMATION();
				bool bRtn = PInvokeWin32.GetFileInformationByHandle(hRoot, out fi);
				if (bRtn)
				{
					UInt64 fileIndexHigh = (UInt64)fi.FileIndexHigh;
					UInt64 indexRoot = (fileIndexHigh << 32) | fi.FileIndexLow;

					FileNameAndFrn f = new FileNameAndFrn(driveRoot, 0);
					_directories.Add(indexRoot, f);
				}
				else
				{
					throw new IOException("GetFileInformationbyHandle() returned invalid handle",
						new Win32Exception(Marshal.GetLastWin32Error()));
				}
				PInvokeWin32.CloseHandle(hRoot);
			}
			else
			{
				throw new IOException("Unable to get root frn entry", new Win32Exception(Marshal.GetLastWin32Error()));
			}
		}

		private void GetRootHandle()
		{
			string vol = string.Concat("\\\\.\\", _drive);
			_changeJournalRootHandle = PInvokeWin32.CreateFile(vol,
				 PInvokeWin32.GENERIC_READ | PInvokeWin32.GENERIC_WRITE,
				 PInvokeWin32.FILE_SHARE_READ | PInvokeWin32.FILE_SHARE_WRITE,
				 IntPtr.Zero,
				 PInvokeWin32.OPEN_EXISTING,
				 0,
				 IntPtr.Zero);
			if (_changeJournalRootHandle.ToInt32() == PInvokeWin32.INVALID_HANDLE_VALUE)
			{
				throw new IOException("CreateFile() returned invalid handle",
					new Win32Exception(Marshal.GetLastWin32Error()));
			}
		}

		unsafe public void EnumerateFiles(IntPtr medBuffer, ref Dictionary<ulong, FileNameAndFrn> files, string[] fileExtensions)
		{
			IntPtr pData = Marshal.AllocHGlobal(sizeof(UInt64) + 0x10000);
			PInvokeWin32.ZeroMemory(pData, sizeof(UInt64) + 0x10000);
			uint outBytesReturned = 0;

			while (false != PInvokeWin32.DeviceIoControl(_changeJournalRootHandle, PInvokeWin32.FSCTL_ENUM_USN_DATA, medBuffer,
									sizeof(PInvokeWin32.MFT_ENUM_DATA), pData, sizeof(UInt64) + 0x10000, out outBytesReturned,
									IntPtr.Zero))
			{
				IntPtr pUsnRecord = new IntPtr(pData.ToInt32() + sizeof(Int64));
				while (outBytesReturned > 60)
				{
					PInvokeWin32.USN_RECORD usn = new PInvokeWin32.USN_RECORD(pUsnRecord);
					if (0 != (usn.FileAttributes & PInvokeWin32.FILE_ATTRIBUTE_DIRECTORY))
					{
						//  
						// handle directories  
						//  
						if (!_directories.ContainsKey(usn.FileReferenceNumber))
						{
							_directories.Add(usn.FileReferenceNumber,
								new FileNameAndFrn(usn.FileName, usn.ParentFileReferenceNumber));
						}
						else
						{   // this is debug code and should be removed when we are certain that  
							// duplicate frn's don't exist on a given drive.  To date, this exception has  
							// never been thrown.  Removing this code improves performance....  
							throw new Exception(string.Format("Duplicate FRN: {0} for {1}",
								usn.FileReferenceNumber, usn.FileName));
						}
					}
					else
					{
						//   
						// handle files  
						//  
						bool add = true;
						if (fileExtensions != null && fileExtensions.Length != 0)
						{
							add = false;
							string s = Path.GetExtension(usn.FileName);
							foreach (string extension in fileExtensions)
							{
								if (0 == string.Compare(s, extension, true))
								{
									add = true;
									break;
								}
							}
						}
						if (add)
						{
							if (!files.ContainsKey(usn.FileReferenceNumber))
							{
								files.Add(usn.FileReferenceNumber,
									new FileNameAndFrn(usn.FileName, usn.ParentFileReferenceNumber));
							}
							else
							{
								FileNameAndFrn frn = files[usn.FileReferenceNumber];
								if (0 != string.Compare(usn.FileName, frn.Name, true))
								{
									//	Log.InfoFormat(
									//	"Attempt to add duplicate file reference number: {0} for file {1}, file from index {2}",
									//	usn.FileReferenceNumber, usn.FileName, frn.Name);
									throw new Exception(string.Format("Duplicate FRN: {0} for {1}",
										usn.FileReferenceNumber, usn.FileName));
								}
							}
						}
					}
					pUsnRecord = new IntPtr(pUsnRecord.ToInt32() + usn.RecordLength);
					outBytesReturned -= usn.RecordLength;
				}
				Marshal.WriteInt64(medBuffer, Marshal.ReadInt64(pData, 0));
			}
			Marshal.FreeHGlobal(pData);
		}

		unsafe private void CreateChangeJournal()
		{
			// This function creates a journal on the volume. If a journal already  
			// exists this function will adjust the MaximumSize and AllocationDelta  
			// parameters of the journal  
			UInt64 MaximumSize = 0x800000;
			UInt64 AllocationDelta = 0x100000;
			UInt32 cb;
			PInvokeWin32.CREATE_USN_JOURNAL_DATA cujd;
			cujd.MaximumSize = MaximumSize;
			cujd.AllocationDelta = AllocationDelta;

			int sizeCujd = Marshal.SizeOf(cujd);
			IntPtr cujdBuffer = Marshal.AllocHGlobal(sizeCujd);
			PInvokeWin32.ZeroMemory(cujdBuffer, sizeCujd);
			Marshal.StructureToPtr(cujd, cujdBuffer, true);

			bool fOk = PInvokeWin32.DeviceIoControl(_changeJournalRootHandle, PInvokeWin32.FSCTL_CREATE_USN_JOURNAL,
				cujdBuffer, sizeCujd, IntPtr.Zero, 0, out cb, IntPtr.Zero);
			if (!fOk)
			{
				throw new IOException("DeviceIoControl() returned false", new Win32Exception(Marshal.GetLastWin32Error()));
			}
		}

		unsafe private void SetupMFT_Enum_DataBuffer(ref IntPtr medBuffer)
		{
			uint bytesReturned = 0;
			PInvokeWin32.USN_JOURNAL_DATA ujd = new PInvokeWin32.USN_JOURNAL_DATA();

			bool bOk = PInvokeWin32.DeviceIoControl(_changeJournalRootHandle,                           // Handle to drive  
				PInvokeWin32.FSCTL_QUERY_USN_JOURNAL,   // IO Control Code  
				IntPtr.Zero,                // In Buffer  
				0,                          // In Buffer Size  
				out ujd,                    // Out Buffer  
				sizeof(PInvokeWin32.USN_JOURNAL_DATA),  // Size Of Out Buffer  
				out bytesReturned,          // Bytes Returned  
				IntPtr.Zero);               // lpOverlapped  
			if (bOk)
			{
				PInvokeWin32.MFT_ENUM_DATA med;
				med.StartFileReferenceNumber = 0;
				med.LowUsn = 0;
				med.HighUsn = ujd.NextUsn;
				int sizeMftEnumData = Marshal.SizeOf(med);
				medBuffer = Marshal.AllocHGlobal(sizeMftEnumData);
				PInvokeWin32.ZeroMemory(medBuffer, sizeMftEnumData);
				Marshal.StructureToPtr(med, medBuffer, true);
			}
			else
			{
				throw new IOException("DeviceIoControl() returned false", new Win32Exception(Marshal.GetLastWin32Error()));
			}
		}
	}

}

public class FileNameAndFrn
{
	#region Properties
	private string _name;
	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}

	private UInt64 _parentFrn;
	public UInt64 ParentFrn
	{
		get { return _parentFrn; }
		set { _parentFrn = value; }
	}
	#endregion

	#region Constructor
	public FileNameAndFrn(string name, UInt64 parentFrn)
	{
		if (name != null && name.Length > 0)
		{
			_name = name;
		}
		else
		{
			throw new ArgumentException("Invalid argument: null or Length = zero", "name");
		}
		if (!(parentFrn < 0))
		{
			_parentFrn = parentFrn;
		}
		else
		{
			throw new ArgumentException("Invalid argument: less than zero", "parentFrn");
		}
	}
	#endregion
}
