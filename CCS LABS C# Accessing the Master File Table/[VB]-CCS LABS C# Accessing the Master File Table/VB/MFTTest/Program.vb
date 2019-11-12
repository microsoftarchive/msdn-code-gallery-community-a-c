Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.ComponentModel


Namespace MFTTest
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			Dim fExt(0) As String
			fExt(0) = "exe"

			Dim mDict As New Dictionary(Of ULong, FileNameAndParentFrn)()

			Dim mft As New EnumerateVolume.PInvokeWin32()
			mft.Drive = "C:"
			mft.EnumerateVolume(mDict, New String() { "*" })
			For Each entry As KeyValuePair(Of UInt64, FileNameAndParentFrn) In mDict
				Dim file As FileNameAndParentFrn = CType(entry.Value, FileNameAndParentFrn)

				Console.WriteLine(file.Name & " " & file.ParentFrn)
			Next entry

			Console.WriteLine("DONE")
			Console.ReadKey()
		End Sub
	End Class


	Namespace EnumerateVolume
		Public Class PInvokeWin32

			Private _directories As New Dictionary(Of ULong, FileNameAndParentFrn)()

			Public Property Directories() As Dictionary(Of ULong, FileNameAndParentFrn)
				Get
					Return _directories
				End Get
				Set(ByVal value As Dictionary(Of ULong, FileNameAndParentFrn))
					_directories = value
				End Set
			End Property


			Private _changeJournalRootHandle As IntPtr
			Private _drive As String

			Public Property Drive() As String
				Get
					Return _drive
				End Get
				Set(ByVal value As String)
					_drive = value
				End Set
			End Property

			#Region "DllImports and Constants"

			Public Const GENERIC_READ As UInt32 = &H80000000L
			Public Const GENERIC_WRITE As UInt32 = &H40000000
			Public Const FILE_SHARE_READ As UInt32 = &H1
			Public Const FILE_SHARE_WRITE As UInt32 = &H2
			Public Const FILE_ATTRIBUTE_DIRECTORY As UInt32 = &H10
			Public Const OPEN_EXISTING As UInt32 = 3
			Public Const FILE_FLAG_BACKUP_SEMANTICS As UInt32 = &H2000000
			Public Const INVALID_HANDLE_VALUE As Int32 = -1
			Public Const FSCTL_QUERY_USN_JOURNAL As UInt32 = &H900f4
			Public Const FSCTL_ENUM_USN_DATA As UInt32 = &H900b3
			Public Const FSCTL_CREATE_USN_JOURNAL As UInt32 = &H900e7

			<DllImport("kernel32.dll", SetLastError := True)> _
			Public Shared Function CreateFile(ByVal lpFileName As String, ByVal dwDesiredAccess As UInteger, ByVal dwShareMode As UInteger, ByVal lpSecurityAttributes As IntPtr, ByVal dwCreationDisposition As UInteger, ByVal dwFlagsAndAttributes As UInteger, ByVal hTemplateFile As IntPtr) As IntPtr
			End Function

			<DllImport("kernel32.dll", SetLastError := True)> _
			Public Shared Function GetFileInformationByHandle(ByVal hFile As IntPtr, <System.Runtime.InteropServices.Out()> ByRef lpFileInformation As BY_HANDLE_FILE_INFORMATION) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			<DllImport("kernel32.dll", SetLastError := True)> _
			Public Shared Function CloseHandle(ByVal hObject As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			<DllImport("kernel32.dll", ExactSpelling := True, SetLastError := True, CharSet := CharSet.Auto)> _
			Public Shared Function DeviceIoControl(ByVal hDevice As IntPtr, ByVal dwIoControlCode As UInt32, ByVal lpInBuffer As IntPtr, ByVal nInBufferSize As Int32, <System.Runtime.InteropServices.Out()> ByRef lpOutBuffer As USN_JOURNAL_DATA, ByVal nOutBufferSize As Int32, <System.Runtime.InteropServices.Out()> ByRef lpBytesReturned As UInteger, ByVal lpOverlapped As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			<DllImport("kernel32.dll", ExactSpelling := True, SetLastError := True, CharSet := CharSet.Auto)> _
			Public Shared Function DeviceIoControl(ByVal hDevice As IntPtr, ByVal dwIoControlCode As UInt32, ByVal lpInBuffer As IntPtr, ByVal nInBufferSize As Int32, ByVal lpOutBuffer As IntPtr, ByVal nOutBufferSize As Int32, <System.Runtime.InteropServices.Out()> ByRef lpBytesReturned As UInteger, ByVal lpOverlapped As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			<DllImport("kernel32.dll")> _
			Public Shared Sub ZeroMemory(ByVal ptr As IntPtr, ByVal size As Int32)
			End Sub

			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure BY_HANDLE_FILE_INFORMATION
				Public FileAttributes As UInteger
				Public CreationTime As FILETIME
				Public LastAccessTime As FILETIME
				Public LastWriteTime As FILETIME
				Public VolumeSerialNumber As UInteger
				Public FileSizeHigh As UInteger
				Public FileSizeLow As UInteger
				Public NumberOfLinks As UInteger
				Public FileIndexHigh As UInteger
				Public FileIndexLow As UInteger
			End Structure

			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure FILETIME
				Public DateTimeLow As UInteger
				Public DateTimeHigh As UInteger
			End Structure


			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure USN_JOURNAL_DATA
				Public UsnJournalID As UInt64
				Public FirstUsn As Int64
				Public NextUsn As Int64
				Public LowestValidUsn As Int64
				Public MaxUsn As Int64
				Public MaximumSize As UInt64
				Public AllocationDelta As UInt64
			End Structure

			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure MFT_ENUM_DATA
				Public StartFileReferenceNumber As UInt64
				Public LowUsn As Int64
				Public HighUsn As Int64
			End Structure

			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure CREATE_USN_JOURNAL_DATA
				Public MaximumSize As UInt64
				Public AllocationDelta As UInt64
			End Structure

			Public Class USN_RECORD
				Public RecordLength As UInt32
				Public FileReferenceNumber As UInt64
				Public ParentFileReferenceNumber As UInt64
				Public FileAttributes As UInt32
				Public FileNameLength As Int32
				Public FileNameOffset As Int32
				Public FileName As String = String.Empty

				Private Const FR_OFFSET As Integer = 8
				Private Const PFR_OFFSET As Integer = 16
				Private Const FA_OFFSET As Integer = 52
				Private Const FNL_OFFSET As Integer = 56
				Private Const FN_OFFSET As Integer = 58

				Public Sub New(ByVal p As IntPtr)
					Me.RecordLength = CUInt(Marshal.ReadInt32(p))
					Me.FileReferenceNumber = CULng(Marshal.ReadInt64(p, FR_OFFSET))
					Me.ParentFileReferenceNumber = CULng(Marshal.ReadInt64(p, PFR_OFFSET))
					Me.FileAttributes = CUInt(Marshal.ReadInt32(p, FA_OFFSET))
					Me.FileNameLength = Marshal.ReadInt16(p, FNL_OFFSET)
					Me.FileNameOffset = Marshal.ReadInt16(p, FN_OFFSET)
					FileName = Marshal.PtrToStringUni(New IntPtr(p.ToInt32() + Me.FileNameOffset), Me.FileNameLength / Len(New Char))
				End Sub
			End Class

			#End Region

			Public Sub EnumerateVolume(<System.Runtime.InteropServices.Out()> ByRef files As Dictionary(Of UInt64, FileNameAndParentFrn), ByVal fileExtensions() As String)
				files = New Dictionary(Of ULong, FileNameAndParentFrn)()
				Dim medBuffer As IntPtr = IntPtr.Zero
				Try
					GetRootFrnEntry()
					GetRootHandle()

					CreateChangeJournal()

					SetupMFT_Enum_DataBuffer(medBuffer)
					EnumerateFiles(medBuffer, files, fileExtensions)
				Catch e As Exception
					'	Log.Info(e.Message, e);
					Dim innerException As Exception = e.InnerException
					Do While innerException IsNot Nothing
						'		Log.Info(innerException.Message, innerException);
						innerException = innerException.InnerException
					Loop
					Throw New ApplicationException("Error in EnumerateVolume()", e)
				Finally
					If _changeJournalRootHandle.ToInt32() <> PInvokeWin32.INVALID_HANDLE_VALUE Then
						PInvokeWin32.CloseHandle(_changeJournalRootHandle)
					End If
					If medBuffer <> IntPtr.Zero Then
						Marshal.FreeHGlobal(medBuffer)
					End If
				End Try
			End Sub

			Private Sub GetRootFrnEntry()
				Dim driveRoot As String = String.Concat("\\.\", _drive)
				driveRoot = String.Concat(driveRoot, Path.DirectorySeparatorChar)
				Dim hRoot As IntPtr = PInvokeWin32.CreateFile(driveRoot, 0, PInvokeWin32.FILE_SHARE_READ Or PInvokeWin32.FILE_SHARE_WRITE, IntPtr.Zero, PInvokeWin32.OPEN_EXISTING, PInvokeWin32.FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero)

				If hRoot.ToInt32() <> PInvokeWin32.INVALID_HANDLE_VALUE Then
					Dim fi As New PInvokeWin32.BY_HANDLE_FILE_INFORMATION()
					Dim bRtn As Boolean = PInvokeWin32.GetFileInformationByHandle(hRoot, fi)
					If bRtn Then
						Dim fileIndexHigh As UInt64 = CULng(fi.FileIndexHigh)
						Dim indexRoot As UInt64 = (fileIndexHigh << 32) Or fi.FileIndexLow

						Dim f As New FileNameAndParentFrn(driveRoot, 0)
						_directories.Add(indexRoot, f)
					Else
						Throw New IOException("GetFileInformationbyHandle() returned invalid handle", New Win32Exception(Marshal.GetLastWin32Error()))
					End If
					PInvokeWin32.CloseHandle(hRoot)
				Else
					Throw New IOException("Unable to get root frn entry", New Win32Exception(Marshal.GetLastWin32Error()))
				End If
			End Sub

			Private Sub GetRootHandle()
				Dim vol As String = String.Concat("\\.\", _drive)
				_changeJournalRootHandle = PInvokeWin32.CreateFile(vol, PInvokeWin32.GENERIC_READ Or PInvokeWin32.GENERIC_WRITE, PInvokeWin32.FILE_SHARE_READ Or PInvokeWin32.FILE_SHARE_WRITE, IntPtr.Zero, PInvokeWin32.OPEN_EXISTING, 0, IntPtr.Zero)
				If _changeJournalRootHandle.ToInt32() = PInvokeWin32.INVALID_HANDLE_VALUE Then
					Throw New IOException("CreateFile() returned invalid handle", New Win32Exception(Marshal.GetLastWin32Error()))
				End If
			End Sub

'INSTANT VB TODO TASK: There is no equivalent to the 'unsafe' modifier in VB:
'ORIGINAL LINE: unsafe public void EnumerateFiles(IntPtr medBuffer, ref Dictionary(Of ulong, FileNameAndParentFrn) files, string[] fileExtensions)
			Public Sub EnumerateFiles(ByVal medBuffer As IntPtr, ByRef files As Dictionary(Of ULong, FileNameAndParentFrn), ByVal fileExtensions() As String)
				Dim pData As IntPtr = Marshal.AllocHGlobal(Len(New UInt64) + &H10000)
				PInvokeWin32.ZeroMemory(pData, Len(New UInt64) + &H10000)
				Dim outBytesReturned As UInteger = 0

'INSTANT VB TODO TASK: There is no VB equivalent to 'sizeof':
				Do While False <> PInvokeWin32.DeviceIoControl(_changeJournalRootHandle, PInvokeWin32.FSCTL_ENUM_USN_DATA, medBuffer, sizeof(PInvokeWin32.MFT_ENUM_DATA), pData, Len(New UInt64) + &H10000, outBytesReturned, IntPtr.Zero)
					Dim pUsnRecord As New IntPtr(pData.ToInt32() + Len(New Int64))
					Do While outBytesReturned > 60
						Dim usn As New PInvokeWin32.USN_RECORD(pUsnRecord)
						If 0 <> (usn.FileAttributes And PInvokeWin32.FILE_ATTRIBUTE_DIRECTORY) Then
							'  
							' handle directories  
							'  
							If Not _directories.ContainsKey(usn.FileReferenceNumber) Then
								_directories.Add(usn.FileReferenceNumber, New FileNameAndParentFrn(usn.FileName, usn.ParentFileReferenceNumber))
							Else
								' duplicate frn's don't exist on a given drive.  To date, this exception has  
								' never been thrown.  Removing this code improves performance....  
								Throw New Exception(String.Format("Duplicate FRN: {0} for {1}", usn.FileReferenceNumber, usn.FileName))
							End If
						Else
							'   
							' handle files  
							'  

							' at this point we could get the * for the extension
							Dim add As Boolean = True
							Dim fullpath As Boolean = False
							If fileExtensions IsNot Nothing AndAlso fileExtensions.Length <> 0 Then
								If fileExtensions(0).ToString() = "*" Then
									add = True
									fullpath = True
								Else
									add = False
									Dim s As String = Path.GetExtension(usn.FileName)
									For Each extension As String In fileExtensions
										If 0 = String.Compare(s, extension, True) Then
											add = True
											Exit For
										End If
									Next extension
								End If
							End If
							If add Then
								If fullpath Then
									If Not files.ContainsKey(usn.FileReferenceNumber) Then
										files.Add(usn.FileReferenceNumber, New FileNameAndParentFrn(usn.FileName, usn.ParentFileReferenceNumber))
									Else
										Dim frn As FileNameAndParentFrn = files(usn.FileReferenceNumber)
										If 0 <> String.Compare(usn.FileName, frn.Name, True) Then
											'	Log.InfoFormat(
											'	"Attempt to add duplicate file reference number: {0} for file {1}, file from index {2}",
											'	usn.FileReferenceNumber, usn.FileName, frn.Name);
											Throw New Exception(String.Format("Duplicate FRN: {0} for {1}", usn.FileReferenceNumber, usn.FileName))
										End If
									End If
								Else
									If Not files.ContainsKey(usn.FileReferenceNumber) Then
										files.Add(usn.FileReferenceNumber, New FileNameAndParentFrn(usn.FileName, usn.ParentFileReferenceNumber))
									Else
										Dim frn As FileNameAndParentFrn = files(usn.FileReferenceNumber)
										If 0 <> String.Compare(usn.FileName, frn.Name, True) Then
											'	Log.InfoFormat(
											'	"Attempt to add duplicate file reference number: {0} for file {1}, file from index {2}",
											'	usn.FileReferenceNumber, usn.FileName, frn.Name);
											Throw New Exception(String.Format("Duplicate FRN: {0} for {1}", usn.FileReferenceNumber, usn.FileName))
										End If
									End If
								End If
							End If
						End If
						pUsnRecord = New IntPtr(pUsnRecord.ToInt32() + usn.RecordLength)
						outBytesReturned -= usn.RecordLength
					Loop
					Marshal.WriteInt64(medBuffer, Marshal.ReadInt64(pData, 0))
				Loop
				Marshal.FreeHGlobal(pData)
			End Sub

'INSTANT VB TODO TASK: There is no equivalent to the 'unsafe' modifier in VB:
'ORIGINAL LINE: unsafe private void CreateChangeJournal()
			Private Sub CreateChangeJournal()
				' This function creates a journal on the volume. If a journal already  
				' exists this function will adjust the MaximumSize and AllocationDelta  
				' parameters of the journal  
				Dim MaximumSize As UInt64 = &H800000
				Dim AllocationDelta As UInt64 = &H100000
				Dim cb As UInt32
				Dim cujd As PInvokeWin32.CREATE_USN_JOURNAL_DATA
				cujd.MaximumSize = MaximumSize
				cujd.AllocationDelta = AllocationDelta

				Dim sizeCujd As Integer = Marshal.SizeOf(cujd)
				Dim cujdBuffer As IntPtr = Marshal.AllocHGlobal(sizeCujd)
				PInvokeWin32.ZeroMemory(cujdBuffer, sizeCujd)
				Marshal.StructureToPtr(cujd, cujdBuffer, True)

				Dim fOk As Boolean = PInvokeWin32.DeviceIoControl(_changeJournalRootHandle, PInvokeWin32.FSCTL_CREATE_USN_JOURNAL, cujdBuffer, sizeCujd, IntPtr.Zero, 0, cb, IntPtr.Zero)
				If Not fOk Then
					Throw New IOException("DeviceIoControl() returned false", New Win32Exception(Marshal.GetLastWin32Error()))
				End If
			End Sub

'INSTANT VB TODO TASK: There is no equivalent to the 'unsafe' modifier in VB:
'ORIGINAL LINE: unsafe private void SetupMFT_Enum_DataBuffer(ref IntPtr medBuffer)
			Private Sub SetupMFT_Enum_DataBuffer(ByRef medBuffer As IntPtr)
				Dim bytesReturned As UInteger = 0
				Dim ujd As New PInvokeWin32.USN_JOURNAL_DATA()

'INSTANT VB TODO TASK: There is no VB equivalent to 'sizeof':
				Dim bOk As Boolean = PInvokeWin32.DeviceIoControl(_changeJournalRootHandle, PInvokeWin32.FSCTL_QUERY_USN_JOURNAL, IntPtr.Zero, 0, ujd, sizeof(PInvokeWin32.USN_JOURNAL_DATA), bytesReturned, IntPtr.Zero) ' lpOverlapped -  Bytes Returned -  Size Of Out Buffer -  Out Buffer -  In Buffer Size -  In Buffer -  IO Control Code -  Handle to drive
				If bOk Then
					Dim med As PInvokeWin32.MFT_ENUM_DATA
					med.StartFileReferenceNumber = 0
					med.LowUsn = 0
					med.HighUsn = ujd.NextUsn
					Dim sizeMftEnumData As Integer = Marshal.SizeOf(med)
					medBuffer = Marshal.AllocHGlobal(sizeMftEnumData)
					PInvokeWin32.ZeroMemory(medBuffer, sizeMftEnumData)
					Marshal.StructureToPtr(med, medBuffer, True)
				Else
					Throw New IOException("DeviceIoControl() returned false", New Win32Exception(Marshal.GetLastWin32Error()))
				End If
			End Sub
		End Class

	End Namespace

	Public Class FileNameAndParentFrn
		#Region "Properties"
		Private _name As String
		Public Property Name() As String
			Get
				Return _name
			End Get
			Set(ByVal value As String)
				_name = value
			End Set
		End Property

		Private _parentFrn As UInt64
		Public Property ParentFrn() As UInt64
			Get
				Return _parentFrn
			End Get
			Set(ByVal value As UInt64)
				_parentFrn = value
			End Set
		End Property
		#End Region

		#Region "Constructor"
		Public Sub New(ByVal name As String, ByVal parentFrn As UInt64)
			If name IsNot Nothing AndAlso name.Length > 0 Then
				_name = name
			Else
				Throw New ArgumentException("Invalid argument: null or Length = zero", "name")
			End If
			If Not(parentFrn < 0) Then
				_parentFrn = parentFrn
			Else
				Throw New ArgumentException("Invalid argument: less than zero", "parentFrn")
			End If
		End Sub
		#End Region
	End Class


End Namespace
