namespace MVCRegistrationActivities
{
    using System;

    internal class MailTemplate
    {
        #region Constructors and Destructors

        internal MailTemplate(DateTime dateTime)
        {
            this.LastWrite = dateTime;
        }

        #endregion

        #region Properties

        internal DateTime LastWrite { get; set; }

        internal string Template { get; set; }

        #endregion
    }
}