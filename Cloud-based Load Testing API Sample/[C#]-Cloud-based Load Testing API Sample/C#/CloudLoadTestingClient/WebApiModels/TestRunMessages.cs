using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CloudLoadTestingClient
{
    [DataContract]
    public class TestRunMessages
    {
        [DataMember(EmitDefaultValue = false)]
        public int count { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<TestRunMessage> Value { get; set; }
    }


    [DataContract]
    public class TestRunMessage
    {
        [DataMember(EmitDefaultValue = false)]
        public string MessageId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string TestRunId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AgentId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public MessageType MessageType { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public MessageSource MessageSource { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime LoggedDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }
    }

    [DataContract]
    public enum MessageType
    {
        [EnumMember]
        Info,

        [EnumMember]
        Output,

        [EnumMember]
        Error,

        [EnumMember]
        Warning,

        [EnumMember]
        Critical
    }

    public enum MessageSource
    {
        [EnumMember]
        SetupScript,

        [EnumMember]
        CleanupScript,

        [EnumMember]
        Validation,

        [EnumMember]
        Other,

        [EnumMember]
        AutCounterCollection
    }
}
