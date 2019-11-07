Imports WebApplication

Partial Class utility
  Inherits System.Web.UI.Page
  Private BackupExists As Boolean = IO.File.Exists(BackupFileName)


#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub


  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
    'TryAutoLogin()
    If IsLocal() = False And CurrentUser.GeneralRole < Authentication.User.RoleType.Supervisor Then
      Response.End()
      Exit Sub 'Threading.Thread.CurrentThread.Abort()
    End If
  End Sub

#End Region


  Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    RepairUser()
  End Sub

  Public Sub RepairUser()
    Dim Root As String = Extension.MapPath(UsersSubDirectory)
    Dim dir As New System.IO.DirectoryInfo(Root)
    Dim Files As System.IO.FileSystemInfo() = dir.GetFileSystemInfos("*.old")
    For Each File As System.IO.FileSystemInfo In Files
      Dim Username As String = Left(File.Name, Len(File.Name) - 4)
      Dim VbsFile As String = Left(File.FullName, Len(File.FullName) - 4)
      If System.IO.File.Exists(VbsFile) = False Then
        Try
          'Microsoft.VisualBasic.FileSystem.Rename(File.FullName, VbsFile)
          System.IO.File.Copy(File.FullName, VbsFile)
        Catch ex As Exception

        End Try
      Else
        Dim FileInfo As New System.IO.FileInfo(VbsFile)
        If FileInfo.Length = 0 Then
          Try
            'System.IO.File.Delete(VbsFile)
            'Microsoft.VisualBasic.FileSystem.Rename(File.FullName, VbsFile)
            System.IO.File.Copy(File.FullName, VbsFile, True)
          Catch ex As Exception

          End Try
        End If
      End If
    Next
  End Sub

  Protected Sub utility_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    Dim Languages As LanguageManager.Language() = LanguageManager.LanguagesUsed
    For Each Language As LanguageManager.Language In Languages
      Me.Languages.Items.Add(Acronym(Language))
    Next
    BackUp.Enabled = Not BackUpAppDataInProgress()

    If Not BackupExists Then
      FtpUploadBackUp.Enabled = False
    End If

  End Sub

  Shared ThreadBackUp As System.Threading.Thread
  Shared ThreadRestore As System.Threading.Thread

  Protected Sub BackUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BackUp.Click
    If ThreadBackUp Is Nothing OrElse Not ThreadBackUp.IsAlive Then
      ThreadBackUp = Extension.BackUp(True)
    End If
  End Sub

  Protected Sub Restore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Restore.Click
    If ThreadRestore Is Nothing OrElse Not ThreadRestore.IsAlive Then
      ThreadRestore = RestoreBackUp(True)
    End If
  End Sub

  Protected Sub BackUp_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles BackUp.PreRender
    If (ThreadBackUp IsNot Nothing AndAlso ThreadBackUp.IsAlive) OrElse BackupExists Then
      BackUp.Enabled = False
    End If
  End Sub

  Protected Sub Restore_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Restore.PreRender
    If (ThreadRestore IsNot Nothing AndAlso ThreadRestore.IsAlive) OrElse Not BackupExists Then
      Restore.Enabled = False
    End If
  End Sub

  Protected Sub FtpUploadBackUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FtpUploadBackUp.Click

    'Variables
    Dim local_file As String = BackupFileName
    Dim remote_file As String = "ftp://" & Host.Text & "/app_data/App_Data.GzBackUp"
    Dim cls_request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(remote_file), System.Net.FtpWebRequest)
    Dim user_name As String = UserName.Text
    Dim password As String = Me.Password.Text

    'Establish credentials for logging into ftp site
    cls_request.Credentials = New System.Net.NetworkCredential(user_name, password)

    'Set properties
    cls_request.KeepAlive = False
    cls_request.Proxy = Nothing
    cls_request.Method =
    System.Net.WebRequestMethods.Ftp.UploadFile
    cls_request.UseBinary = True

    'Read in the file
    Dim b_file() As Byte = System.IO.File.ReadAllBytes(local_file)

    'Upload the file
    Dim cls_stream As System.IO.Stream = cls_request.GetRequestStream()
    cls_stream.Write(b_file, 0, b_file.Length)
    cls_stream.Close()
    cls_stream.Dispose()
  End Sub

  Protected Sub Merge_Click(sender As Object, e As System.EventArgs) Handles Merge.Click
    Dim Lng As String = Request("languages")
    Dim Language As LanguageManager.Language = Acronym2Enum(Lng)
    Dim Update As Boolean = ReplaceOld.Checked

    Dim DataReader As Data.OleDb.OleDbDataReader = DataManager.Table(Server.MapPath(Config.ReadWriteDirectory & "/" & MergeDataBase.Text), "Phrases")
    While DataReader.Read
      Dim Text As String = DataReader(Lng)
      Dim ID As Integer = DataReader("ID")
      If Update Or Phrase(Language, ID) = "" Then
        If Phrase(Language, ID) <> Text Then
          'Replace record
          Dim Source As Data.OleDb.OleDbDataReader = DataManager.Table(LocalizationDataFile, "Phrases", "ID=" & ID)
          Try
            'verify phrase is not changed
            Source.Read()
            If Phrase(LanguageManager.Language.Italian, ID) = Source("IT") Then
              Dim Cells() As DataManager.Cell = DataReaderToCells(Source)
              For Each Cell As DataManager.Cell In Cells
                If StrComp(Cell.Name, Lng, CompareMethod.Text) = 0 Then
                  Cell.Value = Text
                End If
              Next
              CloseConnection(Source)
              DataManager.AddRow(LocalizationDataFile, "Phrases", Cells, , ID)
            End If
          Catch ex As Exception
          End Try
        End If
      End If
    End While
    CloseConnection(DataReader)

  End Sub


  Protected Sub Translate_Click(sender As Object, e As System.EventArgs) Handles Translate.Click
    Dim Language As LanguageManager.Language = Language.Italian
    Dim Lng As String = Acronym(Language)

    Dim DataReader As Data.OleDb.OleDbDataReader = DataManager.Table(LocalizationDataFile, "Phrases", , "ID")
    While DataReader.Read
      Dim Cells() As DataManager.Cell = DataReaderToCells(DataReader)
      Dim Text As String = "" '= DataReader(Lng)
      Dim ID As Integer '= DataReader("ID")
      For Each Cell As DataManager.Cell In Cells
        If Cell.Name = Lng Then
          If Not IsDBNull(Cell.Value) Then
            Text = Cell.Value
          End If
        End If
        If Cell.Name = "ID" Then
          ID = Cell.Value
        End If
      Next

      If Text <> "" Then
        Dim Added As Boolean = False
        For Each TranslateTo As Language In LanguageManager.LanguagesUsed
          If TranslateTo <> Language Then
            Dim TextTarget As DataManager.Cell = Nothing
            For Each Cell As DataManager.Cell In Cells
              If Cell.Name = Acronym(TranslateTo) Then
                TextTarget = Cell : Exit For
              End If
            Next
            If IsDBNull(TextTarget.Value) OrElse TextTarget.Value = "" Then
              TextTarget.Value = Common.Translate(Text, Language, TranslateTo)
              Added = True
            End If
          End If
        Next
        If Added Then
          DataManager.AddRow(LocalizationDataFile, "Phrases", Cells, , ID)
        End If
      End If


    End While
    CloseConnection(DataReader)

  End Sub
End Class

