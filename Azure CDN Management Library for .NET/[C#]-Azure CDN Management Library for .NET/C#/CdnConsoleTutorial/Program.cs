using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace CdnConsoleTutorial
{
    class Program
    {
        //Tenant app constants
        private const string clientID = "<YOUR CLIENT ID>";
        private const string clientSecret = "<YOUR CLIENT AUTHENTICATION KEY>"; //Only for service principals
        private const string authority = "https://login.microsoftonline.com/<YOUR TENANT ID>/<YOUR TENANT DOMAIN NAME>";

        //Application constants
        private const string subscriptionId = "<YOUR SUBSCRIPTION ID>";
        private const string profileName = "CdnConsoleApp";
        private const string endpointName = "<A UNIQUE NAME FOR YOUR CDN ENDPOINT>";
        private const string resourceGroupName = "CdnConsoleTutorial";
        private const string resourceLocation = "Central US";

        // We'll use these to indicate if the profile and/or endpoint already exist
        static bool profileAlreadyExists = false;
        static bool endpointAlreadyExists = false;

        static void Main(string[] args)
        {
            //Get a token
            AuthenticationResult authResult = GetAccessToken();

            // Create CDN client
            CdnManagementClient cdn = new CdnManagementClient(new TokenCredentials(authResult.AccessToken))
            { SubscriptionId = subscriptionId };

            ListProfilesAndEndpoints(cdn);

            // Create CDN Profile
            CreateCdnProfile(cdn);

            // Create CDN Endpoint
            CreateCdnEndpoint(cdn);

            Console.WriteLine();

            // Purge CDN Endpoint
            PromptPurgeCdnEndpoint(cdn);

            // Delete CDN Endpoint
            PromptDeleteCdnEndpoint(cdn);

            // Delete CDN Profile
            PromptDeleteCdnProfile(cdn);

            Console.WriteLine("Press Enter to end program.");
            Console.ReadLine();
        }

        /// <summary>
        /// Prompts the user with a yes/no question and returns the result.
        /// </summary>
        /// <param name="Question">The question to ask the user.</param>
        /// <returns>A boolean if the user's response.</returns>
        private static bool PromptUser(string Question)
        {
            Console.Write(Question + " (Y/N): ");
            var response = Console.ReadKey();
            Console.WriteLine();
            if (response.Key == ConsoleKey.Y)
            {
                return true;
            }
            else if (response.Key == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                // They're not pressing Y or N.  Let's ask them again.
                return PromptUser(Question);
            }
        }

        /// <summary>
        /// Gets an access token for the service principal
        /// </summary>
        /// <returns>AuthenticationResult</returns>
        private static AuthenticationResult GetAccessToken()
        {
            AuthenticationContext authContext = new AuthenticationContext(authority);
            ClientCredential credential = new ClientCredential(clientID, clientSecret);
            AuthenticationResult authResult = authContext.AcquireTokenAsync("https://management.core.windows.net/", credential).Result;

            return authResult;
        }

        /// <summary>
        /// Lists all of the CDN profiles and endpoints for a given resource group.
        /// </summary>
        /// <param name="cdn">Authenticated CdnManagementClient</param>
        private static void ListProfilesAndEndpoints(CdnManagementClient cdn)
        {
            // List all the CDN profiles in this resource group
            var profileList = cdn.Profiles.ListByResourceGroup(resourceGroupName);
            foreach (Profile p in profileList)
            {
                Console.WriteLine("CDN profile {0}", p.Name);
                if (p.Name.Equals(profileName, StringComparison.OrdinalIgnoreCase))
                {
                    // Hey, that's the name of the CDN profile we want to create!
                    profileAlreadyExists = true;
                }

                //List all the CDN endpoints on this CDN profile
                Console.WriteLine("Endpoints:");
                var endpointList = cdn.Endpoints.ListByProfile(p.Name, resourceGroupName);
                foreach (Endpoint e in endpointList)
                {
                    Console.WriteLine("-{0} ({1})", e.Name, e.HostName);
                    if (e.Name.Equals(endpointName, StringComparison.OrdinalIgnoreCase))
                    {
                        // The unique endpoint name already exists.
                        endpointAlreadyExists = true;
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Creates a CDN profile.
        /// </summary>
        /// <param name="cdn">An authenticated CdnManagementClient</param>
        private static void CreateCdnProfile(CdnManagementClient cdn)
        {
            if (profileAlreadyExists)
            {
                Console.WriteLine("Profile {0} already exists.", profileName);
            }
            else
            {
                Console.WriteLine("Creating profile {0}.", profileName);
                ProfileCreateParameters profileParms =
                    new ProfileCreateParameters() { Location = resourceLocation, Sku = new Sku(SkuName.StandardVerizon) };
                cdn.Profiles.Create(profileName, profileParms, resourceGroupName);
            }
        }

        /// <summary>
        /// Creates the CDN endpoint.
        /// </summary>
        /// <param name="cdn">An authenticated CdnManagementClient</param>
        private static void CreateCdnEndpoint(CdnManagementClient cdn)
        {
            if (endpointAlreadyExists)
            {
                Console.WriteLine("Profile {0} already exists.", profileName);
            }
            else
            {
                Console.WriteLine("Creating endpoint {0} on profile {1}.", endpointName, profileName);
                EndpointCreateParameters endpointParms =
                  new EndpointCreateParameters()
                  {
                      Origins = new List<DeepCreatedOrigin>() { new DeepCreatedOrigin("Contoso", "www.contoso.com") },
                      IsHttpAllowed = true,
                      IsHttpsAllowed = true,
                      Location = resourceLocation
                  };
                cdn.Endpoints.Create(endpointName, endpointParms, profileName, resourceGroupName);
            }
        }

        /// <summary>
        /// Purges the CDN endpoint.
        /// </summary>
        /// <param name="cdn">An authenticated CdnManagementClient</param>
        private static void PromptPurgeCdnEndpoint(CdnManagementClient cdn)
        {
            if (PromptUser(String.Format("Purge CDN endpoint {0}?", endpointName)))
            {
                Console.WriteLine("Purging endpoint. Please wait...");
                cdn.Endpoints.PurgeContent(endpointName, profileName, resourceGroupName, new List<string>() { "/*" });
                Console.WriteLine("Done.");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prompts the user to delete the CDN profile, then carries it out.
        /// </summary>
        /// <param name="cdn">An authenticated CdnManagementClient</param>
        private static void PromptDeleteCdnProfile(CdnManagementClient cdn)
        {
            if (PromptUser(String.Format("Delete CDN profile {0}?", profileName)))
            {
                Console.WriteLine("Deleting profile. Please wait...");
                cdn.Profiles.DeleteIfExists(profileName, resourceGroupName);
                Console.WriteLine("Done.");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prompts the user to delete the CDN endpoint, then carries it out.
        /// </summary>
        /// <param name="cdn">An authenticated CdnManagementClient</param>
        private static void PromptDeleteCdnEndpoint(CdnManagementClient cdn)
        {
            if (PromptUser(String.Format("Delete CDN endpoint {0} on profile {1}?", endpointName, profileName)))
            {
                Console.WriteLine("Deleting endpoint. Please wait...");
                cdn.Endpoints.DeleteIfExists(endpointName, profileName, resourceGroupName);
                Console.WriteLine("Done.");
                Console.WriteLine();
            }
        }
    }
}
