using System;
using System.Runtime.Serialization;

namespace CloudLoadTestingClient
{
    [DataContract]
    public class TestRunBasic
    {
        /// <summary>
        /// Gets the unique identifier for the test run definition.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets the name of the test run definition.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets the number of the test run (unique within a tenant)
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int RunNumber { get; set; }

        /// <summary>
        /// Gets the creation time of the test run
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets the finish time of the test run
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime FinishedDate { get; set; }

        /// <summary>
        /// Run specific details.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public LoadTestRunDetails RunSpecificDetails { get; set; }

        /// <summary>
        /// Vss User identity who created the test run.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public IdentityRef CreatedBy { get; set; }

        /// <summary>
        /// State of the test run.
        /// </summary>
        [DataMember]
        public TestRunState State { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Url { get; set; }
    }
}