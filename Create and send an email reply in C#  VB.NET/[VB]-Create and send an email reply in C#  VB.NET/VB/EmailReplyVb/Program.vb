Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
Imports System.Text
Imports S22.Imap

Module Program

    Private Const imapHost As String = "<HOST>" 'e.g. imap.gmail.com
    Private Const imapUser As String = "<USERNAME>"
    Private Const imapPassword As String = "<PASSWORD>"

    Private Const smtpHost As String = "<HOST>" 'e.g. smpt.gmail.com
    Private Const smtpUser As String = "<USERNAME>"
    Private Const smtpPassword As String = "<PASSWORD>"

    Private Const senderName As String = "<DISPLAY NAME>"

    Private Function GetMessages() As IEnumerable(Of MailMessage)
        Using client As New ImapClient(imapHost, 993, True)
            Console.WriteLine("Connected to " & imapHost & "."c)

            ' Login
            client.Login(imapUser, imapPassword, AuthMethod.Auto)
            Console.WriteLine("Authenticated.")

            ' Get a collection of all unseen messages in the INBOX folder
            client.DefaultMailbox = "INBOX"
            Dim uids As IEnumerable(Of UInteger) = client.Search(SearchCondition.Unseen())

            If (uids.Count = 0) Then Return Nothing

            Return client.GetMessages(uids)
        End Using
    End Function

    Private Function CreateReply(source As MailMessage) As MailMessage
        Dim reply As New MailMessage(New MailAddress(imapUser, "Sender"), source.From)

        ' Get message id And add 'In-Reply-To' header
        Dim id As String = source.Headers("Message-ID")
        reply.Headers.Add("In-Reply-To", id)

        ' Try to get 'References' header from the source and add it to the reply
        Dim references As String = source.Headers("References")
        If Not String.IsNullOrEmpty(references) Then references &= " "c
        reply.Headers.Add("References", references & id)

        ' Add subject
        If Not source.Subject.StartsWith("Re:", StringComparison.OrdinalIgnoreCase) Then
            reply.Subject = "Re: "
        End If

        reply.Subject &= source.Subject

        ' Add body
        Dim body As New StringBuilder()
        If source.IsBodyHtml Then
            body.Append("<p>Thank you for your email!</p>")
            body.Append("<p>We are currently out of the office, but we will reply as soon as possible.</p>")
            body.Append("<p>Best regards,<br>")
            body.Append(senderName)
            body.Append("</p>")
            body.Append("<br>")

            body.Append("<div>")
            If source.Date().HasValue Then body.AppendFormat("On {0}, ", source.Date().Value.ToString(CultureInfo.InvariantCulture))
            If Not String.IsNullOrEmpty(source.From.DisplayName) Then body.Append(source.From.DisplayName & " "c)

            body.AppendFormat("<<a href=""mailto:{0}"">{0}</a>> wrote:<br/>", source.From.Address)

            If Not String.IsNullOrEmpty(source.Body) Then
                body.Append("<blockqoute style=""margin:0 0 0 5px;border-left:2px blue solid;padding-left:5px"">")
                body.Append(source.Body)
                body.Append("</blockquote>")
            End If

            body.Append("</div>")
        Else
            body.AppendLine("Thank you for your email!")
            body.AppendLine()
            body.AppendLine("We are currently out of the office, but we will reply as soon as possible.")
            body.AppendLine()
            body.AppendLine("Best regards,")
            body.AppendLine(senderName)
            body.AppendLine()

            If source.Date().HasValue Then body.AppendFormat("On {0}, ", source.Date().Value.ToString(CultureInfo.InvariantCulture))

            body.Append(source.From)
            body.AppendLine(" wrote:")

            If Not String.IsNullOrEmpty(source.Body) Then
                body.AppendLine()
                body.Append("> " & source.Body.Replace(vbCrLf, vbCrLf & ">"c))
            End If
        End If

        reply.Body = body.ToString()
        reply.IsBodyHtml = source.IsBodyHtml

        Return reply
    End Function

    Private Sub SendReplies(replies As IEnumerable(Of MailMessage))
        Using client As New SmtpClient(smtpHost, 587)
            ' Set SMTP client properties
            client.EnableSsl = True
            client.UseDefaultCredentials = False
            client.Credentials = New NetworkCredential(smtpUser, smtpPassword)

            ' Send
            Dim retry As Boolean = True
            For Each msg As MailMessage In replies
                Try
                    client.Send(msg)
                    retry = True
                Catch ex As Exception
                    If Not retry Then
                        Console.WriteLine("Failed to send email reply to " & msg.To.ToString() & "."c)
                        Console.WriteLine("Exception: " & ex.Message)
                        Exit Sub
                    End If

                    retry = False
                Finally
                    msg.Dispose()
                End Try
            Next

            Console.WriteLine("All email replies successfully sent.")
        End Using
    End Sub

    Sub Main()
        ' Download unread messages from the server
        Dim messages As IEnumerable(Of MailMessage) = GetMessages()

        If messages IsNot Nothing Then
            Console.WriteLine(messages.Count().ToString() & " new email message(s).")

            ' Create message replies
            Dim replies As New List(Of MailMessage)()

            For Each msg As MailMessage In messages
                replies.Add(CreateReply(msg))
                msg.Dispose()
            Next

            ' Send replies
            SendReplies(replies)
        Else
            Console.WriteLine("No new email messages.")
        End If

        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub

End Module
