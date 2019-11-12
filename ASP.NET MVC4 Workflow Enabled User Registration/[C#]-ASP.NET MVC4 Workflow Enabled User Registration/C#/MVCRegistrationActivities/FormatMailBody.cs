namespace MVCRegistrationActivities
{
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public sealed class FormatMailBody : AsyncCodeActivity
    {
        #region Constants and Fields

        private const int CancelUrlIndex = 2;

        private const int InstanceIdIndex = 0;

        private const int StylesUrlIndex = 3;

        private const int TemplateIndex = 4;

        private const int VerificationUrlIndex = 1;

        #endregion

        #region Public Properties

        [RequiredArgument]
        public InArgument<RegistrationData> Data { get; set; }

        [RequiredArgument]
        public InArgument<int> EmailTemplateIndex { get; set; }

        public OutArgument<string> MailBody { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// When implemented in a derived class and using the specified execution context, callback method, and user state, enqueues an asynchronous activity in a run-time workflow. 
        /// </summary>
        /// <returns>
        /// The object that saves variable information for an instance of an asynchronous activity.
        /// </returns>
        /// <param name="context">Information that defines the execution environment for the <see cref="T:System.Activities.AsyncCodeActivity"/>.</param><param name="callback">The method to be called after the asynchronous activity and completion notification have occurred.</param><param name="state">An object that saves variable information for an instance of an asynchronous activity.</param>
        protected override IAsyncResult BeginExecute(
            AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            return
                ((Action<string, RegistrationData, Guid, int>)LoadTemplate).BeginInvoke(
                    this.Data.Get(context).EmailTemplates.ElementAt(this.EmailTemplateIndex.Get(context)),
                    this.Data.Get(context),
                    context.WorkflowInstanceId,
                    this.EmailTemplateIndex.Get(context),
                    callback,
                    state);
        }

        /// <summary>
        /// When implemented in a derived class and using the specified execution environment information, notifies the workflow runtime that the associated asynchronous activity operation has completed.
        /// </summary>
        /// <param name="context">Information that defines the execution environment for the <see cref="T:System.Activities.AsyncCodeActivity"/>.</param><param name="result">The implemented <see cref="T:System.IAsyncResult"/> that returns the status of an asynchronous activity when execution ends.</param>
        protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            this.MailBody.Set(context, this.Data.Get(context).Body);
        }

        private static void LoadTemplate(string path, RegistrationData data, Guid instanceId, int index)
        {
            var emailTemplate = TemplateCache.GetTemplate(path, data.BodyEncoding ?? Encoding.ASCII);

            var args = new object[5];

            args[InstanceIdIndex] = instanceId;
            args[VerificationUrlIndex] = data.VerificationUrl;
            args[CancelUrlIndex] = data.CancelUrl;
            args[StylesUrlIndex] = data.StylesUrl;
            args[TemplateIndex] = index;

            var body = string.Format(emailTemplate, data.BodyArguments.ToArray());
            body = ReplaceTokens(body, args);


            data.Body = string.Format(body, args.ToArray());
        }

        private static string ReplaceTokens(string format, IList<object> args)
        {
            var result = format.Replace("{InstanceId}", args[InstanceIdIndex].ToString());
            result = result.Replace("{VerificationUrl}", args[VerificationUrlIndex].ToString());
            result = result.Replace("{CancelUrl}", args[CancelUrlIndex].ToString());
            result = result.Replace("{StylesUrl}", args[StylesUrlIndex].ToString());
            result = result.Replace("{TemplateIndex}", args[TemplateIndex].ToString());
            return result;
        }

        #endregion
    }
}