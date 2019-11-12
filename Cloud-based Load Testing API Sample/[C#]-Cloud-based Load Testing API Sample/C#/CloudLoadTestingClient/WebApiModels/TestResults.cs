using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CloudLoadTestingClient
{
    [DataContract]
    public class TestResults
    {
        /// <summary>
        /// The uri to the test run results file.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ResultsUrl { get; set; }

        /// <summary>
        /// The uri to the test run results file.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string CloudLoadTestSolutionUrl { get; set; }

        /// <summary>
        /// The object contains diagnostic details 
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Diagnostics Diagnostics { get; set; }


        [DataMember(EmitDefaultValue = false)]
        public List<CounterGroup> CounterGroups { get; set; }
    }

    [DataContract]
    public class CounterGroup
    {
        [DataMember(EmitDefaultValue = false)]
        public string GroupName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Url { get; set; }
    }

    [DataContract]
    public class Diagnostics
    {
        [DataMember(EmitDefaultValue = false)]
        public string DiagnosticStoreConnectionString { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string RelativePathToDiagnosticFiles { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime LastModifiedTime { get; set; }
    }
}
