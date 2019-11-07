namespace MVCRegistrationActivities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Text;

    public class RegistrationData
    {
        #region Public Properties

        public TimeSpan ReminderDelay { get; set; }

        public IEnumerable<AlternateView> AlternateViews { get; set; }

        public IEnumerable<Attachment> Attachments { get; set; }

        public IEnumerable<string> Bcc { get; set; }

        public string Body { get; set; }

        public IEnumerable<object> BodyArguments { get; set; }

        public Encoding BodyEncoding { get; set; }

        public TransferEncoding? BodyTransferEncoding { get; set; }

        public IEnumerable<string> CC { get; set; }

        public DeliveryNotificationOptions? DeliveryNotificationOptions { get; set; }

        public IEnumerable<string> EmailTemplates { get; set; }

        public string From { get; set; }

        public NameValueCollection Headers { get; set; }

        public Encoding HeadersEncoding { get; set; }

        public string Host { get; set; }

        public bool? IsBodyHtml { get; set; }

        public object Model { get; set; }

        public int? Port { get; set; }

        public MailPriority? Priority { get; set; }

        public IEnumerable<string> ReplyToList { get; set; }

        public string Sender { get; set; }

        public string StylesUrl { get; set; }

        public string Subject { get; set; }

        public Encoding SubjectEncoding { get; set; }

        public IEnumerable<string> To { get; set; }

        public string UserName { get; set; }

        public string VerificationUrl { get; set; }

        public string UserEmail { get; set; }

        public string CancelUrl { get; set; }

        #endregion
    }
}