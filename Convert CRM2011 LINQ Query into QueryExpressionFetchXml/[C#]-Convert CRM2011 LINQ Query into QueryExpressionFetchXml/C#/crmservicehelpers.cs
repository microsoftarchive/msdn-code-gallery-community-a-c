// =====================================================================
//  This file is part of the Microsoft Dynamics CRM SDK code samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================

//<snippetCrmServiceHelper>
using System;
using System.Collections.Generic;
using System.ServiceModel.Description;
using System.IO;
using System.Xml;
using System.Xml.Linq;

// These namespaces are found in the Microsoft.Xrm.Sdk.dll assembly
// located in the SDK\bin folder of the SDK download.
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using System.Text;

namespace Microsoft.Crm.Sdk.Samples
{
    /// <summary>
    /// Provides server connection information.
    /// </summary>
    public class ServerConnection
    {
        #region Inner classes
        /// <summary>
        /// Stores CRM server configuration information.
        /// </summary>
        public class Configuration
        {
            public String ServerAddress;
            public String OrganizationName;
            public Uri DiscoveryUri;
            public Uri OrganizationUri;
            public Uri HomeRealmUri = null;
            public ClientCredentials DeviceCredentials = null;
            public ClientCredentials Credentials = null;
            public AuthenticationProviderType EndpointType;

            public override bool Equals(object obj)
            {
                //Check for null and compare run-time types.
                if (obj == null || GetType() != obj.GetType()) return false;

                Configuration c = (Configuration)obj;

                if (!this.ServerAddress.Equals(c.ServerAddress, StringComparison.InvariantCultureIgnoreCase))
                    return false;
                if (!this.OrganizationName.Equals(c.OrganizationName, StringComparison.InvariantCultureIgnoreCase))
                    return false;
                if (this.EndpointType != c.EndpointType)
                    return false;
                if (this.EndpointType == AuthenticationProviderType.ActiveDirectory)
                {
                    if (!this.Credentials.Windows.ClientCredential.Domain.Equals(
                        c.Credentials.Windows.ClientCredential.Domain, StringComparison.InvariantCultureIgnoreCase))
                        return false;
                    if (!this.Credentials.Windows.ClientCredential.UserName.Equals(
                        c.Credentials.Windows.ClientCredential.UserName, StringComparison.InvariantCultureIgnoreCase))
                        return false;
                }
                else
                {
                    if (!this.Credentials.UserName.UserName.Equals(c.Credentials.UserName.UserName, 
                        StringComparison.InvariantCultureIgnoreCase))
                        return false;
                }
                return true;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

        }
        #endregion Inner classes

        #region Public properties

        public List<Configuration> configurations = null;

        #endregion Public properties

        #region Private properties

        private Configuration config = new Configuration();

        #endregion Private properties

        #region Public methods
        /// <summary>
        /// Obtains the server connection information including the target organization's
        /// Uri and user login credentials from the user.
        /// </summary>
        public virtual Configuration GetServerConfiguration()
        {
            Boolean ssl;
            Boolean addConfig;
            int configNumber;
            // Read configuration from disk if exist at C:\Users\<username>\AppData\Roaming\CrmServer\Credentials.xml.
            Boolean isConfigExist = ReadConfigurations();

            // Check if server configuration settings are already available on disk.
            if (isConfigExist)
            {
                //Console.WriteLine("\nList of server configurations that are available from earlier saved settings:");
                Console.Write("\n(0) Add New Server Configuration (Maximum number upto 9)\t");
                for (int n = 0; n < configurations.Count; n++)
                {
                    String user;

                    switch (configurations[n].EndpointType)
                    {
                        case AuthenticationProviderType.ActiveDirectory:
                            if (configurations[n].Credentials != null)
                                user = configurations[n].Credentials.Windows.ClientCredential.Domain + "\\" + configurations[n].Credentials.Windows.ClientCredential.UserName;
                            else
                                user = "default";
                            break;
                        default:
                            if (configurations[n].Credentials != null)
                                user = configurations[n].Credentials.UserName.UserName;
                            else
                                user = "default";
                            break;
                    }

                    Console.Write("\n({0}) Server: {1},  Org: {2},  User: {3}\t",
                        n + 1, configurations[n].ServerAddress, configurations[n].OrganizationName, user);
                }

                Console.WriteLine();

                Console.Write("\nSpecify the saved server configuration number (1-{0}) [{0}] : ", configurations.Count);
                String input = Console.ReadLine();
                Console.WriteLine();
                if (input == String.Empty) input = configurations.Count.ToString();
                configNumber = Int32.Parse(input);

                if (configNumber == 0)
                {
                    addConfig = true;
                }
                else if (configNumber > 0 && configNumber <= configurations.Count)
                {
                    // Return the organization Uri.
                    config = configurations[configNumber - 1];
                    // Reorder configuration list and save it to file to save recent config as a latest one. 
                    if (configNumber != configurations.Count)
                    {
                        Configuration temp = configurations[configurations.Count - 1];
                        configurations[configurations.Count - 1] = configurations[configNumber - 1];
                        configurations[configNumber - 1] = temp;
                        SaveConfigurations();
                    }
                    addConfig = false;
                }
                else
                    throw new Exception("The specified server configuration does not exist.");
            }
            else
                addConfig = true;

            if (addConfig)
            {
                // Get the server address. If no value is entered, default to Microsoft Dynamics
                // CRM Online in the North American data center.
                config.ServerAddress = GetServerAddress(out ssl);
                if (String.IsNullOrWhiteSpace(config.ServerAddress))
                    config.ServerAddress = "crm.dynamics.com";

                // One of the Microsoft Dynamics CRM Online data centers.
                if (config.ServerAddress.EndsWith(".dynamics.com"))
                {
                    config.DiscoveryUri =
                        new Uri(String.Format("https://dev.{0}/XRMServices/2011/Discovery.svc", config.ServerAddress));

                    // Set or get the device credentials. Required for Windows Live ID authentication. 
                    config.DeviceCredentials = GetDeviceCredentials();
                }

                // Does the server use Secure Socket Layer (https)?
                else if (ssl)
                    config.DiscoveryUri =
                        new Uri(String.Format("https://{0}/XRMServices/2011/Discovery.svc", config.ServerAddress));
                else
                    config.DiscoveryUri =
                        new Uri(String.Format("http://{0}/XRMServices/2011/Discovery.svc", config.ServerAddress));

                // Set the endpoint type.
                config.EndpointType = GetServerType(config.DiscoveryUri);
            }

            // Get the user's logon credentials.
            config.Credentials = GetUserLogonCredentials();


            if (addConfig)
            {
                // Get the target organization.
                config.OrganizationUri = GetOrganizationAddress(config.DiscoveryUri);
                configurations.Add(config);
                int length = configurations.Count;
                int i = length-2;
                // Check if new config already exist. If found then reorder list to show latest in use.                                   
                while (i > 0)
                {

                    if (configurations[configurations.Count - 1].Equals(configurations[i]))
                    {
                        configurations.RemoveAt(i);
                    }
                    i--;
                }
                // Set max configurations to 9 otherwise overrite existing one.
                if (configurations.Count > 9)
                {
                    configurations.RemoveAt(0);
                }
                SaveConfigurations();
            }

            return config;
        }

        /// <summary>
        /// Discovers the organizations that the calling user belongs to.
        /// </summary>
        /// <param name="service">A Discovery service proxy instance.</param>
        /// <returns>Array containing detailed information on each organization that 
        /// the user belongs to.</returns>
        public OrganizationDetailCollection DiscoverOrganizations(IDiscoveryService service)
        {
            RetrieveOrganizationsRequest orgRequest = new RetrieveOrganizationsRequest();
            RetrieveOrganizationsResponse orgResponse =
                (RetrieveOrganizationsResponse)service.Execute(orgRequest);

            return orgResponse.Details;
        }

        /// <summary>
        /// Finds a specific organization detail in the array of organization details
        /// returned from the Discovery service.
        /// </summary>
        /// <param name=orgFriendlyName">The friendly name of the organization to find.</param>
        /// <param name="orgDetails">Array of organization detail object returned from the discovery service.</param>
        /// <returns>Organization details or null if the organization was not found.</returns>
        /// <seealso cref="DiscoveryOrganizations"/>
        public OrganizationDetail FindOrganization(string orgFriendlyName, OrganizationDetail[] orgDetails)
        {
            OrganizationDetail orgDetail = null;

            foreach (OrganizationDetail detail in orgDetails)
            {
                if (String.Compare(detail.FriendlyName, orgFriendlyName) == 0)
                {
                    orgDetail = detail;
                    break;
                }
            }
            return orgDetail;
        }

        /// <summary>
        /// Reads a server configuration file.
        /// Read configuration from disk if exist at C:\Users\YourUserName\AppData\Roaming\CrmServer\Credentials.xml.
        /// </summary>
        /// <returns>Is configuration settings already available on disk.</returns>
        public Boolean ReadConfigurations()
        {
            Boolean isConfigExist = false;

            if (configurations == null)
                configurations = new List<Configuration>();

            if (File.Exists(CrmServiceHelperConstants.ServerCredentialsFile))
            {
                XElement configurationsFromFile = XElement.Load(CrmServiceHelperConstants.ServerCredentialsFile);
                foreach (XElement config in configurationsFromFile.Nodes())
                {
                    Configuration newConfig = new Configuration();

                    if (!String.IsNullOrEmpty(config.Element("ServerAddress").Value))
                        newConfig.ServerAddress = config.Element("ServerAddress").Value;
                    if (!String.IsNullOrEmpty(config.Element("OrganizationName").Value))
                        newConfig.OrganizationName = config.Element("OrganizationName").Value;
                    if (!String.IsNullOrEmpty(config.Element("DiscoveryUri").Value))
                        newConfig.DiscoveryUri = new Uri(config.Element("DiscoveryUri").Value);
                    if (!String.IsNullOrEmpty(config.Element("OrganizationUri").Value))
                        newConfig.OrganizationUri = new Uri(config.Element("OrganizationUri").Value);
                    if (!String.IsNullOrEmpty(config.Element("HomeRealmUri").Value))
                        newConfig.HomeRealmUri = new Uri(config.Element("HomeRealmUri").Value);
                    newConfig.EndpointType =
                            RetrieveAuthenticationType(config.Element("EndpointType").Value);
                    if (config.Element("Credentials").HasElements)
                    {
                        newConfig.Credentials =
                            ParseInCredentials(config.Element("Credentials"), newConfig.EndpointType);
                    }
                    if (newConfig.EndpointType == AuthenticationProviderType.LiveId)
                    {
                        newConfig.DeviceCredentials = GetDeviceCredentials();
                    }

                    configurations.Add(newConfig);
                }
            }

            if (configurations.Count > 0)
                isConfigExist = true;

            return isConfigExist;
        }

        /// <summary>
        /// Writes all server configurations to a file.
        /// </summary>
        /// <remarks>If the file exists, it is overwritten.</remarks>
        public void SaveConfigurations()
        {
            if (configurations == null)
                throw new Exception("No server connection configurations were found.");

            FileInfo file = new FileInfo(CrmServiceHelperConstants.ServerCredentialsFile);

            // Create directory if not exist.
            if (!file.Directory.Exists)
                file.Directory.Create();

            // Replace file if it exists.
            using (FileStream fs = file.Open(FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (XmlTextWriter writer = new XmlTextWriter(fs, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Configurations");
                    writer.WriteFullEndElement();
                    writer.WriteEndDocument();
                }
            }

            foreach (Configuration config in configurations)
                SaveConfiguration(CrmServiceHelperConstants.ServerCredentialsFile, config, true);
        }

        /// <summary>
        /// Writes a server configuration to a file.
        /// </summary>
        /// <param name="pathname">The file name and system path of the output configuration file.</param>
        /// <param name="config">A server connection configuration.</param>
        /// <param name="append">If true, the configuration is appended to the file, otherwise a new file
        /// is created.</param>
        public void SaveConfiguration(String pathname, Configuration config, bool append)
        {
            XElement configurationsFromFile = XElement.Load(pathname);
            XElement newConfig =
                new XElement("Configuration",
                    new XElement("ServerAddress", config.ServerAddress),
                    new XElement("OrganizationName", config.OrganizationName),
                    new XElement("DiscoveryUri",
                        (config.DiscoveryUri != null)
                        ? config.DiscoveryUri.OriginalString
                        : String.Empty),
                    new XElement("OrganizationUri",
                        (config.OrganizationUri != null)
                        ? config.OrganizationUri.OriginalString
                        : String.Empty),
                    new XElement("HomeRealmUri",
                        (config.HomeRealmUri != null)
                        ? config.HomeRealmUri.OriginalString
                        : String.Empty),
                    ParseOutCredentials(config.Credentials, config.EndpointType),
                    new XElement("EndpointType", config.EndpointType.ToString())
                );

            if (append)
            {
                configurationsFromFile.Add(newConfig);
            }
            else
            {
                configurationsFromFile.ReplaceAll(newConfig);
            }

            using (XmlTextWriter writer = new XmlTextWriter(pathname, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                configurationsFromFile.Save(writer);
            }
        }

        /// <summary>
        /// Obtains the authentication type of the CRM server.
        /// </summary>
        /// <param name="uri">Uri of the CRM Discovery service.</param>
        /// <returns>Authentication type.</returns>
        public AuthenticationProviderType GetServerType(Uri uri)
        {
            return ServiceConfigurationFactory.CreateConfiguration<IDiscoveryService>(uri).AuthenticationType;
        }
        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Obtains the name and port of the server running the Microsoft Dynamics CRM
        /// Discovery service.
        /// </summary>
        /// <returns>The server's network name and optional TCP/IP port.</returns>
        protected virtual String GetServerAddress(out bool ssl)
        {
            ssl = false;

            Console.Write("Enter a CRM server name and port [crm.dynamics.com]: ");
            String server = Console.ReadLine();

            if (server.EndsWith(".dynamics.com") || String.IsNullOrWhiteSpace(server))
            {
                ssl = true;
            }
            else
            {
                Console.Write("Is this server configured for Secure Socket Layer (https) (y/n) [n]: ");
                String answer = Console.ReadLine();

                if (answer == "y" || answer == "Y")
                    ssl = true;
            }

            return server;
        }

        /// <summary>
        /// Obtains the Web address (Uri) of the target organization.
        /// </summary>
        /// <param name="discoveryServiceUri">The Uri of the CRM Discovery service.</param>
        /// <returns>Uri of the organization service or an empty string.</returns>
        protected virtual Uri GetOrganizationAddress(Uri discoveryServiceUri)
        {
            using (DiscoveryServiceProxy serviceProxy = new DiscoveryServiceProxy(discoveryServiceUri, null, config.Credentials, config.DeviceCredentials))
            {
                // Obtain organization information from the Discovery service. 
                if (serviceProxy != null)
                {
                    // Obtain information about the organizations that the system user belongs to.
                    OrganizationDetailCollection orgs = DiscoverOrganizations(serviceProxy);

                    if (orgs.Count > 0)
                    {
                        Console.WriteLine("\nList of organizations that you belong to:");
                        for (int n = 0; n < orgs.Count; n++)
                            Console.Write("\n({0}) {1} ({2})\t", n + 1, orgs[n].FriendlyName, orgs[n].UrlName);

                        Console.Write("\n\nSpecify an organization number (1-{0}) [1]: ", orgs.Count);
                        String input = Console.ReadLine();
                        if (input == String.Empty) input = "1";
                        int orgNumber = Int32.Parse(input);

                        if (orgNumber > 0 && orgNumber <= orgs.Count)
                        {
                            config.OrganizationName = orgs[orgNumber - 1].FriendlyName;
                            // Return the organization Uri.
                            return new System.Uri(orgs[orgNumber - 1].Endpoints[EndpointType.OrganizationService]);
                        }
                        else
                            throw new Exception("The specified organization does not exist.");
                    }
                    else
                    {
                        Console.WriteLine("\nYou do not belong to any organizations on the specified server.");
                        return new System.Uri(String.Empty);
                    }
                }
                else
                    throw new Exception("An invalid server name was specified.");
            }
        }

        /// <summary>
        /// Obtains the user's logon credentials for the target server.
        /// </summary>
        /// <returns>Logon credentials of the user.</returns>
        protected virtual ClientCredentials GetUserLogonCredentials()
        {
            ClientCredentials credentials = new ClientCredentials(); ;
            String userName;
            String password;
            String domain;
            Boolean isCredentialExist = (config.Credentials != null) ? true : false;
            
            // An on-premises Microsoft Dynamics CRM server deployment. 
            if (config.EndpointType == AuthenticationProviderType.ActiveDirectory)
            {
                String[] domainAndUserName;
                do
                {
                    Console.Write("\nEnter domain\\username: ");
                    if (isCredentialExist) Console.WriteLine(
                        config.Credentials.Windows.ClientCredential.Domain + "\\" + config.Credentials.Windows.ClientCredential.UserName);
                    domainAndUserName = (isCredentialExist) ?
                        new String[] { config.Credentials.Windows.ClientCredential.Domain, 
                            config.Credentials.Windows.ClientCredential.UserName } :
                        Console.ReadLine().Split('\\');

                    if (domainAndUserName.Length == 1 && String.IsNullOrWhiteSpace(domainAndUserName[0]))
                    {
                        return null;
                    }
                }
                while (domainAndUserName.Length != 2 || String.IsNullOrWhiteSpace(domainAndUserName[0]) 
                    || String.IsNullOrWhiteSpace(domainAndUserName[1]));

                domain = domainAndUserName[0];
                userName = domainAndUserName[1];
                
                Console.Write("       Enter password: ");
                password = ReadPassword();

                if (!String.IsNullOrEmpty(password))
                    credentials.Windows.ClientCredential = new System.Net.NetworkCredential(userName, password, domain);
                else
                    credentials.Windows.ClientCredential = null;
            }
            // An Microsoft Dynamics CRM Online server deployment. 
            else if (config.EndpointType == AuthenticationProviderType.LiveId)
            {
                Console.Write("\n Enter Live ID: ");
                if (isCredentialExist) Console.WriteLine(config.Credentials.UserName.UserName);
                userName = (isCredentialExist) ? config.Credentials.UserName.UserName : Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userName))
                {
                    return null;
                }

                Console.Write("Enter Password: ");
                password = ReadPassword();
                
                credentials.UserName.UserName = userName;
                credentials.UserName.Password = password;
            }
            // An internet facing (IFD) Microsoft Dynamics CRM server deployment.  
            else if (config.EndpointType == AuthenticationProviderType.Federation)
            {
                Console.Write("\n Enter username: ");
                if (isCredentialExist) Console.WriteLine(config.Credentials.UserName.UserName);
                userName = (isCredentialExist) ? config.Credentials.UserName.UserName : Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userName))
                {
                    return null;
                }

                Console.Write("Enter Password: ");
                password = ReadPassword();

                credentials.UserName.UserName = userName;
                credentials.UserName.Password = password;
            }
            else
                return null;

            return credentials;
        }

        /// <summary>
        /// Prompts user to enter password in console window and capture the entered password.
        /// </summary>
        /// <returns>string password.</returns>
        protected string ReadPassword()
        {
            StringBuilder sbPassword = new StringBuilder();

            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key == ConsoleKey.Backspace)
                {
                    if (sbPassword.Length != 0)
                    {
                        sbPassword.Remove(sbPassword.Length - 1, 1);
                        Console.Write("\b \b");     // erase last char
                    }
                }
                else if (info.KeyChar >= ' ')           // no control chars
                {
                    sbPassword.Append(info.KeyChar);
                    Console.Write("*");
                }
                info = Console.ReadKey(true);
            }

            Console.WriteLine();
            Console.WriteLine();

            return sbPassword.ToString();
        }

        /// <summary>
        /// Get the device credentials by either loading from local cache 
        /// or request new device credentials by registering the device.
        /// </summary>
        /// <returns>Device Credentials.</returns>
        protected virtual ClientCredentials GetDeviceCredentials()
        {
            return Microsoft.Crm.Services.Utility.DeviceIdManager.LoadOrRegisterDevice();
        }
        
        /// <summary>
        /// Verify passed strings with the supported AuthenticationProviderType.
        /// </summary>
        /// <param name="authType">String AuthenticationType</param>
        /// <returns>Supported AuthenticatoinProviderType</returns>
        private AuthenticationProviderType RetrieveAuthenticationType(String authType)
        {
            switch (authType)
            {
                case "ActiveDirectory":
                    return AuthenticationProviderType.ActiveDirectory;
                case "LiveId":
                    return AuthenticationProviderType.LiveId;
                case "Federation":
                    return AuthenticationProviderType.Federation;
                default:
                    throw new ArgumentException(String.Format("{0} is not a valid authentication type", authType));
            }
        }

        /// <summary>
        /// Parse credentials from a xml node to required ClientCredentials data type 
        /// based on passed AuthenticationProviderType.
        /// </summary>
        /// <param name="credentials">Credential xml node.</param>
        /// <param name="endpointType">AuthenticationProviderType of the credential.</param>
        /// <returns>Required ClientCredentials type.</returns>
        private ClientCredentials ParseInCredentials(XElement credentials, AuthenticationProviderType endpointType)
        {
            ClientCredentials result = new ClientCredentials();

            switch (endpointType)
            {
                case AuthenticationProviderType.ActiveDirectory:
                    result.Windows.ClientCredential = new System.Net.NetworkCredential()
                    {
                        UserName = credentials.Element("UserName").Value,
                        Domain = credentials.Element("Domain").Value
                    };
                    break;
                case AuthenticationProviderType.LiveId:
                    result.UserName.UserName = credentials.Element("UserName").Value;
                    break;
                case AuthenticationProviderType.Federation:
                    result.UserName.UserName = credentials.Element("UserName").Value;
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// Parse ClientCredentials in to xml node. 
        /// </summary>
        /// <param name="clientCredentials">ClientCredentials type.</param>
        /// <param name="endpointType">AuthenticationProviderType of the credentials.</param>
        /// <returns>Xml node containing credentials data.</returns>
        private XElement ParseOutCredentials(ClientCredentials clientCredentials, AuthenticationProviderType endpointType)
        {
            if (clientCredentials != null)
            {
                switch (endpointType)
                {
                    case AuthenticationProviderType.ActiveDirectory:
                        return new XElement("Credentials",
                            new XElement("UserName", clientCredentials.Windows.ClientCredential.UserName),
                            new XElement("Domain", clientCredentials.Windows.ClientCredential.Domain)
                            );
                    case AuthenticationProviderType.LiveId:
                        return new XElement("Credentials",
                            new XElement("UserName", clientCredentials.UserName.UserName)
                            );
                    case AuthenticationProviderType.Federation:
                        return new XElement("Credentials",
                           new XElement("UserName", clientCredentials.UserName.UserName)
                           );
                    default:
                        break;
                }
            }          

            return new XElement("Credentials", "");
        }

        #endregion Private methods

        #region Private Classes
        /// <summary>
        /// private static class to store constants required by the CrmServiceHelper class.
        /// </summary>
        private static class CrmServiceHelperConstants
        {
            /// <summary>
            /// Credentials file path.
            /// </summary>
            public static readonly string ServerCredentialsFile = Path.Combine(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CrmServer"),
                "Credentials.xml");
        }
        #endregion
    }
}
//</snippetCrmServiceHelper>
