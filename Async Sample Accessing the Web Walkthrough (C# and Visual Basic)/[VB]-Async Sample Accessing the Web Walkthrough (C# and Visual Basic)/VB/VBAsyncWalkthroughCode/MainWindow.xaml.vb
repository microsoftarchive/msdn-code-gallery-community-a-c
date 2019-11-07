

' Add the following Imports statements, and add a reference for System.Net.Http.
Imports System.Net.Http
Imports System.Net
Imports System.IO


Class MainWindow

    Async Sub startButton_Click(sender As Object, e As RoutedEventArgs) Handles startButton.Click

        resultsTextBox.Clear()

        ' Two-step async call.
        Dim sumTask = SumPageSizesAsync()
        Await sumTask

        '' One-step async call.
        'Await SumPageSizesAsync()

        resultsTextBox.Text += vbCrLf & "Control returned to button1_Click."

    End Sub


    Private Async Function SumPageSizesAsync() As Task

        ' Make a list of web addresses.
        Dim urlList As List(Of String) = SetUpURLList()

        Dim total = 0
        For Each url In urlList
            ' GetURLContentsAsync returns a task. At completion, the task
            ' produces a byte array.
            Dim getContentTask As Task(Of Byte()) = GetURLContentsAsync(url)
            Dim urlContent As Byte() = Await getContentTask

            ' The following line can replace the previous two assignment statements.
            'Dim urlContent As Byte() = Await GetURLContentsAsync(url)

            DisplayResults(url, urlContent)

            ' Update the total.
            total += urlContent.Length
        Next

        ' Display the total count for all of the web addresses.
        resultsTextBox.Text += String.Format(vbCrLf & vbCrLf &
                                             "Total bytes returned:  {0}" & vbCrLf, total)
    End Function


    Private Function SetUpURLList() As List(Of String)

        Dim urls = New List(Of String) From
            {
                "http://www.msdn.com",
                "http://msdn.microsoft.com/en-us/library/hh290136.aspx",
                "http://msdn.microsoft.com/en-us/library/ee256749.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290138.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
            }
        Return urls
    End Function

    Private Async Function GetURLContentsAsync(url As String) As Task(Of Byte())

        ' Initialize an HttpWebRequest for the current URL.
        Dim webReq = CType(WebRequest.Create(url), HttpWebRequest)

        ' Send the request to the Internet resource and wait for
        ' the response.
        Dim responseTask As Task(Of WebResponse) = webReq.GetResponseAsync()
        Dim response As WebResponse = Await responseTask

        ' The following line can replace the previous two assignment statements.
        'Dim response As WebResponse = Await webReq.GetResponseAsync()

        ' Get the data stream that is associated with the specified url.
        Dim responseStream As Stream = response.GetResponseStream()

        ' Read the bytes in responseStream and copy them to outputStream.  
        Dim content = New MemoryStream()

        ' CopyToAsync returns a Task, not a Task<T>.
        Dim copyTask As Task = responseStream.CopyToAsync(content)

        ' When copyTask is completed, content contains a copy of
        ' responseStream.
        Await copyTask

        ' The following line can replace the previous two lines
        'Await responseStream.CopyToAsync(content)

        ' Return the result as a byte array.
        Return content.ToArray()
    End Function


    Private Sub DisplayResults(url As String, content As Byte())

        ' Display the length of each web site. The string format 
        ' is designed to be used with a monospaced font, such as
        ' Lucida Console or Global Monospace.
        Dim bytes = content.Length
        ' Strip off the "http://".
        Dim displayURL = url.Split(New String() {"//"}, StringSplitOptions.None)(1)
        resultsTextBox.Text += String.Format(vbCrLf & "{0,-58} {1,8}", displayURL, bytes)
    End Sub

End Class

