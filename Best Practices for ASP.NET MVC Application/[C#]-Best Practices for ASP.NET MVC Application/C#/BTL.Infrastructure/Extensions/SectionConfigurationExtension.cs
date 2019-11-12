#region

using System.Configuration;
using BTL.Infrastructure.Configuration;

#endregion

namespace BTL.Infrastructure.Extensions
{
    public static class SectionConfigurationExtension
    {
        public static T GetInstance<T>(this SectionConfiguration sectionConfiguration, string section)
            where T : ISectionConfiguration, new()
        {
            //Declare object
            var retValue = new T();

            //Read configuration for provided section
            var configurationSection = (SectionConfiguration) ConfigurationManager.GetSection(section);

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