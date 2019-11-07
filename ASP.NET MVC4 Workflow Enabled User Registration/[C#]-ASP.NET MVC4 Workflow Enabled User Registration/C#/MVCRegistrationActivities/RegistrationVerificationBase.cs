namespace MVCRegistrationActivities
{
    using System;
    using System.Activities;
    using System.Activities.DurableInstancing;
    using System.Runtime.DurableInstancing;
    using System.Xml.Linq;

    public class RegistrationVerificationBase
    {
        protected static WorkflowIdentity RegistrationIdentity = new WorkflowIdentity("Registration", new Version(1, 0), "RegistrationPackage");
        protected static SqlWorkflowInstanceStore InstanceStore;

        /// <summary>
        ///   The workflow host type name.
        /// </summary>
        /// <remarks>
        ///   Create a unique name that is used to associate instances in the instance store hosts that can load them. This is needed to prevent a Workflow host from loading
        ///   instances that have different implementations. The unique name should change whenever the implementation of the workflow changes to prevent workflow load exceptions.
        ///   For the purposes of the demo we create a unique name every time the program is run.
        /// </remarks>
        protected static XName WorkflowHostTypeName;

        /// <summary>
        ///   The workflow host type property name.
        /// </summary>
        /// <remarks>
        ///   A well known property that is needed by WorkflowApplication and the InstanceStore
        /// </remarks>
        protected static readonly XName WorkflowHostTypePropertyName =
            XNamespace.Get("urn:schemas-microsoft-com:System.Activities/4.0/properties").GetName("WorkflowHostType");

        /// <summary>
        ///   The instance detection period
        /// </summary>
        protected static int InstanceDetectionPeriod = 2;

        protected static InstanceHandle InstanceHandle;

        protected static TimeSpan Timeout = TimeSpan.FromSeconds(30);
    }
}