using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SharePoint.Client;

namespace n8d.UserProfileBulkImport
{
    class Program
    {

        private const string wsString = "/_vti_bin/userprofileservice.asmx";
        private static Uri _adminUrl;
        private static string _username;
        private static string _filename;

        static void Main(string[] args)
        {

            bool checkPassed = CheckArguments(args);

            if (checkPassed == false)
            {
                ShowHelp();
                return;
            }

            // As user for password and convert it into a secure string
            System.Security.SecureString mySecurePassword = GetSecurePassword();

            // Getting the online credentials to work
            SharePointOnlineCredentials onlineCred = new SharePointOnlineCredentials(_username, mySecurePassword);

            // Get the cookie for authentication agains the web service
            string authCookie = null;
            try
            {
                authCookie = onlineCred.GetAuthenticationCookie(_adminUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                return;
            }

            // Check if all worked well with the authentication
            if (authCookie != null)
            {
                Console.WriteLine("\nSuccessfully authenticated against Office 365 !!!");
                Console.WriteLine("Begin updating user profiles");
                // creating updater object
                UserProfileUpdater userProfUpdater = new UserProfileUpdater(authCookie, _adminUrl,  _filename);
                
                // read update files and update profiles.
                userProfUpdater.Update();

            }
            else 
            {
                Console.WriteLine("Ups !!! Something went wrong but no exception was raised sorry");
            }
            Console.WriteLine("WORK DONE !!!");

        }

        /// <summary>
        /// Checks if all required arguments are passed to the command line
        /// </summary>
        /// <param name="args"></param>
        private static bool CheckArguments(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("ERROR: Not enough parameter specified");
                Console.WriteLine();
                return false;
            }
            else
            {
                if (!args[0].StartsWith("http"))
                {
                    Console.WriteLine("ERROR: First parameter needs to point to the administration of SharePoint Online");
                    Console.WriteLine("\t Example: https://yourcompany-admin.sharepoint.com");
                    return false;
                }
                else
                {
                    if (args[0].EndsWith("/"))
                    {
                        _adminUrl = new Uri(args[0].Substring(0, args[0].Length - 1) + wsString);
                    }
                    else
                    {
                        _adminUrl = new Uri(args[0] + wsString);
                    }
                }

                if (!args[1].Contains("@"))
                {
                    Console.WriteLine("ERROR: Second parameter needs to specify a username that has granted administration rights");
                    Console.WriteLine("\t Example: stefan.bauer@yourcompany.onmicrosoft.com");
                    return false;
                }
                else
                {
                    _username = args[1];
                }

                if (!System.IO.File.Exists(args[2]))
                {
                    Console.WriteLine("ERROR: Import File doesn't exist");
                    Console.WriteLine("\t Please make sure that the file exists");
                    return false;
                }
                else
                {
                    _filename = args[2];
                }


            }
            return true;
        }

        /// <summary>
        /// Display the command line tool help
        /// </summary>
        private static void ShowHelp()
        {

            Console.WriteLine("\nUSAGE: n8d.UserProfileBulkImport.exe <Url to Office 365 Admin> <Username> <Path2Importfile>");
            Console.WriteLine("<Url to Office 365 Admin> \t\t This url defines the path to your Office 365 Administration web site");
            Console.WriteLine("<Username> \t\t Specify your administration accounts");
            Console.WriteLine("<Path2Importfile> \t\t add here the path to your <tab> - separated file");
        }

        /// <summary>
        /// Convert user input to a SecureString that is required to authenticate against SharePoint Online
        /// </summary>
        /// <returns>Password as SecureString</returns>
        private static System.Security.SecureString GetSecurePassword()
        {

            Console.Write("Enter password: ");
            System.Security.SecureString securePassword = new System.Security.SecureString();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Append the character to the password.
                securePassword.AppendChar(key.KeyChar);
                Console.Write("*");

                // Exit if Enter key is pressed.
            } while (key.Key != ConsoleKey.Enter);
            return securePassword;

        }
    }
}
