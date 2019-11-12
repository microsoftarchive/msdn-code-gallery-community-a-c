using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudLoadTestingClient.WebApiModels
{
    [DataContract]
    public class CounterSamplesResult
    {
        /// <summary>
        /// Count of the samples
        /// </summary>
        [DataMember]
        public int TotalSamplesCount { get; set; }

        /// <summary>
        /// Maximum number of samples returned in this object
        /// </summary>
        [DataMember]
        public int MaxBatchSize { get; set; }

        /// <summary>
        /// Count of the samples
        /// </summary>
        [DataMember]
        public int Count { get; set; }

        /// <summary>
        /// The result samples
        /// </summary>
        [DataMember(Name = "Values")]
        public List<CounterInstanceSamples> InstanceSamples { get; set; }
    }

    [DataContract]
    public class CounterInstanceSamples
    {
        [DataMember]
        public string CounterInstanceId { get; set; }

        /// <summary>
        /// The time of next refresh
        /// </summary>
        [DataMember]
        public DateTime NextRefreshTime { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember(Name = "Values")]
        public List<CounterSample> Samples { get; set; }
    }

    [DataContract]
    public class CounterSample
    {
        [DataMember]
        public string CounterInstanceId { get; set; }

        [DataMember]
        public int IntervalNumber { get; set; }

        [DataMember]
        public DateTime IntervalEndDate { get; set; }

        [DataMember]
        public long RawValue { get; set; }

        [DataMember]
        public long BaseValue { get; set; }

        [DataMember]
        public long CounterFrequency { get; set; }

        [DataMember]
        public long SystemFrequency { get; set; }

        [DataMember]
        public long TimeStamp { get; set; }

        [DataMember]
        public string CounterType { get; set; }

        [DataMember]
        public float? ComputedValue { get; set; }
    }
}
