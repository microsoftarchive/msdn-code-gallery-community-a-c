using System;
using System.Runtime.Serialization;

namespace CloudLoadTestingClient
{
    /// <summary>
    /// An abstracted reference to some other resource. This class is used to provide the load test
    /// data contracts with a uniform way to reference other resources in a way that provides easy
    /// traversal through links.
    /// </summary>
    [DataContract]
    public class TestDropRef
    {
        /// <summary>
        /// Id of the resource
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Full http link to the resource
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public String Url { get; set; }
    }
}
