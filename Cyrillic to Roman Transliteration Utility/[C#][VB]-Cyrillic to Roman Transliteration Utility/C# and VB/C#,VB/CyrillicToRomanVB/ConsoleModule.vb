Imports System.IO
Imports System.Text

Module ConsoleModule
   Sub Main()
      Dim args() As String = Environment.GetCommandLineArgs()
      Dim source As String = Nothing
      Dim destination As String = Nothing
      Dim sr As StreamReader = Nothing
      Dim sw As StreamWriter = Nothing

      ' Get command line arguments.
      If args.Length <> 3 Then
         Console.WriteLine("There must be a source and a destination file.") : ShowSyntax()
         Exit Sub
      Else
         source = args(1)
         destination = args(2)
      End If

      If String.IsNullOrWhiteSpace(source) Or String.IsNullOrWhiteSpace(destination) Then
         Console.WriteLine("There must be a source and a destination file.") : ShowSyntax()
         Exit Sub
      End If

      If Not File.Exists(source) Then
         Console.WriteLine("The source file {1}   '{0}'{1}cannot be found.", source, vbCrLf) : ShowSyntax()
         Exit Sub
      Else
         Try
            sr = New StreamReader(source)
         Catch e As DirectoryNotFoundException
            Console.WriteLine("The directory is invalid.")
            Exit Sub
         Catch e As IOException
            Console.WriteLine("An I/O exception occurred in opening the source file.")
            Exit Sub
         End Try
      End If

      ' Check whether destination file exists and exit if it should not be overwritten.
      If File.Exists(destination) Then
         Console.Write("The destination file {1}   '{0}'{1}exists. Overwrite it? (Y/N) ", source, vbCrLf)
         Dim keyPressed As ConsoleKeyInfo = Console.ReadKey(True)
         If Char.ToUpper(keyPressed.KeyChar) = "Y"c Or Char.ToUpper(keyPressed.KeyChar) = "N"c Then
            Console.WriteLine(keyPressed.KeyChar)
            If Char.ToUpper(keyPressed.KeyChar) = "N" Then Exit Sub
         End If
      End If

      Try
         sw = New StreamWriter(destination, False, System.Text.Encoding.UTF8)
      Catch e As DirectoryNotFoundException
         Console.WriteLine("The directory is invalid.")
         Exit Sub
      Catch e As IOException
         Console.WriteLine("An I/O exception occurred in opening the destination file.")
         Exit Sub
      End Try

      ' Instantiate the encoder
      Dim encoding As Encoding = encoding.GetEncoding(1252, New CyrillicToRomanFallback(), New DecoderExceptionFallback())
      ' This is an encoding operation, so we only need to get the encoder.
      Dim encoder As Encoder = encoding.GetEncoder()
      Dim decoder As Decoder = encoding.GetDecoder()

      ' Define buffer to read characters
      Dim buffer(99) As Char
      Dim charsRead As Integer

      Do
         ' Read next 100 characters from input stream.
         charsRead = sr.ReadBlock(buffer, 0, buffer.Length)

         ' Encode characters.
         Dim byteCount As Integer = encoder.GetByteCount(buffer, 0, charsRead, False)
         Dim bytes(byteCount - 1) As Byte
         Dim bytesWritten As Integer = encoder.GetBytes(buffer, 0, charsRead, bytes, 0, False)

         ' Decode characters back to Unicode and write to a UTF-8-encoded file.
         Dim charsToWrite(decoder.GetCharCount(bytes, 0, byteCount)) As Char
         decoder.GetChars(bytes, 0, bytesWritten, charsToWrite, 0)
         sw.Write(charsToWrite)
      Loop While charsRead = buffer.Length
      sr.Close()
      sw.Close()
   End Sub

   Private Sub ShowSyntax()
      Console.WriteLine()
      Console.WriteLine("Syntax: CyrillicToRoman <source> <destination>")
      Console.WriteLine("   where <source>      = source filename")
      Console.WriteLine("         <destination> = destination filename")
      Console.WriteLine()
   End Sub
End Module
