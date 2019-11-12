using S22.Imap;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EmailReplyCs
{
    class Program
    {
        private const string imapHost = "<HOST>"; // e.g. imap.gmail.com
        private const string imapUser = "<USERNAME>";
        private const string imapPassword = "<PASSWORD>";

        private const string smtpHost = "<HOST>"; // e.g. smpt.gmail.com
        private const string smtpUser = "<USERNAME>";
        private const string smtpPassword = "<PASSWORD>";

        private const string senderName = "<DISPLAY NAME>";

        private static IEnumerable<MailMessage> GetMessages()
        {
            using (ImapClient client = new ImapClient(imapHost, 993, true))
            {
                Console.WriteLine("Connected to " + imapHost + '.');

                // Login
                client.Login(imapUser, imapPassword, AuthMethod.Auto);
                Console.WriteLine("Authenticated.");

                // Get a collection of all unseen messages in the INBOX folder
                client.DefaultMailbox = "INBOX";
                IEnumerable<uint> uids = client.Search(SearchCondition.Unseen());

                if (uids.Count() == 0)
                    return null;

                return client.GetMessages(uids);
            }
        }

        private static MailMessage CreateReply(MailMessage source)
        {
            MailMessage reply = new MailMessage(new MailAddress(imapUser, "Sender"), source.From);

            // Get message id and add 'In-Reply-To' header
            string id = source.Headers["Message-ID"];
            reply.Headers.Add("In-Reply-To", id);

            // Try to get 'References' header from the source and add it to the reply
            string references = source.Headers["References"];

            if (!string.IsNullOrEmpty(references))
                references += ' ';

            reply.Headers.Add("References", references + id);

            // Add subject
            if (!source.Subject.StartsWith("Re:", StringComparison.OrdinalIgnoreCase))
                reply.Subject = "Re: ";

            reply.Subject += source.Subject;

            // Add body
            StringBuilder body = new StringBuilder();
            if (source.IsBodyHtml)
            {
                body.Append("<p>Thank you for your email!</p>");
                body.Append("<p>We are currently out of the office, but we will reply as soon as possible.</p>");
                body.Append("<p>Best regards,<br>");
                body.Append(senderName);
                body.Append("</p>");
                body.Append("<br>");

                body.Append("<div>");
                if (source.Date().HasValue)
                    body.AppendFormat("On {0}, ", source.Date().Value.ToString(CultureInfo.InvariantCulture));

                if (!string.IsNullOrEmpty(source.From.DisplayName))
                    body.Append(source.From.DisplayName + ' ');

                body.AppendFormat("<<a href=\"mailto:{0}\">{0}</a>> wrote:<br/>", source.From.Address);

                if (!string.IsNullOrEmpty(source.Body))
                {
                    body.Append("<blockqoute style=\"margin: 0 0 0 5px;border-left:2px blue solid;padding-left:5px\">");
                    body.Append(source.Body);
                    body.Append("</blockquote>");
                }

                body.Append("</div>");
            }
            else
            {
                body.AppendLine("Thank you for your email!");
                body.AppendLine();
                body.AppendLine("We are currently out of the office, but we will reply as soon as possible.");
                body.AppendLine();
                body.AppendLine("Best regards,");
                body.AppendLine(senderName);
                body.AppendLine();

                if (source.Date().HasValue)
                    body.AppendFormat("On {0}, ", source.Date().Value.ToString(CultureInfo.InvariantCulture));

                body.Append(source.From);
                body.AppendLine(" wrote:");

                if (!string.IsNullOrEmpty(source.Body))
                {
                    body.AppendLine();
                    body.Append("> " + source.Body.Replace("\r\n", "\r\n> "));
                }
            }

            reply.Body = body.ToString();
            reply.IsBodyHtml = source.IsBodyHtml;

            return reply;
        }

        private static void SendReplies(IEnumerable<MailMessage> replies)
        {
            using (SmtpClient client = new SmtpClient(smtpHost, 587))
            {
                // Set SMTP client properties
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(smtpUser, smtpPassword);

                // Send
                bool retry = true;
                foreach (MailMessage msg in replies)
                {
                    try
                    {
                        client.Send(msg);
                        retry = true;
                    }
                    catch (Exception ex)
                    {
                        if (!retry)
                        {
                            Console.WriteLine("Failed to send email reply to " + msg.To.ToString() + '.');
                            Console.WriteLine("Exception: " + ex.Message);
                            return;
                        }

                        retry = false;
                    }
                    finally
                    {
                        msg.Dispose();
                    }
                }

                Console.WriteLine("All email replies successfully sent.");
            }
        }

        static void Main(string[] args)
        {
            // Download unread messages from the server
            IEnumerable<MailMessage> messages = GetMessages();
            if (messages != null)
            {
                Console.WriteLine(messages.Count().ToString() + " new email message(s).");

                // Create message replies
                List<MailMessage> replies = new List<MailMessage>();
                foreach (MailMessage msg in messages)
                {
                    replies.Add(CreateReply(msg));
                    msg.Dispose();
                }

                // Send replies
                SendReplies(replies);
            }
            else
            {
                Console.WriteLine("No new email messages.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
