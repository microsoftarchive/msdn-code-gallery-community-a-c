Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Management
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Microsoft.Win32.SafeHandles
Imports Nexus.Windows.Forms


Namespace netLowLevelDiskFunctions
	Partial Public Class Form1
		Inherits Form

		Private secondsCounter As Double = 0
		Private previousSectorCount As Double = 0
		Private previousTrackCount As Double = 0

		Public Sub New()
			InitializeComponent()
			PopulateDriveListBox()

		End Sub

		' Populate drive list box
		Private Sub PopulateDriveListBox()
			For Each dID As String In GetDriveList()
				lbDriveList.Items.Add(dID)
			Next dID
		End Sub

		#region "WMI LOW LEVEL COMMANDS"

		''' <summary>
		''' Returns the number of bytes that the drive sectors contain.
		''' </summary>
		''' <param name="drive">
		''' Int: The drive number to scan.
		''' </param>
		''' <returns>
		''' Int: The number of bytes the sector contains.
		''' </returns>
		Public Function BytesPerSector(ByVal drive As Integer) As Integer
			Dim driveCounter As Integer = 0
			Try
				Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_DiskDrive")

				For Each queryObj As ManagementObject In searcher.Get()
					If driveCounter = drive Then
						Dim t = queryObj("BytesPerSector")
						Return Integer.Parse(t.ToString())

					End If
					driveCounter += 1
				Next queryObj
			Catch e1 As ManagementException
				Return -1
			End Try
			Return 0
		End Function

		''' <summary>
		''' Returns a list of physical drive IDs
		''' </summary>
		''' <returns>
		''' ArrayList: Device IDs of all connected physical hard drives
		'''  </returns>
		Public Function GetDriveList() As ArrayList
			Dim drivelist As New ArrayList()

			Try
				Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_DiskDrive")

				For Each queryObj As ManagementObject In searcher.Get()
					drivelist.Add(queryObj("DeviceID").ToString())
				Next queryObj
			Catch e1 As ManagementException
				Return Nothing
			End Try
			Return drivelist
		End Function

		''' <summary>
		''' Returns the total sectors on the specified drive
		''' </summary>
		''' <param name="drive">
		''' int: The drive to be queried.
		''' </param>
		''' <returns>
		''' int: Returns the total number of sectors
		''' </returns>
		Public Shared Function GetTotalSectors(ByVal drive As Integer) As Integer
			Dim driveCount As Integer = 0
			Try
				Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_DiskDrive")

				For Each queryObj As ManagementObject In searcher.Get()
					If driveCount = drive Then
						Dim t = queryObj("TotalSectors")
						Return Integer.Parse(t.ToString())

					End If
					driveCount += 1
				Next queryObj
			Catch e1 As ManagementException
				Return -1
			End Try
			Return -1
		End Function

		''' <summary>
		''' Returns the number of Sectors per track.
		''' </summary>
		''' <param name="drive">
		''' The drive to be queried.
		''' </param>
		''' <returns>
		''' int: the number of sectors per track
		''' </returns>
		Public Shared Function GetSectorsPerTrack(ByVal drive As Integer) As Integer
			Dim driveCount As Integer = 0
			Try
				Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_DiskDrive")

				For Each queryObj As ManagementObject In searcher.Get()
					If driveCount = drive Then
						Dim t = queryObj("SectorsPerTrack")
						Return Integer.Parse(t.ToString())
					End If
					driveCount += 1
				Next queryObj
			Catch e1 As ManagementException
				Return -1
			End Try
			Return -1
		End Function

		''' <summary>
		''' Returns the total number of tracks on this hard drive
		''' </summary>
		''' <param name="drive">
		''' The drive to be parsed
		''' </param>
		''' <returns>
		''' int: the number of tracks on the drive
		''' </returns>
		Public Shared Function GetTotalTracks(ByVal drive As Integer) As Integer
			Dim DriveCount As Integer = 0
			Try
				Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_DiskDrive")

				For Each queryObj As ManagementObject In searcher.Get()
					If DriveCount = drive Then
						Dim t = queryObj("TotalTracks")
						Return Integer.Parse((t.ToString()))
					End If
					DriveCount += 1
				Next queryObj

			Catch e1 As ManagementException
				Return -1
			End Try
			Return -1
		End Function

		#End Region

		#region "API CALLS"

		Public Enum EMoveMethod As UInteger
			Begin = 0
			Current = 1
			[End] = 2
		End Enum

		<DllImport("Kernel32.dll", SetLastError := True, CharSet := CharSet.Auto)> _
		Shared Function SetFilePointer(<[In]> ByVal hFile As SafeFileHandle, <[In]> ByVal lDistanceToMove As Long, <Out()> ByRef lpDistanceToMoveHigh As Integer, <[In]> ByVal dwMoveMethod As EMoveMethod) As UInteger
		End Function

		<DllImport("kernel32.dll", SetLastError := True, CharSet := CharSet.Unicode)> _
		Shared Function CreateFile(ByVal lpFileName As String, ByVal dwDesiredAccess As UInteger, ByVal dwShareMode As UInteger, ByVal lpSecurityAttributes As IntPtr, ByVal dwCreationDisposition As UInteger, ByVal dwFlagsAndAttributes As UInteger, ByVal hTemplateFile As IntPtr) As SafeFileHandle
		End Function

		<DllImport("kernel32", SetLastError := True)> _
		Friend Shared Function ReadFile(ByVal handle As SafeFileHandle, ByVal bytes() As Byte, ByVal numBytesToRead As Integer, ByRef numBytesRead As Integer, ByVal overlapped_MustBeZero As IntPtr) As Integer
		End Function

		#End Region

		Private Sub btnStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStart.Click
			timerSeconds.Enabled = True
			Dim drive As Integer = lbDriveList.SelectedIndex
			Dim trackBufferSize As Integer = Integer.Parse(tbTrackBufferSize.Text)

			If cbTracks.CheckState = CheckState.Checked Then
				Dim bps As Integer = BytesPerSector(drive)
				Dim spt As Integer = GetSectorsPerTrack(drive)
				Dim bpt As Integer = bps*spt
				Dim tt As Double = GetTotalTracks(drive)
				lblBytesPerSector.Text = bps.ToString("N0")
				lblBytesPerTrack.Text = (bps*spt).ToString("N0")
				lblTotalTracks.Text = tt.ToString("N0")
				progress.Maximum = Integer.Parse(tt.ToString())

				Dim p As Double = 100 / tt


				Dim dr As String = lbDriveList.Items(0).ToString()


				For idx As Double = 0 To tt - 1 Step (1 * trackBufferSize)
					Dim sb As New StringBuilder()
					lblTrack.Text = idx.ToString("N0")
					progress.Value = Integer.Parse(idx.ToString())
					Dim r As Double = p * idx
					lblPercentage.Text = r.ToString()
					r = Math.Round(r, 0)
					progressPie.Items.Add(New PieChartItem(r, Color.BurlyWood, "Tracks", "Number of Tracks Processed", 0))
			 '      

					 Dim b() As Byte = DumpTrack(dr, idx, bpt,trackBufferSize)


					For Each byt As Byte In b
						sb.Append(byt.ToString("X2"))
					Next byt
					lblHash.Text = md5Hash(sb.ToString()).ToUpperInvariant() ' hash this and show
					progressPie.Items.RemoveAt(0)
					Application.DoEvents()
				Next idx
			Else

			lblBytesPerSector.Text = BytesPerSector(drive).ToString("N0")
			lblTotalSectors.Text = GetTotalSectors(drive).ToString("N0")
			Dim dr As String = lbDriveList.Items(0).ToString()
			For idx As Double = 0 To Double.Parse(lblTotalSectors.Text) - 1
				Dim sb As New StringBuilder()
				lblSector.Text = idx.ToString("N0")
				Dim b() As Byte = DumpSector(dr, idx, Integer.Parse(lblBytesPerSector.Text))

				For Each byt As Byte In b
					sb.Append(byt.ToString("X2"))
				Next byt
			   lblHash.Text = md5Hash(sb.ToString()).ToUpperInvariant() ' hash this and show
				Application.DoEvents()
			Next idx

			End If
		End Sub

		Private Function md5Hash(ByVal p As String) As String
			Dim x As New System.Security.Cryptography.MD5CryptoServiceProvider()
			Dim bs() As Byte = System.Text.Encoding.UTF8.GetBytes(p)
			bs = x.ComputeHash(bs)
			Dim s As New System.Text.StringBuilder()
			For Each b As Byte In bs
				s.Append(b.ToString("x2").ToLower())
			Next b
		   Return s.ToString()

		End Function

		''' <summary>
		''' Returns the Sector from the drive at the specified location
		''' </summary>
		''' <param name="drive">
		''' The drive to have a sector read
		''' </param>
		''' <param name="sector">
		''' The sector number to read.
		''' </param>
		''' <param name="bytesPerSector"></param>
		''' <returns></returns>
		Private Function DumpSector(ByVal drive As String, ByVal sector As Double, ByVal bytesPerSector As Integer) As Byte()
			Dim FILE_ATTRIBUTE_NORMAL As Short = &H80
			Dim INVALID_HANDLE_VALUE As Short = -1
			Dim GENERIC_READ As UInteger = &H80000000L
			Dim GENERIC_WRITE As UInteger = &H40000000
			Dim CREATE_NEW As UInteger = 1
			Dim CREATE_ALWAYS As UInteger = 2
			Dim OPEN_EXISTING As UInteger = 3



			Dim handleValue As SafeFileHandle = CreateFile(drive, GENERIC_READ, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
			If handleValue.IsInvalid Then
				Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error())
			End If
			Dim sec As Double = sector * bytesPerSector

'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim size_Renamed As Integer = Integer.Parse(bytesPerSector.ToString())
			Dim buf(size_Renamed - 1) As Byte
			Dim read As Integer = 0
			Dim moveToHigh As Integer
			SetFilePointer(handleValue, Integer.Parse(sec.ToString()), moveToHigh, EMoveMethod.Begin)
			ReadFile(handleValue, buf, size_Renamed, read, IntPtr.Zero)
			handleValue.Close()
			Return buf
		End Function

		''' <summary>
		''' Returns the Sector from the drive at the specified location
		''' </summary>
		''' <param name="drive">
		''' The drive to have a sector read
		''' </param>
		''' <param name="sector">
		''' The sector number to read.
		''' </param>
		''' <param name="bytesPerSector"></param>
		''' <returns></returns>
		Private Function DumpTrack(ByVal drive As String, ByVal track As Double, ByVal bytesPerTrack As Integer, ByVal TrackBufferSize As Integer) As Byte()
			Dim FILE_ATTRIBUTE_NORMAL As Short = &H80
			Dim INVALID_HANDLE_VALUE As Short = -1
			Dim GENERIC_READ As UInteger = &H80000000L
			Dim GENERIC_WRITE As UInteger = &H40000000
			Dim CREATE_NEW As UInteger = 1
			Dim CREATE_ALWAYS As UInteger = 2
			Dim OPEN_EXISTING As UInteger = 3



			Dim handleValue As SafeFileHandle = CreateFile(drive, GENERIC_READ, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
			If handleValue.IsInvalid Then
				Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error())
			End If
			Dim trx As Double = (track * bytesPerTrack * TrackBufferSize)

'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim size_Renamed As Integer = Integer.Parse(bytesPerTrack.ToString())
			Dim buf((size_Renamed * TrackBufferSize) - 1) As Byte
			Dim read As Integer = 0
			Dim moveToHigh As Integer
			SetFilePointer(handleValue, Long.Parse(trx.ToString()), moveToHigh, EMoveMethod.Begin)
			ReadFile(handleValue, buf, size_Renamed, read, IntPtr.Zero)
			handleValue.Close()
			Return buf
		End Function


		Private Sub timerSeconds_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerSeconds.Tick
			secondsCounter += 1
			lblSectorsPerSecond.Text = (Double.Parse(lblSector.Text) - previousSectorCount).ToString(("N0"))
			previousSectorCount = Double.Parse(lblSector.Text)

			lblTracksPerSecond.Text = (Double.Parse(lblTrack.Text) - previousTrackCount).ToString(("N0"))
			previousTrackCount = Double.Parse(lblTrack.Text)

		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub

	End Class


End Namespace
