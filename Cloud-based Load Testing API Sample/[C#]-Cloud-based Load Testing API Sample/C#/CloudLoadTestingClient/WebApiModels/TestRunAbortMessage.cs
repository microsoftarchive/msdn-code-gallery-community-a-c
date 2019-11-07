using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CloudLoadTestingClient
{
    [DataContract]
    public class TestRunAbortMessage
    {
        [DataMember(EmitDefaultValue = false)]
        public string Cause { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Action { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Source { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime LoggedDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> Details { get; set; }
    }
}
