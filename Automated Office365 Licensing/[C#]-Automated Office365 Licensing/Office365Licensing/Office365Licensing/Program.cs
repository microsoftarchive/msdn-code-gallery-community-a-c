using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.Azure.ActiveDirectory.GraphClient.ErrorHandling;
using Microsoft.Azure.ActiveDirectory.GraphClient.Extensions;
using System.Linq.Expressions;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Security;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

//*************************************************************************************************************************************************************************************************
//  BACKGROUND AND DESCRIPTION.
//
//  Licensing for enterprises and large companies that have enabled Office365 workloads is needed to be handled as a service rather than a user by user task.  New users are added to their 
//  directories daily and roles change just as often, so the need for licenses to be added for these users needs to happen just as often to enable their productivity.  With this solution we have 
//  attempted to come up with a design that allows ITPros to license new/unlicensed (never had any licenses) users or users based on their role.  For the role based licensing we will license 
//  these users based upon their presence within an Azure Active Directory (AAD) security group.
//
//  All the information that is required to connect to AAD and pull security group information as well as license a user within their AAD tenant will be stored in a XML config file.  This 
//  way you can alter the connection information based on which tenant you would want to license users for.
//
//  The solution requires the ITPro to create a service principal in Azure Active Directory for their tenant that has read / write permissions to AAD directory 
//  data (https://azure.microsoft.com/en-us/documentation/articles/active-directory-integrating-applications/).  This is how the licenses are assigned.  It also requires permissions to connect
//  via powershell to AAD to pull group and unlicensed user information.
//
//  MIT LICENSE
//  Copyright (c) <year> <copyright holders>
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.

//*************************************************************************************************************************************************************************************************

namespace Office365Licensing
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ensure Log File is Created
            CheckLogFile();
            #endregion

            #region Check Args Passed To App
            bool verbose = CheckArgs(args);
            #endregion

            #region Read XML Config
            //*************************************************************************************************************************************************************************************
            //  Read in the configuration information from the XML file (config.xml) in the same directory as the application.  These will be the variables used to connect to Azure Active
            //  Directory and ensure the right licenses for each user is assigned.  In most cases where the XML variable provided isnt multivalue, we use the .First() function to be sure
            //  we dont get a null reference exception when loading the XML.
            //*************************************************************************************************************************************************************************************
            XElement xml = XElement.Load("config.xml");
            var tenantName = xml.Descendants("tenantname").First().Value;
            var tenantID = xml.Descendants("tenantid").First().Value;
            var clientID = xml.Descendants("clientid").First().Value;
            var clientSecret = xml.Descendants("clientsecret").First().Value;
            var adminUPN = xml.Descendants("adminupn").First().Value;
            var adminPass = xml.Descendants("adminpassword").First().Value;
            var groupbased = xml.Descendants("groupbased").First().Value;
            var aadgroup = xml.Descendants("aadgroupobjectid").First().Value;
            var assignedPlanID = xml.Descendants("skuid").First().Value;
            var enabledPlansXML = xml.Descendants("enabledplanid");
            var removeSku = xml.Descendants("removeskuid");

            Collection<string> removeSkus = new Collection<string>();
            foreach (var rs in removeSku)
            {
                removeSkus.Add(rs.Value.ToString());
            }

            Collection<string> enabledPlans = new Collection<string>();

            foreach (var ep in enabledPlansXML)
            {
                enabledPlans.Add(ep.Value.ToString());
            }

            #endregion

            #region Setup Active Directory Client

            //*************************************************************************************************************************************************************************************
            //  Setup the Active Directory Client, thanks to Danny Strockis (https://github.com/AzureADSamples/ConsoleApp-GraphAPI-DotNet) for the Helper and Authentication Helper classes.  This
            //  will create a connection to AAD via Graph based on the information provided in the above XML config file.  The authentication is done using an application object of the clientID
            //  provided.  
            //*************************************************************************************************************************************************************************************
            ActiveDirectoryClient activeDirectoryClient;
            Console.WriteLine("Connecting to AAD Graph...");
            try
            {
                activeDirectoryClient = AuthenticationHelper.GetActiveDirectoryClientAsApplication(tenantID, clientID, clientSecret, tenantName);
            }
            catch (AuthenticationException ex)
            {
                ToggleConsoleColor();
                Console.WriteLine("Acquiring a token failed with the following error: {0}", ex.Message);
                WriteLogs("Error", "Unable to Authenticate with AAD.  " + ex.Message, "ActiveDirectoryClient");
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Error detail: {0}", ex.InnerException.Message);
                    WriteLogs("Error", "Unable to Authenticate with AAD.  " + ex.InnerException.Message, "ActiveDirectoryClient");
                }
                ToggleConsoleColor();
                return;
            }

            #endregion

            #region Get Usage Location if None Provided
            //  We get the usage location from the Tenant information.
            string usageLocation = GetUsageLocation(activeDirectoryClient, tenantName);
            #endregion

            #region Get Users to License
            //  Create a collection of strings to hold the users to apply a license to.
            //  Check to see if we are going to be licensing a group or all unlicensed users.
            Collection<string> unlicensedUsers = new Collection<string>();
            if (groupbased.ToLower() == "false")
            {
                Console.WriteLine("Getting all Unlicensed users...");
                unlicensedUsers = GetUnlicensedUsers(adminUPN, adminPass);
            }
            else if (groupbased.ToLower() == "true")
            {
                Console.WriteLine("Getting all user in group " +aadgroup.ToString()+"...");
                unlicensedUsers = GetUnlicensedUsers(aadgroup.ToString(), adminUPN, adminPass);
            }
            #endregion

            #region Get Available Licenses from Tenant
            //  Get the License information for the SKU ID matching the SKU ID passed through the XML file.
            ISubscribedSku sku = GetSubscribedSkus(activeDirectoryClient, assignedPlanID);
            #endregion

            #region AssignLicenses
            //*************************************************************************************************************************************************************************************
            //  Assign Licenses to the users returned in the group search or unlicensed users search.  We need to do some queries first to ensure the user information retrieved from graph.
            //  We then use that user information to ensure the user location is set correctly (or else license assignment will fail), get the disabled plans for the user's sku that is to
            //  be assigned.  Finally, check to see if the user's license set is already has the plans you want to enable for that user.
            //*************************************************************************************************************************************************************************************
            foreach (string upn in unlicensedUsers)
            {
                User retrievedUser = FindUser(upn, activeDirectoryClient);
                
                //  If user info isnt null and the user location doesnt match the tenants location, set the location
                if (retrievedUser.UsageLocation != usageLocation.ToString() && retrievedUser.UserPrincipalName != null)
                {
                    SetUserLocation(retrievedUser, usageLocation);
                }

                //  If the user is found and valid, find the plans you need to enable / disable.
                if (retrievedUser.UserPrincipalName != null)
                {
                    Collection<string> disabledPlans = GetDisabledPlans(sku, enabledPlans);
                    bool checkLicense = CheckForLicense(retrievedUser, sku, enabledPlans, disabledPlans);

                    //  If user already has the licences you want to assign, dont assign them again.
                    if (checkLicense)
                    {
                        //  If there are SKUs to be removed as part of the licensing process use the overload that removes sku's.
                        if (removeSkus.Count > 0)
                        {
                            AssignLicense(retrievedUser, assignedPlanID, disabledPlans, removeSkus, verbose);
                        }
                        else
                        {
                            AssignLicense(retrievedUser, assignedPlanID, disabledPlans, verbose);
                            
                        }
                    }
                    else
                    {
                        //  If -v is passed then write to the screen.
                        if (verbose)
                        {
                            Console.WriteLine(retrievedUser.UserPrincipalName + " already has these plans enabled for this SKU.");
                        }
                    }
                }
            }
            #endregion

        }

        public static bool CheckArgs(string[] args)
        {
            //*************************************************************************************************************************************************************************************
            //  This function checks to see if the -v is passed at the command line.  If so we're going to display verbose messaging to the screen.  Can be expanded to evaluate other command
            //  line flags if nessessary.
            //*************************************************************************************************************************************************************************************
            bool verbose;
            if (args.Contains("-v"))
            {
                verbose = true;
            }
            else
            {
                verbose = false;
            }

            return verbose;
        }

        public static ISubscribedSku GetSubscribedSkus(ActiveDirectoryClient activeDirectoryClient, string skuID)
        {
            //Try to get the subscribed skus for the tenant.
            IPagedCollection<ISubscribedSku> skus = null;
            try
            {
                skus = activeDirectoryClient.SubscribedSkus.ExecuteAsync().Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError getting Applications {0} {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            //  Loop through all the available skus for the tenant until the SKU provided in the XML is found and return this Sku to be used later.
            ISubscribedSku sku = null;
            do
            {
                List<ISubscribedSku> subscribedSkus = skus.CurrentPage.ToList();
                foreach (ISubscribedSku s in subscribedSkus)
                {
                    if (s.SkuId == new Guid(skuID))
                    {
                        sku = s;
                    }
                }
                skus = skus.GetNextPageAsync().Result;
            } while (skus != null);

            return sku;
        }

        public static string GetUsageLocation(ActiveDirectoryClient activeDirectoryClient, string tenantName)
        {
            //  Get the usage location of the tenant, to ensure the user has the correct usage location, so license appliction doesn't fail.
            ITenantDetail tenant = null;
            try
            {
                List<ITenantDetail> tenantsList = activeDirectoryClient.TenantDetails
                    .ExecuteAsync().Result.CurrentPage.ToList();
                if (tenantsList.Count > 0)
                {
                    tenant = tenantsList.First();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError getting TenantDetails {0} {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return tenant.CountryLetterCode;
        }

        public static void SetUserLocation(User usr, string usageLoc)
        {
            //  Set the user's usage location.  
            //  Write to the error log if it fails.
            usr.UsageLocation = usageLoc;
            try
            {
                usr.UpdateAsync().Wait();
                Console.Write("\nUser {0} successfully assigned location.", usr.DisplayName,
                    usr.DisplayName);

            }
            catch (Exception e)
            {
                ToggleConsoleColor();
                Console.WriteLine("\nError assigning location to user. {0} {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
                WriteLogs("Error", e.Message + ".  Error Assigning Location for User.  " + usr.UserPrincipalName.ToString(), "SetUserLocation");
                ToggleConsoleColor();
            }
        }

        public static void ToggleConsoleColor()
        {
            //  When writing to the screen lets have the color change to make it more noticable in verbose mode.
            if ((Console.ForegroundColor == ConsoleColor.Black) && (Console.BackgroundColor == ConsoleColor.Yellow))
            {
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
        }

        public static Collection<string> GetDisabledPlans(ISubscribedSku sku, Collection<string> enabledPlans)
        {
            //************************************************************************************************************************************************************************************
            //  Loop through the plans for the sku you want to enable, retrieved from graph.  If the service plan does not match one of the plans that you want to enable for this user (plans 
            //  from the XML config file), then add the plan to the collection of disabled plans.  
            //
            //  The logic for this is that you have to give the plans you want disabled when assigning a sku.  However, we want to do our check for enabled plans since we dont want to have two 
            //  of these processes fighting back and forth, enabling and disabling users.
            //
            //  Also, note that Yammer is always in pending activation, no matter what and therefore needs to be excluded.
            //************************************************************************************************************************************************************************************
            #region Get Disabled Plans from Sku
            Collection<string> disabledPlans = new Collection<string>();
            
            foreach (ServicePlanInfo lic in sku.ServicePlans)
            {
                if (!enabledPlans.Contains(lic.ServicePlanId.ToString()) && (!lic.ServicePlanName.Contains("YAMMER")))
                {
                    disabledPlans.Add(lic.ServicePlanId.ToString());
                }
            }
            #endregion
            return disabledPlans;
        }

        public static bool CheckForLicense(User retrievedUser, ISubscribedSku sku, Collection<string> assignedPlans, Collection<string> disabledPlans)
        {
            //************************************************************************************************************************************************************************************
            //  To be sure we dont make unneccessary calls to the Graph API which counts against our throttling policy we should check to see if the user already has the plans that you want 
            //  enabled.  To accomplish this, we loop through all the user's currently assigned licenses and find the SKU we want to evaluate.  For those plans in the matching sku we check to
            //  see if the service plans are not in that user's disabled plans, this tells us if that service plan is already assigned.
            //
            //  Now that we have all the plans that are currently assigned to the user we can compare them against the plans you want to assign to the use, that are passed in from the config 
            //  XML file.  If the plans all match return false, if a plan is found that isnt in the users assigned plans, immediately return true.
            //************************************************************************************************************************************************************************************

            bool check = true;
            Collection<string> userPlans = new Collection<string>();

            #region Get all users enabled plans for the SKU passed
            
            //  Find all the user's assigned plans for the SKU passed. 
            foreach (AssignedLicense lic in retrievedUser.AssignedLicenses)
            {
                if (lic.SkuId == sku.SkuId)
                {
                    foreach (ServicePlanInfo sp in sku.ServicePlans)
                    {
                        if (!lic.DisabledPlans.Contains(new Guid(sp.ServicePlanId.Value.ToString())))
                        {
                            userPlans.Add(sp.ServicePlanId.ToString());
                        }
                        
                    }
                }
            }
            #endregion

            #region Check all the plans you want assigned against the user's currently assigned plans.

            //  Compare assigned plans with the plans passed in from the XML file.
            foreach (string planToCheck in assignedPlans)
            {
                if (userPlans.Contains(planToCheck))
                {
                    check = false;
                }
                else
                {
                    check = true;
                    break;
                }
            }
            #endregion

            return check;
            
        }

        public static void AssignLicense(User retrievedUser, string assignedPlanID, Collection<string> disabledPlans, bool verbose)
        {
            //************************************************************************************************************************************************************************************
            //  Now that we have all the information necessary we need to license the users.  Set the License Sku to add, Add the disabled plans to the license.  Assign the license, and 
            //  report any errors to the log file.  Handle the errors that could be thrown.
            //************************************************************************************************************************************************************************************
            #region Assign License to User
            //  Create and assign the SKU to the new license object.
            AssignedLicense addLicense = new AssignedLicense();
            addLicense.SkuId = new Guid(assignedPlanID);
            //  Load the disabled plans into the license object.
            foreach (string dp in disabledPlans)
            {
                try
                {
                    addLicense.DisabledPlans.Add(new Guid(dp));
                }
                catch (FormatException)
                {
                    ToggleConsoleColor();
                    Console.WriteLine("Null value or incorrect GUID format provided for Disabled Plan: " + dp + "\nLicense will still be applied for " + retrievedUser.UserPrincipalName);
                    WriteLogs("ERROR", "Null value or incorrect GUID format provided for Disabled Plan: " + dp + " License will still be applied for " + retrievedUser.UserPrincipalName, "AssignLicense");
                    ToggleConsoleColor();
                }
            }

            //  Add the license object to the IEnumerable that the AssignLicenseAsync method takes.
            IList<AssignedLicense> licensesToAdd = new AssignedLicense[] { addLicense };
            IList<Guid> licensesToRemove = new Guid[] { };

            //  Assign the License.
            try
            {
                retrievedUser.AssignLicenseAsync(licensesToAdd, licensesToRemove).Wait();
                Console.WriteLine("\nUser {0} was assigned license {1}", retrievedUser.UserPrincipalName, addLicense.SkuId);
                if (verbose)
                {
                    WriteLogs("Info", "User "+retrievedUser.UserPrincipalName+" was assigned license " + addLicense.SkuId +".", "AssignLicenses");
                    WriteLogs("Debug", "User " + retrievedUser.UserPrincipalName + " was assigned license " + addLicense.SkuId + " DisabledPlans: " + addLicense.DisabledPlans.Count.ToString(), "AssignLicenses");
                }

            }
            catch (GraphException e)
            {
                //  Graph Error Handling.
                ToggleConsoleColor();
                Console.WriteLine("\nLicense assingment failed {0} {1}", e.Message,
                                        e.InnerException != null ? e.InnerException.Message : "");
                WriteLogs("Error", "License assignment failed.  " + e.Message + "," + retrievedUser.UserPrincipalName, "AssignLicense_GraphException");
                ToggleConsoleColor();
            }
            catch (AggregateException e)
            {
                //  AggrigateExceptions could be due to throttling, check for throttling errors and backoff.  Write error to logs.
                ToggleConsoleColor();
                Console.WriteLine("\nLicense assingment failed {0} {1}", e.Message,
                                        e.InnerException != null ? e.InnerException.Message : "");

                JObject o = new JObject();
                try
                {
                    o = JObject.Parse(@e.InnerExceptions[0].InnerException.Message.ToString());
                }
                catch (Exception ex)
                {
                    WriteLogs("Error", "License assignment failed, unable to parse Aggrigage Exception.  " + ex.Message + "|" + retrievedUser.UserPrincipalName, "AssignLicense_AggrigateException");
                }
                
                string message = "";
                string code = "";
                try
                {
                    message = (string)o["odata.error"]["message"]["value"];
                    code = (string)o["odata.error"]["code"];
                }
                catch(Exception)
                {
                    message = "Json Error, Possible Throttling.  Enable backoff logic.";
                    code = "Request_ThrottledTemporarily";
                }

                WriteLogs("Error", "License assignment failed.  " + message + "|" + retrievedUser.UserPrincipalName, "AssignLicense_AggrigateException");
                ToggleConsoleColor();
                if (code == "Request_ThrottledTemporarily")
                {
                    Console.WriteLine("Graph is being Throttled: Sleeping for 300 Seconds...");
                    System.Threading.Thread.Sleep(300000);
                }
            }
            catch (Exception x)
            {
                ToggleConsoleColor();
                Console.WriteLine("\nLicense assingment failed {0} {1}", x.Message,
                                    x.InnerException != null ? x.InnerException.Message : "");
                WriteLogs("Error", "License assignment failed.  " + x.InnerException.Message.ToString() + "|" + retrievedUser.UserPrincipalName, "AssignLicense_Exception");
                ToggleConsoleColor();
            }

            #endregion
        }

        public static void AssignLicense(User retrievedUser, string assignedPlanID, Collection<string> disabledPlans, Collection<string> removeskus, bool verbose)
        {
            //************************************************************************************************************************************************************************************
            //  Now that we have all the information necessary we need to license the users.  Set the License Sku to add, Add the disabled plans to the license.  Assign the license, and 
            //  report any errors to the log file.  Handle the errors that could be thrown.
            //************************************************************************************************************************************************************************************
           
            #region Assign License to User

            //  Create and assign the SKU to the new license object.
            AssignedLicense addLicense = new AssignedLicense();
            addLicense.SkuId = new Guid(assignedPlanID);

            //  Load the disabled plans into the license object.
            foreach (string dp in disabledPlans)
            {
                try
                {
                    addLicense.DisabledPlans.Add(new Guid(dp));
                }
                catch (FormatException)
                {
                    ToggleConsoleColor();
                    Console.WriteLine("Null value or incorrect GUID format provided for Disabled Plan: " + dp + "\nLicense will still be applied for "+ retrievedUser.UserPrincipalName);
                    WriteLogs("ERROR", "Null value or incorrect GUID format provided for Disabled Plan: " + dp + " License will still be applied for " + retrievedUser.UserPrincipalName, "AssignLicense");
                    ToggleConsoleColor();
                }

            }

            //  Add the license object to the IEnumerable that the AssignLicenseAsync method takes.
            IList<AssignedLicense> licensesToAdd = new AssignedLicense[] { addLicense };
            Collection<Guid> licensesToRemove = new Collection<Guid>();

            //  Check all licenses applied to the current user and remove the SKU if it is one of the SKU Ids present and passed in by the XML file.
            foreach (AssignedLicense removeSkuID in retrievedUser.AssignedLicenses)
            {
                if (removeskus.Contains(removeSkuID.SkuId.ToString()))
                {
                    licensesToRemove.Add(new Guid(removeSkuID.SkuId.ToString()));
                }
            }
            
            //  Assign the license.
            try
            {
                retrievedUser.AssignLicenseAsync(licensesToAdd, licensesToRemove).Wait();
                Console.WriteLine("\nUser {0} was assigned license {1}", retrievedUser.UserPrincipalName, addLicense.SkuId);
                if (verbose)
                {
                    WriteLogs("Info", "User " + retrievedUser.UserPrincipalName + " was assigned license " + addLicense.SkuId + ".", "AssignLicenses");
                    WriteLogs("Debug", "User " + retrievedUser.UserPrincipalName + " was assigned license " + addLicense.SkuId + " DisabledPlans: " + addLicense.DisabledPlans.Count.ToString(), "AssignLicenses");
                }

            }
            catch (GraphException e)
            {
                //  Graph Error Handling.
                ToggleConsoleColor();
                Console.WriteLine("\nLicense assingment failed {0} {1}", e.Message,
                                        e.InnerException != null ? e.InnerException.Message : "");
                WriteLogs("Error", "License assignment failed.  " + e.Message + ","+retrievedUser.UserPrincipalName, "AssignLicense_GraphException");
                ToggleConsoleColor();
            }
            catch (AggregateException e)
            {
                //  AggrigateExceptions could be due to throttling, check for throttling errors and backoff.  Write error to logs.
                ToggleConsoleColor();
                Console.WriteLine("\nLicense assingment failed {0} {1}", e.Message,
                                        e.InnerException != null ? e.InnerException.Message : "");
                try
                {
                    JObject o = new JObject();
                    try
                    {
                        o = JObject.Parse(@e.InnerExceptions[0].InnerException.Message.ToString());
                    }
                    catch (Exception ex)
                    {
                        WriteLogs("Error", "License assignment failed, unable to parse Aggrigage Exception.  " + ex.Message + "|" + retrievedUser.UserPrincipalName, "AssignLicense_AggrigateException");
                    }
                    
                    string message = "";
                    string code = "";
                    try
                    {
                        message = (string)o["odata.error"]["message"]["value"];
                        code = (string)o["odata.error"]["code"];
                    }
                    catch (Exception)
                    {
                        message = "Json Error, Possible Throttling.  Enable backoff logic.";
                        code = "Request_ThrottledTemporarily";
                    }

                    WriteLogs("Error", "License assignment failed.  " + message + "|" + retrievedUser.UserPrincipalName, "AssignLicense_AggrigateException");
                    ToggleConsoleColor();
                    if (code == "Request_ThrottledTemporarily")
                    {
                        Console.WriteLine("Graph is being Throttled: Sleeping for 300 Seconds...");
                        System.Threading.Thread.Sleep(300000);
                    }
                }
                catch (Exception x)
                {
                    ToggleConsoleColor();
                    Console.WriteLine("\nLicense assingment failed {0} {1}", x.Message,
                                        x.InnerException != null ? x.InnerException.Message : "");
                    WriteLogs("Error", "License assignment failed.  " + x.InnerException.Message.ToString() + "|" + retrievedUser.UserPrincipalName, "AssignLicense_Exception");
                    ToggleConsoleColor();
                }
            }

            #endregion
        }

        public static void CheckLogFile()
        {
            //  Check if a log file exists, if it does, do nothing, If not then create with headers, "|" delimited.
            if (!System.IO.File.Exists("Logs.log"))
            {
                Console.WriteLine("Creating Log File...");
                System.IO.File.AppendAllText(@"Logs.log", "TYPE|DATETIME|DETAILS|ADDITIONALINFO\r\n");
            }
        }

        public static User FindUser(string upn, ActiveDirectoryClient activeDirectoryClient)
        {
            //************************************************************************************************************************************************************************************
            //  Search for a User by their UserPrincipalName.  Make a call to the graph API and retrieve the first object found.
            //************************************************************************************************************************************************************************************
            
            // search for a single user by UPN
            string searchString = upn;
            User retrievedUser = new User();
            List<IUser> retrievedUsers = null;

            try
            {
                retrievedUsers = activeDirectoryClient.Users
                    .Where(user => user.UserPrincipalName.Equals(searchString))
                    .ExecuteAsync().Result.CurrentPage.ToList();
            }
            catch (Exception e)
            {
                ToggleConsoleColor();
                Console.WriteLine("\nError getting new user {0} {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
                WriteLogs("Error", e.Message + ".  Error getting new user." + upn, "FindUsers");
                ToggleConsoleColor();
            }

            User foundUser = new User();
            
            // should only find one user with the specified UPN
            if (retrievedUsers != null && retrievedUsers.Count == 1)
            {
                foundUser = (User)retrievedUsers.First();
            }
            else
            {
                ToggleConsoleColor();
                Console.WriteLine("User not found {0}", searchString);
                WriteLogs("Error", "User not found. "+ upn, "FindUsers");
                ToggleConsoleColor();
            }

            return foundUser;
        }
        
        public static Collection<string> GetUnlicensedUsers(string adminUPN, string adminPass)
        {
            //************************************************************************************************************************************************************************************
            //  For performance issues we're going to use PowerShell to pull our user information from AAD.  We're going to create a new powershell session and import the MSOnline module 
            //  (https://msdn.microsoft.com/en-us/library/azure/jj151815.aspx).  We will then authenticate to AAD with a new command object.  We will then create a command object that will pull
            //  all our users to license.  We then loop through these commands to get the information we need and return the array of users to license to the program.
            //************************************************************************************************************************************************************************************

            #region Get Unlicensed Users

            Collection<string> unlicensedUsers = new Collection<string>();

            // Create Initial Session State for runspace.
            InitialSessionState initialSession = InitialSessionState.CreateDefault();
            initialSession.ImportPSModule(new[] { "MSOnline" });
            // Create credential object.
            SecureString secureString = new SecureString();
            foreach (char c in adminPass.ToCharArray())
            {
                secureString.AppendChar(c);
            }
            PSCredential credential = new PSCredential(adminUPN, secureString);

            // Create command to connect office 365.
            Command connectCommand = new Command("Connect-MsolService");
            connectCommand.Parameters.Add((new CommandParameter("Credential", credential)));

            // Create command to get office 365 users.
            Command getUnLicensedCommand = new Command("Get-MsolUser");
            getUnLicensedCommand.Parameters.Add((new CommandParameter("UnlicensedUsersOnly")));
            getUnLicensedCommand.Parameters.Add((new CommandParameter("All")));
            getUnLicensedCommand.Parameters.Add((new CommandParameter("Synchronized")));

            using (Runspace psRunSpace = RunspaceFactory.CreateRunspace(initialSession))
            {
                // Open runspace.
                psRunSpace.Open();

                //Iterate through each command and executes it.
                foreach (var com in new Command[] { connectCommand, getUnLicensedCommand })
                {
                    var pipe = psRunSpace.CreatePipeline();
                    pipe.Commands.Add(com);

                    // Execute command and generate results and errors (if any).
                    Collection<PSObject> results = pipe.Invoke();
                    var error = pipe.Error.ReadToEnd();
                    if (error.Count > 0 && com == connectCommand)
                    {
                        ToggleConsoleColor();
                        Console.WriteLine(error[0].ToString(), "Problem in login.  Ensure you have the Microsoft Signin Assistant and Microsoft Online Powershell Module installed.");
                        WriteLogs("Error", error[0].ToString() + ".  Problem in login.  Ensure you have the Microsoft Signin Assistant and Microsoft Online Powershell Module installed.", "GetUnlicensedUsers");
                        ToggleConsoleColor();
                    }
                    if (error.Count > 0 && com == getUnLicensedCommand)
                    {
                        ToggleConsoleColor();
                        Console.WriteLine(error[0].ToString(), "Problem in getting licenses");
                        WriteLogs("Error", error[0].ToString() + "Problem in getting licenses.", "GetUnlicensedUsers");
                        ToggleConsoleColor();
                    }
                    if (error.Count < 1 && com == getUnLicensedCommand)
                    {
                        foreach (PSObject unlicensedUser in results)
                        {
                            unlicensedUsers.Add(unlicensedUser.Members["UserPrincipalName"].Value.ToString());
                        }
                    }
                }
                // Close the runspace.
                psRunSpace.Close();
            }
            return unlicensedUsers;
            #endregion
        }

        public static Collection<string> GetUnlicensedUsers(string groupName, string adminUPN, string adminPass)
        {
            //************************************************************************************************************************************************************************************
            //  For performance issues we're going to use PowerShell to pull our user information from AAD.  We're going to create a new powershell session and import the MSOnline module 
            //  (https://msdn.microsoft.com/en-us/library/azure/jj151815.aspx).  We will then authenticate to AAD with a new command object.  We will then create a command object that will pull
            //  all our users to license.  We then loop through these commands to get the information we need and return the array of users to license to the program.
            //************************************************************************************************************************************************************************************

            #region Get Unlicensed Users

            Collection<string> unlicensedUsers = new Collection<string>();

            // Create Initial Session State for runspace.
            InitialSessionState initialSession = InitialSessionState.CreateDefault();
            initialSession.ImportPSModule(new[] { "MSOnline" });

            // Create credential object.
            SecureString secureString = new SecureString();
            foreach (char c in adminPass.ToCharArray())
            {
                secureString.AppendChar(c);
            }
            PSCredential credential = new PSCredential(adminUPN, secureString);

            // Create command to connect office 365.
            Command connectCommand = new Command("Connect-MsolService");
            connectCommand.Parameters.Add((new CommandParameter("Credential", credential)));

            // Create command to get office 365 users.
            Command getUnLicensedCommand = new Command("Get-MsolGroupMember");
            getUnLicensedCommand.Parameters.Add((new CommandParameter("All")));
            getUnLicensedCommand.Parameters.Add((new CommandParameter("GroupObjectID",groupName)));
            using (Runspace psRunSpace = RunspaceFactory.CreateRunspace(initialSession))
            {
                // Open runspace.
                psRunSpace.Open();

                //Iterate through each command and executes it.
                foreach (var com in new Command[] { connectCommand, getUnLicensedCommand })
                {
                    var pipe = psRunSpace.CreatePipeline();
                    pipe.Commands.Add(com);
                    // Execute command and generate results and errors (if any).
                    Collection<PSObject> results = pipe.Invoke();
                    var error = pipe.Error.ReadToEnd();
                    if (error.Count > 0 && com == connectCommand)
                    {
                        ToggleConsoleColor();
                        Console.WriteLine(error[0].ToString(), "Problem in login.  Ensure you have the Microsoft Signin Assistant and Microsoft Online Powershell Module installed.");
                        WriteLogs("Error", error[0].ToString() + ".  Problem in login.  Ensure you have the Microsoft Signin Assistant and Microsoft Online Powershell Module installed.", "GetUnlicensedUsers");
                        ToggleConsoleColor();
                    }
                    if (error.Count > 0 && com == getUnLicensedCommand)
                    {
                        ToggleConsoleColor();
                        Console.WriteLine(error[0].ToString(), "Problem in getting licenses");
                        WriteLogs("Error", error[0].ToString() + "Problem in getting licenses.", "GetUnlicensedUsers");
                        ToggleConsoleColor();
                    }
                    if (error.Count < 1 && com == getUnLicensedCommand)
                    {
                        foreach (PSObject unlicensedUser in results)
                        {
                            unlicensedUsers.Add(unlicensedUser.Members["EmailAddress"].Value.ToString());
                        }
                    }
                }
                // Close the runspace.
                psRunSpace.Close();
            }
            return unlicensedUsers;
            #endregion
        }

        public static void WriteLogs(string type, string message, string function)
        {
            //  Write whatever is passed to the log file.
            System.IO.File.AppendAllText(@"Logs.log", type + "|" + DateTime.Now + "|" + message + "|" + function + "\r\n");
        }
    }
}
