'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications
Option Explicit On
Option Strict On
Imports Microsoft.VisualBasic
Namespace WebApplication
	Public Module AntyDDoSAttacks
    Public IpDDoSAttacks As New Collections.Specialized.StringCollection
    Private ListHitsToStaticContent As New Collections.Generic.List(Of Hits)
    Private ListHitsToDynamicContent As New Collections.Generic.List(Of Hits)
    Private ListHitsToDynamicContentReferrer As New Collections.Generic.List(Of Hits)
    Private SyncListHitsToStaticContent As New Object
    Private SyncListHitsToDynamicContent As New Object
    Private SyncListHitsToDynamicContentReferrer As New Object

    Private TcpConnections As New Collections.Generic.Dictionary(Of String, Integer)
  
    Public Sub AntiAbnormalSimultaneousRequests(Request As HttpRequest)
      Const MaxQuickRequest As Integer = 6 'Max simultaneous TCP connections allowed before go in "low speed mode"
      Const Max As Integer = 10 'Max simultaneous TCP connections allowed
      Dim IP As String = Request.UserHostAddress
      SyncLock IpDDoSAttacks
        If IpDDoSAttacks.Contains(IP) Then
          StopResponse()
        End If
        Dim Counter As Integer
        SyncLock TcpConnections
          If TcpConnections.ContainsKey(IP) Then
            TcpConnections(IP) += 1
            Counter = TcpConnections(IP)
          Else
            TcpConnections.Add(IP, 1)
            Counter = 1
          End If
        End SyncLock

        'remowe thhis++++++++++
        'Static Record As Integer 'rIMUOVERE QUESTA LINEA
        'Static ADDED As New Collections.Specialized.StringCollection    'rIMUOVERE QUESTA LINEA
        'If Counter >= 7 Then
        ' SyncLock ADDED
        '   If Not ADDED.Contains(IP) Or Counter >= 8 Then
        '      ADDED.Add(IP)
        '      Log("RecordDDoS", 1000, Counter, IP, Request.UserAgent, HostUser, AbsoluteUri(Request))
        '    End If
        '  End SyncLock
        'End If
        '+++++++++++++++++++

        If Counter > Max Then
          IpDDoSAttacks.Add(IP)
          SyncLock TcpConnections
            TcpConnections.Remove(IP)
          End SyncLock
          If Setup.Security.DdosPrevention.LogEvents Then
            Dim UrlReferrer As String = Nothing : If Request.UrlReferrer IsNot Nothing Then UrlReferrer = Request.UrlReferrer.AbsoluteUri
            Log("DDoS_AntiAbnormalSimultaneousRequests", 1000, Counter.ToString, IP, Request.UserAgent, HostUser, AbsoluteUri(Request), UrlReferrer)
          End If
          StopResponse()
        ElseIf Counter > MaxQuickRequest Then
          'Threading.Thread.CurrentThread.Sleep(10000)
          Threading.Thread.CurrentThread.Priority = Threading.ThreadPriority.Lowest
        End If
      End SyncLock

    End Sub

    Sub AdviseRequestIsEnd(Request As HttpRequest)
      Dim IP As String
      Try
        IP = Request.UserHostAddress
      Catch ex As Exception
        Exit Sub
      End Try
      Dim Counter As Integer
      SyncLock TcpConnections
        If TcpConnections.ContainsKey(IP) Then
          Counter = TcpConnections(IP)
          Try
            If Counter = 1 Then
              TcpConnections.Remove(IP)
            Else
              TcpConnections(IP) -= 1
            End If
          Catch ex As Exception
            'if change the Config.Setup.Security.DetectDdosAttacks value an error will as occur
          End Try
        End If
      End SyncLock
    End Sub

    Sub TemporarilyCrawlersStoppingDuringOverload(Request As HttpRequest)
      If IsCrawler(Request) Then
        If MonitorOfResources.AddCurrentThreadToQueue Then
          If Setup.Security.DdosPrevention.LogEvents Then
            Dim UrlReferrer As String = Nothing : If Request.UrlReferrer IsNot Nothing Then UrlReferrer = Request.UrlReferrer.AbsoluteUri
            Log("DDoS_TemporarilyCrawlersStoppingDuringOverload", 1000, Request.UserHostAddress, Request.UserAgent, HostUser, AbsoluteUri(Request), UrlReferrer)
          End If
          StopResponse()
        End If
      End If
    End Sub


    Private Class Hits
      Public IP As String
      Public Time As Date
      Public Sub New(ByVal IP As String, ByVal Time As Date)
        Me.IP = IP
        Me.Time = Time
      End Sub
    End Class

    ' Private TrN As Integer
    Public Sub DisableTheSourcesOfAbnormalHighTraffic(Request As HttpRequest)
      Try
        Dim IpHit As String = Request.UserHostAddress
        If IpDDoSAttacks.Contains(IpHit) Then
          StopResponse()
        Else
          Dim TimeNow As Date = Now
          Dim MaxRequest As Integer
          Dim LimitRequestSlow As Integer
          Dim Seconds As Integer
          Dim ListHits As Collections.Generic.List(Of Hits)
          Dim SyncObject As Object
          Dim DirRequest As String = Mid(Request.Path, Len(Request.ApplicationPath) + 2)
          Dim Resources As String = Config.Resources

          'This routine use 2 different setting for detect DDoS Attach:
          '1 for statik + 1 for dynamic content

          If DirRequest.StartsWith(Resources, StringComparison.OrdinalIgnoreCase) Then
            'Is a request in directory resource
            'Is a request of static content
            Seconds = 60
            LimitRequestSlow = 120
            MaxRequest = 180
            ListHits = ListHitsToStaticContent
            SyncObject = SyncListHitsToStaticContent
          ElseIf Request.UrlReferrer IsNot Nothing AndAlso Request.UrlReferrer.Authority = Request.Url.Authority Then
            'Is a general ruequest of dynamic content with inside Referrer
            Seconds = 180
            LimitRequestSlow = 270
            MaxRequest = 540
            ListHits = ListHitsToDynamicContentReferrer
            SyncObject = SyncListHitsToDynamicContentReferrer
          Else
            'Is a general ruequest of dynamic content
            'Tipical for the spider 
            Seconds = 60
            LimitRequestSlow = 60
            MaxRequest = 70
            ListHits = ListHitsToDynamicContent
            SyncObject = SyncListHitsToDynamicContent
          End If
          Dim Counter As Integer
          Dim NHits As Integer
          Dim Hits As Hits
          Dim Sleep As Integer
          SyncLock SyncObject
            While NHits < ListHits.Count
              Try
                Hits = ListHits.Item(NHits)
              Catch ex As Exception
                Exit While
              End Try
              If Hits Is Nothing Then
                Try
                  ListHits.RemoveAt(NHits)
                Catch ex As Exception
                  Extension.Log("SpecificError", 1000, "AntyDDoSAttacks", "ListHits.RemoveAt", NHits.ToString)
                End Try
                Extension.Log("SpecificError", 1000, "AntyDDoSAttacks", "Hits Is Nothing", NHits.ToString)
              Else
                Dim SecDiff As Long = DateDiff(DateInterval.Second, Hits.Time, TimeNow)
                If SecDiff > Seconds Then
                  ListHits.Remove(Hits)
                Else
                  NHits += 1
                  If IpHit = Hits.IP Then
                    Counter += 1
                    If Counter > MaxRequest Then
                      'Add IP of current visitors to banned IP list for DDoS Attacks
                      'System.Threading.Thread.Sleep(1000)
                      IpDDoSAttacks.Add(IpHit)
                      If Setup.Security.DdosPrevention.LogEvents Then
                        Dim UrlReferrer As String = Nothing : If Request.UrlReferrer IsNot Nothing Then UrlReferrer = Request.UrlReferrer.AbsoluteUri
                        Log("DDoS_DisableTheSourcesOfAbnormalHighTraffic", 1000, Counter.ToString, IpHit, Request.UserAgent, HostUser, AbsoluteUri(Request), UrlReferrer)
                      End If
                      StopResponse()
                    ElseIf LimitRequestSlow <> 0 AndAlso Counter > LimitRequestSlow Then
                      'Sleep request
                      Sleep = CInt((Seconds / MaxRequest) * 1000 + 1)
                      Exit While
                    End If
                  End If
                End If
              End If
            End While
            Dim ThisHits As New Hits(IpHit, TimeNow)
            Try
              ListHits.Add(ThisHits)
            Catch ex As Exception
              Extension.Log("ErrorListHitsAdd", 1000, "AntyDDoSAttacks", "ListHits.Add", NHits.ToString)
            End Try
          End SyncLock
          If CBool(Sleep) Then
            System.Threading.Thread.Sleep(Sleep)
          End If
        End If
      Catch ex As Exception
        Extension.Log("SpecificError", 1000, "AntyDDoSAttacks", ex.Message)
      End Try
    End Sub

    Private Sub StopResponse()
      Dim Response As HttpResponse = HttpContext.Current.Response
      Response.Clear()
      If Setup.SEO.ErrorToBeUsedInCaseOfOverload = Configuration.SearchEngineOptimizationConfiguration.HttpError.Error503 Then
        Response.Status = "503 ServiceUnavailable"
        Response.StatusCode = 503
        Response.StatusDescription = "The server is currently unable to handle the request due to a temporary overloading or maintenance of the server."
      Else
        Response.Status = "408 RequestTimedOut"
        Response.StatusCode = 408
        Response.StatusDescription = "For some reason the server took too much time processing your request. Net congestion is the most likely reason."
      End If
      Response.Flush()
      Response.End()
    End Sub

  End Module
End Namespace
