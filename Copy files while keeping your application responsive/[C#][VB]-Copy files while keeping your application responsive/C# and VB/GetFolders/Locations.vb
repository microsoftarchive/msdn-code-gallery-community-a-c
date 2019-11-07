Imports Extensions
Public Class Locations
    Private mSourceFolder As String
    Public ReadOnly Property SourceFolder As String
        Get
            Return mSourceFolder
        End Get
    End Property
    Private mDestinationFolder As String
    Public ReadOnly Property DestinationFolder As String
        Get
            Return mDestinationFolder
        End Get
    End Property
    Public Sub New()
        Dim Folders = (From T In XDocument.Load(IO.Path.Combine(UpperFolder(AppDomain.CurrentDomain.BaseDirectory, 4), "Folders.xml"))...<Folders> Select New With {.SourceFolder = T.<SourceFolder>.Value, .DestinationFolder = T.<DestinationFolder>.Value}).FirstOrDefault
        If IO.Directory.Exists(Folders.SourceFolder) Then
            mSourceFolder = Folders.SourceFolder
        Else
            mSourceFolder = ""
        End If
        If IO.Directory.Exists(Folders.DestinationFolder) Then
            mDestinationFolder = Folders.DestinationFolder
        Else
            mDestinationFolder = ""
        End If

    End Sub
End Class
