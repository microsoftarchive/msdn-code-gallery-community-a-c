#region

using System.Configuration;

#endregion

namespace BTL.Infrastructure.Configuration
{
    public class SectionElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SectionConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SectionConfigurationElement) element).Name;
        }
    }
}