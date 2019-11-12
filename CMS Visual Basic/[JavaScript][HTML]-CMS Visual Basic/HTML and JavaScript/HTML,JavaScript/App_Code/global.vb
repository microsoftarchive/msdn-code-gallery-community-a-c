'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Namespace WebApplication
	Public Class [Global]
		Inherits System.Web.HttpApplication


		Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
			' Code that runs on application startup

      'CodeTranslator.SourceTranslator("C:\Users\Andrea\Documents\My Webs\WebSiteMaker", "C:\Users\Andrea\Documents\My Webs\WebSiteMaker\app_code\Private\prova.vb", "C:\Users\Andrea\Documents\My Webs\WebSiteMaker C", ProgrammLanguage.CSharp)
			'Stop

      Extension.Log("application_start", 1000, Threading.Thread.CurrentThread.GetHashCode, "==========Application_Start==========", My.Computer.Name)
			'AcceptHttpRequest = True : Exit Sub
      Config.Run()
		End Sub

		Public Shared EndInProgress As Boolean
		Public Shared SecureTasks As New Collections.Generic.List(Of Threading.Thread)
		Public Shared Sub SecureTaskStart()
			If EndInProgress Then
				Threading.Thread.CurrentThread.Abort()
			Else
				SyncLock SecureTasks
					SecureTasks.Add(Threading.Thread.CurrentThread)
				End SyncLock
			End If
		End Sub
		Public Shared Sub SecureTaskEnd()
			SyncLock SecureTasks
				SecureTasks.Remove(Threading.Thread.CurrentThread)
			End SyncLock
			If EndInProgress Then
				Threading.Thread.CurrentThread.Abort()
			End If
		End Sub


		Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
			' Code that runs on application shutdown
      Extension.Log("application_end", 1000, Threading.Thread.CurrentThread.GetHashCode, "==========Application_End==========", My.Computer.Name)

			Try
				PluginManager.RaiseApplicationEndEvent()
			Catch ex As Exception
        Log("application_end", 1000, ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf, vbCrLf)
			End Try

			Try
				Dim LastError As System.Exception = Server.GetLastError.GetBaseException
        Log("application_end", 1000, LastError.Message & vbCrLf, LastError.Source & vbCrLf, LastError.StackTrace & vbCrLf, vbCrLf)
			Catch ex As Exception
				'No last error
			End Try

			Try
        Config.Application_End()
			Catch ex As Exception
        Log("application_end", 1000, ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf, vbCrLf)
			End Try
      Log("application_end", 1000, "successful")

			'Waithing end of all secure staks 
			EndInProgress = True
			SyncLock SecureTasks
				For Each Thread As Threading.Thread In SecureTasks
					Thread.Join()
				Next
			End SyncLock

		End Sub

		Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
			' Code that runs when a new session is started
      If Setup.Performance.InhibitSessionForCrawlers AndAlso IsCrawler(HttpContext.Current.Request) Then
        Session("NoSession") = True
        Session.Abandon()
        Exit Sub
      End If
      Me.Session.Timeout = Config.Setup.Ambient.SessionTimeOut
      Authentication.TryAutoLogin()
      Authentication.AddOnLineUser(Me.Session)
      Dim CounterAccess As Integer = Val(Cookie("CounterAccess"))
      CounterAccess += 1
      Session("CounterAccess") = CounterAccess
      Cookie("CounterAccess") = CounterAccess
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
      ' Code that runs when a session ends.
      ' Note: The Session_End event is raised only when the sessionstate mode
      ' is set to InProc in the Web.config file. If session mode is set to StateServer 
      ' or SQLServer, the event is not raised.
      If Setup.Performance.InhibitSessionForCrawlers AndAlso Me.Session("NoSession") = True Then
        Exit Sub
      End If
      CurrentUser(Me.Session).LogOut()
      Authentication.RemoveOnLineUser(Me.Session)
    End Sub

    Private Sub Global_BeginRequest(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BeginRequest

      'Dim h As String = LCase(Request.ServerVariables("HTTP_HOST"))

      If Config.Setup Is Nothing Then
        If CheckWritePermission() Then
          Exit Sub
        End If
      End If

      If Config.AcceptHttpRequest = False Then
        Response.Status = "503 Service Unavailable"
        Response.StatusCode = 503
        Response.End()
      End If

      '============ Anty DDoS prevention by Andrea Bruno    [part 1/2]
      If Config.Setup.Security.DdosPrevention.AntiAbnormalSimultaneousRequests Then
        AntiAbnormalSimultaneousRequests(Request)
      End If
      If Config.Setup.Security.DdosPrevention.TemporarilyCrawlersStoppingDuringOverload Then
        TemporarilyCrawlersStoppingDuringOverload(Request)
      End If
      If Config.Setup.Security.DdosPrevention.DisableTheSourcesOfAbnormalHighTraffic Then
        DisableTheSourcesOfAbnormalHighTraffic(Request)
      End If
      '============ END Anty DDoS prevention by Andrea Bruno


      If Setup.SEO.WWWSubdomine <> Configuration.SearchEngineOptimizationConfiguration.WWWUsage.Both Then
        Dim ThisUrl As String = Request.Url.Authority
        If ThisUrl.ToLower.StartsWith("www.") Then
          If Setup.SEO.WWWSubdomine = Configuration.SearchEngineOptimizationConfiguration.WWWUsage.NoWWW Then
            Response.RedirectPermanent(HttpContext.Current.Request.Url.Scheme & System.Uri.SchemeDelimiter & Mid(Request.Url.Authority & Request.Url.PathAndQuery, 5), True)
          End If
        Else
          If Setup.SEO.WWWSubdomine = Configuration.SearchEngineOptimizationConfiguration.WWWUsage.OnlyWWW Then
            Response.RedirectPermanent(HttpContext.Current.Request.Url.Scheme & System.Uri.SchemeDelimiter & "www." & Request.Url.Authority & Request.Url.PathAndQuery, True)
          End If
        End If
      End If

      '==========Track log debugging procedure
      HttpContext.Current.Items("Start") = Now
      'If HttpContext.Current.Request.UserHostAddress = "84.237.189.149" Then
      'Dim t As Global.System.TimeSpan = Now.Subtract(HttpContext.Current.Items("Start"))
      'Log("Debug", 0, t.Milliseconds, "SetVisualization")
      'End If
      '==========END Track log debugging procedure

      'Dim t As System.Threading.Thread = Threading.Thread.CurrentThread
      'Dim d As New System.Diagnostics.StackTrace(t, True)




      Dim RelativePathAndFile As String = Me.Request.Path.Substring(Me.Request.ApplicationPath.Length)
      If RelativePathAndFile.StartsWith("/" & Config.Resources) OrElse RelativePathAndFile.StartsWith("/clientbin", StringComparison.InvariantCultureIgnoreCase) Then
        Response.Cache.SetExpires(Now.AddYears(1))
      End If

      'File not found case (in godaddy host)
      If HttpContext.Current.Request.Url.Query.StartsWith("?404;") Then
        'Enable access to content in resource folder
        If AbsoluteUri(HttpContext.Current.Request).EndsWith(".mod") Then 'enable access to .mod files
          Dim P As Integer = InStrRev(AbsoluteUri(HttpContext.Current.Request), ":80")
          Dim File As String = HttpUtility.UrlDecode(AbsoluteUri(HttpContext.Current.Request).Substring(P + 3))
          If File.ToLower.StartsWith(Resources.ToLower) Then
            File = MapPath(File)
            Response.Clear()
            Response.WriteFile(File)
            Response.End()
          End If
        End If
      End If

      'Redirect if this host is not for this setting
      If RedirectDomain() Then
        Exit Sub
      End If

      'Remove SS (subsite) parameter if is not necessary
      If HttpContext.Current.Request.QueryString("ss") <> "" AndAlso CurrentDomainConfiguration.SubSitesAvailable.Count = 1 Then
        Dim Flag As Boolean
        Dim Params As New StringBuilder
        For Each Key As String In HttpContext.Current.Request.QueryString.AllKeys
          If Key <> "ss" Then
            If Flag = False Then
              Flag = True
              Params.Append("?")
            Else
              Params.Append("&")
            End If
            Params.Append(Key & "=" & HttpContext.Current.Request.QueryString(Key))
          End If
        Next
        HttpContext.Current.Response.RedirectPermanent(HttpContext.Current.Request.Url.AbsolutePath & Params.ToString, True)
      End If

    End Sub

    Private Sub Global_EndRequest(sender As Object, e As EventArgs) Handles Me.EndRequest
      '============ Anty DDoS prevention by Andrea Bruno    [part 2/2]
      If Config.Setup IsNot Nothing AndAlso Config.Setup.Security.DdosPrevention.AntiAbnormalSimultaneousRequests Then
        AdviseRequestIsEnd(Request)
      End If
      '============ END Anty DDoS prevention by Andrea Bruno
    End Sub

    Private Sub Global_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
      'Code that runs when an unhandled error occurs
      'Dim Content As System.Web.HttpContext = HttpContext.Current
      'Dim ThisError As System.Exception = Content.Error
      Try

        Dim ThisError As System.Exception = Server.GetLastError.GetBaseException
        Dim HttpException As System.Web.HttpException = Nothing

        Try
          HttpException = CType(Context.Error, Web.HttpException)
        Catch ex As Exception
        End Try

        'Try
        '  HttpException = HttpContext.Current.Error
        'Catch ex As Exception
        'End Try

        Dim StatusCode As Integer
        If HttpException IsNot Nothing Then
          StatusCode = HttpException.GetHttpCode
          Select Case StatusCode
            Case 400
              'A potentially dangerous Request.Path value was detected from the client (&).
              Try
                'Some crawler or browser don't intend correctly the relative URL. This part try to make a correction!
                If Context.Request.ServerVariables("URL").StartsWith("/http") Then
                  Response.RedirectPermanent(Context.Request.ServerVariables("URL").Substring(1), True)
                End If
              Catch ex As Exception
              End Try
              RedirectToHomePage()
            Case 404
              'Page not found

              'Generate dinamically the page not founted
              PageNotFound(HttpContext.Current.Request.Url.AbsolutePath)

              'Remove xxx in http://website.com/xxx/xxx/page.aspx
              Dim ExecutionFile As String = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath
              If Not ExecutionFile.StartsWith("~/" & Resources) OrElse ExecutionFile.EndsWith(".aspx") Then
                Dim P As Integer = InStrRev(ExecutionFile, "/", , CompareMethod.Binary)
                If P > 2 Then
                  Dim ApplicationPath As String = HttpContext.Current.Request.ApplicationPath
                  If Not ApplicationPath.EndsWith("/") Then
                    ApplicationPath &= "/"
                  End If
                  Dim Redirect As String = HttpContext.Current.Request.Url.Scheme & System.Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & ApplicationPath & ExecutionFile.Substring(P) & HttpContext.Current.Request.Url.Query
                  Log("redirect", 1000, AbsoluteUri(HttpContext.Current.Request), Redirect, HttpContext.Current.Request.UserHostAddress, HostUser())
                  HttpContext.Current.Response.RedirectPermanent(Redirect, True)
                End If
              End If

          End Select
        End If


        '  Dim ErrorCode = Err.Number


        'http://msdn.microsoft.com/library/aa378137(VS.85).aspx
        Dim HResult As Integer = Runtime.InteropServices.Marshal.GetHRForException(ThisError)

        If Setup Is Nothing OrElse StatusCode <> 404 OrElse Setup.ReportErrorsByEmail.ExcludeErrorHttp404 = False Then
          If Setup Is Nothing OrElse HResult <> &H80070057 OrElse Setup.ReportErrorsByEmail.ExcludeError80070057 = False Then
            Common.ReportErrorByEmail()
          End If
        End If

        Select Case HResult
          Case &H8007000E 'Out of memory
            'Restart the web application
            System.Web.HttpRuntime.UnloadAppDomain()
          Case &H80070070
            'There is not enough space on the disk.
            PreserveDiskSpace()
        End Select

        Dim Reference As String = Nothing
        If HttpContext.Current.Request.UrlReferrer IsNot Nothing Then
          Reference = vbCrLf & "Url Reference=" & HttpContext.Current.Request.UrlReferrer.ToString
        End If

        If StatusCode = 500 Then
          Log("Error " & Hex(HResult), 1000 & vbCrLf, ThisError.Message & vbCrLf, ThisError.Source & vbCrLf, HttpContext.Current.Request.Url.ToString & Reference & vbCrLf, HttpContext.Current.Request.UserAgent & vbCrLf, ThisError.StackTrace & vbCrLf, vbCrLf)
        Else
          Log("ErrorHttp " & StatusCode, 1000 & vbCrLf, ThisError.Message & vbCrLf, ThisError.Source & vbCrLf, HttpContext.Current.Request.Url.ToString & Reference & vbCrLf, HttpContext.Current.Request.UserAgent & vbCrLf, ThisError.StackTrace & vbCrLf, vbCrLf)
        End If

        'If IsCrawler() Then
        RedirectToHomePage()
        'End If
      Catch ex As Exception
        Try
          Log("Error in Global_Error", 0, ex, ex.Message, ex.StackTrace)
        Catch ex2 As Exception
          'No write access into log folder
        End Try
      End Try
    End Sub

    'Private Sub Global_PreSendRequestHeaders(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreSendRequestHeaders
    '	If HttpContext.Current.Response IsNot Nothing Then
    '		HttpContext.Current.Response.Headers.Remove("ETag")
    '	End If
    'End Sub
  End Class
End Namespace
