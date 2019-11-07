Imports System.IO

Public NotInheritable Class ExceptionUtility

    ' All methods are static, so this can be private
    Private Sub New()
    End Sub

    ' Log an Exception
    Public Shared Sub LogException(exc As Exception, source As String)
        ' Include logic for logging exceptions
        ' Get the absolute path to the log file
        Dim logFile As String = "App_Data/ErrorLog.txt"
        logFile = HttpContext.Current.Server.MapPath(logFile)

        ' Open the log file for append and write the log
        Dim sw As New StreamWriter(logFile, True)
        sw.WriteLine("********** {0} **********", DateTime.Now)
        If exc.InnerException IsNot Nothing Then
            sw.Write("Inner Exception Type: ")
            sw.WriteLine(exc.InnerException.[GetType]().ToString())
            sw.Write("Inner Exception: ")
            sw.WriteLine(exc.InnerException.Message)
            sw.Write("Inner Source: ")
            sw.WriteLine(exc.InnerException.Source)
            If exc.InnerException.StackTrace IsNot Nothing Then
                sw.WriteLine("Inner Stack Trace: ")
                sw.WriteLine(exc.InnerException.StackTrace)
            End If
        End If
        sw.Write("Exception Type: ")
        sw.WriteLine(exc.[GetType]().ToString())
        sw.WriteLine("Exception: " + exc.Message)
        sw.WriteLine("Source: " + source)
        sw.WriteLine("Stack Trace: ")
        If exc.StackTrace IsNot Nothing Then
            sw.WriteLine(exc.StackTrace)
            sw.WriteLine()
        End If
        sw.Close()
    End Sub

End Class