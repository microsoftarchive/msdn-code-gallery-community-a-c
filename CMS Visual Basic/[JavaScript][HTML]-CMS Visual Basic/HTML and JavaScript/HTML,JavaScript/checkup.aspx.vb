'CheckUp plugin by Andrea Bruno
Imports WebApplication
Partial Class CheckUp
 
  Inherits System.Web.UI.Page
  Private Setting As SubSite
  Private CurrentUser As User

  Shared WithEvents Plugin As PluginManager.Plugin = Initialize()
  Shared Function Initialize() As PluginManager.Plugin
    If Plugin Is Nothing Then Plugin = New PluginManager.Plugin(AddressOf Description, Authentication.User.RoleType.Supervisor, True, , PluginManager.Plugin.Characteristics.CorePlugin)
    Return Plugin
  End Function
  Shared Sub New()
    Initialize()
  End Sub

  Shared Function Description(ByVal Language As LanguageManager.Language, ByVal ShortDescription As Boolean) As String
    If ShortDescription Then
      'Return the short description of plugin
      Select Case Language
        Case Else
          Return "CheckUp"
      End Select
    Else
      'Return the long description of plugin
      Select Case Language
        Case LanguageManager.Language.Italian
          Return "Questo plugin esegue un rapido controllo del server e verifica il corretto funzionamento della applicazione"
        Case Else
          Return "This plugin performs a quick check of the server and verifies the correct operation of the application"
      End Select
    End If
  End Function

  'Protected Sub CheckUp_Init(sender As Object, e As EventArgs) Handles Me.Init
  '  If Request.QueryString("action") = "ip" Then
  '    Response.ContentType = "text/plain"
  '    Response.Write(Request.UserHostAddress)
  '    Response.End()
  '  End If
  'End Sub

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Setting = CurrentSetting()
    CurrentUser = Authentication.CurrentUser
    Dim MasterPage As MasterPage = SetMasterPage(Me, , , False)

    MasterPage.TitleDocument = Description(Setting.Language, True)
    MasterPage.Description = Description(Setting.Language, False)


    If Not MonitorOfResources.IsActive Then
      Performance.Rows(2).Visible = False
      Performance.Rows(3).Visible = False
      Performance.Rows(4).Visible = False
    Else
      Page.Header.Controls.Add(New LiteralControl("<script type='text/javascript'src='https://www.google.com/jsapi'></script>"))
      'Add chart cpu average: https://google-developers.appspot.com/chart/interactive/docs/gallery/gauge
      Page.Header.Controls.Add(New LiteralControl("<script type='text/javascript'>google.load('visualization','1',{packages:['gauge']});google.setOnLoadCallback(drawChart);function drawChart(){var data=google.visualization.arrayToDataTable([['Label','Value'],['Cpu'," & CInt(Polling.MonitorOfResources.CpuUsageLast60Sec.Average) & "]]);var options={width:400,height:120,redFrom:90,redTo:100,yellowFrom:75,yellowTo:90,minorTicks:5};var chart=new google.visualization.Gauge(document.getElementById('ChartCpuAverage'));chart.draw(data,options)}</script>"))

      'Add chart cpu usage last 60 sec.
      Dim JavaValues As String = Nothing
      Dim CpuUsage60Sec() As Single = Polling.MonitorOfResources.CpuUsageLast60Sec
      For N = 0 To 59
        JavaValues &= "['" & N & "'," & CInt(CpuUsage60Sec(N)) & "]"
        If N <> 59 Then JavaValues &= ","
      Next
      Page.Header.Controls.Add(New LiteralControl("<script type='text/javascript'>google.load('visualization','1',{packages:['corechart']});google.setOnLoadCallback(drawChart);function drawChart(){var data=google.visualization.arrayToDataTable([['Sec.','Cpu']," & JavaValues & "]);var options={title:'CPU usage',vAxis:{minValue:0,maxValue:100},hAxis:{title:'Last 60 sec.',titleTextStyle:{color:'red'}}};var chart=new google.visualization.AreaChart(document.getElementById('ChartCpuUsage60Sec'));chart.draw(data,options)}</script>"))

      'Add chart cpu usage last 24 h.
      JavaValues = ""
      Dim CpuUsage24H() As Single = Polling.MonitorOfResources.CpuUsageLast1440Min
      For N = 0 To 1439
        JavaValues &= "[" & (N / 60).ToString(Globalization.CultureInfo.InvariantCulture) & "," & CInt(CpuUsage24H(N)) & "]"
        If N <> 1439 Then JavaValues &= ","
      Next
      Page.Header.Controls.Add(New LiteralControl("<script type='text/javascript'>google.load('visualization','1',{packages:['corechart']});google.setOnLoadCallback(drawChart);function drawChart(){var data=google.visualization.arrayToDataTable([['Hours','Cpu']," & JavaValues & "]);var options={title:'CPU usage',vAxis:{minValue:0,maxValue:100},hAxis:{minValue:0,maxValue:24,gridlines:{count:24},title:'Last 24 hours',titleTextStyle:{color:'red'}}};var chart=new google.visualization.AreaChart(document.getElementById('ChartCpuUsage24H'));chart.draw(data,options)}</script>"))
    End If


    Dim IdIp As Integer
    If AntyDDoSAttacks.IpDDoSAttacks.Count Then
      Panel1.Visible = True
    End If

    While IdIp < AntyDDoSAttacks.IpDDoSAttacks.Count
      Dim HyperLink As New HyperLink
      HyperLink.Text = HttpUtility.HtmlEncode(AntyDDoSAttacks.IpDDoSAttacks.Item(IdIp))
      HyperLink.Target = "_blank"
      HyperLink.NavigateUrl = NavigateUrlIpLookup & AntyDDoSAttacks.IpDDoSAttacks.Item(IdIp)
      DDoSIp.Controls.Add(HyperLink)
      DDoSIp.Controls.Add(Literal(" "))
      IdIp += 1
    End While

    UserStats.Controls.Add(Components.OnlineUser(Setting, , True))
    Path.Text = AppDomain.CurrentDomain.BaseDirectory

    Try
      ComputerName.Text = My.Computer.Name
    Catch ex As Exception
    End Try

    For Each Server As String In Servers()
      If MultiServer.Text <> "" Then
        MultiServer.Text &= ","
      End If
      MultiServer.Text &= Server
    Next

    Try
      Dim MB As Long
      Dim Disk As New System.IO.DriveInfo(AppDomain.CurrentDomain.BaseDirectory)
      MB = Disk.TotalFreeSpace / 1024 ^ 2

      'Dim b1(1), b2(1), b3(1) As Long
      'com.ms.win32.Kernel32.GetDiskFreeSpaceEx(AppDomain.CurrentDomain.BaseDirectory, b1, b2, b3)
      'MB = b1(0) / 1024 ^ 2

      DiskFreeSpace.Text = MB & " Mb"
      If MB < 100 Then
        SetWarning(DiskFreeSpace)
      End If
    Catch ex As Exception

    End Try

    Try
      AvailablePhysicalMemory.Text = CLng(My.Computer.Info.AvailablePhysicalMemory / 1024 ^ 2) & " Mb"
    Catch ex As Exception
    End Try

    Try
      AvailableVirtualMemory.Text = CLng(My.Computer.Info.AvailableVirtualMemory / 1024 ^ 2) & " Mb"
    Catch ex As Exception
    End Try

    Try
      TotalPhysicalMemory.Text = CLng(My.Computer.Info.TotalPhysicalMemory / 1024 ^ 2) & " Mb"
    Catch ex As Exception
    End Try

    Try
      TotalVirtualMemory.Text = CLng(My.Computer.Info.TotalVirtualMemory / 1024 ^ 2) & " Mb"
    Catch ex As Exception
    End Try

    Try
      OSFullName.Text = My.Computer.Info.OSFullName
    Catch ex As Exception
    End Try
    Try
      OSPlatform.Text = My.Computer.Info.OSPlatform
    Catch ex As Exception
    End Try

    Try
      OSVersion.Text = My.Computer.Info.OSVersion
    Catch ex As Exception
    End Try

    TimeServer.Text = Now
    TimeUTC.Text = Date.UtcNow

    Try
      ServerTimeOut.Text = Context.Server.ScriptTimeout & " Sec."
    Catch ex As Exception
    End Try

    Try
      IP.Text = MyIp()
    Catch ex As Exception
    End Try

    Try
      Dim Ticks As Long
      Dim Priority As Threading.ThreadPriority = Threading.Thread.CurrentThread.Priority
      Threading.Thread.CurrentThread.Priority = Threading.ThreadPriority.Highest
      Ticks = Now.Ticks
      Dim Record As Integer = Integer.MinValue
      Do
      Loop Until Ticks <> Now.Ticks
      'For Test As Integer = 1 To 10
      Dim Score As Integer = Integer.MinValue
      Dim EndBenchmark As Date = Now.AddMilliseconds(1000)
      Do
        Threading.Tasks.Parallel.For(0, 64, Sub(x)
                                              Threading.Thread.CurrentThread.Priority = Threading.ThreadPriority.Highest
                                              For N = 0 To 64
                                                Dim A As String = "a"
                                                Dim Parent As HtmlAnchor
                                                Parent = New HtmlAnchor
                                                Dim Control As HtmlGenericControl, Html As String
                                                Control = New HtmlGenericControl("section")
                                                Parent.Attributes.Add(CStr(1) & "b", CStr(1) & "b")
                                                Parent.Controls.Add(Control)
                                                Html = Control.InnerHtml
                                                Score += 1
                                                If Now >= EndBenchmark Then
                                                  Exit Sub
                                                End If
                                              Next
                                            End Sub)
      Loop Until Now >= EndBenchmark
      If Score > Record Then
        Record = Score
      End If
      'Next
      Threading.Thread.CurrentThread.Priority = Priority
      Dim ScoreResult As Long = CLng(Int(Record)) - CLng(Integer.MinValue)
      Benchmark.Text = Int(ScoreResult / 134)
    Catch ex As Exception
    End Try


    Select Case ErrorLog.ErrorDiskSpacePreserved
      Case 0
        Me.ErrorDiskSpacePreserved.Text = "None"
      Case Is > 0
        Me.ErrorDiskSpacePreserved.Text = ErrorLog.ErrorDiskSpacePreserved
        SetWarning(ErrorDiskSpacePreserved)
      Case -1
        Me.ErrorDiskSpacePreserved.Text = "Sub dir """ & PreserveDiskSpaceDirectory & """ not exists!"
        SetWarning(ErrorDiskSpacePreserved)
      Case -2
        Me.ErrorDiskSpacePreserved.Text = "Sub dir """ & PreserveDiskSpaceDirectory & """ not writable!"
        SetWarning(ErrorDiskSpacePreserved)
    End Select

    Dim DomainsNoConnect As Collections.Specialized.StringCollection = AllDomainNamesNotConnected()
    If DomainsNoConnect IsNot Nothing Then
      For Each Domain As String In DomainsNoConnect
        Dim HiperLink As New HyperLink
        HiperLink.NavigateUrl = "http://" & Domain
        HiperLink.Text = HttpUtility.HtmlEncode(Domain)
        HiperLink.Target = "_blank"
        DomainsNotConnected.Controls.Add(HiperLink)
        DomainsNotConnected.Controls.Add(BR)
      Next
    End If

    Dim Domains As Collections.Specialized.StringCollection = AllDomainNames()
    If Domains IsNot Nothing Then
      For Each Domain As String In Domains
        Dim DomainSetting As DomainConfiguration = DomainConfiguration.Load(Domain)
        If DomainSetting.Redirect = "" Then
          If Not DomainsNoConnect.Contains(Domain) Then
            Dim Url = Href(Domain, True, "default.aspx", QueryKey.Show, DefaultPageShowType.Ip)
            Dim Ok As Boolean
            Try
              ReadHtmlFromWeb(Url, , 15000)
              Ok = True
            Catch ex As Exception
              Ok = False
            End Try
            If Ok = False Then
              Dim HiperLink As New HyperLink
              HiperLink.NavigateUrl = "http://" & Domain
              HiperLink.Text = HttpUtility.HtmlEncode(Domain)
              HiperLink.Target = "_blank"
              DomainsNotResponse.Controls.Add(HiperLink)
              DomainsNotResponse.Controls.Add(BR)
            End If
          End If
        End If
      Next
    End If

    If ExchangeRateUnavailable Then
      ErrorExchangeRate.Text = "Unavailable"
      SetWarning(ErrorExchangeRate)
    Else
      ErrorExchangeRate.Text = "None"
    End If

    If ErrorSendEmail IsNot Nothing Then
      ErrorSendEmail.Text = ErrorLog.ErrorSendEmail
      SetWarning(ErrorSendEmail)
    Else
      ErrorSendEmail.Text = "None"
    End If

  End Sub

  Private Sub SetWarning(ByVal Label As WebControls.Label)
    Label.BackColor = Drawing.Color.Yellow
    Label.ForeColor = Drawing.Color.Red
  End Sub

End Class
