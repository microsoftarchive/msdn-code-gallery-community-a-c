namespace MVCRegistrationActivities
{
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class SendMail : AsyncCodeActivity
    {
        #region Constants and Fields

        private TaskCompletionSource<bool> mailCompletionSource;

        private SmtpClient smtpClient;

        private AsyncCallback workflowCallback;

        #endregion

        #region Public Properties

        public InArgument<IEnumerable<AlternateView>> AlternateViews { get; set; }

        public InArgument<IEnumerable<Attachment>> Attachments { get; set; }

        public InArgument<IEnumerable<string>> Bcc { get; set; }

        public InArgument<string> Body { get; set; }

        public InArgument<IEnumerable<object>> BodyArguments { get; set; }

        public InArgument<Encoding> BodyEncoding { get; set; }

        public InArgument<TransferEncoding?> BodyTransferEncoding { get; set; }

        public InArgument<IEnumerable<string>> CC { get; set; }

        public InArgument<DeliveryNotificationOptions?> DeliveryNotificationOptions { get; set; }

        [RequiredArgument]
        public InArgument<IEnumerable<string>> EmailTemplate { get; set; }

        [RequiredArgument]
        public InArgument<int> EmailTemplateIndex { get; set; }

        [RequiredArgument]
        public InArgument<string> From { get; set; }

        public InArgument<NameValueCollection> Headers { get; set; }

        public InArgument<Encoding> HeadersEncoding { get; set; }

        public InArgument<string> Host { get; set; }

        public InArgument<bool?> IsBodyHtml { get; set; }

        public InArgument<int?> Port { get; set; }

        public InArgument<MailPriority?> Priority { get; set; }

        public InArgument<IEnumerable<string>> ReplyToList { get; set; }

        public InArgument<string> Sender { get; set; }

        [RequiredArgument]
        public InArgument<string> Subject { get; set; }

        public InArgument<Encoding> SubjectEncoding { get; set; }

        public InArgument<IEnumerable<string>> To { get; set; }

        #endregion

        #region Methods

        protected override IAsyncResult BeginExecute(
            AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            this.InitializeSmtpClient(context);
            this.mailCompletionSource = new TaskCompletionSource<bool>(state);
            this.workflowCallback = callback;
            this.SendMailAsync(this.CreateMailMessage(context));
            return this.mailCompletionSource.Task;
        }

        protected override void Cancel(AsyncCodeActivityContext context)
        {
            this.smtpClient.SendAsyncCancel();
            this.mailCompletionSource.TrySetCanceled();
            base.Cancel(context);
        }

        protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            // Nothing to do here since there are no OutArgument properties
        }

        private MailMessage CreateMailMessage(AsyncCodeActivityContext context)
        {
            var message = new MailMessage
                {
                    From = new MailAddress(this.From.Get(context)),
                    Sender = new MailAddress(this.Sender.Get(context)),
                    Subject = this.Subject.Get(context)
                };

            var alternateViews = this.AlternateViews.Get(context);

            if (alternateViews != null)
            {
                foreach (var alternateView in alternateViews)
                {
                    message.AlternateViews.Add(alternateView);
                }
            }

            var attachments = this.Attachments.Get(context);

            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    message.Attachments.Add(attachment);
                }
            }

            var bcc = this.Bcc.Get(context);

            if (bcc != null)
            {
                foreach (var address in bcc)
                {
                    message.Bcc.Add(address);
                }
            }

            var bodyEncoding = this.BodyEncoding.Get(context);

            if (bodyEncoding != null)
            {
                message.BodyEncoding = bodyEncoding;
            }

            var cc = this.CC.Get(context);

            if (cc != null)
            {
                foreach (var address in cc)
                {
                    message.CC.Add(address);
                }
            }

            var deliveryNotificationOptions = this.DeliveryNotificationOptions.Get(context);

            if (deliveryNotificationOptions.HasValue)
            {
                message.DeliveryNotificationOptions = deliveryNotificationOptions.GetValueOrDefault();
            }

            var headers = this.Headers.Get(context);

            if (headers != null)
            {
                for (var i = 0; i < headers.Count; i++)
                {
                    message.Headers.Add(headers.AllKeys[i], headers[i]);
                }
            }

            var headersEncoding = this.HeadersEncoding.Get(context);

            if (headersEncoding != null)
            {
                message.HeadersEncoding = bodyEncoding;
            }

            var priority = this.Priority.Get(context);

            if (priority.HasValue)
            {
                message.Priority = priority.GetValueOrDefault();
            }

            var replyToList = this.ReplyToList.Get(context);

            if (replyToList != null)
            {
                foreach (var address in replyToList)
                {
                    message.ReplyToList.Add(address);
                }
            }

            var subjectEncoding = this.SubjectEncoding.Get(context);

            if (subjectEncoding != null)
            {
                message.SubjectEncoding = bodyEncoding;
            }

            var bodyTransferEncoding = this.BodyTransferEncoding.Get(context);

            if (bodyTransferEncoding.HasValue)
            {
                message.BodyTransferEncoding = bodyTransferEncoding.GetValueOrDefault();
            }

            var toAddresses = this.To.Get(context);

            if (toAddresses != null)
            {
                foreach (var address in toAddresses)
                {
                    message.To.Add(address);
                }
            }

            var body = this.Body.Get(context);

            if (string.IsNullOrWhiteSpace(body))
            {
                var emailTemplate = this.LoadMailTemplate(context);

                var bodyArgs = this.BodyArguments.Get(context);

                message.Body = bodyArgs != null ? string.Format(emailTemplate, (object[])bodyArgs) : emailTemplate;
            }
            else
            {
                message.Body = body;
            }

            var isBodyHtml = this.IsBodyHtml.Get(context);

            if (isBodyHtml.HasValue)
            {
                message.IsBodyHtml = isBodyHtml.GetValueOrDefault();
            }

            return message;
        }

        private void InitializeSmtpClient(ActivityContext context)
        {
            var host = this.Host.Get(context);

            // If no host was provided, config will supply it
            if (string.IsNullOrWhiteSpace(host))
            {
                this.smtpClient = new SmtpClient();
            }
            else
            {
                var port = this.Port.Get(context);
                if (port.HasValue && port.Value > 0)
                {
                    this.smtpClient = new SmtpClient(host, port.Value);
                }
                else
                {
                    this.smtpClient = new SmtpClient(host);
                }
            }
        }

        private string LoadMailTemplate(ActivityContext context)
        {
            return
                TemplateCache.GetTemplate(
                    this.EmailTemplate.Get(context).ElementAt(this.EmailTemplateIndex.Get(context)),
                    this.BodyEncoding.Get(context) ?? Encoding.ASCII);
        }

        private void SendMailAsync(MailMessage message)
        {
            this.smtpClient.SendCompleted += (sender, args) =>
                {
                    if (args.Error != null)
                    {
                        this.mailCompletionSource.TrySetException(args.Error);
                    }
                    else if (args.Cancelled)
                    {
                        this.mailCompletionSource.TrySetCanceled();
                    }

                    // You have to do the callback to complete the activity
                    this.workflowCallback(this.mailCompletionSource.Task);
                };

            this.smtpClient.SendAsync(message, null);
        }

        #endregion
    }
}