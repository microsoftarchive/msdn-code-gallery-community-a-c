Public Class ErrorPage
    Inherits Page

    Protected Sub Page_Load()

        ' Create safe error messages.
        Const generalErrorMsg As String = "A problem has occurred on this web site. Please try again. " & "If this error continues, please contact support."
        Const httpErrorMsg As String = "An HTTP error occurred. Page Not found. Please try again."
        Const unhandledErrorMsg As String = "The error was unhandled by application code."

        ' Display safe error message.
        FriendlyErrorMsg.Text = generalErrorMsg

        ' Determine where error was handled.
        Dim errorHandler1 As String = Request.QueryString("handler")
        If errorHandler1 Is Nothing Then
            errorHandler1 = "Error Page"
        End If

        ' Get the last error from the server.
        Dim ex As Exception = Server.GetLastError()

        ' Get the error number passed as a querystring value.
        Dim errorMsg As String = Request.QueryString("msg")
        If errorMsg = "404" Then
            ex = New HttpException(404, httpErrorMsg, ex)
            FriendlyErrorMsg.Text = ex.Message
        End If

        ' If the exception no longer exists, create a generic exception.
        If ex Is Nothing Then
            ex = New Exception(unhandledErrorMsg)
        End If

        ' Show error details to only you (developer). LOCAL ACCESS ONLY.
        If Request.IsLocal Then
            ' Detailed Error Message.
            ErrorDetailedMsg.Text = ex.Message

            ' Show where the error was handled.
            ErrorHandler.Text = errorHandler1

            ' Show local access details.
            DetailedErrorPanel.Visible = True

            If ex.InnerException IsNot Nothing Then
                InnerMessage.Text = ex.[GetType]().ToString() & "<br/>" & ex.InnerException.Message
                InnerTrace.Text = ex.InnerException.StackTrace
            Else
                InnerMessage.Text = ex.[GetType]().ToString()
                If ex.StackTrace IsNot Nothing Then
                    InnerTrace.Text = ex.StackTrace.ToString().TrimStart()
                End If
            End If
        End If

        ' Log the exception.
        ExceptionUtility.LogException(ex, errorHandler1)

        ' Clear the error from the server.
        Server.ClearError()
    End Sub

End Class