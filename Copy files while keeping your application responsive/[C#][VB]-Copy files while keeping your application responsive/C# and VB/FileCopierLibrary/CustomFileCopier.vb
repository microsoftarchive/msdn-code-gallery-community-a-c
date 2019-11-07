Imports System.IO

Public Delegate Sub ProgressChangeDelegate(ByVal Percentage As Integer, ByRef Cancel As Boolean)
Public Delegate Sub Completedelegate()

Public Class CustomFileCopier
    Public Sub New()

        AddHandler OnProgressChanged, Sub()
                                      End Sub
        AddHandler OnComplete, Sub()
                               End Sub
    End Sub
    Public Sub New(ByVal Source As String, ByVal Dest As String)
        Me.SourceFilePath = Source
        Me.DestFilePath = Dest

        AddHandler OnProgressChanged, Sub()
                                      End Sub
        AddHandler OnComplete, Sub()
                               End Sub
    End Sub

    Public Sub Copy()
        Dim buffer(1024 * 1024 - 1) As Byte ' 1MB buffer
        Dim cancelFlag As Boolean = False

        Using source As New FileStream(SourceFilePath, FileMode.Open, FileAccess.Read)
            Dim fileLength As Long = source.Length
            If IO.File.Exists(DestFilePath) Then
                IO.File.Delete(DestFilePath)
            End If
            Using dest As New FileStream(DestFilePath, FileMode.CreateNew, FileAccess.Write)
                Dim totalBytes As Long = 0
                Dim currentBlockSize As Integer = 0

                currentBlockSize = source.Read(buffer, 0, buffer.Length)

                Do While currentBlockSize > 0
                    totalBytes += currentBlockSize
                    Dim percentage As Double = CDbl(totalBytes) * 100.0 / fileLength

                    dest.Write(buffer, 0, currentBlockSize)

                    cancelFlag = False
                    RaiseEvent OnProgressChanged(CInt(percentage), cancelFlag)

                    If cancelFlag = True Then
                        ' Delete dest file here
                        Exit Do
                    End If
                    currentBlockSize = source.Read(buffer, 0, buffer.Length)
                Loop
            End Using
        End Using

        RaiseEvent OnComplete()
    End Sub

    Public Property SourceFilePath() As String
    Public Property DestFilePath() As String

    Public Event OnProgressChanged As ProgressChangeDelegate
    Public Event OnComplete As Completedelegate
End Class