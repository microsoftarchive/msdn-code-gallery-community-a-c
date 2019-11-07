'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Imports Microsoft.VisualBasic
Imports System.IO
Imports System.IO.Compression


Namespace WebApplication
	Public Module Zip

		Public Sub Compress(ByVal Dir As System.IO.DirectoryInfo, ByVal ZipFileName As String, Optional ByVal ReplaceZipFile As Boolean = True)
			If ReplaceZipFile Then
				If System.IO.File.Exists(ZipFileName) Then
					System.IO.File.Delete(ZipFileName)
				End If
			End If
      Dim Files() As String = Nothing
			For Each File As IO.FileInfo In Dir.GetFiles("*", IO.SearchOption.AllDirectories)
				If Files Is Nothing Then
					ReDim Files(0)
				Else
					Array.Resize(Files, Files.Length + 1)
				End If
				Files(Files.Length - 1) = File.FullName
			Next

			'Zip.Compress(Files, ZipFileName)

		End Sub

		Public Sub UncompressGZip(ByVal GzFileName As String, ByVal CopyTo As String)
			Dim fileName As String
			Dim fileContents(0) As Byte
			If Not CopyTo.EndsWith("\") Then
				CopyTo &= "\"
			End If

			Using reader As New GZipStream(New FileStream(GzFileName, FileMode.Open), CompressionMode.Decompress)
				Do
					fileName = UncompressGZipFromStream(reader, fileContents)
					If fileContents.Length > 0 Then
						Dim newFileName As String
						If fileName.StartsWith(CopyTo) Then
							newFileName = fileName
						Else
							newFileName = CopyTo & fileName
						End If
						MakeSubDirectory(newFileName)

						'Replace only if length of exist file is different 
						Dim Skyp As Boolean
						Skyp = False
						If IO.File.Exists(newFileName) Then
							Skyp = New IO.FileInfo(newFileName).Length = fileContents.Length
						Else
							Log("Zip", 1000, newFileName)
						End If
						If Not Skyp Then
							Using writer As New FileStream(newFileName, FileMode.Create)
								Try
									writer.Write(fileContents, 0, fileContents.Length)
								Catch ex As Exception
									Log("SpecificError", 1000, "UncompressGZip", ex.Message)
								End Try
							End Using
						End If
					End If
				Loop Until String.IsNullOrEmpty(fileName)
			End Using
		End Sub
		Private Sub MakeSubDirectory(ByVal PathNameFile As String)
			Dim Dirs() As String = Split(PathNameFile, "\"c)
			For N As Integer = 1 To Dirs.GetUpperBound(0)
				Dim Dirs2(N - 1) As String
				Array.Copy(Dirs, Dirs2, N)
				Dim Dir As String = Join(Dirs2, "\")
				If Not Dir.EndsWith(":") AndAlso Not System.IO.Directory.Exists(Dir) Then
					Try
						System.IO.Directory.CreateDirectory(Dir)
					Catch ex As Exception
						'This directory is inaccesible by security setting
					End Try
				End If
			Next
		End Sub

    Public Sub CompressGZip(ByVal FileName As String, ByVal ZipFileName As String, Optional ByVal PathName As String = Nothing)
      If System.IO.Directory.Exists(FileName) Then
        Dim Dir As New System.IO.DirectoryInfo(FileName)
        CompressGZip(Dir, ZipFileName, PathName)
      Else
        Dim FileNames(0) As String
        FileNames(0) = FileName
        CompressGZip(FileNames, ZipFileName, PathName)
      End If
    End Sub

    Public Sub CompressGZip(ByVal FileNames() As String, ByVal ZipFileName As String, Optional ByVal PathName As String = Nothing)
      Dim Output As New System.IO.FileStream(ZipFileName, IO.FileMode.Create, IO.FileAccess.Write)
      Dim OuputGzip As New System.IO.Compression.GZipStream(Output, CompressionMode.Compress)
      For Each FileName As String In FileNames
        Try
          Dim Bytes() As Byte = ReadAllBinary(FileName)
          CompressToGzipStream(OuputGzip, Nodrive(FileName, PathName), Bytes)
        Catch ex As Exception
          Log("Zip", 1000, PathName, FileName, ex.Message)
        End Try
      Next
      OuputGzip.Close()
      Output.Close()
    End Sub

		Private Function Nodrive(ByVal FullFileName As String, ByVal Path As String) As String
			If Path <> "" And FullFileName.StartsWith(Path, StringComparison.InvariantCultureIgnoreCase) Then
				Return FullFileName.Substring(Path.Length)
			Else
				Return FullFileName.Substring(FullFileName.IndexOf(":"c) + 1)
			End If
		End Function

		Public Sub CompressGZip(ByVal Dir As System.IO.DirectoryInfo, ByVal ZipFileName As String, Optional ByVal PathName As String = Nothing)
			If System.IO.File.Exists(ZipFileName) Then
				System.IO.File.Delete(ZipFileName)
			End If
			Dim FilesInfo() As IO.FileInfo = Dir.GetFiles("*", IO.SearchOption.AllDirectories)
			If FilesInfo IsNot Nothing Then
				Dim Files(FilesInfo.GetUpperBound(0)) As String
				Dim Index As Integer
				For Each File As IO.FileInfo In FilesInfo
					Files(Index) = File.FullName
					Index += 1
				Next
				CompressGZip(Files, ZipFileName, PathName)
			End If
		End Sub

		' Reads a file from the stream.  If no files remain, contents() is empty and the string is empty.
		Private Function UncompressGZipFromStream(ByVal stream As GZipStream, ByRef fileContents() As Byte) As String
			Dim fileName As String
			Dim fileNameLengthBytes(3) As Byte
			Dim fileNameLength As Integer
			Dim fileLengthBytes(3) As Byte
			Dim fileLength As UInteger
			Dim bytesRead As Integer

			' Get the length of the file name
			bytesRead = stream.Read(fileNameLengthBytes, 0, 4)

			'Validate bites
			If Not 4 = bytesRead Then
				fileContents = New Byte() {}
				Return ""
			End If

			fileNameLength = BitConverter.ToInt32(fileNameLengthBytes, 0)
			Dim fileNameBytes(fileNameLength - 1) As Byte

			stream.Read(fileNameBytes, 0, fileNameLength)
			' If it seems like a lot of work to go from string -> binary -> string, it is!
			'Dim decoder As System.Text.Decoder = System.Text.Encoding.Unicode.GetDecoder()
			' Since it's unicode, there could be more bytes than characters
			'Dim fileNameChars(decoder.GetCharCount(fileNameBytes, 0, fileNameLength) - 1) As Char
			'decoder.GetChars(fileNameBytes, 0, fileNameLength, fileNameChars, 0)
			'fileName = New String(fileNameChars, 0, fileNameChars.Length)

			fileName = System.Text.Encoding.UTF8.GetString(fileNameBytes)

			' Now we have the file name; get the length of the file contents
			stream.Read(fileLengthBytes, 0, 4)
			fileLength = BitConverter.ToUInt32(fileLengthBytes, 0)

			ReDim fileContents(fileLength - 1)
			stream.Read(fileContents, 0, fileLength)

			Return fileName
		End Function

		Private Sub CompressToGzipStream(ByVal stream As GZipStream, ByVal fileName As String, ByVal fileContents As Byte())
			If fileContents IsNot Nothing Then
				If fileContents.LongLength <= UInteger.MaxValue Then

					' Write the file's name with a length prefix:

					Dim fileNameBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(fileName)
					stream.Write(BitConverter.GetBytes(fileNameBytes.Length), 0, 4)	' integer should be 4 bytes
					stream.Write(fileNameBytes, 0, fileNameBytes.Length)

					' Write the file's length
					stream.Write(BitConverter.GetBytes(CUInt(fileContents.LongLength)), 0, 4)	' integer should be 4 bytes

					' Write the file's content
					stream.Write(fileContents, 0, fileContents.Length)
				Else
					Log("Zip", 1000, fileName, "Too Big", fileContents.LongLength)
				End If
			End If
		End Sub

	End Module
End Namespace
