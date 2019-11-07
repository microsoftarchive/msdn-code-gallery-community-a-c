Imports WebApplication
'Namespace WebApplication
Partial Class ScriptSender
  Inherits System.Web.UI.Page
	Private Source As SourceScript
  Protected Sub script_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		'Response.AddHeader("Expires", Now.AddYears(1).ToString("r"))
		Response.Cache.SetExpires(Now.AddYears(1))
		Dim Value As String
		Try
			Source = Request.QueryString("s")
		Catch ex As Exception
			EndResponse()
			Exit Sub
		End Try
		If Request.QueryString("v") IsNot Nothing Then
			Try
				Value = Request.QueryString("v")
			Catch ex As Exception
				EndResponse()
				Exit Sub
			End Try
			SetByValue(Value)
		End If
    Dim NameFile As String = Nothing
    Select Case source
      Case SourceScript.DetectTimeZoneOffset
        NameFile = source.ToString & ".js"
        Response.ContentType = "text/javascript"
    End Select
    NameFile = ScriptsResources & "/" & NameFile
    Dim Code As String = ReadAll(MapPath(NameFile))
    Response.Write(Code)
    Response.End()
  End Sub

  Private Sub SetByValue(ByVal Value As String)
    Select Case source
      Case SourceScript.DetectTimeZoneOffset
        'Dim DeteRemote As Date = #1/1/1970#.AddMilliseconds(Value)
        Dim DateElements() As String = Split(Value)
        Dim DeteClient As New Date(CInt(DateElements(0)), CInt(DateElements(1)) + 1, CInt(DateElements(2)), CInt(DateElements(3)), CInt(DateElements(4)), CInt(DateElements(5)))
        Dim DateServer As Date = Now
        Dim SecDifs As Long = DateDiff(DateInterval.Second, DateServer, DeteClient)
        CurrentUser.TimeOffsetSeconds = SecDifs
    End Select
    Response.End()
  End Sub


End Class
'End Namespace