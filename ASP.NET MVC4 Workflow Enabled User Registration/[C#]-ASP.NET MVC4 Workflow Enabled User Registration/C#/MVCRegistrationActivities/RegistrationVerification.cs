namespace MVCRegistrationActivities
{
    using System;
    using System.Activities;
    using System.Activities.DurableInstancing;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.DurableInstancing;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using Microsoft.Activities.Extensions.Diagnostics;

    public class RegistrationVerification<TActivity> : RegistrationVerificationBase
        where TActivity : Activity, new()
    {
        #region Constants and Fields

        public static TActivity RegistrationWorkflow;

        /// <summary>
        /// The find existing instances sql.
        /// </summary>
        private const string FindExistingInstancesSql = @"SELECT InstanceId, Value1      
FROM [System.Activities.DurableInstancing].[InstancePromotedProperties]
WHERE PromotionName = @PromotionName 
AND Value1 = @Email";

        private const string VerificationCodeParameter = "verificationCode";

        #endregion

        #region Constructors and Destructors

        static RegistrationVerification()
        {
            // ReSharper disable AssignNullToNotNullAttribute
            WorkflowHostTypeName = XName.Get(typeof(TActivity).FullName, "MVCRegistration");
            // ReSharper restore AssignNullToNotNullAttribute

            var instanceDetectionSetting = ConfigurationManager.AppSettings["InstanceDetectionPeriod"];
            if (!string.IsNullOrWhiteSpace(instanceDetectionSetting))
            {
                if (!int.TryParse(instanceDetectionSetting, out InstanceDetectionPeriod))
                {
                    throw new InvalidOperationException(
                        "Invalid InstanceDetectionPeriod in configuration.  Must be a number in seconds");
                }
            }

            InstanceStore =
                new SqlWorkflowInstanceStore(ConfigurationManager.ConnectionStrings["InstanceStore"].ConnectionString)
                    { RunnableInstancesDetectionPeriod = TimeSpan.FromSeconds(InstanceDetectionPeriod) };

            RegistrationPeristenceParticipant.Promote(InstanceStore);

            CreateInstanceStoreOwner();
        }

        #endregion

        #region Public Methods and Operators

        public static Guid GetInstanceIdFromEmail(string email)
        {
            // Get Workflow ID of user by querying promoted properties
            using (
                var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["InstanceStore"].ConnectionString))
            {
                var command = new SqlCommand(FindExistingInstancesSql, connection);

                command.Parameters.AddWithValue("@PromotionName", RegistrationPeristenceParticipant.PromotionName);
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                var dataReader = command.ExecuteReader();
                dataReader.Read();

                return dataReader.HasRows ? dataReader.GetGuid(0) : Guid.Empty;
            }
        }

        public static void MonitorRegistrations()
        {
            Task.Factory.StartNew(MonitorAndRun);
        }

        public bool CancelRegistration(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("email");
            }

            var instanceId = GetInstanceIdFromEmail(email);
            return instanceId != Guid.Empty && ResumeWorkflow(instanceId, RegistrationCommand.Cancel);
        }

        public bool CancelRegistration(Guid instanceId)
        {
            return ResumeWorkflow(instanceId, RegistrationCommand.Cancel);
        }

        public bool CompleteRegistration(string verificationCode)
        {
            Guid instanceId;
            return Guid.TryParse(verificationCode, out instanceId)
                   && ResumeWorkflow(instanceId, RegistrationCommand.Confirm);
        }

        public bool ResendRegistrationEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("email");
            }

            return ResumeWorkflow(email, RegistrationCommand.SendMail);
        }

        public Guid VerifyRegistration(RegistrationData data)
        {
            if (RegistrationWorkflow == null)
            {
                RegistrationWorkflow = new TActivity();
            }

            var host = CreateWorkflowApplication(data);

            data.VerificationUrl = this.AddVerificationCode(data.VerificationUrl, host.Id);
            data.CancelUrl = this.AddVerificationCode(data.CancelUrl, host.Id);
            host.Run();

            return host.Id;
        }

        #endregion

        #region Methods

        private static void CreateInstanceStoreOwner()
        {
            InstanceHandle = InstanceStore.CreateInstanceHandle();

            var ownerCommand = new CreateWorkflowOwnerCommand();
            ownerCommand.InstanceOwnerMetadata.Add(
                WorkflowHostTypePropertyName, new InstanceValue(WorkflowHostTypeName));

            InstanceStore.DefaultInstanceOwner =
                InstanceStore.Execute(InstanceHandle, ownerCommand, TimeSpan.FromSeconds(30)).InstanceOwner;
        }

        private static WorkflowApplication CreateWorkflowApplication(RegistrationData arguments = null)
        {
            if (RegistrationWorkflow == null)
            {
                RegistrationWorkflow = new TActivity();
            }

            var host = arguments != null
                           ? new WorkflowApplication(
                                 RegistrationWorkflow, new Dictionary<string, object> { { "RegData", arguments } })
                           : new WorkflowApplication(RegistrationWorkflow);

            var scope = new Dictionary<XName, object> { { WorkflowHostTypePropertyName, WorkflowHostTypeName } };

            // Add the WorkflowHostType value to workflow application so that it stores this data in the instance store when persisted
            host.AddInitialInstanceValues(scope);
            host.InstanceStore = InstanceStore;
            host.PersistableIdle += args => PersistableIdleAction.Unload;

            // Setup the persistence participant
            host.Extensions.Add(new RegistrationPeristenceParticipant());
#if DEBUG
            // Output Workflow Tracking to VS Debug Window
            host.Extensions.Add(new TraceTrackingParticipant());
#endif
            return host;
        }

        private static WorkflowApplication LoadRegistrationWorkflow(Guid instanceId)
        {
            var host = CreateWorkflowApplication();
            host.Load(instanceId);
            return host;
        }

        private static void MonitorAndRun()
        {
            while (true)
            {
#if DEBUG
                Trace.WriteLine("Monitoring instance store for workflows with expired timers");
#endif

                WaitForRunnableInstance();
                var host = CreateWorkflowApplication();
                try
                {
                    host.LoadRunnableInstance(Timeout);
                    host.Run();
                }
                catch (InstanceNotReadyException)
                {
                    // Sometimes this will happen - not a problem, just retry
                    Trace.WriteLine(
                        string.Format(
                            "InstanceNotReadyException waiting {0} seconds and retrying...", InstanceDetectionPeriod));
                    Thread.Sleep(TimeSpan.FromSeconds(InstanceDetectionPeriod));
                }
                catch (InstancePersistenceCommandException exception)
                {
                    // Some other kind of persistence problem
                    // TODO: Need to log these in your preferred logging system
                    Trace.WriteLine(exception.Message);
                }
            }
        }

        private static bool ResumeWorkflow(Guid instanceId, RegistrationCommand command)
        {
            // Try to load the workflow and resume the bookmark
            var host = LoadRegistrationWorkflow(instanceId);
            var commandDone = new AutoResetEvent(false);

            // Run the workflow until idle, or complete
            host.Completed += completedEventArgs => commandDone.Set();
            host.Idle += args => commandDone.Set();

            Exception abortedException = null;

            host.Aborted += abortedEventArgs =>
                {
                    abortedException = abortedEventArgs.Reason;
                    commandDone.Set();
                };

            // Resume the bookmark and Wait for the workflow to complete
            // ReSharper disable AssignNullToNotNullAttribute
            if (host.ResumeBookmark(command.ToString(), null) != BookmarkResumptionResult.Success) // ReSharper restore AssignNullToNotNullAttribute
            {
                throw new InvalidOperationException("Unable to resume registration process with command " + command);
            }

            if (!commandDone.WaitOne(Timeout))
            {
                throw new TimeoutException("Timeout waiting to confirm registration");
            }

            if (abortedException != null)
            {
                throw abortedException;
            }

            return abortedException == null;
        }

        private static bool ResumeWorkflow(string email, RegistrationCommand command)
        {
            var instanceId = GetInstanceIdFromEmail(email);
            return instanceId != Guid.Empty && ResumeWorkflow(instanceId, command);
        }

        private static void WaitForRunnableInstance()
        {
            bool foundWorkflow;

            do
            {
                foundWorkflow =
                    InstanceStore.WaitForEvents(InstanceHandle, TimeSpan.MaxValue).Any(
                        persistenceEvent => persistenceEvent == HasRunnableWorkflowEvent.Value);
            }
            while (!foundWorkflow);
#if DEBUG
            Trace.WriteLine("Found registration workflow with expired timer");
#endif

        }

        private string AddVerificationCode(string url, Guid id)
        {
            return new UriBuilder(url) { Query = VerificationCodeParameter + "=" + id }.Uri.ToString();
        }

        #endregion
    }
}