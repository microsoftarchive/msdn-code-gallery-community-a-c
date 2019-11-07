using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;   
using System.Diagnostics;
using System.Net;
using System.IO;
using AppHelpers;


namespace AutodiscoverChecker
{
    public partial class ScpChecker : Form
    {
        public ScpChecker()
        {
            InitializeComponent();

            string s = string.Empty;
            cmboTimeout.Items.Clear();
            for (int i = 1; i <= 150; i++)
            {
                s = string.Format("{0}\r\n", i.ToString());
                cmboTimeout.Items.Add(s);
            }
        }

        private void ScpChecker_Load(object sender, EventArgs e)
        {
 

           // http://msdn.microsoft.com/en-us/library/ee160402(EXCHG.80).aspx
            //http://msdn.microsoft.com/en-us/library/ee332364(EXCHG.140).aspx

 

        }

        private string DoAdLookups(bool bDoPosts)
        {
            string sRet = string.Empty;
            bool bFail = false;
            string sMailbox = txtTargetMailbox.Text.Trim();
            StringBuilder oSB = new StringBuilder();
            DirectoryEntry oRootDSE = null;
            DirectoryEntry oQuery = null;
            DirectorySearcher oDirectorySearcher = null;
            SearchResultCollection oSearchResultCollection = null;
            //string scpUrl = null;
            //const string ScpUrlGuidString = @"77378F46-2C66-4aa9-A6A6-3E7A48B19596";

            this.Cursor = Cursors.WaitCursor;
            oSB.AppendFormat("- DoAdLookups - Find SCP records: {0}\r\n", DateTime.Now);

            //string sPostUrl = "https://autodiscover-s.outlook.com/autodiscover/autodiscover.svc";

            // #1 Get AD entries
            try
                {
                oSB.AppendFormat("  Start inital binding to LDAP://rootDSE\r\n");
                oRootDSE = new DirectoryEntry("LDAP://rootDSE");
                oSB.AppendFormat("  Finished binding to LDAP://rootDSE\r\n");
                oSB.AppendFormat("  Obtaining configurationNamingContext - if it fails then Autodiscover should be used.\r\n");
                string ConfigurationNamingContext = (string)oRootDSE.Properties["configurationNamingContext"].Value;
                oSB.AppendFormat("  configurationNamingContext {0}\r\n", ConfigurationNamingContext);
 
                string sQuery = "LDAP://" + ConfigurationNamingContext;

                oSB.AppendFormat("  Query: {0}\r\n", sQuery);

                string sFilter =
                    "(&(objectcategory=serviceConnectionPoint)(|(keywords=67661D7F-8FC4-4fa7-BFAC-E1D7794C1F68)( keywords=77378F46-2C66-4aa9-A6A6-3E7A48B19596)))";
                oSB.AppendFormat("  Filter: {0}\r\n", sFilter);
        
                oQuery = new DirectoryEntry(sQuery);
                oDirectorySearcher = new DirectorySearcher(oQuery);
                oDirectorySearcher.PropertiesToLoad.Add("cn");
                oDirectorySearcher.PropertiesToLoad.Add("name");
                oDirectorySearcher.PropertiesToLoad.Add("serviceBindingInformation");
                oDirectorySearcher.PropertiesToLoad.Add("legacyExchangeDN");
                oDirectorySearcher.PropertiesToLoad.Add("Domain");
                oDirectorySearcher.PropertiesToLoad.Add("site");
                oDirectorySearcher.PropertiesToLoad.Add("keywords"); 
          
  
                oDirectorySearcher.Filter = sFilter;
      
                oSB.AppendFormat("\r\n");
                
                oSB.AppendFormat("+ Searching AD for CAS URLs: {0}\r\n", DateTime.Now);
                DateTime oStart = DateTime.Now;
                oSearchResultCollection = oDirectorySearcher.FindAll();
                TimeSpan oTimeSpan = DateTime.Now.Subtract(oStart);
                oSB.AppendFormat("    Time to do Search: {0} miliseconds\r\n", oTimeSpan.TotalMilliseconds.ToString());
                oSB.AppendFormat("- Searching AD for CAS URLs: {0}\r\n", DateTime.Now);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                bFail = true;
                System.Runtime.InteropServices.COMException COMExceptionEx = new System.Runtime.InteropServices.COMException();
                Console.WriteLine(COMExceptionEx.Message);
                oSB.AppendFormat("!! Error: ");
                oSB.AppendFormat("    Message: {0}\r\n", COMExceptionEx.Message);
                oSB.AppendFormat("    InnerException: {0}\r\n", COMExceptionEx.InnerException);
                oSB.AppendFormat("");
                oSB.AppendFormat("    StackTrace: {0}\r\n", COMExceptionEx.StackTrace);
                oSB.AppendFormat("- Searching: {0}\r\n", DateTime.Now);
            }
            catch (InvalidOperationException)
            {
                bFail = true;
                InvalidOperationException InvOpEx = new InvalidOperationException(); 
                Console.WriteLine(InvOpEx.Message);
                oSB.AppendFormat("!! Error: ");
                oSB.AppendFormat("    Message: {0}\r\n", InvOpEx.Message);
                oSB.AppendFormat("    InnerException: {0}\r\n", InvOpEx.InnerException);
                oSB.AppendFormat("");
                oSB.AppendFormat("    StackTrace: {0}\r\n", InvOpEx.StackTrace);
                oSB.AppendFormat("- Searching: {0}\r\n", DateTime.Now);
            }
            catch (NotSupportedException)
            {
                bFail = true;
                NotSupportedException NotSuppEx = new NotSupportedException();
                Console.WriteLine(NotSuppEx.Message);
 
                oSB.AppendFormat("!! Error: ");
                oSB.AppendFormat("    Message: {0}\r\n", NotSuppEx.Message);
                oSB.AppendFormat("    InnerException: {0}\r\n", NotSuppEx.InnerException);
                oSB.AppendFormat("");
                oSB.AppendFormat("    StackTrace: {0}\r\n", NotSuppEx.StackTrace);
                oSB.AppendFormat("- Searching: {0}\r\n", DateTime.Now);
            }
            catch (Exception ex)
            {
                bFail = true;
                Console.WriteLine(ex.Message);
                oSB.AppendFormat("!! Error: ");
                oSB.AppendFormat("    Message: {0}\r\n", ex.Message);
                oSB.AppendFormat("    InnerException: {0}\r\n", ex.InnerException);
                oSB.AppendFormat("");
                oSB.AppendFormat("    StackTrace: {0}\r\n", ex.StackTrace);
                oSB.AppendFormat("- Searching: {0}\r\n", DateTime.Now);
            }

            System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site =
                System.DirectoryServices.ActiveDirectory.ActiveDirectorySite.GetComputerSite();
            string computerSiteName = site.Name;
            oSB.AppendFormat("Site Name: " + computerSiteName + "\r\n");

            if (bFail != true)
            {
                oSB.AppendFormat("\r\n");
                oSB.AppendFormat("  Results found: {0} URLs\r\n", oSearchResultCollection.Count.ToString());
                oSB.AppendFormat("+ List Results: {0}\r\n", DateTime.Now);
                oSB.AppendFormat("\r\n");
                string sUrl = string.Empty;
  
                try
                {
                    foreach (SearchResult oSearchResult in oSearchResultCollection)
                    {
                         
                        oSB.AppendFormat("    Result Path: {0}\r\n", oSearchResult.Path);
                         
                        if (oSearchResult.Properties["cn"].Count != 0)
                            oSB.AppendFormat("    cn: {0}\r\n", oSearchResult.Properties["cn"][0].ToString());
                        if (oSearchResult.Properties["name"].Count != 0)
                            oSB.AppendFormat("    name: {0}\r\n", oSearchResult.Properties["name"][0].ToString());
                          
                        if (oSearchResult.Properties["serviceBindingInformation"].Count != 0)
                            oSB.AppendFormat("    serviceBindingInformation: {0}\r\n", oSearchResult.Properties["serviceBindingInformation"][0].ToString());
                        if (oSearchResult.Properties["legacyExchangeDN"].Count != 0)
                            oSB.AppendFormat("    legacyExchangeDN: {0}\r\n", oSearchResult.Properties["legacyExchangeDN"][0].ToString());
                        if (oSearchResult.Properties["Domain"].Count != 0)
                            oSB.AppendFormat("    Domain: {0}\r\n", oSearchResult.Properties["Domain"][0].ToString());
                        if (oSearchResult.Properties["site"].Count != 0)
                            oSB.AppendFormat("    site: {0}\r\n", oSearchResult.Properties["site"][0].ToString());

                        //if (oSearchResult.Properties["keywords"].Count != 0)
                        //{
                        //    if (!string.IsNullOrEmpty(computerSiteName))
                        //    {
                        //        // Search for SCP entries.
                        //        string sitePrefix = "Site=";
                        //        string siteMatch = sitePrefix + computerSiteName;
                        //        System.Collections.Generic.List<string> scpListNoSiteMatch =  new System.Collections.Generic.List<string>();
  
                        //        System.DirectoryServices.ResultPropertyValueCollection entryKeywords = oSearchResult.Properties["keywords"];

                        //        // Identify SCP URLs.
                        //        if (AppHelpers.CollectionHelpers.CollectionContains(entryKeywords, ScpUrlGuidString))
                        //            {
                        //                // Get the SCP URL.
                        //                scpUrl = oSearchResult.Properties["serviceBindingInformation"][0] as string;

                        //                // If the SCP URL matches the exact ComputerSiteName.
                        //                if (CollectionHelpers.CollectionContains(entryKeywords, siteMatch))
                        //                {
                        //                    // Priority 1 SCP URL. Add SCP URL to the list if it's not already there.
                        //                    oSB.Append("    Priority 1 type. SCP URL matches the exact ComputerSiteName.  Top of the list.\r\n");
                        //                    oSB.Append("    Path: " + oSearchResult.Path + " \r\n");
                        //                    oSB.Append("    SCP URL: " + scpUrl + "\r\n");
 
                        //                    //scpUrlList.Add(scpUrl);
                        //                }
                        //            }

                        //            // No match between the SCP URL and the ComputerSiteName
                        //            else
                        //            {
                        //                bool hasSiteKeyword = false;

                        //                // Check if SCP URL entry has any keyword starting with "Site=" 
                        //                foreach (string keyword in entryKeywords)
                        //                {
                        //                    hasSiteKeyword |= keyword.StartsWith(sitePrefix, System.StringComparison.InvariantCultureIgnoreCase);
                        //                }

                        //                // Add SCP URL to the scpListNoSiteMatch list if it's not already there.
                        //                if (!CollectionHelpers.CollectionContains(scpListNoSiteMatch, scpUrl))
                        //                {
                        //                    // Priority 2 SCP URL. SCP entry doesn't have any "Site=<otherSite>" keywords, insert at the top of list.
                        //                    if (!hasSiteKeyword)
                        //                    {
                        //                        oSB.Append("    Priority 2 type. SCP entry doesn't have any \"Site=<otherSite>\" keywords\r\n");
                        //                        oSB.Append("    Path: " + oSearchResult.Path + " \r\n");
                        //                        oSB.Append("    SCP URL: " + scpUrl + "\r\n");
                        //                        scpListNoSiteMatch.Insert(0, scpUrl);
                        //                    }
                        //                    // Priority 3 SCP URL. SCP entry has at least one "Site=<otherSite>" keyword, add to the end of list.
                        //                    else
                        //                    {
                        //                        oSB.Append("    Priority 3 type. SCP entry has at least one \"Site=<otherSite>\" keyword. This should be at the end of the list.\r\n");
                        //                        oSB.Append("    Path: " + oSearchResult.Path + " \r\n");
                        //                        oSB.Append("    SCP URL: " + scpUrl + "\r\n");
                        //                        scpListNoSiteMatch.Insert(0, scpUrl);
 
                        //                    }
                        //                }
                                     
                        //        }
 
                        //    }
                        //}



                        int iTimeoutSeconds = Int32.Parse(cmboTimeout.Text.Trim());
                        if (bDoPosts == true)
                        {
                            oSB.Append("\r\n");
                            sUrl = oSearchResult.Properties["serviceBindingInformation"][0].ToString();
                            if (sUrl.StartsWith("LDAP:"))
                                oSB.AppendFormat("  ! Skipping POST due to URL starting with LDAP\r\n");
                            else
                            {
                                oSB.Append(DoPostToUrl(sUrl, sMailbox, iTimeoutSeconds));
                            }

 
                        }
                        oSB.AppendFormat("\r\n");
                        oSB.AppendFormat("--------\r\n");
                        oSB.AppendFormat("\r\n");
                    }
                     
                    oSB.AppendFormat("- List Results: {0}\r\n", DateTime.Now);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    bFail = true;
                    System.Runtime.InteropServices.COMException COMExceptionEx = new System.Runtime.InteropServices.COMException();
                    Console.WriteLine(COMExceptionEx);

                    oSB.AppendFormat("!! Error");
                    oSB.AppendFormat("    Message: {0}\r\n", COMExceptionEx.Message);
                    oSB.AppendFormat("    InnerException: {0}\r\n", COMExceptionEx.InnerException);
                    oSB.AppendFormat("\r\n");
                    oSB.AppendFormat("    StackTrace: {0}\r\n", COMExceptionEx.StackTrace);

                    oSB.AppendFormat("- List Results: {0}\r\n", DateTime.Now);
                }
                catch (InvalidOperationException)
                {
                    bFail = true;
                    InvalidOperationException InvOpEx = new InvalidOperationException();
                    Console.WriteLine(InvOpEx.Message);
                    oSB.AppendFormat("!! Error");
                    oSB.AppendFormat("    Message: {0}\r\n", InvOpEx.Message);
                    oSB.AppendFormat("    InnerException: {0}\r\n", InvOpEx.InnerException);
                    oSB.AppendFormat("\r\n");
                    oSB.AppendFormat("    StackTrace: {0}\r\n", InvOpEx.StackTrace);

                    oSB.AppendFormat("- List Results: {0}\r\n", DateTime.Now);
                }
                catch (NotSupportedException)
                {
                    bFail = true;
                    NotSupportedException NotSuppEx = new NotSupportedException();
                    Console.WriteLine(NotSuppEx.Message);

                    oSB.AppendFormat("!! Error");
                    oSB.AppendFormat("    Message: {0}\r\n", NotSuppEx.Message);
                    oSB.AppendFormat("    InnerException: {0}\r\n", NotSuppEx.InnerException);
                    oSB.AppendFormat("\r\n");
                    oSB.AppendFormat("    StackTrace: {0}\r\n", NotSuppEx.StackTrace);

                    oSB.AppendFormat("- List Results: {0}\r\n", DateTime.Now);
                }
            }
 
            oSB.AppendFormat("");
            oSB.AppendFormat("- DoAdLookups - Find SCP records: {0}\r\n", DateTime.Now);
 
            sRet = oSB.ToString();

            this.Cursor = Cursors.Default;

            return sRet;
 
            // #2 Do test posts.
            // //[System.Net.ServicePointManager]::ServerCertificateValidationCallback = {$true }

             
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtAdQueryResults.Text = string.Empty;
            txtAdQueryResults.Update();
            txtAdQueryResults.Text =  DoAdLookups(false);
            this.Cursor = Cursors.Default;
        }

