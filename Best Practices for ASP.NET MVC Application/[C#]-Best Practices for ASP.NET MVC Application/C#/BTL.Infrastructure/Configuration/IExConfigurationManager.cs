#region

using System.Collections.Specialized;
using System.Configuration;

#endregion

namespace BTL.Infrastructure.Configuration
{
    public interface IExConfigurationManager
    {
        object GetSection(string sectionName);

        ConnectionStringSettingsCollection GetConnectionStrings();

        NameValueCollection GetAppSettings();

        string GetAppConfigBy(string appConfigName);
    }
}