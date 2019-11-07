using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace n8d.UserProfileBulkImport
{
    class UserProfileUpdater
    {
        private string _authCookie;
        private Uri _adminUrl;
        private string _filename;

        private string[] header;

        public UserProfileUpdater(string authCookie, Uri adminUrl, string filename)
        {
            // TODO: Complete member initialization
            _authCookie = authCookie;
            _adminUrl = adminUrl;
            _filename = filename;

        }

        internal void Update()
        {

            // Create a CookieContainer to authenticate against the web service
            CookieContainer authContainer = new CookieContainer();

            // Put the authenticationCookie in the container
            authContainer.SetCookies(_adminUrl, _authCookie);

            // Setting up the web service
            UserProfileWS.UserProfileService upService = new UserProfileWS.UserProfileService();
            upService.CookieContainer = authContainer;
            upService.Url = _adminUrl.AbsoluteUri;

            // Open the file that should be imported
            using (var file = System.IO.File.OpenText(_filename))
            {
                header = ExtractPropertyInfo(file);

                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] data = GetData(line);
                    string accountName = "";
                    string originalAccountName = "";

                    if (data.Length > 0)
                    {
                        UserProfileWS.PropertyData[] newdata = new UserProfileWS.PropertyData[data.Length - 1];

                        for (int i = 0; i < data.Length; i++)
                        {
                            // Checking if current field is Accountname
                            if (header[i] == "AccountName")
                            {
                                // adding membership provider prefix to username
                                originalAccountName = data[i];
                                accountName = "i:0#.f|membership|" + data[i];
                            }
                            else
                            {
                                UserProfileWS.PropertyData prop = upService.GetUserPropertyByAccountName(accountName, header[i]);
                                // Setting Properties
                                newdata[i - 1] = new UserProfileWS.PropertyData();
                                newdata[i - 1].Name = header[i];
                                if(data[i].Contains(";"))
                                {
                                    newdata[i - 1].Values = GetProfileValues(data[i], ';');
                                }
                                else if(data[i].Contains(","))
                                {
                                    newdata[i - 1].Values = GetProfileValues(data[i], ',');
                                }
                                else
                                {
                                    newdata[i - 1].Values = new UserProfileWS.ValueData[1];
                                    newdata[i - 1].Values[0] = new UserProfileWS.ValueData();
                                    newdata[i - 1].Values[0].Value = data[i];
                                }
                                newdata[i - 1].IsValueChanged = true;

                            }
                        }

                        try
                        {
                            // Try to update user profile
                            upService.ModifyUserPropertyByAccountName(accountName, newdata);
                            Console.WriteLine(originalAccountName + "\t...\tOK");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                System.Threading.Thread.Sleep(500);

            }
        }

        private UserProfileWS.ValueData[] GetProfileValues(string data, char delimiter)
        {
            string[] dataValues = data.Split(delimiter);
            
            UserProfileWS.ValueData[] profValues = new UserProfileWS.ValueData[dataValues.Length];

            int counter = 0;

            foreach (string dataValue in dataValues)
            {
                UserProfileWS.ValueData valueData = new UserProfileWS.ValueData();
                valueData.Value = dataValue;

                profValues[counter] = valueData;

                counter += 1;
            }
            return profValues;
        }

        private static string[] GetData(string line)
        {
            return line.Split('\t');
        }

        private string[] ExtractPropertyInfo(System.IO.StreamReader file)
        {
            string lineOne = file.ReadLine();
            return lineOne.Split('\t');
        }
    }
}
