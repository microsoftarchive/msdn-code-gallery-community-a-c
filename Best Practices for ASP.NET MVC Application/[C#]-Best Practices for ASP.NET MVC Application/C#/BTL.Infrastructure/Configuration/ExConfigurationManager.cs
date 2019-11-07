#region

using System.Collections.Specialized;
using System.Configuration;

#endregion

namespace BTL.Infrastructure.Configuration
{
    public class ExConfigurationManager : IExConfigurationManager
    {
        #region IExConfigurationManager Members

        public object GetSection(string sectionName)
        {
            return ConfigurationManager.GetSection(sectionName);
        }

        public ConnectionStringSettingsCollection GetConnectionStrings()
        {
            return ConfigurationManager.ConnectionStrings;
        }

        public NameValueCollection GetAppSettings()
        {
            return ConfigurationManager.AppSettings;
        }

        public string GetAppConfigBy(string appConfigName)
        {
            Guard.MakeSureAllInstancesIsNullNot(GetAppSettings());

            return GetAppSettings()[appConfigName];
        }

        #endregion
    }
}