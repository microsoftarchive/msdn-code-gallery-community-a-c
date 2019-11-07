using System;
using System.Configuration;

namespace NtierMvc.Common
{
    /// <summary>
    /// Purpose: Cross-cutting helper component for application configuration.
    /// </summary>
    public class ConfigurationHandler : IDisposable
    {
        #region Class Declarations

        private string _connectionString;
        private string _connectionProvider;

        #endregion

        #region Class Methods

        private void InitConfigurationHandler()
        {
            try
            {
                //get current connection name 
                var currentConnectionName = GetAppSettingsValueByKey("CurrentAppConnection");

                if (string.IsNullOrEmpty(currentConnectionName))
                    throw new ConfigurationErrorsException(string.Format("No connection name exist in the current app/web.config."));

                ConnectionStringSettings connectionName = ConfigurationManager.ConnectionStrings[currentConnectionName];
                if (connectionName == null)
                    throw new ConfigurationErrorsException(string.Format("Failed to find connection named '{0}' in app/web.config.", currentConnectionName));

                _connectionString = connectionName.ConnectionString;
                _connectionProvider = connectionName.ProviderName;

                if (string.IsNullOrEmpty(_connectionString) || string.IsNullOrEmpty(_connectionProvider))
                    throw new ConfigurationErrorsException(string.Format("The Connection String and/or the Data Provider can't be found in app/web.config."));
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ConfigurationHandler::InitConfigurationHandler::Error occured.", ex);
            }
        }

        /// <summary>
        /// Purpose: ConfigurationHandler class constructor
        /// </summary>
        public ConfigurationHandler()
        {
            InitConfigurationHandler();
        }

        /// <summary>
        /// Purpose: Implements the IDispose interface.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public string GetAppSettingsValueByKey(string sKey)
        {
            try
            {
                if (string.IsNullOrEmpty(sKey))
                    throw new ArgumentNullException("sKey", "The AppSettings key name can't be Null or Empty.");

                if (ConfigurationManager.AppSettings[sKey] == null)
                    throw new ConfigurationErrorsException(string.Format("Failed to find the AppSettings Key named '{0}' in app/web.config.", sKey));

                return ConfigurationManager.AppSettings[sKey].ToString();
            }
            catch (Exception ex)
            {
                //bubble error.
                throw new Exception("ConfigurationHandler::GetAppSettingsValueByKey:Error occured.", ex);
            }
        }

        #endregion

        #region Class Properties

        /// <summary>
        /// The connection string details for the project.
        /// </summary>
        public string ConnectionString { get { return _connectionString; } }

        /// <summary>
        /// The target data-source provider for the connection.
        /// </summary>
        public string ConnectionProvider { get { return _connectionProvider; } }

        #endregion
    }
}
