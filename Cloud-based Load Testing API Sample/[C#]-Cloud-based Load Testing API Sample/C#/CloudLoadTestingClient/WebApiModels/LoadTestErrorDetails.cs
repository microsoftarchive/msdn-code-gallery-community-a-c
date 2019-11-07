using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudLoadTestingClient.WebApiModels
{
    [DataContract]
    public class LoadTestErrors
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public int Occurrences { get; set; }
        [DataMember]
        public List<Type> Types;
        [DataMember]
        public string Url;
    }

    [DataContract]
    public class Type
    {
        [DataMember]
        public string TypeName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public int Occurrences { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public List<SubType> SubTypes;
    }

    [DataContract]
    public class SubType
    {
        [DataMember]
        public string SubTypeName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public int Occurrences { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public List<ErrorDetails> ErrorDetailList;

    }

    [DataContract]
    public class ErrorDetails
    {
        
        [DataMember]
        public int Occurrences { get; set; }

        [DataMember]
        public string TestCaseName { get; set; }

        [DataMember]
        public string ScenarioName { get; set; }

        [DataMember]
        public string Request { get; set; }

        [DataMember]
        public string StackTrace { get; set; }

        [DataMember]
        public string MessageText { get; set; }

        [DataMember]
        public DateTime LastErrorDate { get; set; }
    }
}
