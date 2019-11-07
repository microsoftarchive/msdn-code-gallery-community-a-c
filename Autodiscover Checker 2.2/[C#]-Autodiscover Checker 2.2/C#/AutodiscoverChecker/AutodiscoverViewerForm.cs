using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using System.Security.Cryptography.X509Certificates;
using System.Net;

using AppHelpers;


namespace AutodiscoverChecker
{

    public enum AutodiscoverType
    {
        DirectlyAgainstAutodisocoverService = 0,
        AgainstServiceObject = 1 
    }

    public partial class AutodiscoverViewerForm : Form
    {
        public string _Certs = string.Empty;
        public string _Redirects = string.Empty;
        private ExchangeVersion _Version = new ExchangeVersion();
      
        public AutodiscoverViewerForm()
        {
            InitializeComponent();

 
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnGo_Click(object sender, EventArgs e)
        {
            bool bDoAutodiscover = true;

            this.Cursor = Cursors.WaitCursor;
 
 
            bDoAutodiscover =  CheckCredentials(
                        this.chkDefaultWindowsCredentials.Checked,
                        this.txtUser.Text,
                        this.txtPassword.Text, 
                        this.txtDomain.Text
                        );

            if (this.txtTargetMailbox.Text.Trim().Length == 0)
            {
                MessageBox.Show("The target mailbox smtp address needs to be entered.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bDoAutodiscover = false;
            }

            if (bDoAutodiscover == true)
                DoAutodiscoverDirectlyAgainstAutiodiscoverService();

            this.Cursor = Cursors.Default;

        }

 
 
        private void DoAutodiscoverDirectlyAgainstAutiodiscoverService()
        {
            bool bEnableInMemoryTracing = true;

            this.Cursor = Cursors.WaitCursor;

            _Certs = string.Empty;
            _Redirects = string.Empty;
            WebCredentials credentials = null;
            InMemoryListener oIML = null;

            string sResults = string.Empty;

 
            // Clear results
            this.txtCerts.Text = "";
            this.txtTracing.Text = "";
            this.txtResults.Text = "";

            this.txtCerts.Update();
            this.txtTracing.Update();
            this.txtResults.Update();

            _Version = GetExchangeVersion(cmboExchangeVersion.Text.Trim());
 
            EwsRedirectLoggingCallbackHelper oEwsRedirectLoggingCallbackHelper = new EwsRedirectLoggingCallbackHelper();
            EwsCertificateLoggingCallbackHelper oEwsCertificateLoggingCallbackHelper = new EwsCertificateLoggingCallbackHelper();
            // EwsLoggingCallbackHelper oAutodiscoveryCallbackHelper = new EwsLoggingCallbackHelper();

 
            AutodiscoverService service = new AutodiscoverService(_Version);

            credentials = GetWebCredentials(
                this.chkDefaultWindowsCredentials.Checked, 
                txtUser.Text.Trim(), 
                txtPassword.Text.Trim(), 
                txtDomain.Text.Trim()
                );

 
            service.Credentials = credentials;

            // Prevent the AutodiscoverService from looking in the local Active Directory for the Exchange Web Services Services SCP.
            service.EnableScpLookup = this.chkEnableScpLookup.Checked;
            service.PreAuthenticate = this.chkPreAuthenticate.Checked;
           
            if (bEnableInMemoryTracing == true)
            {
                oIML = new InMemoryListener();     // Enable for EWS tracing
                service.TraceFlags = TraceFlags.All;                                                  // Enable for EWS tracing
                service.TraceEnabled = true;                                                          // Enable for EWS tracing
                service.TraceListener = oIML;                                                         // Enable for EWS tracing
            }

            service.UserAgent = "AutodiscoverCheckerGetUserSettings";

            ServicePointManager.ServerCertificateValidationCallback = oEwsCertificateLoggingCallbackHelper.CertificateValidationCallBack;

            // Handle and Log redirects
             
            service.RedirectionUrlValidationCallback = oEwsRedirectLoggingCallbackHelper.RedirectionUrlValidationCallbackAllowAnything;
            oEwsRedirectLoggingCallbackHelper.UseCredentials =  this.GetWebWebRequestCredentials(
                        this.chkDefaultWindowsCredentials.Checked,
                        txtUser.Text.Trim(),
                        txtPassword.Text.Trim(),
                        txtDomain.Text.Trim()
                        );


            // The following is used in the work-arouind for a redirect which involves an SMTP address change - it needs to be st to what you autodiscovering on.
            oEwsRedirectLoggingCallbackHelper.AutodiscoveringAddress = txtTargetMailbox.Text.Trim();
            oEwsRedirectLoggingCallbackHelper._DoAddressRedirectWorkAround = chkWorkAroundAddressRedirectIssue.Checked;

            // Do Autodiscover: 
            sResults = AutodiscoverGetUserSettings(ref service, txtTargetMailbox.Text.Trim());

            if (oEwsRedirectLoggingCallbackHelper._AddressRedirection == true)
            {
                // Lets do Autodiscover again - but this time use the alternative address.

                string AutodiscoveringAddress = oEwsRedirectLoggingCallbackHelper._RedirectEmailAddress;
                oEwsRedirectLoggingCallbackHelper.ResetRedirects();
                oEwsRedirectLoggingCallbackHelper.AutodiscoveringAddress = AutodiscoveringAddress;

                //oEwsRedirectLoggingCallbackHelper.AutodiscoveringAddress = oEwsRedirectLoggingCallbackHelper._RedirectEmailAddress;
                sResults += "\r\n";
                sResults += "Autodiscover failed but a redirect address was found.  So, do Autodiscover again with the new address.\r\n";
                sResults += "Now doing Autodiscover process with: " + AutodiscoveringAddress + "\r\n\r\n";
                sResults += AutodiscoverGetUserSettings(ref service, AutodiscoveringAddress);

            }

            txtCerts.Text = oEwsCertificateLoggingCallbackHelper._Certificates;
            txtTracing.Text += "\r\n[*****============================[Redirects]=====================================*****]\r\n\r\n";

            txtTracing.Text += oEwsRedirectLoggingCallbackHelper._RedirectionUrls;

            if (bEnableInMemoryTracing == true)
            {
                txtTracing.Text += "\r\n[*****============================[Trace Log]=====================================*****]\r\n\r\n";
                txtTracing.Text += oIML.LogText;
            }

            txtResults.Text = sResults;

            service.TraceListener = null;
            oIML = null;                                // Enable for EWS tracing
 
            service.RedirectionUrlValidationCallback = null;
            ServicePointManager.ServerCertificateValidationCallback = null;

            oEwsCertificateLoggingCallbackHelper = null;
            oEwsRedirectLoggingCallbackHelper = null;

            this.Cursor = Cursors.Default;
 
        }

        private void DoAutodiscoverUsingServiceObject()
        {
            bool bEnableInMemoryTracing = true;

            this.Cursor = Cursors.WaitCursor;

            this.txtCerts.Text = string.Empty;
            this.txtResults.Text = string.Empty;
            this.txtTracing.Text = string.Empty;
            this.txtCerts.Update();
            this.txtTracing.Update();
            this.txtResults.Update();

            _Certs = string.Empty;
            _Redirects = string.Empty;
            WebCredentials credentials = null;
            InMemoryListener oIML = null;

            string sResults = string.Empty;

            // Clear results
            this.txtCerts.Text = "";
            this.txtTracing.Text = "";
            this.txtResults.Text = "";

            _Version = GetExchangeVersion(cmboExchangeVersion.Text.Trim());

  
            //EwsLoggingCallbackHelper oAutodiscoveryCallbackHelper = new EwsLoggingCallbackHelper();

            ExchangeService service = new ExchangeService(_Version);

            credentials = GetWebCredentials(
                this.chkDefaultWindowsCredentials.Checked,
                txtUser.Text.Trim(),
                txtPassword.Text.Trim(),
                txtDomain.Text.Trim()
                );


            service.Credentials = credentials;

            EwsCertificateLoggingCallbackHelper oEwsCertificateLoggingCallbackHelper = new EwsCertificateLoggingCallbackHelper();
            EwsRedirectLoggingCallbackHelper oEwsRedirectLoggingCallbackHelper = new EwsRedirectLoggingCallbackHelper();
             

            //// Handle and Log redirects
            //service.RedirectionUrlValidationCallback = oEwsRedirectLoggingCallbackHelper.RedirectionUrlValidationCallbackAllowAnything;
            oEwsRedirectLoggingCallbackHelper.UseCredentials = this.GetWebWebRequestCredentials(
                        this.chkDefaultWindowsCredentials.Checked,
                        txtUser.Text.Trim(),
                        txtPassword.Text.Trim(),
                        txtDomain.Text.Trim()
                        );

            // The following is used in the work-arouind for a redirect which involves an SMTP address change - it needs to be st to what you autodiscovering on.
            oEwsRedirectLoggingCallbackHelper.AutodiscoveringAddress = txtTargetMailbox.Text.Trim();
            oEwsRedirectLoggingCallbackHelper._DoAddressRedirectWorkAround = chkWorkAroundAddressRedirectIssue.Checked;
  
            // Prevent the AutodiscoverService from looking in the local Active Directory for the Exchange Web Services Services SCP.
            service.EnableScpLookup = this.chkEnableScpLookup.Checked;
            service.PreAuthenticate = this.chkPreAuthenticate.Checked;

            if (bEnableInMemoryTracing == true)
            {
                oIML = new InMemoryListener();     // Enable for EWS tracing
                service.TraceFlags = TraceFlags.All;                                                  // Enable for EWS tracing
                service.TraceEnabled = true;                                                          // Enable for EWS tracing
                service.TraceListener = oIML;                                                         // Enable for EWS tracing
            }

            service.UserAgent = "AutodiscoverCheckerServiceObject";

             
            ServicePointManager.ServerCertificateValidationCallback = oEwsCertificateLoggingCallbackHelper.CertificateValidationCallBack;

            // oAutodiscoveryCallbackHelper..
            bool bFoundInfo = true;
   
            //string sResult = string.Empty;
  
            sResults += "! Trying to Autodiscover using: " + this.txtTargetMailbox.Text.Trim() + "\r\n";
 
  
            try
            {

                service.AutodiscoverUrl(
                        this.txtTargetMailbox.Text.Trim(),
                        oEwsRedirectLoggingCallbackHelper.RedirectionUrlValidationCallbackAllowAnything 
                        );

                bFoundInfo = true;

            }
            catch (Exception ex1)
            {
                sResults += "\r\n"; 
                sResults += "!! Error trying to Autodiscover address.\r\n";
                sResults += "    Address: " + this.txtTargetMailbox.Text.Trim() + "\r\n";
                sResults += "       Error Message: " + ex1.Message + "\r\n";
                sResults += "       Inner Error Message: " + ex1.Message + "\r\n";
                sResults += "\r\n";
                sResults += "       StackTrace: " + ex1.StackTrace + "\r\n";
                sResults += "\r\n";
                bFoundInfo = false;
            }
 
            if (oEwsRedirectLoggingCallbackHelper._AddressRedirection == true)
            {
                try
                {
                    // Lets do Autodiscover again - but this time use the alternative address.
                    //string RedirectEmailAddress = oEwsRedirectLoggingCallbackHelper._RedirectEmailAddress;
                     
                    string AutodiscoveringAddress = oEwsRedirectLoggingCallbackHelper._RedirectEmailAddress;
                    oEwsRedirectLoggingCallbackHelper.ResetRedirects();
                    oEwsRedirectLoggingCallbackHelper.AutodiscoveringAddress = AutodiscoveringAddress;


                    sResults += "! Rediretion Mail Address found (" + AutodiscoveringAddress + ")     * * * \r\n";
                    sResults += "  Autodiscover redirect address was found.  So, do autodiscover again with the new address.\r\n";
                    sResults += "  Starting new Autodiscover call for '" + AutodiscoveringAddress + "'.\r\n";
                    service.AutodiscoverUrl(
                        AutodiscoveringAddress,
                        oEwsRedirectLoggingCallbackHelper.RedirectionUrlValidationCallbackAllowAnything
                        );
                     
                    bFoundInfo = true;
                }
                catch (Exception ex2)
                {
                        sResults += "\r\n";
                        sResults += "!! Error trying to Autodiscover redirect address.\r\n";
                        sResults += "    Address: " + oEwsRedirectLoggingCallbackHelper._RedirectEmailAddress + "\r\n";
                        sResults += "       Error Message: " + ex2.Message + "\r\n";
                        sResults += "       Inner Error Message: " + ex2.Message + "\r\n";
                        sResults += "\r\n"; 
                        sResults += "       StackTrace: " + ex2.StackTrace + "\r\n"; 
                        sResults += "\r\n";
                        bFoundInfo = false;
                }

                if (bFoundInfo == true)
                {
                    sResults += "\r\n[*****============================[Resolved URL]=====================================*****]\r\n\r\n";
                    sResults += "Server Url: " + service.Url + "\r\n";
                    sResults += "\r\n";
                }
                
            }

            txtResults.Text = sResults;


            txtCerts.Text = oEwsCertificateLoggingCallbackHelper._Certificates;
            txtTracing.Text += "\r\n[*****============================[Redirects]=====================================*****]\r\n\r\n";

            txtTracing.Text += oEwsRedirectLoggingCallbackHelper._RedirectionUrls;

            if (bEnableInMemoryTracing == true)
            {
                txtTracing.Text += "\r\n[*****============================[Trace Log]=====================================*****]\r\n\r\n";
                txtTracing.Text += oIML.LogText;
            }

            sResults += "  * Ews URL: ";
            if (service.Url != null)
                sResults += service.Url;
            sResults += "\r\n";
           
             
             
            sResults += "! Trying to Autodiscover using: " + this.txtTargetMailbox.Text.Trim() + "\r\n";
            sResults += "\r\n";
            sResults += "Note: See above fields for details.\r\n";
            txtResults.Text = sResults;

            service.TraceListener = null;
            oIML = null;                                // Enable for EWS tracing

            //service.RedirectionUrlValidationCallback = null;
            ServicePointManager.ServerCertificateValidationCallback = null;

            oEwsRedirectLoggingCallbackHelper = null;
            oEwsCertificateLoggingCallbackHelper = null;

            this.Cursor = Cursors.Default;

        }

 

        private ExchangeVersion GetExchangeVersion(string sExchangeVersion)
        { 
            // Set Version
            ExchangeVersion oVersion = new ExchangeVersion();
            oVersion = ExchangeVersion.Exchange2010_SP1;
            switch (sExchangeVersion)
            {
                case "Exchange2007_SP1":
                    oVersion = ExchangeVersion.Exchange2007_SP1;
                    break;
                case "Exchange2010":
                    oVersion = ExchangeVersion.Exchange2010;
                    break;
                case "Exchange2010_SP1":
                    oVersion = ExchangeVersion.Exchange2010_SP1;
                    break;
                case "Exchange2010_SP2":
                    oVersion = ExchangeVersion.Exchange2010_SP2;
                    break;
                case "Exchange2013":
                    oVersion = ExchangeVersion.Exchange2013;
                    break;
            }
             //_Version = oVersion;
            return oVersion;
        }

        private bool CheckCredentials(bool bDefaultCredentials,  string sUser, string sPassword, string sDomain)
        {  
            bool bDoAutodiscover = true;
 
            if (this.chkDefaultWindowsCredentials.Checked == false)
            {
                if (sUser.Trim().Length == 0)
                {
                    MessageBox.Show("The user ID or SMTP address needs to be entered.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bDoAutodiscover = false;
                }

                if (sPassword.Trim().Length == 0)
                {
                    MessageBox.Show("The password needs to be entered.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bDoAutodiscover = false;
                }
            }
            return bDoAutodiscover;
        }

        private WebCredentials GetWebCredentials(bool bDefaultCredentials, string sUser, string sPassword, string sDomain)
        {
            WebCredentials credentials = null;

            if (bDefaultCredentials == true)
            {
                credentials = new WebCredentials();
            }
            else
            {

                if (txtDomain.Text.Trim().Length != 0)
                {
                    credentials = new WebCredentials(sUser, sPassword, sDomain);
                }
                else
                {
                    credentials = new WebCredentials(sUser, sPassword);
                }

            }

            return credentials;
        }

        private NetworkCredential GetWebWebRequestCredentials(bool bDefaultCredentials, string sUser, string sPassword, string sDomain)
        {
            NetworkCredential oNetworkCredential = null;

            if (bDefaultCredentials == true)
            {
                oNetworkCredential = new NetworkCredential();
            }
            else
            {

                if (txtDomain.Text.Trim().Length != 0)
                {
                    oNetworkCredential = new NetworkCredential(sUser, sPassword, sDomain);
                }
                else
                {
                    oNetworkCredential = new NetworkCredential(sUser, sPassword);
                }

            }

            return oNetworkCredential;
        }


        public string AutodiscoverGetUserSettings(ref AutodiscoverService service, string sUserSmtpAddress)
        {
            string sRet = string.Empty;
            GetUserSettingsResponse oResponse = null;
            bool bWasError = false;

 
            sRet += "+ Calling GetUserSettings for " + sUserSmtpAddress + " - " + DateTime.Now + "\r\n";
            sRet += "\r\n";
            switch (_Version)
            {
                case ExchangeVersion.Exchange2007_SP1:
                    try
                    {
                        oResponse = service.GetUserSettings(
                            sUserSmtpAddress,
                            UserSettingName.ActiveDirectoryServer,
                            UserSettingName.AlternateMailboxes,
                            UserSettingName.CasVersion,
                            UserSettingName.CrossOrganizationSharingEnabled,
                            UserSettingName.EcpDeliveryReportUrlFragment,
                            UserSettingName.EcpEmailSubscriptionsUrlFragment,
                            UserSettingName.EcpTextMessagingUrlFragment,
                            UserSettingName.EcpVoicemailUrlFragment,
                            UserSettingName.EwsSupportedSchemas,
                            UserSettingName.ExternalEcpDeliveryReportUrl,
                            UserSettingName.ExternalEcpEmailSubscriptionsUrl,
                            UserSettingName.ExternalEcpTextMessagingUrl,
                            UserSettingName.ExternalEcpUrl,
                            UserSettingName.ExternalEcpVoicemailUrl,
                            UserSettingName.ExternalEwsUrl,
                            UserSettingName.ExternalImap4Connections,
                            UserSettingName.ExternalMailboxServer,
                            UserSettingName.ExternalMailboxServerAuthenticationMethods,
                            UserSettingName.ExternalMailboxServerRequiresSSL,
                            UserSettingName.ExternalOABUrl,
                            UserSettingName.ExternalPop3Connections,
                            UserSettingName.ExternalSmtpConnections,
                            UserSettingName.ExternalUMUrl,
                            UserSettingName.ExternalWebClientUrls,
                            UserSettingName.InternalEcpDeliveryReportUrl,
                            UserSettingName.InternalEcpEmailSubscriptionsUrl,
                            UserSettingName.InternalEcpTextMessagingUrl,
                            UserSettingName.InternalEcpUrl,
                            UserSettingName.InternalEcpVoicemailUrl,
                            UserSettingName.InternalEwsUrl,
                            UserSettingName.InternalImap4Connections,
                            UserSettingName.InternalMailboxServer,
                            UserSettingName.InternalMailboxServerDN,
                            UserSettingName.InternalOABUrl,
                            UserSettingName.InternalPop3Connections,
                            UserSettingName.InternalRpcClientServer,
                            UserSettingName.InternalSmtpConnections,
                            UserSettingName.InternalUMUrl,
                            UserSettingName.InternalWebClientUrls,
                            UserSettingName.MailboxDN,
                            UserSettingName.PublicFolderServer,
                            UserSettingName.UserDeploymentId,
                            UserSettingName.UserDisplayName,
                            UserSettingName.UserDN,
                            UserSettingName.MobileMailboxPolicy,
                            UserSettingName.ExternalEwsVersion,
                            UserSettingName.ExchangeRpcUrl

                        );
                    }
                    catch (Exception ex)
                    {
                        sRet += "\r\n";
                        sRet += "!! Error: \r\n";
                        sRet += "    Message: " + ex.Message + "\r\n";
                        sRet += "    InnerException: " + ex.InnerException + "\r\n";
                        sRet += "\r\n";
                        sRet += "    StackTrace: " + ex.StackTrace + "\r\n";
                        sRet += "\r\n";
                        bWasError = true;
                    }
                    break;

                case ExchangeVersion.Exchange2010:
                    try
                    {
                        oResponse = service.GetUserSettings(
                            sUserSmtpAddress,
                            UserSettingName.ActiveDirectoryServer,
                            UserSettingName.AlternateMailboxes,
                            UserSettingName.CasVersion,
                            UserSettingName.EwsSupportedSchemas,
                            UserSettingName.ExternalMailboxServer,
                            UserSettingName.ExternalMailboxServerAuthenticationMethods,
                            UserSettingName.ExternalMailboxServerRequiresSSL,

                            UserSettingName.ExternalEwsUrl,
                            UserSettingName.ExternalPop3Connections,
                            UserSettingName.ExternalSmtpConnections,

                            UserSettingName.ExternalWebClientUrls,
                            UserSettingName.InternalEwsUrl,
                            UserSettingName.InternalMailboxServer,
                            UserSettingName.InternalMailboxServerDN,
                            UserSettingName.InternalWebClientUrls,
                             UserSettingName.MailboxDN,
                            UserSettingName.PublicFolderServer,
                            UserSettingName.UserDeploymentId,
                            UserSettingName.UserDisplayName,
                            UserSettingName.UserDN,
                            UserSettingName.MobileMailboxPolicy,
                            UserSettingName.ExternalEwsVersion,
                            UserSettingName.ExchangeRpcUrl  

                             
                        );
                    }
                    catch (Exception ex)
                    {
                        sRet += "\r\n";
                        sRet += "!! Error: \r\n";
                        sRet += "    Message: " + ex.Message + "\r\n";
                        sRet += "    InnerException: " + ex.InnerException + "\r\n";
                        sRet += "\r\n";
                        sRet += "    StackTrace: " + ex.StackTrace + "\r\n";
                        sRet += "\r\n";
                        bWasError = true;
                    }
                    break;
                case ExchangeVersion.Exchange2010_SP1:
                    try
                    {
                        oResponse = service.GetUserSettings(
                            sUserSmtpAddress,
                            UserSettingName.ActiveDirectoryServer,
                            UserSettingName.AlternateMailboxes,
                            UserSettingName.CasVersion,
                            UserSettingName.EwsSupportedSchemas,
                            UserSettingName.ExternalMailboxServer,
                            UserSettingName.ExternalMailboxServerAuthenticationMethods,
                            UserSettingName.ExternalMailboxServerRequiresSSL,

                            UserSettingName.ExternalEwsUrl,
                            UserSettingName.ExternalPop3Connections,
                            UserSettingName.ExternalSmtpConnections,

                            UserSettingName.ExternalWebClientUrls,
                            UserSettingName.InternalEwsUrl,
                            UserSettingName.InternalMailboxServer,
                            UserSettingName.InternalMailboxServerDN,
                            UserSettingName.InternalWebClientUrls,
                             UserSettingName.MailboxDN,
                            UserSettingName.PublicFolderServer,
                            UserSettingName.UserDeploymentId,
                            UserSettingName.UserDisplayName,
                            UserSettingName.UserDN,
                            UserSettingName.MobileMailboxPolicy,
                            UserSettingName.ExternalEwsVersion,
                            UserSettingName.ExchangeRpcUrl  
                        );
                    }
                    catch (Exception ex)
                    {
                        sRet += "\r\n";
                        sRet += "!! Error: \r\n";
                        sRet += "    Message: " + ex.Message + "\r\n";
                        sRet += "    InnerException: " + ex.InnerException + "\r\n";
                        sRet += "\r\n";
                        sRet += "    StackTrace: " + ex.StackTrace + "\r\n";
                        sRet += "\r\n";
                        bWasError = true;
                    }
                    break;
                case ExchangeVersion.Exchange2010_SP2:
                    try
                    {
                        oResponse = service.GetUserSettings(
                            sUserSmtpAddress,
                            UserSettingName.ActiveDirectoryServer,
                            UserSettingName.AlternateMailboxes,
                            UserSettingName.CasVersion,
                            UserSettingName.EwsSupportedSchemas,
                            UserSettingName.ExternalMailboxServer,
                            UserSettingName.ExternalMailboxServerAuthenticationMethods,
                            UserSettingName.ExternalMailboxServerRequiresSSL,

                            UserSettingName.ExternalEwsUrl,
                            UserSettingName.ExternalPop3Connections,
                            UserSettingName.ExternalSmtpConnections,

                            UserSettingName.ExternalWebClientUrls,
                            UserSettingName.InternalEwsUrl,
                            UserSettingName.InternalMailboxServer,
                            UserSettingName.InternalMailboxServerDN,
                            UserSettingName.InternalWebClientUrls,
                             UserSettingName.MailboxDN,
                            UserSettingName.PublicFolderServer,
                            UserSettingName.UserDeploymentId,
                            UserSettingName.UserDisplayName,
                            UserSettingName.UserDN,
                            UserSettingName.MobileMailboxPolicy,
                            UserSettingName.ExternalEwsVersion,
                            UserSettingName.ExchangeRpcUrl
                        );
                    }
                    catch (Exception ex)
                    {
                        sRet += "\r\n";
                        sRet += "!! Error: \r\n";
                        sRet += "    Message: " + ex.Message + "\r\n";
                        sRet += "    InnerException: " + ex.InnerException + "\r\n";
                        sRet += "\r\n";
                        sRet += "    StackTrace: " + ex.StackTrace + "\r\n";
                        sRet += "\r\n";
                        bWasError = true;
                    }
                    break;
                case ExchangeVersion.Exchange2013:
                    try
                    {
                        oResponse = service.GetUserSettings(
                            sUserSmtpAddress,
                            UserSettingName.ActiveDirectoryServer,
                            UserSettingName.AlternateMailboxes,
                            UserSettingName.CasVersion,
                            UserSettingName.EwsSupportedSchemas,
                            UserSettingName.ExternalMailboxServer,
                            UserSettingName.ExternalMailboxServerAuthenticationMethods,
                            UserSettingName.ExternalMailboxServerRequiresSSL,

                            UserSettingName.ExternalEwsUrl,
                            UserSettingName.ExternalPop3Connections,
                            UserSettingName.ExternalSmtpConnections,

                            UserSettingName.ExternalWebClientUrls,
                            UserSettingName.InternalEwsUrl,
                            UserSettingName.InternalMailboxServer,
                            UserSettingName.InternalMailboxServerDN,
                            UserSettingName.InternalWebClientUrls,
                             UserSettingName.MailboxDN,
                            UserSettingName.PublicFolderServer,
                            UserSettingName.UserDeploymentId,
                            UserSettingName.UserDisplayName,
                            UserSettingName.UserDN,
                            UserSettingName.MobileMailboxPolicy,
                            UserSettingName.ExternalEwsVersion,
                            UserSettingName.ExchangeRpcUrl
                        );
                    }
                    catch (Exception ex)
                    {
                        sRet += "\r\n";

                        sRet += "!! Error: \r\n";
                        sRet += "    Message: " + ex.Message + "\r\n";
                        sRet += "    InnerException: " + ex.InnerException + "\r\n";
                        sRet += "\r\n";
                        sRet += "    StackTrace: " + ex.StackTrace + "\r\n";
                        sRet += "\r\n";
                        bWasError = true;
                    }
                    break;
                }

            if (bWasError == false)
            {
                try
                {

                    string sLine = string.Empty;

                    // Display each retrieved value. The settings are part of a key value pair.
                    string sValue = string.Empty;
                    string sType = string.Empty;
                    foreach (KeyValuePair<UserSettingName, Object> usersetting in oResponse.Settings)
                    {
                        sValue = string.Empty;

                        sLine = string.Format("{0}:\r\n", usersetting.Key.ToString());

                        sType = usersetting.Value.ToString();
                        switch (sType)
                        {
                            case ("Microsoft.Exchange.WebServices.Autodiscover.WebClientUrlCollection"):
                                Microsoft.Exchange.WebServices.Autodiscover.WebClientUrlCollection oCollection1;
                                oCollection1 = (Microsoft.Exchange.WebServices.Autodiscover.WebClientUrlCollection)usersetting.Value;
                                foreach (WebClientUrl oUrl in oCollection1.Urls)
                                {
                                    sValue += string.Format("    Url: {0} - Authentication: {1}\r\n", oUrl.Url, oUrl.AuthenticationMethods);
                                }
                                break;
                            case ("Microsoft.Exchange.WebServices.Autodiscover.ProtocolConnectionCollection"):
                                Microsoft.Exchange.WebServices.Autodiscover.ProtocolConnectionCollection oCollection2;
                                oCollection2 = (Microsoft.Exchange.WebServices.Autodiscover.ProtocolConnectionCollection)usersetting.Value;
                                foreach (ProtocolConnection oProtocolConnection in oCollection2.Connections)
                                {
                                    sValue += string.Format("    Hostname: {0} - Port: {1} - EncryptionMethod: {2}\r\n", oProtocolConnection.Hostname, oProtocolConnection.Port, oProtocolConnection.EncryptionMethod);
                                }

                                break;
                            default:
                                sValue = string.Format("    {0}\r\n", usersetting.Value.ToString());
                                break;


                        }
                        sLine += sValue;
                        //sLine = string.Format("{0}:\r\n    {1}", usersetting.Key.ToString(), sValue);

                        sRet += sLine;
                    }

                    sRet += "\r\n";
                    sRet += "+ Response Information\r\n";
                    sRet += "    Response Redirect Target: " + oResponse.RedirectTarget + "\r\n";
                    sRet += "    Response Errors: \r\n";
                    sRet += "       ErrorCode: " + oResponse.ErrorCode + "\r\n";
                    sRet += "       ErrorMessage: " + oResponse.ErrorMessage + "\r\n";
                    if (oResponse.UserSettingErrors.Count > 0)
                    {
                        sRet += "       Per user setting errors:  \r\n";

                        foreach (UserSettingError oError in oResponse.UserSettingErrors)
                        {
                            sRet += "         Setting: " + oError.SettingName + "\r\n";
                            sRet += "           ErrorCode: " + oError.ErrorCode + "\r\n";
                            sRet += "           ErrorMessage: " + oError.ErrorMessage + "\r\n";
                            sRet += "\r\n";
                        }
                    }
                    sRet += "- Response Information\r\n";

                }
                catch (Exception ex)
                {

                    sRet += "\r\n";
                    sRet += "!! Error: \r\n";
                    sRet += "    Message: " + ex.Message + "\r\n";
                    sRet += "    InnerException: " + ex.InnerException + "\r\n";
                    sRet += "\r\n";
                    sRet += "    StackTrace: " + ex.StackTrace + "\r\n";
                    sRet += "\r\n";
                }

            }
            sRet += "\r\n";
            sRet += "- Calling GetUserSettings for " + sUserSmtpAddress +  " - " + DateTime.Now + "\r\n";

            return sRet;
        }

        private void chkDefaultWindowsCredentials_CheckedChanged(object sender, EventArgs e)
        {
            bool bEnable = false;
            if (chkDefaultWindowsCredentials.Checked == false)
                bEnable = true;

            this.txtUser.Enabled = bEnable;
            this.txtPassword.Enabled = bEnable;
            this.txtDomain.Enabled = bEnable;
        }

        private void cmboExchangeVersion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 

        private void btnAutodiscoverOffOfServiceObject_Click(object sender, EventArgs e)
        {
            bool bDoAutodiscover = true;

            this.Cursor = Cursors.WaitCursor;


            bDoAutodiscover = CheckCredentials(
                        this.chkDefaultWindowsCredentials.Checked,
                        this.txtUser.Text,
                        this.txtPassword.Text,
                        this.txtDomain.Text
                        );

            if (this.txtTargetMailbox.Text.Trim().Length == 0)
            {
                MessageBox.Show("The target mailbox smtp address needs to be entered.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bDoAutodiscover = false;
            }

            if (bDoAutodiscover== true)
                DoAutodiscoverUsingServiceObject();

            this.Cursor = Cursors.Default;
        }

        private void txtCerts_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCerts_DoubleClick(object sender, EventArgs e)
        {
            DisplayText oForm = new DisplayText();
            oForm.BodyText.Text = this.txtCerts.Text;
            oForm.ShowDialog();
        }

        private void txtTracing_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void txtTracing_DoubleClick(object sender, EventArgs e)
        {
            DisplayText oForm = new DisplayText();
            oForm.BodyText.Text = this.txtTracing.Text;
            oForm.ShowDialog();
        }

        private void txtResults_DoubleClick(object sender, EventArgs e)
        {
            DisplayText oForm = new DisplayText();
            oForm.BodyText.Text = this.txtResults.Text;
            oForm.ShowDialog();
        }


         
    }
}
