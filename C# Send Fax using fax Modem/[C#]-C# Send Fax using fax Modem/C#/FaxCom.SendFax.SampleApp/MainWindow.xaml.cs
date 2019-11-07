
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Documents;
using FAXCOMEXLib;
using Microsoft.Win32;

namespace FaxCom.SendFax.SampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties

        private static FaxServer _faxServer;
        private static FaxServer faxServer
        {
            get { return _faxServer; }
            set { _faxServer = value; }
        }

        private FaxDocument _faxDoc;
        public FaxDocument faxDoc
        {
            get { return _faxDoc; }
            set { _faxDoc = value; }
        }

        private FaxModel _faxObj;
        public FaxModel FaxObj
        {
            get { return _faxObj; }
            set { _faxObj = value; }
        }

        OpenFileDialog dlg;

        #endregion

        #region Constructor

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                recipientNameTextBox.Text = "";
                recipientNumberTextBox.Text = "";
                faxDocumentNameTextbox.Text = "";
                faxSubjectTextbox.Text = "";
                filePathTextBox.Text = "";
                senderNameTextBox.Text = "";
                SenderCompanyTextBox.Text = "";
                // Device Information
                GetCurrentFaxModemInfo();

                FindAndKillProcess("");
            }
            catch (Exception exception)
            {

                throw exception;
            }


        }

        private void RegisterFaxService()
        {
            ShowInstructionForInstallFaxService();
        }

        private void ShowInstructionForInstallFaxService()
        {
            faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("Windows Fax Service is not installed on your computer, Please install fax service on your computer. " + Environment.NewLine)));
        }



        // This Data will come from user Input
        private void PrepairFaxData()
        {
            FaxObj = new FaxModel();
            FaxObj.SenderName = senderNameTextBox.Text;
            FaxObj.SenderCompany = SenderCompanyTextBox.Text;
            FaxObj.FaxBodyPath = filePathTextBox.Text.ToString();
            FaxObj.FaxSubject = faxSubjectTextbox.Text;
            FaxObj.FaxDocumentName = faxDocumentNameTextbox.Text;
            FaxObj.RecipientFaxNumber = recipientNumberTextBox.Text;
            FaxObj.RecipientName = recipientNameTextBox.Text;

        }



        #endregion

        #region Methods

        private void GetCurrentFaxModemInfo()
        {
            // Loop over returned data
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("Searching connected Modem....." + Environment.NewLine)));

            // Get connected fax modem list
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_POTSModem");
            var collection = searcher.Get();

            if (collection.Count > 0)
            {
                faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("Connected Modem Information:-" + Environment.NewLine)));

                foreach (ManagementObject modemObject in collection)
                {
                    faxStatusTextBox.Document.Blocks.Add(
                        new Paragraph(
                            new Run(modemObject["Name"].ToString() +
                                    Environment.NewLine)));

                }
            }
            else
            {
                faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("No Fax modem connected. Please connect you fax modem and try again." + Environment.NewLine)));
                return;
            }
        }

        private void RegisterFaxServerEvents()
        {
            faxServer.OnOutgoingJobAdded +=
                new IFaxServerNotify2_OnOutgoingJobAddedEventHandler(faxServer_OnOutgoingJobAdded);
            faxServer.OnOutgoingJobChanged +=
                new IFaxServerNotify2_OnOutgoingJobChangedEventHandler(faxServer_OnOutgoingJobChanged);
            faxServer.OnOutgoingJobRemoved +=
                new IFaxServerNotify2_OnOutgoingJobRemovedEventHandler(faxServer_OnOutgoingJobRemoved);
            faxServer.OnDeviceStatusChange +=
                new IFaxServerNotify2_OnDeviceStatusChangeEventHandler(faxServer_OnDeviceStatusChange);
            faxServer.OnActivityLoggingConfigChange +=
                new IFaxServerNotify2_OnActivityLoggingConfigChangeEventHandler(faxServer_OnActivityLoggingConfigChange);
            faxServer.OnDevicesConfigChange +=
                new IFaxServerNotify2_OnDevicesConfigChangeEventHandler(faxServer_OnDevicesConfigChange);
            faxServer.OnEventLoggingConfigChange +=
                new IFaxServerNotify2_OnEventLoggingConfigChangeEventHandler(faxServer_OnEventLoggingConfigChange);
            faxServer.OnGeneralServerConfigChanged +=
                new IFaxServerNotify2_OnGeneralServerConfigChangedEventHandler(faxServer_OnGeneralServerConfigChanged);
            faxServer.OnNewCall += new IFaxServerNotify2_OnNewCallEventHandler(faxServer_OnNewCall);
            faxServer.OnOutboundRoutingGroupsConfigChange +=
                new IFaxServerNotify2_OnOutboundRoutingGroupsConfigChangeEventHandler(
                    faxServer_OnOutboundRoutingGroupsConfigChange);
            faxServer.OnOutboundRoutingRulesConfigChange +=
                new IFaxServerNotify2_OnOutboundRoutingRulesConfigChangeEventHandler(
                    faxServer_OnOutboundRoutingRulesConfigChange);
            faxServer.OnOutgoingArchiveConfigChange +=
                new IFaxServerNotify2_OnOutgoingArchiveConfigChangeEventHandler(faxServer_OnOutgoingArchiveConfigChange);
            faxServer.OnOutgoingMessageAdded +=
                new IFaxServerNotify2_OnOutgoingMessageAddedEventHandler(faxServer_OnOutgoingMessageAdded);
            faxServer.OnOutgoingMessageRemoved +=
                new IFaxServerNotify2_OnOutgoingMessageRemovedEventHandler(faxServer_OnOutgoingMessageRemoved);
            faxServer.OnOutgoingQueueConfigChange +=
                new IFaxServerNotify2_OnOutgoingQueueConfigChangeEventHandler(faxServer_OnOutgoingQueueConfigChange);
            faxServer.OnQueuesStatusChange +=
                new IFaxServerNotify2_OnQueuesStatusChangeEventHandler(faxServer_OnQueuesStatusChange);
            faxServer.OnReceiptOptionsChange +=
                new IFaxServerNotify2_OnReceiptOptionsChangeEventHandler(faxServer_OnReceiptOptionsChange);
            faxServer.OnSecurityConfigChange +=
                new IFaxServerNotify2_OnSecurityConfigChangeEventHandler(faxServer_OnSecurityConfigChange);
            faxServer.OnServerActivityChange +=
                new IFaxServerNotify2_OnServerActivityChangeEventHandler(faxServer_OnServerActivityChange);
            faxServer.OnServerShutDown += new IFaxServerNotify2_OnServerShutDownEventHandler(faxServer_OnServerShutDown);

            var eventsToListen = FaxServerEventsTypeEnum();
            faxServer.ListenToServerEvents(eventsToListen);
        }

        private void SendFax()
        {
            try
            {
                FaxDocumentSetup();
                object submitReturnValue = faxDoc.Submit(faxServer.ServerName);
                faxDoc = null;
                FindAndKillProcess("AcroRd32"); // Kill the reader

            }
            catch (COMException ce)
            {
                faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("Error connecting to fax server. Error Message: " + ce.Message + " " + ce.StackTrace + Environment.NewLine)));
                if (ce.ErrorCode == -2147023741)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("To resolve the issue please install Acro Reader on your PC." + Environment.NewLine)));
                }
            }
        }

        private void FaxDocumentSetup()
        {
            faxDoc = new FaxDocument();
            faxDoc.Priority = FAX_PRIORITY_TYPE_ENUM.fptHIGH;
            faxDoc.ReceiptType = FAX_RECEIPT_TYPE_ENUM.frtNONE;
            faxDoc.AttachFaxToReceipt = true;
            CheckFileIsNotInUse();
            faxDoc.Sender.Name = FaxObj.SenderName;
            faxDoc.Sender.Company = FaxObj.SenderCompany;
            faxDoc.Body = FaxObj.FaxBodyPath;
            faxDoc.Subject = FaxObj.FaxSubject;
            faxDoc.DocumentName = FaxObj.FaxDocumentName;
            faxDoc.Recipients.Add(FaxObj.RecipientFaxNumber, FaxObj.RecipientName);
        }

        private void CheckFileIsNotInUse()
        {
            //Check File is not in use when try to attach and send
            if (FaxObj == null)
            {
                return;
            }
            FileStream fs = null;
            try
            {
                fs = File.OpenRead(FaxObj.FaxBodyPath);
            }
            catch (IOException)
            {
                faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("File is in use. Please release before access." + Environment.NewLine)));
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("File is released." + Environment.NewLine)));
                }
            }
        }

        public bool FindAndKillProcess(string name)
        {
            foreach (var process in Process.GetProcessesByName(name))
            {
                process.Kill();
            }
            return true;
        }

        #endregion

        #region Event Listeners

        private void faxServer_OnOutgoingJobAdded(FaxServer pFaxServer, string bstrJobId)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                faxStatusTextBox.Document.Blocks.Add(
                    new Paragraph(
                        new Run("OnOutgoingJobAdded event fired. A fax is added to the outgoing queue. Please wait...." +
                                Environment.NewLine)));
            }));
        }

        private void faxServer_OnOutgoingJobChanged(FaxServer pFaxServer, string bstrJobId, FaxJobStatus pJobStatus)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                faxStatusTextBox.Document.Blocks.Add(
                    new Paragraph(
                        new Run("OnOutgoingJobChanged event fired. A fax is changed to the outgoing queue." +
                                Environment.NewLine)));
                pFaxServer.Folders.OutgoingQueue.Refresh();
                PrintFaxStatus(pJobStatus);
            }));
        }

        private void faxServer_OnOutgoingJobRemoved(FaxServer pFaxServer, string bstrJobId)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                faxStatusTextBox.Document.Blocks.Add(
                    new Paragraph(
                        new Run("OnOutgoingJobRemoved event fired. Fax job is removed to outbound queue." +
                                Environment.NewLine)));

            }));
        }


        private void faxServer_OnServerShutDown(FaxServer pFaxServer)
        {
            faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("On Server Shut Down." + Environment.NewLine)));
        }

        private void faxServer_OnServerActivityChange(FaxServer pFaxServer, int lIncomingMessages, int lRoutingMessages,
            int lOutgoingMessages, int lQueuedMessages)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Server Activity Change." + Environment.NewLine)));
        }

        private void faxServer_OnSecurityConfigChange(FaxServer pFaxServer)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Security Config Change." + Environment.NewLine)));
        }

        private void faxServer_OnReceiptOptionsChange(FaxServer pFaxServer)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Receipt Options Change." + Environment.NewLine)));
        }

        private void faxServer_OnQueuesStatusChange(FaxServer pFaxServer, bool bOutgoingQueueBlocked,
            bool bOutgoingQueuePaused, bool bIncomingQueueBlocked)
        {
            faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("On Queues Status Change." + Environment.NewLine)));
        }

        private void faxServer_OnOutgoingQueueConfigChange(FaxServer pFaxServer)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Out going Queue Config Change." + Environment.NewLine)));
        }

        private void faxServer_OnOutgoingMessageRemoved(FaxServer pFaxServer, string bstrMessageId)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Out going Message Removed." + Environment.NewLine)));
        }

        private void faxServer_OnOutgoingMessageAdded(FaxServer pFaxServer, string bstrMessageId)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Out going Message Added." + Environment.NewLine)));
        }

        private void faxServer_OnOutgoingArchiveConfigChange(FaxServer pFaxServer)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Out going Archive Config Change." + Environment.NewLine)));
        }

        private void faxServer_OnOutboundRoutingRulesConfigChange(FaxServer pFaxServer)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Out bound Routing Rules Config Change." + Environment.NewLine)));
        }

        private void faxServer_OnOutboundRoutingGroupsConfigChange(FaxServer pFaxServer)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Out bound Routing Groups Config Change." + Environment.NewLine)));

        }

        private void faxServer_OnNewCall(FaxServer pFaxServer, int lCallId, int lDeviceId, string bstrCallerId)
        {
            faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("On New Call." + Environment.NewLine)));

        }

        private void faxServer_OnGeneralServerConfigChanged(FaxServer pFaxServer)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On General Server Config Changed." + Environment.NewLine)));
        }

        private void faxServer_OnEventLoggingConfigChange(FaxServer pFaxServer)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Event Logging Config Change." + Environment.NewLine)));
        }

        private void faxServer_OnDevicesConfigChange(FaxServer pFaxServer)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Devices Config Change." + Environment.NewLine)));

        }

        private void faxServer_OnActivityLoggingConfigChange(FaxServer pFaxServer)
        {
            faxStatusTextBox.Document.Blocks.Add(
                new Paragraph(new Run("On Activity Logging Config Change." + Environment.NewLine)));

        }

        private static FAX_SERVER_EVENTS_TYPE_ENUM FaxServerEventsTypeEnum()
        {
            var eventsToListen = FAX_SERVER_EVENTS_TYPE_ENUM.fsetACTIVITY |
                                 FAX_SERVER_EVENTS_TYPE_ENUM.fsetCONFIG |
                                 FAX_SERVER_EVENTS_TYPE_ENUM.fsetDEVICE_STATUS |
                                 FAX_SERVER_EVENTS_TYPE_ENUM.fsetFXSSVC_ENDED |
                                 FAX_SERVER_EVENTS_TYPE_ENUM.fsetINCOMING_CALL |
                                 FAX_SERVER_EVENTS_TYPE_ENUM.fsetIN_ARCHIVE |
                                 FAX_SERVER_EVENTS_TYPE_ENUM.fsetIN_QUEUE |
                                 FAX_SERVER_EVENTS_TYPE_ENUM.fsetNONE |
                                 FAX_SERVER_EVENTS_TYPE_ENUM.fsetOUT_ARCHIVE |
                                 FAX_SERVER_EVENTS_TYPE_ENUM.fsetOUT_QUEUE |
                                 FAX_SERVER_EVENTS_TYPE_ENUM.fsetQUEUE_STATE;
            return eventsToListen;
        }

        private void faxServer_OnDeviceStatusChange(FaxServer pFaxServer, int lDeviceId, bool bPoweredOff, bool bSending,
            bool bReceiving, bool bRinging)
        {
            faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("On Device Status Change." + Environment.NewLine)));
        }

        #endregion

        #region FaxStatus

        private void PrintFaxStatus(FaxJobStatus faxJobStatus)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {

                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesRECEIVING)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device is receiving a fax." + Environment.NewLine)));
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesPARTIALLY_RECEIVED)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The incoming fax was partially received. Some (but not all) of the pages are available." + Environment.NewLine)));
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesNO_DIAL_TONE)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device has encountered a fatal protocol error. Please check your fax line connection." + Environment.NewLine)));
                    FindAndKillProcess("WFS");
                    return;
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesNO_ANSWER)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The receiving device did not answer the call." + Environment.NewLine)));
                    FindAndKillProcess("WFS");
                    return;
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesNOT_FAX_CALL)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device received a call that was a data call or a voice call." + Environment.NewLine)));
                    FindAndKillProcess("WFS");
                    return;
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesNONE)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("No extended status value Fax Call None..." + Environment.NewLine)));
                    FindAndKillProcess("WFS");
                    return;
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesLINE_UNAVAILABLE)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device is not available because it is in use by another application." + Environment.NewLine)));
                    FindAndKillProcess("WFS");
                    return;

                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesINITIALIZING)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device is initializing a call." + Environment.NewLine)));
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesFATAL_ERROR)
                {

                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device has encountered a fatal protocol error: To resolve the issue please connect your modem driver and if required install driver software for your modem. If your are connecting your modem to this computer for the first time please restart your computer." + Environment.NewLine)));
                    FindAndKillProcess("WFS");
                    return;

                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesDISCONNECTED)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The sender or the caller disconnected the fax call." + Environment.NewLine)));
                    FindAndKillProcess("WFS");
                    return;
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesCALL_DELAYED)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device delayed a fax call because the sending device received a busy signal multiple times. The device cannot retry the call because dialing restrictions exist. (Some countries/regions restrict the number of retry attempts when a number is busy.)" + Environment.NewLine)));
                    FindAndKillProcess("WFS");
                    return;
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesCALL_BLACKLISTED)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device could not complete a call because the telephone number was blocked or reserved; emergency numbers such as 911 are blocked." + Environment.NewLine)));
                    FindAndKillProcess("WFS");
                    return;
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesCALL_ABORTED)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The call was aborted." + Environment.NewLine)));
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesBUSY)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device encountered a busy signal." + Environment.NewLine)));
                    FindAndKillProcess("WFS");
                    return;
                }

                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesDIALING)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device is dialing a fax number." + Environment.NewLine)));
                }
                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesHANDLED)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The fax service processed the outbound fax; the fax service provider will transmit the fax." + Environment.NewLine)));
                }

                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesBAD_ADDRESS)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device dialed an invalid fax number." + Environment.NewLine)));
                }

                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesTRANSMITTING)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The device is sending a fax." + Environment.NewLine)));
                }

                if (faxJobStatus.Status == FAX_JOB_STATUS_ENUM.fjsCOMPLETED && faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesCALL_COMPLETED)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("Fax is sent successfully" + Environment.NewLine)));
                    FindAndKillProcess("WFS");
                }

                if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesPROPRIETARY)
                {
                    faxStatusTextBox.Document.Blocks.Add(new Paragraph(new Run("The ExtendedStatusCode property specifies a code describing the job's extended status." + Environment.NewLine)));
                }



            }));


        }

        #endregion



        #region Click Event

        private void SendFaxButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Prepair Fax Info
            PrepairFaxData();

            try
            {
                faxServer = new FaxServer();
            }
            catch (Exception exception)
            {
                RegisterFaxService();
            }

            faxServer.Connect(Environment.MachineName);
            RegisterFaxServerEvents();
            SendFax();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BrowseButton_OnClick(object sender, RoutedEventArgs e)
        {

            dlg = new OpenFileDialog();
            dlg.ShowDialog();
            FileStream fs;
            if (dlg.FileName == "")
            {
                MessageBoxResult result = MessageBox.Show(" pp.", " gg", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);

                filePathTextBox.Text = fs.Name;

            }
        }

        #endregion
    }
}
