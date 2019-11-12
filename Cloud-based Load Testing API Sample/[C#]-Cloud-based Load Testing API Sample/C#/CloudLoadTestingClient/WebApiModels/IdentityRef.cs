using System.Runtime.Serialization;

namespace CloudLoadTestingClient
{
    [DataContract]
    public class IdentityRef
    {
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string DisplayName { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "imageUrl", EmitDefaultValue = false)]
        public string ImageUrl { get; set; }
        [DataMember(Name = "isContainer", EmitDefaultValue = false)]
        public bool IsContainer { get; set; }
        [DataMember(Name = "profileUrl", EmitDefaultValue = false)]
        public string ProfileUrl { get; set; }
        [DataMember(Name = "uniqueName", EmitDefaultValue = false)]
        public string UniqueName { get; set; }
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }
    }
}
