#region

using System.Configuration;
using BTL.Infrastructure.Extensions;

#endregion

namespace BTL.Infrastructure.Configuration
{
    public class SectionConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("settings")]
        public SectionElementCollection Settings
        {
            get { return (SectionElementCollection) base["settings"]; }
        }

        public static T GetInstance<T>(string section)
            where T : ISectionConfiguration, new()
        {
            //Declare object
            var retValue = new T();

            //Read configuration for provided section
            var configurationSection = (SectionConfiguration)ConfigurationManager.GetSection(section);

            //return null if there is no section specified
            if (configurationSection == null) return retValue;

            //read the settings to the return object
            foreach (SectionConfigurationElement setting in configurationSection.Settings)
            {
                retValue.FillProperty(setting);
            }

            return retValue;
        }
    }
}