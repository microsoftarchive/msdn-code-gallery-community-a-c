using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudLoadTestingClient.WebApiModels
{
    [DataContract]
    public class TestRunCounterInstance
    {

        /// <summary>
        /// Combination of source and SourceInstanceId
        /// </summary>
        [DataMember]
        public string CounterInstanceId { get; set; }

        /// <summary>
        /// Machine from where this counter was collected
        /// Used in case of machine specific counters like - Agent CPU and memory etc.
        /// </summary>
        [DataMember]
        public string MachineName { get; set; }

        /// <summary>
        /// CategoryName for this counter
        /// </summary>
        [DataMember]
        public string CategoryName { get; set; }

        /// <summary>
        /// Name of the counter Eg: Errors/Sec
        /// </summary>
        [DataMember]
        public string CounterName { get; set; }

        /// <summary>
        /// Units for this counter. Empty string for mere numbers
        /// </summary>
        [DataMember]
        public string CounterUnits { get; set; }

        /// <summary>
        /// Instance Name Eg: _Avg,_Total etc
        /// </summary>
        [DataMember]
        public string InstanceName { get; set; }

        /// <summary>
        /// A unique name for this counter instance
        /// </summary>
        [DataMember]
        public string UniqueName { get; set; }

        /// <summary>
        /// Source of the counter Instance - ELS, AppInsights
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// true if this counter instance is a default counter
        /// </summary>
        [DataMember]
        public bool IsPreselectedCounter { get; set; }

        /// <summary>
        /// Counter Groups to which this counter instance is part of
        /// </summary>
        [DataMember]
        public List<string> PartOfCounterGroups { get; set; }
    }
}
