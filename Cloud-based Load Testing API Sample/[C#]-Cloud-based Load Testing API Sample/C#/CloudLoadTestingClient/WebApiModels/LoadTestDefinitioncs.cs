using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CloudLoadTestingClient
{
    [DataContract]
    public class LoadTestDefinition
    {
        [DataMember(EmitDefaultValue = false)]
        public string LoadTestName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int RunDuration { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int ThinkTime { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> Urls { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<BrowserMix> BrowserMixs { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string LoadPatternName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int MaxVusers { get; set; }
    }

    [DataContract]
    public class BrowserMix
    {
        [DataMember(EmitDefaultValue = false)]
        public string BrowserName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public float BrowserPercentage { get; set; }
    }

    [DataContract]
    public class LoadGenerationGeoLocation
    {
        [DataMember(EmitDefaultValue = false)]
        public string Location { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int Percentage { get; set; }
    }
}
