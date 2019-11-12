
' Add an Imports directive and a reference for System.Net.Http.
Imports System.Net.Http

' Add the following Imports directive for System.Threading.
Imports System.Threading

Class MainWindow

    Private Async Sub startButton_Click(sender As Object, e As RoutedEventArgs)

        resultsTextBox.Clear()

        Try
            Dim contentLength As Integer = Await AccessTheWebAsync()

            resultsTextBox.Text &=
                String.Format(vbCrLf & "Length of the downloaded string: {0}." & vbCrLf, contentLength)

        Catch ex As Exception
            resultsTextBox.Text &= vbCrLf & "Download failed." & vbCrLf
        End Try

    End Sub


    Async Function AccessTheWebAsync() As Task(Of Integer)

        Dim client As HttpClient = New HttpClient()

        resultsTextBox.Text &=
            String.Format(vbCrLf & "Ready to download." & vbCrLf)

        ' You might need to slow things down to have a chance to cancel.
        Await Task.Delay(250)

        ' GetAsync returns a Task(Of HttpResponseMessage). 
        Dim response As HttpResponseMessage = Await client.GetAsync("http://msdn.microsoft.com/en-us/library/dd470362.aspx")

        ' Retrieve the website contents from the HttpResponseMessage.
        Dim urlContents As Byte() = Await response.Content.ReadAsByteArrayAsync()

        ' The result of the method is the length of the downloaded web site.
        Return urlContents.Length
    End Function

End Class


' Output:

' Ready to download.

' Length of the downloaded string: 158125.

