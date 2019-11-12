' er's Blog        RSS Feed
''' -----
' Added Code To Get Path (StCroixSkipper's UsnJournalExplorer) NtfsUsnJournal.cs
' 02 May 2010
' Icon Leave Comment
' Posted by StCroixSkipper Icon
' I've added the code to calculate and display the path in the detail window. I had to change Win32Api.cs, NtfsUsnJournal.cs and UsnEntryDetail.cs.

' Note: I haven't dealt with the edge case where the UsnEntry I'm processing points to a directory that has already been deleted.

' Here is the new NtfsUsnJournal.cs file:

	Imports System
	Imports System.Collections.Generic
	Imports System.Linq
	Imports System.Text
	Imports System.IO

'	using PInvoke;
	Imports System.ComponentModel
	Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports Microsoft.Win32
	Imports Microsoft.Win32.SafeHandles
Imports System.Security.Cryptography

	Namespace UsnJournal
		Public Class NtfsUsnJournal
			Implements IDisposable

			#Region "enum(s)"
			Public Enum UsnJournalReturnCode
				INVALID_HANDLE_VALUE = -1
				USN_JOURNAL_SUCCESS = 0
				ERROR_INVALID_FUNCTION = 1
				ERROR_FILE_NOT_FOUND = 2
				ERROR_PATH_NOT_FOUND = 3
				ERROR_TOO_MANY_OPEN_FILES = 4
				ERROR_ACCESS_DENIED = 5
				ERROR_INVALID_HANDLE = 6
				ERROR_INVALID_DATA = 13
				ERROR_HANDLE_EOF = 38
				ERROR_NOT_SUPPORTED = 50
				ERROR_INVALID_PARAMETER = 87
				ERROR_JOURNAL_DELETE_IN_PROGRESS = 1178
				USN_JOURNAL_NOT_ACTIVE = 1179
				ERROR_JOURNAL_ENTRY_DELETED = 1181
				ERROR_INVALID_USER_BUFFER = 1784
				USN_JOURNAL_INVALID = 17001
				VOLUME_NOT_NTFS = 17003
				INVALID_FILE_REFERENCE_NUMBER = 17004
				USN_JOURNAL_ERROR = 17005
			End Enum

			Public Enum UsnReasonCode
				USN_REASON_DATA_OVERWRITE = &H1
				USN_REASON_DATA_EXTEND = &H2
				USN_REASON_DATA_TRUNCATION = &H4
				USN_REASON_NAMED_DATA_OVERWRITE = &H10
				USN_REASON_NAMED_DATA_EXTEND = &H20
				USN_REASON_NAMED_DATA_TRUNCATION = &H40
				USN_REASON_FILE_CREATE = &H100
				USN_REASON_FILE_DELETE = &H200
				USN_REASON_EA_CHANGE = &H400
				USN_REASON_SECURITY_CHANGE = &H800
				USN_REASON_RENAME_OLD_NAME = &H1000
				USN_REASON_RENAME_NEW_NAME = &H2000
				USN_REASON_INDEXABLE_CHANGE = &H4000
				USN_REASON_BASIC_INFO_CHANGE = &H8000
				USN_REASON_HARD_LINK_CHANGE = &H10000
				USN_REASON_COMPRESSION_CHANGE = &H20000
				USN_REASON_ENCRYPTION_CHANGE = &H40000
				USN_REASON_OBJECT_ID_CHANGE = &H80000
				USN_REASON_REPARSE_POINT_CHANGE = &H100000
				USN_REASON_STREAM_CHANGE = &H200000
				USN_REASON_CLOSE = -1
			End Enum

			#End Region

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

			#Region "private member variables"

			Private _driveInfo As DriveInfo = Nothing
			Private _volumeSerialNumber As UInteger
			Private _usnJournalRootHandle As IntPtr

			Private bNtfsVolume As Boolean

			#End Region

			#Region "properties"

			Private Shared _elapsedTime As TimeSpan
			Public Shared ReadOnly Property ElapsedTime() As TimeSpan
				Get
					Return _elapsedTime
				End Get
			End Property

			Public ReadOnly Property VolumeName() As String
				Get
					Return _driveInfo.Name
				End Get
			End Property

			Public ReadOnly Property AvailableFreeSpace() As Long
				Get
					Return _driveInfo.AvailableFreeSpace
				End Get
			End Property

			Public ReadOnly Property TotalFreeSpace() As Long
				Get
					Return _driveInfo.TotalFreeSpace
				End Get
			End Property

			Public ReadOnly Property Format() As String
				Get
					Return _driveInfo.DriveFormat
				End Get
			End Property

			Public ReadOnly Property RootDirectory() As DirectoryInfo
				Get
					Return _driveInfo.RootDirectory
				End Get
			End Property

			Public ReadOnly Property TotalSize() As Long
				Get
					Return _driveInfo.TotalSize
				End Get
			End Property

			Public ReadOnly Property VolumeLabel() As String
				Get
					Return _driveInfo.VolumeLabel
				End Get
			End Property

			Public ReadOnly Property VolumeSerialNumber() As UInteger
				Get
					Return _volumeSerialNumber
				End Get
			End Property

			#End Region

			#Region "constructor(s)"

			''' <summary>
			''' Constructor for NtfsUsnJournal class.  If no exception is thrown, _usnJournalRootHandle and
			''' _volumeSerialNumber can be assumed to be good. If an exception is thrown, the NtfsUsnJournal
			''' object is not usable.
			''' </summary>
			''' <param name="driveInfo">DriveInfo object that provides access to information about a volume</param>
			''' <remarks>
			''' An exception thrown if the volume is not an 'NTFS' volume or
			''' if GetRootHandle() or GetVolumeSerialNumber() functions fail.
			''' Each public method checks to see if the volume is NTFS and if the _usnJournalRootHandle is
			''' valid.  If these two conditions aren't met, then the public function will return a UsnJournalReturnCode
			''' error.
			''' </remarks>
			Public Sub New(ByVal driveInfo As DriveInfo)
				Dim start As Date = Date.Now
				_driveInfo = driveInfo

				If 0 = String.Compare(_driveInfo.DriveFormat, "ntfs", True) Then
					bNtfsVolume = True

					Dim rootHandle As IntPtr = IntPtr.Zero
					Dim usnRtnCode As UsnJournalReturnCode = GetRootHandle(rootHandle)

					If usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS Then
						_usnJournalRootHandle = rootHandle
						usnRtnCode = GetVolumeSerialNumber(_driveInfo, _volumeSerialNumber)
						If usnRtnCode <> UsnJournalReturnCode.USN_JOURNAL_SUCCESS Then
							_elapsedTime = Date.Now.Subtract(start)
							Throw New Win32Exception(CInt(usnRtnCode))
						End If
					Else
						_elapsedTime = Date.Now.Subtract(start)
						Throw New Win32Exception(CInt(usnRtnCode))
					End If
				Else
					_elapsedTime = Date.Now.Subtract(start)
					Throw New Exception(String.Format("{0} is not an 'NTFS' volume.", _driveInfo.Name))
				End If
				_elapsedTime = Date.Now.Subtract(start)
			End Sub

			#End Region

			#Region "public methods"

			''' <summary>
			''' CreateUsnJournal() creates a usn journal on the volume. If a journal already exists this function
			''' will adjust the MaximumSize and AllocationDelta parameters of the journal if the requested size
			''' is larger.
			''' </summary>
			''' <param name="maxSize">maximum size requested for the UsnJournal</param>
			''' <param name="allocationDelta">when space runs out, the amount of additional
			''' space to allocate</param>
			''' <param name="elapsedTime">The TimeSpan object indicating how much time this function
			''' took</param>
			''' <returns>a UsnJournalReturnCode
			''' USN_JOURNAL_SUCCESS                 CreateUsnJournal() function succeeded.
			''' VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			''' INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			''' USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
			''' ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			''' ERROR_INVALID_FUNCTION              error generated by DeviceIoControl() call.
			''' ERROR_FILE_NOT_FOUND                error generated by DeviceIoControl() call.
			''' ERROR_PATH_NOT_FOUND                error generated by DeviceIoControl() call.
			''' ERROR_TOO_MANY_OPEN_FILES           error generated by DeviceIoControl() call.
			''' ERROR_INVALID_HANDLE                error generated by DeviceIoControl() call.
			''' ERROR_INVALID_DATA                  error generated by DeviceIoControl() call.
			''' ERROR_NOT_SUPPORTED                 error generated by DeviceIoControl() call.
			''' ERROR_INVALID_PARAMETER             error generated by DeviceIoControl() call.
			''' ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			''' ERROR_INVALID_USER_BUFFER           error generated by DeviceIoControl() call.
			''' USN_JOURNAL_ERROR                   unspecified usn journal error.
			''' </returns>
			''' <remarks>
			''' If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			''' </remarks>
			Public Function CreateUsnJournal(ByVal maxSize As ULong, ByVal allocationDelta As ULong) As UsnJournalReturnCode
				Dim usnRtnCode As UsnJournalReturnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS
				Dim startTime As Date = Date.Now

				If bNtfsVolume Then
					If _usnJournalRootHandle.ToInt32() <> INVALID_HANDLE_VALUE Then
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS
						Dim cb As UInt32

						Dim cujd As New Win32Api.CREATE_USN_JOURNAL_DATA()
						cujd.MaximumSize = maxSize
						cujd.AllocationDelta = allocationDelta

						Dim sizeCujd As Integer = Marshal.SizeOf(cujd)
						Dim cujdBuffer As IntPtr = Marshal.AllocHGlobal(sizeCujd)
						Win32Api.ZeroMemory(cujdBuffer, sizeCujd)
						Marshal.StructureToPtr(cujd, cujdBuffer, True)

						Dim fOk As Boolean = Win32Api.DeviceIoControl(_usnJournalRootHandle, Win32Api.FSCTL_CREATE_USN_JOURNAL, cujdBuffer, sizeCujd, IntPtr.Zero, 0, cb, IntPtr.Zero)
						If Not fOk Then
							usnRtnCode = ConvertWin32ErrorToUsnError(CType(Marshal.GetLastWin32Error(), Win32Api.GetLastErrorEnum))
						End If
						Marshal.FreeHGlobal(cujdBuffer)
					Else
						usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE
					End If
				End If

				_elapsedTime = Date.Now.Subtract(startTime)
				Return usnRtnCode
			End Function

			''' <summary>
			''' DeleteUsnJournal() deletes a usn journal on the volume. If no usn journal exists, this
			''' function simply returns success.
			''' </summary>
			''' <param name="journalState">USN_JOURNAL_DATA object for this volume</param>
			''' <param name="elapsedTime">The TimeSpan object indicating how much time this function
			''' took</param>
			''' <returns>a UsnJournalReturnCode
			''' USN_JOURNAL_SUCCESS                 DeleteUsnJournal() function succeeded.
			''' VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			''' INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			''' USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
		''' ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			''' ERROR_INVALID_FUNCTION              error generated by DeviceIoControl() call.
			''' ERROR_FILE_NOT_FOUND                error generated by DeviceIoControl() call.
			''' ERROR_PATH_NOT_FOUND                error generated by DeviceIoControl() call.
			''' ERROR_TOO_MANY_OPEN_FILES           error generated by DeviceIoControl() call.
			''' ERROR_INVALID_HANDLE                error generated by DeviceIoControl() call.
			''' ERROR_INVALID_DATA                  error generated by DeviceIoControl() call.
			''' ERROR_NOT_SUPPORTED                 error generated by DeviceIoControl() call.
			''' ERROR_INVALID_PARAMETER             error generated by DeviceIoControl() call.
			''' ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			''' ERROR_INVALID_USER_BUFFER           error generated by DeviceIoControl() call.
			''' USN_JOURNAL_ERROR                   unspecified usn journal error.
			''' </returns>
			''' <remarks>
			''' If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			''' </remarks>
			Public Function DeleteUsnJournal(ByVal journalState As Win32Api.USN_JOURNAL_DATA) As UsnJournalReturnCode
				Dim usnRtnCode As UsnJournalReturnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS
				Dim startTime As Date = Date.Now

				If bNtfsVolume Then
					If _usnJournalRootHandle.ToInt32() <> Win32Api.INVALID_HANDLE_VALUE Then
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS
						Dim cb As UInt32

						Dim dujd As New Win32Api.DELETE_USN_JOURNAL_DATA()
						dujd.UsnJournalID = journalState.UsnJournalID
						dujd.DeleteFlags = CUInt(Win32Api.UsnJournalDeleteFlags.USN_DELETE_FLAG_DELETE)

						Dim sizeDujd As Integer = Marshal.SizeOf(dujd)
						Dim dujdBuffer As IntPtr = Marshal.AllocHGlobal(sizeDujd)
						Win32Api.ZeroMemory(dujdBuffer, sizeDujd)
						Marshal.StructureToPtr(dujd, dujdBuffer, True)

						Dim fOk As Boolean = Win32Api.DeviceIoControl(_usnJournalRootHandle, Win32Api.FSCTL_DELETE_USN_JOURNAL, dujdBuffer, sizeDujd, IntPtr.Zero, 0, cb, IntPtr.Zero)

						If Not fOk Then
							usnRtnCode = ConvertWin32ErrorToUsnError(CType(Marshal.GetLastWin32Error(), Win32Api.GetLastErrorEnum))
						End If
						Marshal.FreeHGlobal(dujdBuffer)
					Else
						usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE
					End If
				End If

				_elapsedTime = Date.Now.Subtract(startTime)
				Return usnRtnCode
			End Function

			''' <summary>
			''' GetNtfsVolumeFolders() reads the Master File Table to find all of the folders on a volume
			''' and returns them in a SortedList<UInt64, Win32Api.UsnEntry> folders out parameter.
			''' </summary>
			''' <param name="folders">A SortedList<string, UInt64> list where string is
			''' the filename and UInt64 is the parent folder's file reference number
			''' </param>
			''' <param name="elapsedTime">A TimeSpan object that on return holds the elapsed time
			''' </param>
			''' <returns>
			''' USN_JOURNAL_SUCCESS                 GetNtfsVolumeFolders() function succeeded.
			''' VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			''' INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			''' USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
			''' ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			''' ERROR_INVALID_FUNCTION              error generated by DeviceIoControl() call.
			''' ERROR_FILE_NOT_FOUND                error generated by DeviceIoControl() call.
			''' ERROR_PATH_NOT_FOUND                error generated by DeviceIoControl() call.
			''' ERROR_TOO_MANY_OPEN_FILES           error generated by DeviceIoControl() call.
			''' ERROR_INVALID_HANDLE                error generated by DeviceIoControl() call.
			''' ERROR_INVALID_DATA                  error generated by DeviceIoControl() call.
			''' ERROR_NOT_SUPPORTED                 error generated by DeviceIoControl() call.
			''' ERROR_INVALID_PARAMETER             error generated by DeviceIoControl() call.
			''' ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			''' ERROR_INVALID_USER_BUFFER           error generated by DeviceIoControl() call.
			''' USN_JOURNAL_ERROR                   unspecified usn journal error.
			''' </returns>
			''' <remarks>
			''' If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			''' </remarks>
			Public Function GetNtfsVolumeFolders(<System.Runtime.InteropServices.Out()> ByRef folders As List(Of Win32Api.UsnEntry)) As UsnJournalReturnCode
				Dim startTime As Date = Date.Now
				folders = New List(Of Win32Api.UsnEntry)()
				Dim usnRtnCode As UsnJournalReturnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS

				If bNtfsVolume Then
					If _usnJournalRootHandle.ToInt32() <> Win32Api.INVALID_HANDLE_VALUE Then
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS

						Dim usnState As New Win32Api.USN_JOURNAL_DATA()
						usnRtnCode = QueryUsnJournal(usnState)

						If usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS Then
							'
							' set up MFT_ENUM_DATA structure
							'
							Dim med As Win32Api.MFT_ENUM_DATA
							med.StartFileReferenceNumber = 0
							med.LowUsn = 0
							med.HighUsn = usnState.NextUsn
							Dim sizeMftEnumData As Int32 = Marshal.SizeOf(med)
							Dim medBuffer As IntPtr = Marshal.AllocHGlobal(sizeMftEnumData)
							Win32Api.ZeroMemory(medBuffer, sizeMftEnumData)
							Marshal.StructureToPtr(med, medBuffer, True)

							'
							' set up the data buffer which receives the USN_RECORD data
							'
							Dim pDataSize As Integer = Len(New UInt64) + 10000
							Dim pData As IntPtr = Marshal.AllocHGlobal(pDataSize)
							Win32Api.ZeroMemory(pData, pDataSize)
							Dim outBytesReturned As UInteger = 0
							Dim usnEntry As Win32Api.UsnEntry = Nothing

							'
							' Gather up volume's directories
							'
							Do While False <> Win32Api.DeviceIoControl(_usnJournalRootHandle, Win32Api.FSCTL_ENUM_USN_DATA, medBuffer, sizeMftEnumData, pData, pDataSize, outBytesReturned, IntPtr.Zero)
								Dim pUsnRecord As New IntPtr(pData.ToInt32() + Len(New Int64))
								Do While outBytesReturned > 60
									usnEntry = New Win32Api.UsnEntry(pUsnRecord)
									'
									' check for directory entries
									'
									If usnEntry.IsFolder Then
										folders.Add(usnEntry)
									End If
									pUsnRecord = New IntPtr(pUsnRecord.ToInt32() + usnEntry.RecordLength)
									outBytesReturned -= usnEntry.RecordLength
								Loop
								Marshal.WriteInt64(medBuffer, Marshal.ReadInt64(pData, 0))
							Loop

							Marshal.FreeHGlobal(pData)
							usnRtnCode = ConvertWin32ErrorToUsnError(CType(Marshal.GetLastWin32Error(), Win32Api.GetLastErrorEnum))
							If usnRtnCode = UsnJournalReturnCode.ERROR_HANDLE_EOF Then
								usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS
							End If
						End If
					Else
						usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE
					End If
				End If

				_elapsedTime = Date.Now.Subtract(startTime)
				Return usnRtnCode
			End Function

			''' <summary>
			''' Given a file reference number GetPathFromFrn() calculates the full path in the out parameter 'path'.
			''' </summary>
			''' <param name="frn">A 64-bit file reference number</param>
			''' <returns>
			''' USN_JOURNAL_SUCCESS                 GetPathFromFrn() function succeeded.
			''' VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			''' INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			''' ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			''' INVALID_FILE_REFERENCE_NUMBER       file reference number not found in Master File Table.
			''' ERROR_INVALID_FUNCTION              error generated by NtCreateFile() or NtQueryInformationFile() call.
			''' ERROR_FILE_NOT_FOUND                error generated by NtCreateFile() or NtQueryInformationFile() call.
			''' ERROR_PATH_NOT_FOUND                error generated by NtCreateFile() or NtQueryInformationFile() call.
			''' ERROR_TOO_MANY_OPEN_FILES           error generated by NtCreateFile() or NtQueryInformationFile() call.
			''' ERROR_INVALID_HANDLE                error generated by NtCreateFile() or NtQueryInformationFile() call.
			''' ERROR_INVALID_DATA                  error generated by NtCreateFile() or NtQueryInformationFile() call.
			''' ERROR_NOT_SUPPORTED                 error generated by NtCreateFile() or NtQueryInformationFile() call.
			''' ERROR_INVALID_PARAMETER             error generated by NtCreateFile() or NtQueryInformationFile() call.
			''' ERROR_INVALID_USER_BUFFER           error generated by NtCreateFile() or NtQueryInformationFile() call.
			''' USN_JOURNAL_ERROR                   unspecified usn journal error.
			''' </returns>
			''' <remarks>
			''' If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			''' </remarks>

			Public Function GetPathFromFileReference(ByVal frn As UInt64, <System.Runtime.InteropServices.Out()> ByRef path As String) As UsnJournalReturnCode
				Dim startTime As Date = Date.Now
				path = "Unavailable"
				Dim usnRtnCode As UsnJournalReturnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS

				If bNtfsVolume Then
					If _usnJournalRootHandle.ToInt32() <> Win32Api.INVALID_HANDLE_VALUE Then
						If frn <> 0 Then
							usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS

							Dim allocSize As Long = 0
							Dim unicodeString As Win32Api.UNICODE_STRING
							Dim objAttributes As New Win32Api.OBJECT_ATTRIBUTES()
							Dim ioStatusBlock As New Win32Api.IO_STATUS_BLOCK()
							Dim hFile As IntPtr = IntPtr.Zero

							Dim buffer As IntPtr = Marshal.AllocHGlobal(4096)
							Dim refPtr As IntPtr = Marshal.AllocHGlobal(8)
							Dim objAttIntPtr As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(objAttributes))

							'
							' pointer >> fileid
							'
							Marshal.WriteInt64(refPtr, CLng(frn))

							unicodeString.Length = 8
							unicodeString.MaximumLength = 8
							unicodeString.Buffer = refPtr
							'
							' copy unicode structure to pointer
							'
							Marshal.StructureToPtr(unicodeString, objAttIntPtr, True)

							'
							'  InitializeObjectAttributes
							'
							objAttributes.Length = Marshal.SizeOf(objAttributes)
							objAttributes.ObjectName = objAttIntPtr
							objAttributes.RootDirectory = _usnJournalRootHandle
							objAttributes.Attributes = CInt(Win32Api.OBJ_CASE_INSENSITIVE)

							Dim fOk As Integer = Win32Api.NtCreateFile(hFile, FileAccess.Read, objAttributes, ioStatusBlock, allocSize, 0, FileShare.ReadWrite, Win32Api.FILE_OPEN, Win32Api.FILE_OPEN_BY_FILE_ID Or Win32Api.FILE_OPEN_FOR_BACKUP_INTENT, IntPtr.Zero, 0)
							If fOk = 0 Then
								fOk = Win32Api.NtQueryInformationFile(hFile, ioStatusBlock, buffer, 4096, Win32Api.FILE_INFORMATION_CLASS.FileNameInformation)
								If fOk = 0 Then
									'
									' first 4 bytes are the name length
									'
									Dim nameLength As Integer = Marshal.ReadInt32(buffer, 0)
									'
									' next bytes are the name
									'
									path = Marshal.PtrToStringUni(New IntPtr(buffer.ToInt32() + 4), nameLength \ 2)
								End If
							End If
							Win32Api.CloseHandle(hFile)
							Marshal.FreeHGlobal(buffer)
							Marshal.FreeHGlobal(objAttIntPtr)
							Marshal.FreeHGlobal(refPtr)
						End If
					End If
				End If
				_elapsedTime = Date.Now.Subtract(startTime)
				Return usnRtnCode
			End Function

			''' <summary>
			''' GetUsnJournalState() gets the current state of the USN Journal if it is active.
			''' </summary>
			''' <param name="usnJournalState">
			''' Reference to usn journal data object filled with the current USN Journal state.
			''' </param>
			''' <param name="elapsedTime">The elapsed time for the GetUsnJournalState() function call.</param>
			''' <returns>
			''' USN_JOURNAL_SUCCESS                 GetUsnJournalState() function succeeded.
			''' VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			''' INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			''' USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
			''' ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			''' ERROR_INVALID_FUNCTION              error generated by DeviceIoControl() call.
			''' ERROR_FILE_NOT_FOUND                error generated by DeviceIoControl() call.
			''' ERROR_PATH_NOT_FOUND                error generated by DeviceIoControl() call.
			''' ERROR_TOO_MANY_OPEN_FILES           error generated by DeviceIoControl() call.
			''' ERROR_INVALID_HANDLE                error generated by DeviceIoControl() call.
			''' ERROR_INVALID_DATA                  error generated by DeviceIoControl() call.
			''' ERROR_NOT_SUPPORTED                 error generated by DeviceIoControl() call.
			''' ERROR_INVALID_PARAMETER             error generated by DeviceIoControl() call.
			''' ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			''' ERROR_INVALID_USER_BUFFER           error generated by DeviceIoControl() call.
			''' USN_JOURNAL_ERROR                   unspecified usn journal error.
			''' </returns>
			''' <remarks>
			''' If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			''' </remarks>
			Public Function GetUsnJournalState(ByRef usnJournalState As Win32Api.USN_JOURNAL_DATA) As UsnJournalReturnCode
				Dim usnRtnCode As UsnJournalReturnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS
				Dim startTime As Date = Date.Now

				If bNtfsVolume Then
					If _usnJournalRootHandle.ToInt32() <> Win32Api.INVALID_HANDLE_VALUE Then
						usnRtnCode = QueryUsnJournal(usnJournalState)
					Else
						usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE
					End If
				End If

				_elapsedTime = Date.Now.Subtract(startTime)
				Return usnRtnCode
			End Function

			''' <summary>
			''' Given a previous state, GetUsnJournalEntries() determines if the USN Journal is active and
			''' no USN Journal entries have been lost (i.e. USN Journal is valid), then
			''' it loads a SortedList<UInt64, Win32Api.UsnEntry> list and returns it as the out parameter 'usnEntries'.
			''' If GetUsnJournalChanges returns anything but USN_JOURNAL_SUCCESS, the usnEntries list will
			''' be empty.
			''' </summary>
			''' <param name="previousUsnState">The USN Journal state the last time volume
			''' changes were requested.</param>
			''' <param name="newFiles">List of the filenames of all new files.</param>
			''' <param name="changedFiles">List of the filenames of all changed files.</param>
			''' <param name="newFolders">List of the names of all new folders.</param>
			''' <param name="changedFolders">List of the names of all changed folders.</param>
			''' <param name="deletedFiles">List of the names of all deleted files</param>
			''' <param name="deletedFolders">List of the names of all deleted folders</param>
			''' <param name="currentState">Current state of the USN Journal</param>
			''' <returns>
			''' USN_JOURNAL_SUCCESS                 GetUsnJournalChanges() function succeeded.
			''' VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			''' INVALID_HANDLE_VALUE                NtfsUsnJournal object failed initialization.
			''' USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
			''' ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights, see remarks.
			''' ERROR_INVALID_FUNCTION              error generated by DeviceIoControl() call.
			''' ERROR_FILE_NOT_FOUND                error generated by DeviceIoControl() call.
			''' ERROR_PATH_NOT_FOUND                error generated by DeviceIoControl() call.
			''' ERROR_TOO_MANY_OPEN_FILES           error generated by DeviceIoControl() call.
			''' ERROR_INVALID_HANDLE                error generated by DeviceIoControl() call.
			''' ERROR_INVALID_DATA                  error generated by DeviceIoControl() call.
			''' ERROR_NOT_SUPPORTED                 error generated by DeviceIoControl() call.
			''' ERROR_INVALID_PARAMETER             error generated by DeviceIoControl() call.
			''' ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			''' ERROR_INVALID_USER_BUFFER           error generated by DeviceIoControl() call.
			''' USN_JOURNAL_ERROR                   unspecified usn journal error.
			''' </returns>
			''' <remarks>
			''' If function returns ERROR_ACCESS_DENIED you need to run application as an Administrator.
			''' </remarks>
			Public Function GetUsnJournalEntries(ByVal previousUsnState As Win32Api.USN_JOURNAL_DATA, ByVal reasonMask As UInt32, <System.Runtime.InteropServices.Out()> ByRef usnEntries As List(Of Win32Api.UsnEntry), <System.Runtime.InteropServices.Out()> ByRef newUsnState As Win32Api.USN_JOURNAL_DATA) As UsnJournalReturnCode
				Dim startTime As Date = Date.Now
				usnEntries = New List(Of Win32Api.UsnEntry)()
				newUsnState = New Win32Api.USN_JOURNAL_DATA()
				Dim usnRtnCode As UsnJournalReturnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS

				If bNtfsVolume Then
					If _usnJournalRootHandle.ToInt32() <> Win32Api.INVALID_HANDLE_VALUE Then
						'
						' get current usn journal state
						'
						usnRtnCode = QueryUsnJournal(newUsnState)
						If usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS Then
							Dim bReadMore As Boolean = True
							'
							' sequentially process the usn journal looking for image file entries
							'
							Dim pbDataSize As Integer = Len(New UInt64) * &H4000
							Dim pbData As IntPtr = Marshal.AllocHGlobal(pbDataSize)
							Win32Api.ZeroMemory(pbData, pbDataSize)
							Dim outBytesReturned As UInteger = 0

							Dim rujd As New Win32Api.READ_USN_JOURNAL_DATA()
							rujd.StartUsn = previousUsnState.NextUsn
							rujd.ReasonMask = reasonMask
							rujd.ReturnOnlyOnClose = 0
							rujd.Timeout = 0
							rujd.bytesToWaitFor = 0
							rujd.UsnJournalId = previousUsnState.UsnJournalID
							Dim sizeRujd As Integer = Marshal.SizeOf(rujd)

							Dim rujdBuffer As IntPtr = Marshal.AllocHGlobal(sizeRujd)
							Win32Api.ZeroMemory(rujdBuffer, sizeRujd)
							Marshal.StructureToPtr(rujd, rujdBuffer, True)

							Dim usnEntry As Win32Api.UsnEntry = Nothing

							'
							' read usn journal entries
							'
							Do While bReadMore
								Dim bRtn As Boolean = Win32Api.DeviceIoControl(_usnJournalRootHandle, Win32Api.FSCTL_READ_USN_JOURNAL, rujdBuffer, sizeRujd, pbData, pbDataSize, outBytesReturned, IntPtr.Zero)
								If bRtn Then
									Dim pUsnRecord As New IntPtr(pbData.ToInt32() + Len(New UInt64))
									Do While outBytesReturned > 60 ' while there are at least one entry in the usn journal
										usnEntry = New Win32Api.UsnEntry(pUsnRecord)
										If usnEntry.USN >= newUsnState.NextUsn Then ' only read until the current usn points beyond the current state's usn
											bReadMore = False
											Exit Do
										End If
										usnEntries.Add(usnEntry)

										pUsnRecord = New IntPtr(pUsnRecord.ToInt32() + usnEntry.RecordLength)
										outBytesReturned -= usnEntry.RecordLength

									Loop ' end while (outBytesReturned > 60) - closing bracket
 ' if (bRtn)- closing bracket
								Else
									Dim lastWin32Error As Win32Api.GetLastErrorEnum = CType(Marshal.GetLastWin32Error(), Win32Api.GetLastErrorEnum)
									If lastWin32Error = Win32Api.GetLastErrorEnum.ERROR_HANDLE_EOF Then
										usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS
									Else
										usnRtnCode = ConvertWin32ErrorToUsnError(lastWin32Error)
									End If
									Exit Do
								End If

								Dim nextUsn As Int64 = Marshal.ReadInt64(pbData, 0)
								If nextUsn >= newUsnState.NextUsn Then
									Exit Do
								End If
								Marshal.WriteInt64(rujdBuffer, nextUsn)

							Loop ' end while (bReadMore) - closing bracket

							Marshal.FreeHGlobal(rujdBuffer)
							Marshal.FreeHGlobal(pbData)

						End If ' if (usnRtnCode == UsnJournalReturnCode.USN_JOURNAL_SUCCESS) - closing bracket
 ' if (_usnJournalRootHandle.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
					Else
						usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE
					End If
				End If ' if (bNtfsVolume) - closing bracket

				_elapsedTime = Date.Now.Subtract(startTime)
				Return usnRtnCode
			End Function ' GetUsnJournalChanges() - closing bracket

			''' <summary>
			''' tests to see if the USN Journal is active on the volume.
			''' </summary>
			''' <returns>true if USN Journal is active
			''' false if no USN Journal on volume</returns>
			Public Function IsUsnJournalActive() As Boolean
				Dim start As Date = Date.Now
				Dim bRtnCode As Boolean = False

				If bNtfsVolume Then
					If _usnJournalRootHandle.ToInt32() <> Win32Api.INVALID_HANDLE_VALUE Then
						Dim usnJournalCurrentState As New Win32Api.USN_JOURNAL_DATA()
						Dim usnError As UsnJournalReturnCode = QueryUsnJournal(usnJournalCurrentState)
						If usnError = UsnJournalReturnCode.USN_JOURNAL_SUCCESS Then
							bRtnCode = True
						End If
					End If
				End If
				_elapsedTime = Date.Now.Subtract(start)
				Return bRtnCode
			End Function

			''' <summary>
			''' tests to see if there is a USN Journal on this volume and if there is
			''' determines whether any journal entries have been lost.
			''' </summary>
			''' <returns>true if the USN Journal is active and if the JournalId's are the same
			''' and if all the usn journal entries expected by the previous state are available
			''' from the current state.
			''' false if not</returns>
			Public Function IsUsnJournalValid(ByVal usnJournalPreviousState As Win32Api.USN_JOURNAL_DATA) As Boolean
				Dim start As Date = Date.Now
				Dim bRtnCode As Boolean = False

				If bNtfsVolume Then
					If _usnJournalRootHandle.ToInt32() <> Win32Api.INVALID_HANDLE_VALUE Then
						Dim usnJournalState As New Win32Api.USN_JOURNAL_DATA()
						Dim usnError As UsnJournalReturnCode = QueryUsnJournal(usnJournalState)

						If usnError = UsnJournalReturnCode.USN_JOURNAL_SUCCESS Then
							If usnJournalPreviousState.UsnJournalID = usnJournalState.UsnJournalID Then
								If usnJournalPreviousState.NextUsn >= usnJournalState.NextUsn Then
									bRtnCode = True
								End If
							End If
						End If
					End If
				End If
				_elapsedTime = Date.Now.Subtract(start)
				Return bRtnCode
			End Function

			#End Region

			#Region "private member functions"
			''' <summary>
			''' Converts a Win32 Error to a UsnJournalReturnCode
			''' </summary>
			''' <param name="Win32LastError">The 'last' Win32 error.</param>
			''' <returns>
			''' INVALID_HANDLE_VALUE                error generated by Win32 Api calls.
			''' USN_JOURNAL_SUCCESS                 usn journal function succeeded.
			''' ERROR_INVALID_FUNCTION              error generated by Win32 Api calls.
			''' ERROR_FILE_NOT_FOUND                error generated by Win32 Api calls.
			''' ERROR_PATH_NOT_FOUND                error generated by Win32 Api calls.
			''' ERROR_TOO_MANY_OPEN_FILES           error generated by Win32 Api calls.
			''' ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights.
			''' ERROR_INVALID_HANDLE                error generated by Win32 Api calls.
		''' ERROR_INVALID_DATA                  error generated by Win32 Api calls.
			''' ERROR_HANDLE_EOF                    error generated by Win32 Api calls.
			''' ERROR_NOT_SUPPORTED                 error generated by Win32 Api calls.
			''' ERROR_INVALID_PARAMETER             error generated by Win32 Api calls.
			''' ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
			''' ERROR_JOURNAL_ENTRY_DELETED         usn journal entry lost, no longer available.
			''' ERROR_INVALID_USER_BUFFER           error generated by Win32 Api calls.
			''' USN_JOURNAL_INVALID                 usn journal is invalid, id's don't match or required entries lost.
			''' USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
			''' VOLUME_NOT_NTFS                     volume is not an NTFS volume.
			''' INVALID_FILE_REFERENCE_NUMBER       bad file reference number - see remarks.
			''' USN_JOURNAL_ERROR                   unspecified usn journal error.
			''' </returns>
			Private Function ConvertWin32ErrorToUsnError(ByVal Win32LastError As Win32Api.GetLastErrorEnum) As UsnJournalReturnCode
			   Dim usnRtnCode As UsnJournalReturnCode

			   Select Case Win32LastError
					Case Win32Api.GetLastErrorEnum.ERROR_JOURNAL_NOT_ACTIVE
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_NOT_ACTIVE
					Case Win32Api.GetLastErrorEnum.ERROR_SUCCESS
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS
				   Case Win32Api.GetLastErrorEnum.ERROR_HANDLE_EOF
						usnRtnCode = UsnJournalReturnCode.ERROR_HANDLE_EOF
					Case Else
						usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_ERROR
			   End Select

			   Return usnRtnCode
			End Function

			''' <summary>
			''' Gets a Volume Serial Number for the volume represented by driveInfo.
			''' </summary>
			''' <param name="driveInfo">DriveInfo object representing the volume in question.</param>
			''' <param name="volumeSerialNumber">out parameter to hold the volume serial number.</param>
			''' <returns></returns>
			Private Function GetVolumeSerialNumber(ByVal driveInfo As DriveInfo, ByRef volumeSerialNumber As UInteger) As UsnJournalReturnCode
				Console.WriteLine("GetVolumeSerialNumber() function entered for drive '{0}'", driveInfo.Name)

				volumeSerialNumber = 0
				Dim usnRtnCode As UsnJournalReturnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS
				Dim pathRoot As String = String.Concat("\\.\", driveInfo.Name)

				Dim hRoot As IntPtr = Win32Api.CreateFile(pathRoot, 0, Win32Api.FILE_SHARE_READ Or Win32Api.FILE_SHARE_WRITE, IntPtr.Zero, Win32Api.OPEN_EXISTING, Win32Api.FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero)

				If hRoot.ToInt32() <> Win32Api.INVALID_HANDLE_VALUE Then
					Dim fi As New Win32Api.BY_HANDLE_FILE_INFORMATION()
					Dim bRtn As Boolean = Win32Api.GetFileInformationByHandle(hRoot, fi)

					If bRtn Then
						Dim fileIndexHigh As UInt64 = CULng(fi.FileIndexHigh)
						Dim indexRoot As UInt64 = (fileIndexHigh << 32) Or fi.FileIndexLow
						volumeSerialNumber = fi.VolumeSerialNumber
					Else
						usnRtnCode = CType(Marshal.GetLastWin32Error(), UsnJournalReturnCode)
					End If

					Win32Api.CloseHandle(hRoot)
				Else
					usnRtnCode = CType(Marshal.GetLastWin32Error(), UsnJournalReturnCode)
				End If

				Return usnRtnCode
			End Function

			Private Function GetRootHandle(ByRef rootHandle As IntPtr) As UsnJournalReturnCode
				'
				' private functions don't need to check for an NTFS volume or
				' a valid _usnJournalRootHandle handle
				'
				Dim usnRtnCode As UsnJournalReturnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS
				rootHandle = IntPtr.Zero
				Dim vol As String = String.Concat("\\.\", _driveInfo.Name.TrimEnd("\"c))

				rootHandle = Win32Api.CreateFile(vol, Win32Api.GENERIC_READ Or Win32Api.GENERIC_WRITE, Win32Api.FILE_SHARE_READ Or Win32Api.FILE_SHARE_WRITE, IntPtr.Zero, Win32Api.OPEN_EXISTING, 0, IntPtr.Zero)

				If rootHandle.ToInt32() = Win32Api.INVALID_HANDLE_VALUE Then
					usnRtnCode = CType(Marshal.GetLastWin32Error(), UsnJournalReturnCode)
				End If


				Return usnRtnCode
			End Function
			''' <summary>
			''' This function queries the usn journal on the volume.
			''' </summary>
			''' <param name="usnJournalState">the USN_JOURNAL_DATA object that is associated with this volume</param>
			''' <returns></returns>
			Private Function QueryUsnJournal(ByRef usnJournalState As Win32Api.USN_JOURNAL_DATA) As UsnJournalReturnCode
				'
				' private functions don't need to check for an NTFS volume or
				' a valid _usnJournalRootHandle handle
				'
				Dim usnReturnCode As UsnJournalReturnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS
				Dim sizeUsnJournalState As Integer = Marshal.SizeOf(usnJournalState)
				Dim cb As UInt32

				Dim fOk As Boolean = Win32Api.DeviceIoControl(_usnJournalRootHandle, Win32Api.FSCTL_QUERY_USN_JOURNAL, IntPtr.Zero, 0, usnJournalState, sizeUsnJournalState, cb, IntPtr.Zero)

				If Not fOk Then
					Dim lastWin32Error As Integer = Marshal.GetLastWin32Error()
					usnReturnCode = ConvertWin32ErrorToUsnError(CType(Marshal.GetLastWin32Error(), Win32Api.GetLastErrorEnum))
				End If

			Return usnReturnCode
			End Function

			#End Region

			#Region "IDisposable Members"

			Public Sub Dispose() Implements IDisposable.Dispose
				Win32Api.CloseHandle(_usnJournalRootHandle)
			End Sub

			#End Region
		End Class

		Public Class Win32Api
			#Region "enums"
			Public Enum GetLastErrorEnum
				INVALID_HANDLE_VALUE = -1
				ERROR_SUCCESS = 0
				ERROR_INVALID_FUNCTION = 1
				ERROR_FILE_NOT_FOUND = 2
				ERROR_PATH_NOT_FOUND = 3
				ERROR_TOO_MANY_OPEN_FILES = 4
				ERROR_ACCESS_DENIED = 5
				ERROR_INVALID_HANDLE = 6
				ERROR_INVALID_DATA = 13
				ERROR_HANDLE_EOF = 38
				ERROR_NOT_SUPPORTED = 50
				ERROR_INVALID_PARAMETER = 87
				ERROR_JOURNAL_DELETE_IN_PROGRESS = 1178
				ERROR_JOURNAL_NOT_ACTIVE = 1179
				ERROR_JOURNAL_ENTRY_DELETED = 1181
				ERROR_INVALID_USER_BUFFER = 1784
			End Enum

			Public Enum UsnJournalDeleteFlags
				USN_DELETE_FLAG_DELETE = 1
				USN_DELETE_FLAG_NOTIFY = 2
			End Enum

			Public Enum FILE_INFORMATION_CLASS
				FileDirectoryInformation = 1 ' 1
				FileFullDirectoryInformation = 2 ' 2
				FileBothDirectoryInformation = 3 ' 3
				FileBasicInformation = 4 ' 4
				FileStandardInformation = 5 ' 5
				FileInternalInformation = 6 ' 6
				FileEaInformation = 7 ' 7
				FileAccessInformation = 8 ' 8
				FileNameInformation = 9 ' 9
				FileRenameInformation = 10 ' 10
				FileLinkInformation = 11 ' 11
				FileNamesInformation = 12 ' 12
				FileDispositionInformation = 13 ' 13
				FilePositionInformation = 14 ' 14
				FileFullEaInformation = 15 ' 15
				FileModeInformation = 16 ' 16
				FileAlignmentInformation = 17 ' 17
				FileAllInformation = 18 ' 18
				FileAllocationInformation = 19 ' 19
				FileEndOfFileInformation = 20 ' 20
				FileAlternateNameInformation = 21 ' 21
				FileStreamInformation = 22 ' 22
				FilePipeInformation = 23 ' 23
				FilePipeLocalInformation = 24 ' 24
				FilePipeRemoteInformation = 25 ' 25
				FileMailslotQueryInformation = 26 ' 26
				FileMailslotSetInformation = 27 ' 27
				FileCompressionInformation = 28 ' 28
				FileObjectIdInformation = 29 ' 29
				FileCompletionInformation = 30 ' 30
				FileMoveClusterInformation = 31 ' 31
				FileQuotaInformation = 32 ' 32
				FileReparsePointInformation = 33 ' 33
				FileNetworkOpenInformation = 34 ' 34
				FileAttributeTagInformation = 35 ' 35
				FileTrackingInformation = 36 ' 36
				FileIdBothDirectoryInformation = 37 ' 37
				FileIdFullDirectoryInformation = 38 ' 38
				FileValidDataLengthInformation = 39 ' 39
				FileShortNameInformation = 40 ' 40
				FileHardLinkInformation = 46 ' 46
			End Enum

			#End Region

			#Region "constants"
			Public Const INVALID_HANDLE_VALUE As Int32 = -1

			Public Const GENERIC_READ As UInt32 = &H80000000L
			Public Const GENERIC_WRITE As UInt32 = &H40000000
			Public Const FILE_SHARE_READ As UInt32 = &H1
			Public Const FILE_SHARE_WRITE As UInt32 = &H2
			Public Const FILE_ATTRIBUTE_DIRECTORY As UInt32 = &H10

			Public Const CREATE_NEW As UInt32 = 1
			Public Const CREATE_ALWAYS As UInt32 = 2
			Public Const OPEN_EXISTING As UInt32 = 3
			Public Const OPEN_ALWAYS As UInt32 = 4
			Public Const TRUNCATE_EXISTING As UInt32 = 5

			Public Const FILE_ATTRIBUTE_NORMAL As UInt32 = &H80
			Public Const FILE_FLAG_BACKUP_SEMANTICS As UInt32 = &H2000000
			Public Const FileNameInformationClass As UInt32 = 9
			Public Const FILE_OPEN_FOR_BACKUP_INTENT As UInt32 = &H4000
			Public Const FILE_OPEN_BY_FILE_ID As UInt32 = &H2000
			Public Const FILE_OPEN As UInt32 = &H1
			Public Const OBJ_CASE_INSENSITIVE As UInt32 = &H40
			'public const OBJ_KERNEL_HANDLE = 0x200;

			' CTL_CODE( DeviceType, Function, Method, Access ) (((DeviceType) << 16) | ((Access) << 14) | ((Function) << 2) | (Method))
			Private Const FILE_DEVICE_FILE_SYSTEM As UInt32 = &H9
			Private Const METHOD_NEITHER As UInt32 = 3
			Private Const METHOD_BUFFERED As UInt32 = 0
			Private Const FILE_ANY_ACCESS As UInt32 = 0
			Private Const FILE_SPECIAL_ACCESS As UInt32 = 0
			Private Const FILE_READ_ACCESS As UInt32 = 1
			Private Const FILE_WRITE_ACCESS As UInt32 = 2

			Public Const USN_REASON_DATA_OVERWRITE As UInt32 = &H1
			Public Const USN_REASON_DATA_EXTEND As UInt32 = &H2
			Public Const USN_REASON_DATA_TRUNCATION As UInt32 = &H4
			Public Const USN_REASON_NAMED_DATA_OVERWRITE As UInt32 = &H10
			Public Const USN_REASON_NAMED_DATA_EXTEND As UInt32 = &H20
			Public Const USN_REASON_NAMED_DATA_TRUNCATION As UInt32 = &H40
			Public Const USN_REASON_FILE_CREATE As UInt32 = &H100
			Public Const USN_REASON_FILE_DELETE As UInt32 = &H200
			Public Const USN_REASON_EA_CHANGE As UInt32 = &H400
			Public Const USN_REASON_SECURITY_CHANGE As UInt32 = &H800
			Public Const USN_REASON_RENAME_OLD_NAME As UInt32 = &H1000
			Public Const USN_REASON_RENAME_NEW_NAME As UInt32 = &H2000
			Public Const USN_REASON_INDEXABLE_CHANGE As UInt32 = &H4000
			Public Const USN_REASON_BASIC_INFO_CHANGE As UInt32 = &H8000
			Public Const USN_REASON_HARD_LINK_CHANGE As UInt32 = &H10000
			Public Const USN_REASON_COMPRESSION_CHANGE As UInt32 = &H20000
			Public Const USN_REASON_ENCRYPTION_CHANGE As UInt32 = &H40000
			Public Const USN_REASON_OBJECT_ID_CHANGE As UInt32 = &H80000
			Public Const USN_REASON_REPARSE_POINT_CHANGE As UInt32 = &H100000
			Public Const USN_REASON_STREAM_CHANGE As UInt32 = &H200000
			Public Const USN_REASON_CLOSE As UInt32 = &H80000000L

			Public Shared GWL_EXSTYLE As Int32 = -20
			Public Shared WS_EX_LAYERED As Int32 = &H80000
			Public Shared WS_EX_TRANSPARENT As Int32 = &H20

			Public Const FSCTL_GET_OBJECT_ID As UInt32 = &H9009c

			' FSCTL_ENUM_USN_DATA = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 44,  METHOD_NEITHER, FILE_ANY_ACCESS)
			Public Const FSCTL_ENUM_USN_DATA As UInt32 = (FILE_DEVICE_FILE_SYSTEM << 16) Or (FILE_ANY_ACCESS << 14) Or (44 << 2) Or METHOD_NEITHER

			' FSCTL_READ_USN_JOURNAL = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 46,  METHOD_NEITHER, FILE_ANY_ACCESS)
			Public Const FSCTL_READ_USN_JOURNAL As UInt32 = (FILE_DEVICE_FILE_SYSTEM << 16) Or (FILE_ANY_ACCESS << 14) Or (46 << 2) Or METHOD_NEITHER

			'  FSCTL_CREATE_USN_JOURNAL        CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 57,  METHOD_NEITHER, FILE_ANY_ACCESS)
			Public Const FSCTL_CREATE_USN_JOURNAL As UInt32 = (FILE_DEVICE_FILE_SYSTEM << 16) Or (FILE_ANY_ACCESS << 14) Or (57 << 2) Or METHOD_NEITHER

			'  FSCTL_QUERY_USN_JOURNAL         CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 61, METHOD_BUFFERED, FILE_ANY_ACCESS)
			Public Const FSCTL_QUERY_USN_JOURNAL As UInt32 = (FILE_DEVICE_FILE_SYSTEM << 16) Or (FILE_ANY_ACCESS << 14) Or (61 << 2) Or METHOD_BUFFERED

			' FSCTL_DELETE_USN_JOURNAL        CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 62, METHOD_BUFFERED, FILE_ANY_ACCESS)
			Public Const FSCTL_DELETE_USN_JOURNAL As UInt32 = (FILE_DEVICE_FILE_SYSTEM << 16) Or (FILE_ANY_ACCESS << 14) Or (62 << 2) Or METHOD_BUFFERED

			#End Region

			#Region "dll imports"

			''' <summary>
			''' Creates the file specified by 'lpFileName' with desired access, share mode, security attributes,
			''' creation disposition, flags and attributes.
			''' </summary>
			''' <param name="lpFileName">Fully qualified path to a file</param>
			''' <param name="dwDesiredAccess">Requested access (write, read, read/write, none)</param>
			''' <param name="dwShareMode">Share mode (read, write, read/write, delete, all, none)</param>
			''' <param name="lpSecurityAttributes">IntPtr to a 'SECURITY_ATTRIBUTES' structure</param>
			''' <param name="dwCreationDisposition">Action to take on file or device specified by 'lpFileName' (CREATE_NEW,
			''' CREATE_ALWAYS, OPEN_ALWAYS, OPEN_EXISTING, TRUNCATE_EXISTING)</param>
			''' <param name="dwFlagsAndAttributes">File or device attributes and flags (typically FILE_ATTRIBUTE_NORMAL)</param>
			''' <param name="hTemplateFile">IntPtr to a valid handle to a template file with 'GENERIC_READ' access right</param>
			''' <returns>IntPtr handle to the 'lpFileName' file or device or 'INVALID_HANDLE_VALUE'</returns>
			<DllImport("kernel32.dll", SetLastError := True)> _
			Public Shared Function CreateFile(ByVal lpFileName As String, ByVal dwDesiredAccess As UInteger, ByVal dwShareMode As UInteger, ByVal lpSecurityAttributes As IntPtr, ByVal dwCreationDisposition As UInteger, ByVal dwFlagsAndAttributes As UInteger, ByVal hTemplateFile As IntPtr) As IntPtr
			End Function

			''' <summary>
			''' Closes the file specified by the IntPtr 'hObject'.
			''' </summary>
			''' <param name="hObject">IntPtr handle to a file</param>
			''' <returns>'true' if successful, otherwise 'false'</returns>
			<DllImport("kernel32.dll", SetLastError := True)> _
			Public Shared Function CloseHandle(ByVal hObject As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			''' <summary>
			''' Fills the 'BY_HANDLE_FILE_INFORMATION' structure for the file specified by 'hFile'.
			''' </summary>
			''' <param name="hFile">Fully qualified name of a file</param>
			''' <param name="lpFileInformation">Out BY_HANDLE_FILE_INFORMATION argument</param>
			''' <returns>'true' if successful, otherwise 'false'</returns>
			<DllImport("kernel32.dll", SetLastError := True)> _
			Public Shared Function GetFileInformationByHandle(ByVal hFile As IntPtr, <System.Runtime.InteropServices.Out()> ByRef lpFileInformation As BY_HANDLE_FILE_INFORMATION) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			''' <summary>
			''' Deletes the file specified by 'fileName'.
			''' </summary>
			''' <param name="fileName">Fully qualified path to the file to delete</param>
			''' <returns>'true' if successful, otherwise 'false'</returns>
			<DllImport("kernel32.dll", SetLastError := True)> _
			Public Shared Function DeleteFile(ByVal fileName As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			''' <summary>
			''' Read data from the file specified by 'hFile'.
			''' </summary>
			''' <param name="hFile">IntPtr handle to the file to read</param>
			''' <param name="lpBuffer">IntPtr to a buffer of bytes to receive the bytes read from 'hFile'</param>
			''' <param name="nNumberOfBytesToRead">Number of bytes to read from 'hFile'</param>
			''' <param name="lpNumberOfBytesRead">Number of bytes read from 'hFile'</param>
			''' <param name="lpOverlapped">IntPtr to an 'OVERLAPPED' structure</param>
			''' <returns>'true' if successful, otherwise 'false'</returns>
			<DllImport("kernel32.dll")> _
			Public Shared Function ReadFile(ByVal hFile As IntPtr, ByVal lpBuffer As IntPtr, ByVal nNumberOfBytesToRead As UInteger, <System.Runtime.InteropServices.Out()> ByRef lpNumberOfBytesRead As UInteger, ByVal lpOverlapped As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			''' <summary>
			''' Writes the 
			''' </summary>
			''' <param name="hFile">IntPtr handle to the file to write</param>
			''' <param name="bytes">IntPtr to a buffer of bytes to write to 'hFile'</param>
			''' <param name="nNumberOfBytesToWrite">Number of bytes in 'lpBuffer' to write to 'hFile'</param>
			''' <param name="lpNumberOfBytesWritten">Number of bytes written to 'hFile'</param>
			''' <param name="overlapped">IntPtr to an 'OVERLAPPED' structure</param>
			''' <returns>'true' if successful, otherwise 'false'</returns>
			<DllImport("kernel32.dll", SetLastError := True, CharSet := CharSet.Unicode)> _
			Public Shared Function WriteFile(ByVal hFile As IntPtr, ByVal bytes As IntPtr, ByVal nNumberOfBytesToWrite As UInteger, <System.Runtime.InteropServices.Out()> ByRef lpNumberOfBytesWritten As UInteger, ByVal overlapped As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			''' <summary>
			''' Writes the data in 'lpBuffer' to the file specified by 'hFile'.
			''' </summary>
			''' <param name="hFile">IntPtr handle to file to write</param>
			''' <param name="lpBuffer">Buffer of bytes to write to file 'hFile'</param>
			''' <param name="nNumberOfBytesToWrite">Number of bytes in 'lpBuffer' to write to 'hFile'</param>
			''' <param name="lpNumberOfBytesWritten">Number of bytes written to 'hFile'</param>
			''' <param name="overlapped">IntPtr to an 'OVERLAPPED' structure</param>
			''' <returns>'true' if successful, otherwise 'false'</returns>
			<DllImport("kernel32.dll", SetLastError := True, CharSet := CharSet.Unicode)> _
			Public Shared Function WriteFile(ByVal hFile As IntPtr, ByVal lpBuffer() As Byte, ByVal nNumberOfBytesToWrite As UInteger, <System.Runtime.InteropServices.Out()> ByRef lpNumberOfBytesWritten As UInteger, ByVal overlapped As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			''' <summary>
			''' Sends the 'dwIoControlCode' to the device specified by 'hDevice'.
			''' </summary>
			''' <param name="hDevice">IntPtr handle to the device to receive 'dwIoControlCode'</param>
			''' <param name="dwIoControlCode">Device IO Control Code to send</param>
			''' <param name="lpInBuffer">Input buffer if required</param>
			''' <param name="nInBufferSize">Size of input buffer</param>
			''' <param name="lpOutBuffer">Output buffer if required</param>
			''' <param name="nOutBufferSize">Size of output buffer</param>
			''' <param name="lpBytesReturned">Number of bytes returned in output buffer</param>
			''' <param name="lpOverlapped">IntPtr to an 'OVERLAPPED' structure</param>
			''' <returns>'true' if successful, otherwise 'false'</returns>
			<DllImport("kernel32.dll", ExactSpelling := True, SetLastError := True, CharSet := CharSet.Auto)> _
			Public Shared Function DeviceIoControl(ByVal hDevice As IntPtr, ByVal dwIoControlCode As UInt32, ByVal lpInBuffer As IntPtr, ByVal nInBufferSize As Int32, <System.Runtime.InteropServices.Out()> ByRef lpOutBuffer As USN_JOURNAL_DATA, ByVal nOutBufferSize As Int32, <System.Runtime.InteropServices.Out()> ByRef lpBytesReturned As UInteger, ByVal lpOverlapped As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			''' <summary>
			''' Sends the control code 'dwIoControlCode' to the device driver specified by 'hDevice'.
			''' </summary>
			''' <param name="hDevice">IntPtr handle to the device to receive 'dwIoControlCode</param>
			''' <param name="dwIoControlCode">Device IO Control Code to send</param>
			''' <param name="lpInBuffer">Input buffer if required</param>
			''' <param name="nInBufferSize">Size of input buffer </param>
			''' <param name="lpOutBuffer">Output buffer if required</param>
			''' <param name="nOutBufferSize">Size of output buffer</param>
			''' <param name="lpBytesReturned">Number of bytes returned</param>
			''' <param name="lpOverlapped">Pointer to an 'OVERLAPPED' struture</param>
			''' <returns></returns>
			<DllImport("kernel32.dll", ExactSpelling := True, SetLastError := True, CharSet := CharSet.Auto)> _
			Public Shared Function DeviceIoControl(ByVal hDevice As IntPtr, ByVal dwIoControlCode As UInt32, ByVal lpInBuffer As IntPtr, ByVal nInBufferSize As Int32, ByVal lpOutBuffer As IntPtr, ByVal nOutBufferSize As Int32, <System.Runtime.InteropServices.Out()> ByRef lpBytesReturned As UInteger, ByVal lpOverlapped As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			''' <summary>
			''' Sets the number of bytes specified by 'size' of the memory associated with the argument 'ptr' 
			''' to zero.
			''' </summary>
			''' <param name="ptr"></param>
			''' <param name="size"></param>
			<DllImport("kernel32.dll")> _
			Public Shared Sub ZeroMemory(ByVal ptr As IntPtr, ByVal size As Integer)
			End Sub

			''' <summary>
			''' Retrieves the cursor's position, in screen coordinates.
			''' </summary>
			''' <param name="pt">Pointer to a POINT structure that receives the screen coordinates of the cursor</param>
			''' <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
			<DllImport("user32.dll", CharSet := CharSet.Auto)> _
			Public Shared Function GetCursorPos(<System.Runtime.InteropServices.Out()> ByRef pt As POINT) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function

			''' <summary>
			''' retrieves information about the specified window. The function also retrieves the 32-bit (long) 
			''' value at the specified offset into the extra window memory.
			''' </summary>
			''' <param name="hWnd">Handle to the window and, indirectly, the class to which the window belongs</param>
			''' <param name="nIndex">the zero-based offset to the value to be retrieved</param>
			''' <returns>If the function succeeds, the return value is the requested 32-bit value.
			''' If the function fails, the return value is zero. To get extended error information, call GetLastError
			'''</returns>
			<DllImport("user32.dll", CharSet := CharSet.Auto)> _
			Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Int32) As Int32
			End Function

			''' <summary>
			''' changes an attribute of the specified window. The function also sets the 32-bit (long) value at 
			''' the specified offset into the extra window memory
			''' </summary>
			''' <param name="hWnd">Handle to the window and, indirectly, the class to which the window belongs</param>
			''' <param name="nIndex">the zero-based offset to the value to be set</param>
			''' <param name="newVal">the replacement value</param>
			''' <returns>If the function succeeds, the return value is the previous value of the specified 32-bit 
			''' integer. If the function fails, the return value is zero. To get extended error information, call GetLastError.
			''' </returns>
			<DllImport("user32.dll", CharSet := CharSet.Auto)> _
			Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Int32, ByVal newVal As Int32) As Int32
			End Function

			''' <summary>
			''' Creates a new file or directory, or opens an existing file, device, directory, or volume
			''' </summary>
			''' <param name="handle">A pointer to a variable that receives the file handle if the call is successful (out)</param>
			''' <param name="access">ACCESS_MASK value that expresses the type of access that the caller requires to the file or directory (in)</param>
			''' <param name="objectAttributes">A pointer to a structure already initialized with InitializeObjectAttributes (in)</param>
			''' <param name="ioStatus">A pointer to a variable that receives the final completion status and information about the requested operation (out)</param>
			''' <param name="allocSize">The initial allocation size in bytes for the file (in)(optional)</param>
			''' <param name="fileAttributes">file attributes (in)</param>
			''' <param name="share">type of share access that the caller would like to use in the file (in)</param>
			''' <param name="createDisposition">what to do, depending on whether the file already exists (in)</param>
			''' <param name="createOptions">options to be applied when creating or opening the file (in)</param>
			''' <param name="eaBuffer">Pointer to an EA buffer used to pass extended attributes (in)</param>
			''' <param name="eaLength">Length of the EA buffer</param>
			''' <returns>either STATUS_SUCCESS or an appropriate error status. If it returns an error status, the caller can find more information about the cause of the failure by checking the IoStatusBlock</returns>
			<DllImport("ntdll.dll", ExactSpelling := True, SetLastError := True)> _
			Public Shared Function NtCreateFile(ByRef handle As IntPtr, ByVal access As FileAccess, ByRef objectAttributes As OBJECT_ATTRIBUTES, ByRef ioStatus As IO_STATUS_BLOCK, ByRef allocSize As Long, ByVal fileAttributes As UInteger, ByVal share As FileShare, ByVal createDisposition As UInteger, ByVal createOptions As UInteger, ByVal eaBuffer As IntPtr, ByVal eaLength As UInteger) As Integer
			End Function

			''' <summary>
			''' 
			''' </summary>
			''' <param name="fileHandle"></param>
			''' <param name="IoStatusBlock"></param>
			''' <param name="pInfoBlock"></param>
			''' <param name="length"></param>
			''' <param name="fileInformation"></param>
			''' <returns></returns>
			<DllImport("ntdll.dll", ExactSpelling := True, SetLastError := True)> _
			Public Shared Function NtQueryInformationFile(ByVal fileHandle As IntPtr, ByRef IoStatusBlock As IO_STATUS_BLOCK, ByVal pInfoBlock As IntPtr, ByVal length As UInteger, ByVal fileInformation As FILE_INFORMATION_CLASS) As Integer
			End Function

			#End Region

			#Region "structures"

			''' <summary>
			''' By Handle File Information structure, contains File Attributes(32bits), Creation Time(FILETIME),
			''' Last Access Time(FILETIME), Last Write Time(FILETIME), Volume Serial Number(32bits),
			''' File Size High(32bits), File Size Low(32bits), Number of Links(32bits), File Index High(32bits),
			''' File Index Low(32bits).
			''' </summary>
			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure BY_HANDLE_FILE_INFORMATION
				Public FileAttributes As UInteger
				Public CreationTime As System.Runtime.InteropServices.ComTypes.FILETIME
				Public LastAccessTime As System.Runtime.InteropServices.ComTypes.FILETIME
				Public LastWriteTime As System.Runtime.InteropServices.ComTypes.FILETIME
				Public VolumeSerialNumber As UInteger
				Public FileSizeHigh As UInteger
				Public FileSizeLow As UInteger
				Public NumberOfLinks As UInteger
				Public FileIndexHigh As UInteger
				Public FileIndexLow As UInteger
			End Structure

			''' <summary>
			''' USN Journal Data structure, contains USN Journal ID(64bits), First USN(64bits), Next USN(64bits),
			''' Lowest Valid USN(64bits), Max USN(64bits), Maximum Size(64bits) and Allocation Delta(64bits).
			''' </summary>
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

			''' <summary>
			''' MFT Enum Data structure, contains Start File Reference Number(64bits), Low USN(64bits),
			''' High USN(64bits).
			''' </summary>
			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure MFT_ENUM_DATA
				Public StartFileReferenceNumber As UInt64
				Public LowUsn As Int64
				Public HighUsn As Int64
			End Structure

			''' <summary>
			''' Create USN Journal Data structure, contains Maximum Size(64bits) and Allocation Delta(64(bits).
			''' </summary>
			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure CREATE_USN_JOURNAL_DATA
				Public MaximumSize As UInt64
				Public AllocationDelta As UInt64
			End Structure

			''' <summary>
			''' Create USN Journal Data structure, contains Maximum Size(64bits) and Allocation Delta(64(bits).
			''' </summary>
			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure DELETE_USN_JOURNAL_DATA
				Public UsnJournalID As UInt64
				Public DeleteFlags As UInt32
				Public Reserved As UInt32
			End Structure

			''' <summary>
			''' Contains the USN Record Length(32bits), USN(64bits), File Reference Number(64bits), 
			''' Parent File Reference Number(64bits), Reason Code(32bits), File Attributes(32bits),
			''' File Name Length(32bits), the File Name Offset(32bits) and the File Name.
			''' </summary>
			Public Class UsnEntry
				Implements IComparable(Of UsnEntry)

				Private Const FR_OFFSET As Integer = 8
				Private Const PFR_OFFSET As Integer = 16
				Private Const USN_OFFSET As Integer = 24
				Private Const REASON_OFFSET As Integer = 40
				Public Const FA_OFFSET As Integer = 52
				Private Const FNL_OFFSET As Integer = 56
				Private Const FN_OFFSET As Integer = 58

				Private _recordLength As UInt32
				Public ReadOnly Property RecordLength() As UInt32
					Get
						Return _recordLength
					End Get
				End Property

				Private _usn As Int64
				Public ReadOnly Property USN() As Int64
					Get
						Return _usn
					End Get
				End Property

				Private _frn As UInt64
				Public ReadOnly Property FileReferenceNumber() As UInt64
					Get
						Return _frn
					End Get
				End Property

				Private _pfrn As UInt64
				Public ReadOnly Property ParentFileReferenceNumber() As UInt64
					Get
						Return _pfrn
					End Get
				End Property

				Private _reason As UInt32
				Public ReadOnly Property Reason() As UInt32
					Get
						Return _reason
					End Get
				End Property

				Private _name As String
				Public ReadOnly Property Name() As String
					Get
						Return _name
					End Get
				End Property

				Private _oldName As String
				Public Property OldName() As String
					Get
						If 0 <> (_fileAttributes And USN_REASON_RENAME_OLD_NAME) Then
							Return _oldName
						Else
							Return Nothing
						End If
					End Get
					Set(ByVal value As String)
						_oldName = value
					End Set
				End Property

				Private _fileAttributes As UInt32
				Public ReadOnly Property IsFolder() As Boolean
					Get
						Dim bRtn As Boolean = False
						If 0 <> (_fileAttributes And Win32Api.FILE_ATTRIBUTE_DIRECTORY) Then
							bRtn = True
						End If
						Return bRtn
					End Get
				End Property

				Public ReadOnly Property IsFile() As Boolean
					Get
						Dim bRtn As Boolean = False
						If 0 = (_fileAttributes And Win32Api.FILE_ATTRIBUTE_DIRECTORY) Then
							bRtn = True
						End If
						Return bRtn
					End Get
				End Property

				''' <summary>
				''' USN Record Constructor
				''' </summary>
				''' <param name="p">Buffer pointer to first byte of the USN Record</param>
				Public Sub New(ByVal ptrToUsnRecord As IntPtr)
					_recordLength = CUInt(Marshal.ReadInt32(ptrToUsnRecord))
					_frn = CULng(Marshal.ReadInt64(ptrToUsnRecord, FR_OFFSET))
					_pfrn = CULng(Marshal.ReadInt64(ptrToUsnRecord, PFR_OFFSET))
					_usn = CLng(Marshal.ReadInt64(ptrToUsnRecord, USN_OFFSET))
					_reason = CUInt(Marshal.ReadInt32(ptrToUsnRecord, REASON_OFFSET))
					_fileAttributes = CUInt(Marshal.ReadInt32(ptrToUsnRecord, FA_OFFSET))
					Dim fileNameLength As Short = Marshal.ReadInt16(ptrToUsnRecord, FNL_OFFSET)
					Dim fileNameOffset As Short = Marshal.ReadInt16(ptrToUsnRecord, FN_OFFSET)
					_name = Marshal.PtrToStringUni(New IntPtr(ptrToUsnRecord.ToInt32() + fileNameOffset), fileNameLength / Len(New Char))
				End Sub



				#Region "IComparable<UsnEntry> Members"

				Public Function CompareTo(ByVal other As UsnEntry) As Integer Implements IComparable(Of UsnEntry).CompareTo
					Return String.Compare(Me.Name, other.Name, True)
				End Function

				#End Region
			End Class

			''' <summary>
			''' Contains the Start USN(64bits), Reason Mask(32bits), Return Only on Close flag(32bits),
			''' Time Out(64bits), Bytes To Wait For(64bits), and USN Journal ID(64bits).
			''' </summary>
			''' <remarks> possible reason bits are from Win32Api
			''' USN_REASON_DATA_OVERWRITE
			''' USN_REASON_DATA_EXTEND
			''' USN_REASON_DATA_TRUNCATION
			''' USN_REASON_NAMED_DATA_OVERWRITE
			''' USN_REASON_NAMED_DATA_EXTEND
			''' USN_REASON_NAMED_DATA_TRUNCATION
			''' USN_REASON_FILE_CREATE
			''' USN_REASON_FILE_DELETE
			''' USN_REASON_EA_CHANGE
			''' USN_REASON_SECURITY_CHANGE
			''' USN_REASON_RENAME_OLD_NAME
			''' USN_REASON_RENAME_NEW_NAME
			''' USN_REASON_INDEXABLE_CHANGE
			''' USN_REASON_BASIC_INFO_CHANGE
			''' USN_REASON_HARD_LINK_CHANGE
			''' USN_REASON_COMPRESSION_CHANGE
			''' USN_REASON_ENCRYPTION_CHANGE
			''' USN_REASON_OBJECT_ID_CHANGE
			''' USN_REASON_REPARSE_POINT_CHANGE
			''' USN_REASON_STREAM_CHANGE
			''' USN_REASON_CLOSE
			''' </remarks>
			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure READ_USN_JOURNAL_DATA
				Public StartUsn As Int64
				Public ReasonMask As UInt32
				Public ReturnOnlyOnClose As UInt32
				Public Timeout As UInt64
				Public bytesToWaitFor As UInt64
				Public UsnJournalId As UInt64
			End Structure

			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure POINT
				Public X As Integer
				Public Y As Integer

				Public Sub New(ByVal x As Integer, ByVal y As Integer)
					Me.X = x
					Me.Y = y
				End Sub
			End Structure

			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure IO_STATUS_BLOCK
				Public status As UInteger
				Public information As ULong
			End Structure

			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure OBJECT_ATTRIBUTES
				Public Length As Int32
				Public RootDirectory As IntPtr
				Public ObjectName As IntPtr
				Public Attributes As Int32
				Public SecurityDescriptor As Int32
				Public SecurityQualityOfService As Int32
			End Structure

			<StructLayout(LayoutKind.Sequential, Pack := 1)> _
			Public Structure UNICODE_STRING
				Public Length As Int16
				Public MaximumLength As Int16
				Public Buffer As IntPtr
			End Structure

			#End Region

			#Region "functions"

'			
'		public static string GetPathFromFileReference(IntPtr rootIntPtr, UInt64 frn)
'		{
'			string name = string.Empty;
'
'			long allocSize = 0;
'			UNICODE_STRING unicodeString;
'			OBJECT_ATTRIBUTES objAttributes = new OBJECT_ATTRIBUTES();
'			IO_STATUS_BLOCK ioStatusBlock = new IO_STATUS_BLOCK();
'			IntPtr hFile;
'
'			IntPtr buffer = Marshal.AllocHGlobal(4096);
'			IntPtr refPtr = Marshal.AllocHGlobal(8);
'			IntPtr objAttIntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(objAttributes));
'
'			//
'			// pointer >> fileid
'			//
'			Marshal.WriteInt64(refPtr, (long)frn);
'
'			unicodeString.Length = 8;
'			unicodeString.MaximumLength = 8;
'			unicodeString.Buffer = refPtr;
'			//
'			// copy unicode structure to pointer
'			//
'			Marshal.StructureToPtr(unicodeString, objAttIntPtr, true);
'
'			//
'			//  InitializeObjectAttributes 
'			//
'			objAttributes.Length = Marshal.SizeOf(objAttributes);
'			objAttributes.ObjectName = objAttIntPtr;
'			objAttributes.RootDirectory = rootIntPtr;
'			objAttributes.Attributes = (int)OBJ_CASE_INSENSITIVE;
'
'			int fOk = NtCreateFile(out hFile, 0, ref objAttributes, ref ioStatusBlock, ref allocSize, 0,
'				FileShare.ReadWrite,
'				FILE_OPEN, FILE_OPEN_BY_FILE_ID | FILE_OPEN_FOR_BACKUP_INTENT, IntPtr.Zero, 0);
'			if (fOk.ToInt32() == 0)
'			{
'				fOk = NtQueryInformationFile(hFile, ref ioStatusBlock, buffer, 4096, FILE_INFORMATION_CLASS.FileNameInformation);
'				if (fOk.ToInt32() == 0)
'				{
'					//
'					// first 4 bytes are the name length
'					//
'					int nameLength = Marshal.ReadInt32(buffer, 0);
'					//
'					// next bytes are the name
'					//
'					name = Marshal.PtrToStringUni(new IntPtr(buffer.ToInt32() + 4), nameLength / 2);
'				}
'			}
'			hFile.Close();
'			Marshal.FreeHGlobal(buffer);
'			Marshal.FreeHGlobal(objAttIntPtr);
'			Marshal.FreeHGlobal(refPtr);
'			return name;
'		}
'		

			''' <summary>
			''' Writes the data in 'text' to the alternate stream ':Description' of the file 'currentFile.
			''' </summary>
			''' <param name="currentfile">Fully qualified path to a file</param>
			''' <param name="text">Data to write to the ':Description' stream</param>
			Public Shared Sub WriteAlternateStream(ByVal currentfile As String, ByVal text As String)
				Dim AltStreamDesc As String = currentfile & ":Description"
				Dim txtBuffer As IntPtr = IntPtr.Zero
				Dim hFile As IntPtr = IntPtr.Zero
				DeleteFile(AltStreamDesc)
				Dim descText As String = text.TrimEnd(" "c)

				Try
					hFile = CreateFile(AltStreamDesc, GENERIC_WRITE, 0, IntPtr.Zero, CREATE_ALWAYS, 0, IntPtr.Zero)
					If -1 <> hFile.ToInt32() Then
						txtBuffer = Marshal.StringToHGlobalUni(descText)
						Dim nBytes, count As UInteger
						nBytes = CUInt(descText.Length)
						Dim bRtn As Boolean = WriteFile(hFile, txtBuffer, Len(New Char) * nBytes, count, 0)
						If Not bRtn Then
							If (Len(New Char) * nBytes) <> count Then
								Throw New Exception(String.Format("Bytes written {0} should be {1} for file {2}.", count, Len(New Char) * nBytes, AltStreamDesc))
							Else
								Throw New Exception("WriteFile() returned false")
							End If
						End If
					Else
						Throw New Win32Exception(Marshal.GetLastWin32Error())
					End If
				Catch exception As Exception
					Dim msg As String = String.Format("Exception caught in WriteAlternateStream()" & vbLf & "  '{0}'" & vbLf & "  for file '{1}'.", exception.Message, AltStreamDesc)
					Console.WriteLine(msg)
				Finally
					CloseHandle(hFile)
					hFile = IntPtr.Zero
					Marshal.FreeHGlobal(txtBuffer)
					GC.Collect()
				End Try
			End Sub

			''' <summary>
			''' Adds the ':Description' alternate stream name to the argument 'currentFile'.
			''' </summary>
			''' <param name="currentfile">The file whose alternate stream is to be read</param>
			''' <returns>A string value representing the value of the alternate stream</returns>
			Public Shared Function ReadAlternateStream(ByVal currentfile As String) As String
				Dim AltStreamDesc As String = currentfile & ":Description"
				Dim returnstring As String = ReadAlternateStreamEx(AltStreamDesc)
				Return returnstring
			End Function

			''' <summary>
			''' Reads the stream represented by 'currentFile'.
			''' </summary>
			''' <param name="currentfile">Fully qualified path including stream</param>
			''' <returns>Value of the alternate stream as a string</returns>
			Public Shared Function ReadAlternateStreamEx(ByVal currentfile As String) As String
				Dim returnstring As String = String.Empty
				Dim hFile As IntPtr = IntPtr.Zero
				Dim buffer As IntPtr = IntPtr.Zero
				Try
					hFile = CreateFile(currentfile, GENERIC_READ, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
					If -1 <> hFile.ToInt32() Then
						buffer = Marshal.AllocHGlobal(1000 * Len(New Char))
						ZeroMemory(buffer, 1000 * Len(New Char))
						Dim nBytes As UInteger
						Dim bRtn As Boolean = ReadFile(hFile, buffer, 1000 * Len(New Char), nBytes, IntPtr.Zero)
						If bRtn Then
							If nBytes > 0 Then
								returnstring = Marshal.PtrToStringAuto(buffer)
								'byte[] byteBuffer = new byte[nBytes];
								'for (int i = 0; i < nBytes; i++)
								'{
								'    byteBuffer[i] = Marshal.ReadByte(buffer, i);
								'}
								'returnstring = Encoding.Unicode.GetString(byteBuffer, 0, (int)nBytes);
							Else
								Throw New Exception("ReadFile() returned true but read zero bytes")
							End If
						Else
							If nBytes <= 0 Then
								Throw New Exception("ReadFile() read zero bytes.")
							Else
								Throw New Exception("ReadFile() returned false")
							End If
						End If
					Else
						Dim excptn As Exception = New Win32Exception(Marshal.GetLastWin32Error())
						If Not excptn.Message.Contains("cannot find the file") Then
							Throw excptn
						End If
					End If
				Catch exception As Exception
					Dim msg As String = String.Format("Exception caught in ReadAlternateStream(), '{0}'" & vbLf & "  for file '{1}'.", exception.Message, currentfile)
					Console.WriteLine(msg)
					Console.WriteLine(exception.Message)
				Finally
					CloseHandle(hFile)
					hFile = IntPtr.Zero
					If buffer <> IntPtr.Zero Then
						Marshal.FreeHGlobal(buffer)
					End If
					GC.Collect()
				End Try
				Return returnstring
			End Function

			''' <summary>
			''' Read the encrypted alternate stream specified by 'currentFile'.
			''' </summary>
			''' <param name="currentfile">Fully qualified path to encrypted alternate stream</param>
			''' <returns>The un-encrypted value of the alternate stream as a string</returns>
			Public Shared Function ReadAlternateStreamEncrypted(ByVal currentfile As String) As String
				Dim returnstring As String = String.Empty
				Dim buffer As IntPtr = IntPtr.Zero
				Dim hFile As IntPtr = IntPtr.Zero
				Try
					hFile = CreateFile(currentfile, GENERIC_READ, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
					If -1 <> hFile.ToInt32() Then
						buffer = Marshal.AllocHGlobal(1000 * Len(New Char))
						ZeroMemory(buffer, 1000 * Len(New Char))
						Dim nBytes As UInteger
						Dim bRtn As Boolean = ReadFile(hFile, buffer, 1000 * Len(New Char), nBytes, IntPtr.Zero)
						If 0 <> nBytes Then
							returnstring = DecryptLicenseString(buffer, nBytes)
						End If
					Else
						Dim excptn As Exception = New Win32Exception(Marshal.GetLastWin32Error())
						If Not excptn.Message.Contains("cannot find the file") Then
							Throw excptn
						End If
					End If
				Catch exception As Exception
					Console.WriteLine("Exception caught in ReadAlternateStreamEncrypted()")
					Console.WriteLine(exception.Message)
				Finally
					CloseHandle(hFile)
					hFile = IntPtr.Zero
					If buffer <> IntPtr.Zero Then
						Marshal.FreeHGlobal(buffer)
					End If
					GC.Collect()
				End Try
				Return returnstring
			End Function

			''' <summary>
			''' Writes the value of 'LicenseString' as an encrypted stream to the file:stream specified
			''' by 'currentFile'.
			''' </summary>
			''' <param name="currentFile">Fully qualified path to the alternate stream</param>
			''' <param name="LicenseString">The string value to encrypt and write to the alternate stream</param>
			Public Shared Sub WriteAlternateStreamEncrypted(ByVal currentFile As String, ByVal LicenseString As String)
				Dim rc2 As RC2CryptoServiceProvider = Nothing
				Dim cs As CryptoStream = Nothing
				Dim ms As MemoryStream = Nothing
				Dim count As UInteger = 0
				Dim buffer As IntPtr = IntPtr.Zero
				Dim hFile As IntPtr = IntPtr.Zero
				Try
					Dim enc As Encoding = Encoding.Unicode

					Dim ba() As Byte = enc.GetBytes(LicenseString)
					ms = New MemoryStream()

					rc2 = New RC2CryptoServiceProvider()
					rc2.Key = GetBytesFromHexString("7a6823a42a3a3ae27057c647db812d0")
					rc2.IV = GetBytesFromHexString("827d961224d99b2d")

					cs = New CryptoStream(ms, rc2.CreateEncryptor(), CryptoStreamMode.Write)
					cs.Write(ba, 0, ba.Length)
					cs.FlushFinalBlock()

					buffer = Marshal.AllocHGlobal(1000 * Len(New Char))
					ZeroMemory(buffer, 1000 * Len(New Char))
					Dim nBytes As UInteger = CUInt(ms.Length)
					Marshal.Copy(ms.GetBuffer(), 0, buffer, CInt(nBytes))

					DeleteFile(currentFile)
					hFile = CreateFile(currentFile, GENERIC_WRITE, 0, IntPtr.Zero, CREATE_ALWAYS, 0, IntPtr.Zero)
					If -1 <> hFile.ToInt32() Then
						Dim bRtn As Boolean = WriteFile(hFile, buffer, nBytes, count, 0)
					Else
						Dim excptn As Exception = New Win32Exception(Marshal.GetLastWin32Error())
						If Not excptn.Message.Contains("cannot find the file") Then
							Throw excptn
						End If
					End If
				Catch exception As Exception
					Console.WriteLine("WriteAlternateStreamEncrypted()")
					Console.WriteLine(exception.Message)
				Finally
					CloseHandle(hFile)
					hFile = IntPtr.Zero
					If cs IsNot Nothing Then
						cs.Close()
						cs.Dispose()
					End If

					rc2 = Nothing
					If ms IsNot Nothing Then
						ms.Close()
						ms.Dispose()
					End If
					If buffer <> IntPtr.Zero Then
						Marshal.FreeHGlobal(buffer)
					End If
				End Try
			End Sub

			''' <summary>
			''' Encrypt the string 'LicenseString' argument and return as a MemoryStream.
			''' </summary>
			''' <param name="LicenseString">The string value to encrypt</param>
			''' <returns>A MemoryStream which contains the encrypted value of 'LicenseString'</returns>
			Private Shared Function EncryptLicenseString(ByVal LicenseString As String) As MemoryStream
				Dim enc As Encoding = Encoding.Unicode

				Dim ba() As Byte = enc.GetBytes(LicenseString)
				Dim ms As New MemoryStream()

				Dim rc2 As New RC2CryptoServiceProvider()
				rc2.Key = GetBytesFromHexString("7a6823a42a3a3ae27057c647db812d0")
				rc2.IV = GetBytesFromHexString("827d961224d99b2d")

				Dim cs As New CryptoStream(ms, rc2.CreateEncryptor(), CryptoStreamMode.Write)
				cs.Write(ba, 0, ba.Length)

				cs.Close()
				cs.Dispose()
				rc2 = Nothing
				Return ms
			End Function

			''' <summary>
			''' Given an IntPtr to a bufer and the number of bytes, decrypt the buffer and return an 
			''' unencrypted text string.
			''' </summary>
			''' <param name="buffer">An IntPtr to the 'buffer' containing the encrypted string</param>
			''' <param name="nBytes">The number of bytes in 'buffer' to decrypt</param>
			''' <returns></returns>
			Private Shared Function DecryptLicenseString(ByVal buffer As IntPtr, ByVal nBytes As UInteger) As String
				Dim ba(nBytes - 1) As Byte
				For i As Integer = 0 To nBytes - 1
					ba(i) = Marshal.ReadByte(buffer, i)
				Next i
				Dim ms As New MemoryStream(ba)

				Dim rc2 As New RC2CryptoServiceProvider()
				rc2.Key = GetBytesFromHexString("7a6823a42a3a3ae27057c647db812d0")
				rc2.IV = GetBytesFromHexString("827d961224d99b2d")

				Dim cs As New CryptoStream(ms, rc2.CreateDecryptor(), CryptoStreamMode.Read)
				Dim licenseString As String = String.Empty
				Dim ba1(4095) As Byte
				Dim irtn As Integer = cs.Read(ba1, 0, 4096)
				Dim enc As Encoding = Encoding.Unicode
				licenseString = enc.GetString(ba1, 0, irtn)

				cs.Close()
				cs.Dispose()
				ms.Close()
				ms.Dispose()
				rc2 = Nothing
				Return licenseString
			End Function

			''' <summary>
			''' Gets the byte array generated from the value of 'hexString'.
			''' </summary>
			''' <param name="hexString">Hexadecimal string</param>
			''' <returns>Array of bytes generated from 'hexString'.</returns>
			Public Shared Function GetBytesFromHexString(ByVal hexString As String) As Byte()
				Dim numHexChars As Integer = hexString.Length \ 2
				Dim ba(numHexChars - 1) As Byte
				Dim j As Integer = 0
				For i As Integer = 0 To ba.Length - 1
					Dim hex As New String(New Char() { hexString.Chars(j), hexString.Chars(j + 1) })
					ba(i) = Byte.Parse(hex, System.Globalization.NumberStyles.HexNumber)
					j = j + 2
				Next i
				Return ba
			End Function

			#End Region
		End Class

	End Namespace