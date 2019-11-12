namespace MVCRegistrationActivities
{
    using System.Activities.DurableInstancing;
    using System.Activities.Persistence;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Linq;

    public class RegistrationPeristenceParticipant : PersistenceParticipant
    {
        #region Constants and Fields

        public const string PromotionName = "Registration";

        /// <summary>
        /// The x ns.
        /// </summary>
        /// <remarks>
        /// TODO: Set an appropriate namespace
        /// </remarks>
        public static readonly XNamespace Xns = XNamespace.Get("http://schemas.microsoft.com/samples/MVC/Registration");

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets EmailName.
        /// </summary>
        public static string EmailName
        {
            get
            {
                return "Email";
            }
        }

        /// <summary>
        /// Gets EmailXName.
        /// </summary>
        public static XName EmailXName
        {
            get
            {
                return Xns.GetName(EmailName);
            }
        }

        /// <summary>
        /// Gets RegistrationName.
        /// </summary>
        public static string RegistrationName
        {
            get
            {
                return "Registration";
            }
        }

        /// <summary>
        /// Gets RegistrationXName.
        /// </summary>
        public static XName RegistrationXName
        {
            get
            {
                return Xns.GetName(RegistrationName);
            }
        }

        /// <summary>
        /// Gets UsernameName.
        /// </summary>
        public static string UsernameName
        {
            get
            {
                return "UserName";
            }
        }

        /// <summary>
        /// Gets UsernameXName.
        /// </summary>
        public static XName UsernameXName
        {
            get
            {
                return Xns.GetName(UsernameName);
            }
        }

        public string Email { get; set; }

        public string UserName { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The promote.
        /// </summary>
        /// <param name="instanceStore">
        /// The instance store.
        /// </param>
        public static void Promote(SqlWorkflowInstanceStore instanceStore)
        {
            instanceStore.Promote(RegistrationName, new List<XName> { EmailXName, UsernameXName }, null);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The collect values.
        /// </summary>
        /// <param name="readWriteValues">
        /// The read write values.
        /// </param>
        /// <param name="writeOnlyValues">
        /// The write only values.
        /// </param>
        protected override void CollectValues(
            out IDictionary<XName, object> readWriteValues, out IDictionary<XName, object> writeOnlyValues)
        {
            readWriteValues = null;
            writeOnlyValues = new Dictionary<XName, object>
                { { EmailXName, this.Email }, { UsernameXName, this.UserName } };

            Trace.WriteLine(string.Format("CollectValues Email: {0}, UserName: {1}", this.Email, this.UserName));
        }

        #endregion
    }
}