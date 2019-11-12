#region

using System.Collections.Generic;
using System.Configuration;

#endregion

namespace BTL.Infrastructure.Configuration
{
    public class SectionConfigurationElement : ConfigurationElement
    {
        public SectionConfigurationElement()
        {
            KeyValuePairs = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string, string>> KeyValuePairs { get; set; }


        [ConfigurationProperty("name")]
        public string Name
        {
            get { return (string) this["name"]; }
            set { this["name"] = value; }
        }


        [ConfigurationProperty("value")]
        public string Value
        {
            get { return (string) this["value"]; }
            set { this["value"] = value; }
        }


        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            KeyValuePairs.Add(new KeyValuePair<string, string>(name, value));
            return true;
        }
    }
}