        private string DoPostToUrl(string sURL, string sEmailSmtp, int iTimeoutSeconds)
        {
            string sRet = string.Empty;
            string sError = string.Empty;
            string sResponse = string.Empty;
            string sResponseStatusCode = string.Empty;
            string sResponseStatusDescription = string.Empty;
            StringBuilder oSB = new StringBuilder();

            oSB.AppendFormat("+ DoPostToUrl - Doing POST to URL: {0}\r\n", DateTime.Now);


            this.Cursor = Cursors.WaitCursor;

            bool bRet = false;
             

            oSB.AppendFormat("    POST...\r\n" );
            oSB.AppendFormat("    Url: {0}\r\n", sURL);
            oSB.AppendFormat("    Mailbox: {0}\r\n", sEmailSmtp);

            string sRequest = 
                "<Autodiscover xmlns=\"http://schemas.microsoft.com/exchange/autodiscover/outlook/requestschema/2006\">" +
                "<Request>\r\n"   +
                " <EMailAddress>" + sEmailSmtp + "</EMailAddress>\r\n" +
                " <AcceptableResponseSchema>http://schemas.microsoft.com/exchange/autodiscover/outlook/responseschema/2006a</AcceptableResponseSchema>\r\n" +
                " </Request>\r\n" +
                "</Autodiscover>\r\n"; 

            // Do Post
            DateTime oStart = DateTime.Now;
            oSB.AppendFormat("    Starting POST: {0}\r\n", oStart.ToString());
            bRet = HttpPosts.RawPost(sURL, sRequest, iTimeoutSeconds, ref sResponse, ref sError, ref sResponseStatusCode, ref sResponseStatusDescription);
            DateTime oEnd = DateTime.Now;
            oSB.AppendFormat("    Finished POST: {0}\r\n", oEnd.ToString());
            TimeSpan oTS = oEnd.Subtract(oStart);
            oSB.AppendFormat("    Time to complete POST: {0}:{1}:{2}.{3}\r\n", oTS.Hours, oTS.Minutes, oTS.Seconds, oTS.Milliseconds);

             
            oSB.AppendFormat("    Response StatusCode: {0}\r\n", sResponseStatusCode);
            oSB.AppendFormat("    Response StatusDescription: {0}\r\n", sResponseStatusDescription);
            oSB.AppendFormat("    Post Suceeded: {0}\r\n", bRet.ToString());
            oSB.AppendFormat("    Error Text: {0}\r\n", sError);
            oSB.AppendFormat("    Response Text: \r\n{0}\r\n", sResponse.ToString());

            TimeSpan oTimeSpan = DateTime.Now.Subtract(oStart);
            oSB.AppendFormat("    Time to do POST: {0} miliseconds\r\n", oTimeSpan.TotalMilliseconds.ToString()); 
             
            oSB.AppendFormat("- DoPostToUrl - Doing POST to URL: {0}\r\n", DateTime.Now);

            sRet = oSB.ToString();

            this.Cursor = Cursors.Default;

             
            return sRet;

        }

        private void btnAdQueryAndPosts_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtAdQueryResults.Text = string.Empty;
            txtAdQueryResults.Update();

            txtAdQueryResults.Text = DoAdLookups(true);
            this.Cursor = Cursors.Default;
        }

        private void txtAdQueryResults_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAdQueryResults_DoubleClick(object sender, EventArgs e)
        {
            DisplayText oForm = new DisplayText();
            oForm.BodyText.Text = txtAdQueryResults.Text;
            oForm.ShowDialog();
        }
 
 

    }
}
