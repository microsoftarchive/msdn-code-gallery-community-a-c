using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CloudLoadTestingClient
{
    [DataContract]
    public sealed class TestRun : TestRunBasic
    {
        public TestRun()
        { }

        public TestRun(TestRunBasic testRunBasic)
        {
            Id = testRunBasic.Id;
            Name = testRunBasic.Name;
            CreatedDate = testRunBasic.CreatedDate;
            FinishedDate = testRunBasic.FinishedDate;
            RunSpecificDetails = testRunBasic.RunSpecificDetails;
            RunNumber = testRunBasic.RunNumber;
            CreatedBy = testRunBasic.CreatedBy;
            State = testRunBasic.State;
            Url = testRunBasic.Url;
        }

        /// <summary>
        /// Test run description.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets the time when the test run was queued
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime QueuedDate { get; set; }

        /// <summary>
        /// When the test run started execution.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime StartedDate { get; set; }

        /// <summary>
        /// Gets the time when the test run warmup started
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime WarmUpStartedDate { get; set; }

        /// <summary>
        /// Gets the time when the test run warmup finished(if warmup was specified) and load test started
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime ExecutionStartedDate { get; set; }

        /// <summary>
        /// Gets the time when the test run execution finished
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime ExecutionFinishedDate { get; set; }

        /// <summary>
        /// Whether run is chargeable or not
        /// Its chargeable once we configured agent and sent start signal
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool Chargeable { get; set; }


        /// <summary>
        /// SubState is more granular description of the state
        /// </summary>

        [DataMember]
        public TestRunSubState SubState { get; set; }

        /// <summary>
        /// The Test settings for the test run
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public TestSettings TestSettings { get; set; }

        /// <summary>
        /// Drop associated with this test run
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public TestDropRef TestDrop { get; set; }

        /// <summary>
        /// Vss User identity who created the test run.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public IdentityRef StartedBy { get; set; }

        /// <summary>
        /// Vss User identity who created the test run.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public IdentityRef StoppedBy { get; set; }

        /// <summary>
        /// Message associated to state change, 
        /// contains details of infrastructure error. 
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public TestRunAbortMessage AbortMessage { get; set; }

        /// <summary>
        /// true if aut counter collection could not start due to some critical error for this run.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool AutInitializationError { get; set; }

        /// <summary>
        /// List of load generation geo-locations
        /// </summary/>
        [DataMember(EmitDefaultValue = false)]
        public IList<LoadGenerationGeoLocation> LoadGenerationGeoLocations { get; set; }

        /// <summary>
        /// Retention state of the run
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public TestRunRetentionState RetentionState { get; set; }
    }

    [DataContract]
    public enum TestRunState
    {
        [EnumMember]
        Pending,

        [EnumMember]
        Queued,

        [EnumMember]
        InProgress,

        [EnumMember]
        Stopping,

        [EnumMember]
        Completed,

        [EnumMember]
        Aborted,

        [EnumMember]
        Error
    }

    [DataContract]
    public enum TestRunSubState
    {
        /* Default Substate, when specialized one does not matter */
        [EnumMember]
        None,

        /* Substates for Queued Runs */
        [EnumMember]
        ValidatingTestRun,

        [EnumMember]
        AcquiringResources,

        /* Substates for InProgress Runs */
        [EnumMember]
        ConfiguringAgents,

        [EnumMember]
        ExecutingSetupScript,

        [EnumMember]
        WarmingUp,

        [EnumMember]
        RunningTest,

        [EnumMember]
        ExecutingCleanupScript,

        [EnumMember]
        CollectingResults,

        /* Substates for Completed Runs */
        [EnumMember]
        Success,

        [EnumMember]
        PartialSuccess,
        // Note that there is no Failed sub-state as it is equivalent to either of Aborted or Error run state:
        // The run level state will be Aborted if the cause is user caused issue/signal otherwise it will be Error.
    }

    [DataContract]
    public enum TestExecutionVersion
    {
        [EnumMember]
        Default,

        /// <summary>
        /// Support to move samples to blob
        /// </summary>
        [EnumMember]
        MovingCounterSamplesToBlob,

        /// <summary>
        /// Support to continue run with reduced agent cores
        /// </summary>
        [EnumMember]
        ReducedAgentCoreSupport,

        /// <summary>
        /// Support to do the aggregation of all remaining intervals for final aggregation
        /// </summary>
        [EnumMember]
        FinalAggregationSupport,

        /// <summary>
        /// Validation phase would be the first step in the execution job
        /// </summary>
        [EnumMember]
        ValidationInExecutionJob,

        /// <summary>
        /// Machine requests would be processed outside of the pool job
        /// </summary>
        [EnumMember]
        DirectMachineRequestProcessing,

        // Any Breaking feature needs to be added here
        [EnumMember]
        MaxValue,

    }

    [DataContract]
    public enum TestRunRetentionState
    {
        [EnumMember]
        None,

        [EnumMember]
        MarkedForDeletion,

        [EnumMember]
        Deleted,

        [EnumMember]
        Retain
    }
}
