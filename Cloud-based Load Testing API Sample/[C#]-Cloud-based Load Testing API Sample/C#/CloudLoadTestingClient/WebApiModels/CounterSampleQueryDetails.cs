using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudLoadTestingClient.WebApiModels
{
    [DataContract]
    public class CounterSampleQueryDetails
    {
        /// <summary>
        /// The instanceId for which samples are required
        /// </summary>
        [DataMember]
        public string CounterInstanceId { get; set; }

        [DataMember]
        public int FromInterval { get; set; }

        [DataMember]
        public int ToInterval { get; set; }

        [OnDeserializing]
        private void BeforeDeserialization(StreamingContext ctx)
        {
            this.FromInterval = 0;
            this.ToInterval = -1;
        }
    }
}
