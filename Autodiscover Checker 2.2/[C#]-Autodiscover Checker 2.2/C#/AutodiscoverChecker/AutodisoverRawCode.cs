using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using AppHelpers;

namespace AutodiscoverChecker
{
    public partial class AutodisoverRawCode : Form
    {
        private InMemoryListener _IML = null;

        public AutodisoverRawCode()
        {
            InitializeComponent();
            CheckCredentialsEnablement();
        }

        public enum DiscoverType
        {
            Scp,
            Pox,
            Soap
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
 

            int iMaxHops = 15;

            bool bDoAutodiscover = true;
            txtTracing.Text = string.Empty;

            _IML = new InMemoryListener();

            bDoAutodiscover = CheckCredentials(
                        this.chkDefaultWindowsCredentials.Checked,
                        this.txtUser.Text,
                        this.txtPassword.Text,
                        this.txtDomain.Text
                        );

            if (this.txtTargetMailboxText.Text.Trim().Length == 0)
            {
                MessageBox.Show("The target mailbox smtp address needs to be entered.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bDoAutodiscover = false;
            }

            if (bDoAutodiscover == true)
            {
                txtTracing.Text = string.Empty;
                txtTracing.Update();

                NetworkCredential oNetworkCredential = null;
                oNetworkCredential = GetCredentials(
                    this.chkDefaultWindowsCredentials.Checked, 
                    txtUser.Text.Trim(), 
                    txtPassword.Text.Trim(), 
                    txtDomain.Text.Trim()
                    );

                DoAutoDiscoverRaw(
                        DiscoverType.Scp,
                        ref _IML,
                        txtTargetMailboxText.Text.Trim(), 
                        oNetworkCredential,
                         iMaxHops,
                        chkAllowSelfSignedCerts.Checked,
                        chkTraceCertificateInformation.Checked
                        );
            }

            txtTracing.Text = _IML.LogText;

            _IML = null;
        }
 

        private bool CheckCredentials(bool bDefaultCredentials, string sUser, string sPassword, string sDomain)
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

        private NetworkCredential GetCredentials(bool bDefaultCredentials, string sUser, string sPassword, string sDomain)
        {
            NetworkCredential credentials = null;

            if (bDefaultCredentials == true)
            {
                credentials = null; //new NetworkCredential();  //? Default?
                //CredentialCache o = new CredentialCache();
                //o.Add(new Uri("xxxx"), "Basic", credentials);

            }  
            else
            {

                if (txtDomain.Text.Trim().Length != 0)
                {
                    credentials = new NetworkCredential(sUser, sPassword, sDomain);
                }
                else
                {
                    credentials = new NetworkCredential(sUser, sPassword);
                }

            }

            return credentials;
        }

        private bool DoAutoDiscoverRaw(
                DiscoverType oDiscoverType,
                ref InMemoryListener oIML,
                string sEmail, 
                NetworkCredential oNetworkCredential,
                int iMaxHops,
                bool bAllowSelfSignedCerts,
                bool bTraceCertificateInformation
                )
        {
            bool bRet = false;

            try
            {
                // Identifies the maximum number of redirections through either SCP pointer or Autodiscover redirects.

                AutodiscoverRaw oAutodiscoverRaw = new AutodiscoverRaw();
                AutodiscoverRaw.AutodiscoverResponseXml response = null;
                 
                if (oDiscoverType == DiscoverType.Scp)
                {
                    // Call Autodiscover service.
                    response =
                        oAutodiscoverRaw.DiscoverScp(
                            ref oIML,
                            sEmail,
                            oNetworkCredential,
                            ref iMaxHops,
                            bAllowSelfSignedCerts,
                            bTraceCertificateInformation
                            );
                }

                if (oDiscoverType == DiscoverType.Pox)
                {
                    // Call Autodiscover service.
                    response =
                        oAutodiscoverRaw.DiscoverPox(
                            ref oIML,
                            sEmail,
                            oNetworkCredential,
                            ref iMaxHops,
                            bAllowSelfSignedCerts,
                            bTraceCertificateInformation 
                            );
                }

                if (oDiscoverType == DiscoverType.Soap)
                {
                    // Call Autodiscover service.
                    //string sUrl = string.Empty;
                    response =
                        oAutodiscoverRaw.TryDiscoverSoap(
                            ref oIML,
                            sEmail,
                            oNetworkCredential,
                            ref iMaxHops,
                            bAllowSelfSignedCerts,
                            bTraceCertificateInformation 
                            );
                    //if (sUrl == string.Empty)
                    //    response =  false;
                    //else
                    //    response = true;
                }

                // Write response to console.
                WriteResponse(response);

                bRet = true;
            }
            catch (System.Exception e)
            {
                oIML.WriteLine("Error: " + e.ToString());
                //MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //System.Console.WriteLine(e.ToString());
                bRet = false;
            }

            return bRet;

        }

        void WriteValue(string name, object value)
        {
            if (value != null)
            {
                //_IML.WriteLine(name, value);
                _IML.WriteLine(name + "=" + value.ToString());
               //System.Console.WriteLine(name + "=" + value.ToString());
            }
        }

        void WriteValue(string ValueLine)
        {
            if (ValueLine != null)
            {
                //_IML.WriteLine(name, value);
                _IML.WriteLine(ValueLine);
                //System.Console.WriteLine(name + "=" + value.ToString());
            }
        }

        //static void WriteValue(string name, object value)
        //{
        //    if (value != null)
        //    {
        //        System.Console.WriteLine(name + "=" + value.ToString());
        //    }
        //}

        /// <summary>
        /// Write XmlElement and child nodes.
        /// </summary>
        /// <param name="xmlElement"></param>
        /// <param name="prefix"></param>
        void WriteXmlNode(string prefix, System.Xml.XmlNode xmlNode)
        {
            if (xmlNode != null)
            {
                if (xmlNode.NodeType == System.Xml.XmlNodeType.Text)
                {
                    WriteValue(prefix, xmlNode.InnerText);
                }
                else if (xmlNode.NodeType == System.Xml.XmlNodeType.Element)
                {
                    string attributes = string.Empty;

                    if (xmlNode.Attributes != null)
                    {
                        foreach (System.Xml.XmlAttribute attr in xmlNode.Attributes)
                        {
                            attributes = attributes + "[@" + attr.Name + "=\"" + attr.Value + "\"]";
                        }
                    }

                    if (xmlNode.HasChildNodes)
                    {
                        foreach (System.Xml.XmlNode child in xmlNode.ChildNodes)
                        {
                            WriteXmlNode(prefix + "/" + xmlNode.Name + attributes, child);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Write autodiscover response to console.
        /// </summary>
        /// <param name="response"></param>

        void WriteResponse(AutodiscoverRaw.AutodiscoverResponseXml response)
        {
            WriteValue("");
            WriteValue("+ Response Results");
            WriteValue("");
            if (response != null)
            {
                if (response.OutlookData != null)
                {
 

                    if (response.OutlookData.User != null)
                    {
                         
                        WriteValue("  User/DisplayName", response.OutlookData.User.DisplayName);
                        WriteValue("  User/LegacyDN", response.OutlookData.User.LegacyDN);
                        WriteValue("  User/DeploymentId", response.OutlookData.User.DeploymentId);
                    }

                    if (response.OutlookData.Account != null)
                    {
                        WriteValue("  Account/AccountType", response.OutlookData.Account.AccountType);
                        WriteValue("  Account/Action", response.OutlookData.Account.Action);
                        WriteValue("  Account/AuthPackage", response.OutlookData.Account.AuthPackage);
                        WriteValue("  Account/RedirectAddr", response.OutlookData.Account.RedirectAddr);
                        WriteValue("  Account/SSL", response.OutlookData.Account.SSL);

                        if (response.OutlookData.Account.Protocol != null)
                        {
                            foreach (AutodiscoverRaw.ProtocolXml protocolXml in response.OutlookData.Account.Protocol)
                            {
                                WriteValue("  Account/Protocol/Type", protocolXml.Type);
                                WriteValue("  Account/Protocol/ASUrl", protocolXml.ASUrl);
                                WriteValue("  Account/Protocol/AuthPackage", protocolXml.AuthPackage);
                                WriteValue("  Account/Protocol/CertPincipalName", protocolXml.CertPrincipalName);
                                WriteValue("  Account/Protocol/DirectoryPort", protocolXml.DirectoryPort);
                                WriteValue("  Account/Protocol/FBPublish", protocolXml.FBPublish);
                                WriteValue("  Account/Protocol/MdbDN", protocolXml.MdbDN);
                                WriteValue("  Account/Protocol/OABUrl", protocolXml.OABUrl);
                                WriteValue("  Account/Protocol/OOFUrl", protocolXml.OOFUrl);
                                WriteValue("  Account/Protocol/Port", protocolXml.Port);
                                WriteValue("  Account/Protocol/ReferralPort", protocolXml.ReferralPort);
                                WriteValue("  Account/Protocol/Server", protocolXml.Server);
                                WriteValue("  Account/Protocol/ServerDN", protocolXml.ServerDN);
                                WriteValue("  Account/Protocol/ServerVersion", protocolXml.ServerVersion);
                                WriteValue("  Account/Protocol/SSL", protocolXml.SSL);
                                WriteValue("  Account/Protocol/TTL", protocolXml.TTL);
                                WriteValue("  Account/Protocol/UMUrl", protocolXml.UMUrl);

                                if (protocolXml.OtherXml != null)
                                {
                                    foreach (object otherXml in protocolXml.OtherXml)
                                    {
                                        WriteXmlNode("  Account/Protocol", otherXml as System.Xml.XmlNode);
                                    }
                                }
                            }
                        }
                    }
                }

                if ((response.ErrorResponse != null) && (response.ErrorResponse.Error != null))
                {
                    WriteValue("-------------------------------------------------------");
                    WriteValue("!! Errors: ");
                    WriteValue("-------------------------------------------------------");
                    WriteValue("    Error/ErrorCode", response.ErrorResponse.Error.ErrorCode);
                    WriteValue("    Error/Message", response.ErrorResponse.Error.Message);
                    WriteValue("    Error/DebugData", response.ErrorResponse.Error.DebugData);
                    WriteValue("    Error/Id", response.ErrorResponse.Error.Id);
                    WriteValue("    Error/Time", response.ErrorResponse.Error.Time);
                    WriteValue("-------------------------------------------------------");
                    WriteValue("");
                }
            }
            WriteValue("");
            WriteValue("- Response Results");
            WriteValue("");
        }

        private void chkDefaultWindowsCredentials_CheckedChanged(object sender, EventArgs e)
        {
            CheckCredentialsEnablement();
        }

        private void CheckCredentialsEnablement()
        {
            bool bEnabled = false;
            if (chkDefaultWindowsCredentials.Checked == true)
                bEnabled = false;
            else
                bEnabled = true;

            txtUser.Enabled = bEnabled;
            txtDomain.Enabled = bEnabled;
            txtPassword.Enabled = bEnabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iMaxHops = 15;

            bool bDoAutodiscover = true;
            txtTracing.Text = string.Empty;

            _IML = new InMemoryListener();

            bDoAutodiscover = CheckCredentials(
                        this.chkDefaultWindowsCredentials.Checked,
                        this.txtUser.Text,
                        this.txtPassword.Text,
                        this.txtDomain.Text
                        );

            if (this.txtTargetMailboxText.Text.Trim().Length == 0)
            {
                MessageBox.Show("The target mailbox smtp address needs to be entered.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bDoAutodiscover = false;
            }

            if (bDoAutodiscover == true)
            {
                NetworkCredential oNetworkCredential = null;
                oNetworkCredential = GetCredentials(
                    this.chkDefaultWindowsCredentials.Checked,
                    txtUser.Text.Trim(),
                    txtPassword.Text.Trim(),
                    txtDomain.Text.Trim()
                    );

                DoAutoDiscoverRaw(
                        DiscoverType.Pox,
                        ref _IML,
                        txtTargetMailboxText.Text.Trim(),
                        oNetworkCredential,
                         iMaxHops,
                        chkAllowSelfSignedCerts.Checked,
                        chkTraceCertificateInformation.Checked
                        );
            }

            txtTracing.Text = _IML.LogText;

            _IML = null;
        }

        private void btnAutodiscoverBoth_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            int iMaxHops = 15;

            bool bDoAutodiscover = true;
            txtTracing.Text = string.Empty;

            _IML = new InMemoryListener();

            bDoAutodiscover = CheckCredentials(
                        this.chkDefaultWindowsCredentials.Checked,
                        this.txtUser.Text,
                        this.txtPassword.Text,
                        this.txtDomain.Text
                        );

            if (this.txtTargetMailboxText.Text.Trim().Length == 0)
            {
                MessageBox.Show("The target mailbox smtp address needs to be entered.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bDoAutodiscover = false;
            }

            if (bDoAutodiscover == true)
            {
                txtTracing.Text = string.Empty;
                txtTracing.Update();

                NetworkCredential oNetworkCredential = null;
                oNetworkCredential = GetCredentials(
                    this.chkDefaultWindowsCredentials.Checked,
                    txtUser.Text.Trim(),
                    txtPassword.Text.Trim(),
                    txtDomain.Text.Trim()
                    );

                DoAutoDiscoverRaw(
                        DiscoverType.Soap,
                        ref _IML,
                        txtTargetMailboxText.Text.Trim(),
                        oNetworkCredential,
                         iMaxHops,
                        chkAllowSelfSignedCerts.Checked, 
                        chkTraceCertificateInformation.Checked
                        ); 
            }

            txtTracing.Text = _IML.LogText;

            _IML = null;

            this.Cursor = Cursors.Default;
        }

        private void btnAutodiscoverExternal_Click(object sender, EventArgs e)
        {
            int iMaxHops = 15;

            bool bDoAutodiscover = true;

            this.Cursor = Cursors.WaitCursor;

            txtTracing.Text = string.Empty;

            _IML = new InMemoryListener();

            bDoAutodiscover = CheckCredentials(
                        this.chkDefaultWindowsCredentials.Checked,
                        this.txtUser.Text,
                        this.txtPassword.Text,
                        this.txtDomain.Text
                        );

            if (this.txtTargetMailboxText.Text.Trim().Length == 0)
            {
                MessageBox.Show("The target mailbox smtp address needs to be entered.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bDoAutodiscover = false;
            }

            if (bDoAutodiscover == true)
            {
                txtTracing.Text = string.Empty;
                txtTracing.Update();

                NetworkCredential oNetworkCredential = null;
                oNetworkCredential = GetCredentials(
                    this.chkDefaultWindowsCredentials.Checked,
                    txtUser.Text.Trim(),
                    txtPassword.Text.Trim(),
                    txtDomain.Text.Trim()
                    );

                DoAutoDiscoverRaw(
                        DiscoverType.Pox,
                        ref _IML,
                        txtTargetMailboxText.Text.Trim(),
                        oNetworkCredential,
                         iMaxHops,
                        chkAllowSelfSignedCerts.Checked,
                        chkTraceCertificateInformation.Checked
                        );
            }

            txtTracing.Text = _IML.LogText;

            _IML = null;

            this.Cursor = Cursors.Default;
        }

        private void AutodisoverRawCode_Load(object sender, EventArgs e)
        {

        }

        private void chkTraceCertificateInformation_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtTracing_DoubleClick(object sender, EventArgs e)
        {
            DisplayText oForm = new DisplayText();
            oForm.BodyText.Text = this.txtTracing.Text;
            oForm.ShowDialog();
        }

 

    }
}
