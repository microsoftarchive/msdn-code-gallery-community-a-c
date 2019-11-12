using System.Runtime.Serialization;

namespace CloudLoadTestingClient
{
    [DataContract]
    public class LoadTestRunDetails
    {
        [DataMember(EmitDefaultValue = false)]
        public int Duration { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int WarmUpDuration { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int VirtualUserCount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int CoreCount { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int SamplingInterval { get; set; }
    }
}
