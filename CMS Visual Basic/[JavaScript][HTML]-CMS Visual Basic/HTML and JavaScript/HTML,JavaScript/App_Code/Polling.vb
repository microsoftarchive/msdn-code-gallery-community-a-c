'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Namespace WebApplication
	Public Module Polling
    'Public Delivered As Boolean
		Private LastCheck As Date = Today
    Public WithEvents Timer As New Timers.Timer(60000 * 10)  'Every 10 minutes
    Public WithEvents UpdateDefaultLinks As Timers.Timer = TimerSetDefaultLinks()
    Private Sub UpdateDefaultLinks_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles UpdateDefaultLinks.Elapsed
      ContextualLink.PrepareAndCollectContextualLinks()
    End Sub
		Private Function TimerSetDefaultLinks() As Timers.Timer
			TimerSetDefaultLinks = New Timers.Timer(60000 * 10)	'Every 10 minutes
			TimerSetDefaultLinks.AutoReset = False
		End Function
		Private Sub Timer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer.Elapsed
			'Execute operation in polling
			'Skype.CheckSkypecast()

			If Today <> LastCheck Then
				'Execute daily operation
				LastCheck = Today
				Dim LastExecutionOfDailyOperation As Date = PersistentDate("LastExecutionOfDailyOperation")
				If Today <> LastExecutionOfDailyOperation Then
					PersistentDate("LastExecutionOfDailyOperation") = Today
					UpdateCurrencyExchange()
          CleanCacheMalwareWebsiteCheck()
					CleanCacheReadFromWeb()
					RaiseDailyOperationEvent()
				End If
			End If
		End Sub

    Public ResourceMonitor As New MonitorOfResources
    Public Class MonitorOfResources
      Private Shared WithEvents PerformanceMonitor As Timers.Timer = DefaultTimer()
      Private Shared Function DefaultTimer() As Timers.Timer
        DefaultTimer = Nothing
        Try
          CpuCounter = New Diagnostics.PerformanceCounter("Processor", "% Processor Time", "_Total")
          DefaultTimer = New Timers.Timer(1000) 'Every 1 second
          DefaultTimer.Start()
        Catch
          'Service not available, then timer off
        End Try
        Return DefaultTimer
      End Function
      Public Shared Function IsActive() As Boolean
        Return PerformanceMonitor IsNot Nothing
      End Function

      Public Shared Function CpuUsageIsAvailable() As Boolean
        Return CpuCounter IsNot Nothing
      End Function
      Public Shared Function CpuUsageCurrent() As Single
        SyncLock CpuUsageLastMinute
          Return CpuUsageLastMinute(0)
        End SyncLock
      End Function
      Public Shared Function CpuUsageLast60Sec() As Single()
        'The first element is actual cpu usage
        SyncLock CpuUsageLastMinute
          Dim CpuUsage(59) As Single
          Array.Copy(CpuUsageLastMinute, CpuUsage, 59)
          Return CpuUsage
        End SyncLock
      End Function
      Public Shared Function CpuUsageLast1440Min() As Single()
        '1440 Min = 24 h
        'The first element is actual cpu usage
        SyncLock CpuUsageLastDay
          Dim CpuUsage(1439) As Single
          Array.Copy(CpuUsageLastDay, CpuUsage, 1439)
          Return CpuUsage
        End SyncLock
      End Function
      Private Shared CpuUsageLastMinute(59) As Single
      Private Shared CpuUsageLastDay(1440) As Single '1440 min. = 24 h.
      Private Shared CpuCounter As Diagnostics.PerformanceCounter
      Private Shared Sub PerformanceMonitor_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles PerformanceMonitor.Elapsed
        Static SecCounter As Integer
        If SecCounter = 60 Then
          SecCounter = 1
        Else
          SecCounter += 1
        End If
        Dim CpuUsage As Single = CpuCounter.NextValue
        SyncLock CpuUsageLastMinute
          System.Array.Copy(CpuUsageLastMinute, 0, CpuUsageLastMinute, 1, CpuUsageLastMinute.Count - 1)
          CpuUsageLastMinute(0) = CpuUsage
        End SyncLock
        If SecCounter = 60 Then
          SyncLock CpuUsageLastDay
            System.Array.Copy(CpuUsageLastDay, 0, CpuUsageLastDay, 1, CpuUsageLastDay.Count - 1)
            SyncLock CpuUsageLastMinute
              CpuUsageLastDay(0) = CpuUsageLastMinute.Average
            End SyncLock
          End SyncLock
        End If
        SyncLock ThreadsQueue
          If CpuUsage < CpuOverload Then
            'Unblock all thread is CPU is not in overload state
            For Each Thread In ThreadsQueue.ToArray
              ThreadsQueue.Remove(Thread)
              Thread.Semaphore.Release()
            Next
          Else
            'Remove thread in timeout
            For Each Thread In ThreadsQueue.ToArray
              If Thread.TimeOut >= Now Then
                Thread.Feedback = True
                ThreadsQueue.Remove(Thread)
                Thread.Semaphore.Release()
              End If
            Next
          End If
        End SyncLock
      End Sub
      Private Class ThreadsQueueElement
        Public TimeOut As Date
        Public Semaphore As Threading.Semaphore
        Public Feedback As Boolean
      End Class
      Private Shared ThreadsQueue As New List(Of ThreadsQueueElement)
      Private Const CpuOverload As Single = 80.0F '80% CPU Usage
      Public Shared Function AddCurrentThreadToQueue() As Boolean
        'Return True if the current thread run in CPU saturation period  
        If CpuCounter IsNot Nothing Then
          Const PeriodLenghtSeconds As Integer = 10 'Time out period
          If CpuUsageCurrent() >= CpuOverload Then
            Dim ThreadsQueueElement As New ThreadsQueueElement
            ThreadsQueueElement.TimeOut = Now.AddSeconds(PeriodLenghtSeconds) 'Set the timeout
            ThreadsQueueElement.Semaphore = New Threading.Semaphore(0, 1)
            SyncLock ThreadsQueue
              ThreadsQueue.Add(ThreadsQueueElement)
            End SyncLock
            ThreadsQueueElement.Semaphore.WaitOne()
            Return ThreadsQueueElement.Feedback
          End If
        End If
        Return False
      End Function
    End Class
  End Module
End Namespace