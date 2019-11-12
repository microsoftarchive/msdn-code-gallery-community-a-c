using System;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace TCD.Arduino.Bluetooth
{
    public class BluetoothConnectionManager : PropertyChangedBase
    {
        #region Events
        //OnExceptionOccured
        public delegate void AddOnExceptionOccuredDelegate(object sender, Exception ex);
        public event AddOnExceptionOccuredDelegate ExceptionOccured;
        private void OnExceptionOccuredEvent(object sender, Exception ex)
        {
            if (ExceptionOccured != null)
                ExceptionOccured(sender, ex);
        }
        //OnMessageReceived
        public delegate void AddOnMessageReceivedDelegate(object sender, string message);
        public event AddOnMessageReceivedDelegate MessageReceived;
        private void OnMessageReceivedEvent(object sender, string message)
        {
            if (MessageReceived != null)
                MessageReceived(sender, message);
        }
        #endregion

        #region Commands
        public RelayCommand BluetoothCancelCommand { get; private set; }
        public RelayCommand BluetoothDisconnectCommand { get; private set; }
        #endregion

        #region Variables
        private IAsyncOperation<RfcommDeviceService> connectService;
        private IAsyncAction connectAction;
        private RfcommDeviceService rfcommService;
        private StreamSocket socket;
        private DataReader reader;
        private DataWriter writer;

        private BluetoothConnectionState _State;
        public BluetoothConnectionState State { get { return _State; } set { _State = value; OnPropertyChanged(); } }
        #endregion

        #region Lifecycle
        public BluetoothConnectionManager()
        {
            BluetoothCancelCommand = new RelayCommand(AbortConnection);
            BluetoothDisconnectCommand = new RelayCommand(Disconnect);
        }

        /// <summary>
        /// Displays a PopupMenu for selection of the other Bluetooth device.
        /// Continues by establishing a connection to the selected device.
        /// </summary>
        /// <param name="invokerRect">for example: connectButton.GetElementRect();</param>
        public async Task EnumerateDevicesAsync(Rect invokerRect)
        {
            this.State = BluetoothConnectionState.Enumerating;
            var serviceInfoCollection = await DeviceInformation.FindAllAsync(RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort));
            PopupMenu menu = new PopupMenu();
            foreach (var serviceInfo in serviceInfoCollection)
                menu.Commands.Add(new UICommand(serviceInfo.Name, new UICommandInvokedHandler(delegate(IUICommand command) { Task connect = ConnectToServiceAsync(command); }), serviceInfo));
            var result = await menu.ShowForSelectionAsync(invokerRect);
            if (result == null)
                this.State = BluetoothConnectionState.Disconnected;
        }
        private async Task ConnectToServiceAsync(IUICommand command)
        {
            DeviceInformation serviceInfo = (DeviceInformation)command.Id;
            this.State = BluetoothConnectionState.Connecting;
            try
            {
                // Initialize the target Bluetooth RFCOMM device service
                connectService = RfcommDeviceService.FromIdAsync(serviceInfo.Id);
                rfcommService = await connectService;
                if (rfcommService != null)
                {
                    // Create a socket and connect to the target 
                    socket = new StreamSocket();
                    connectAction = socket.ConnectAsync(rfcommService.ConnectionHostName, rfcommService.ConnectionServiceName, SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);
                    await connectAction;//to make it cancellable
                    writer = new DataWriter(socket.OutputStream);
                    reader = new DataReader(socket.InputStream);
                    Task listen = ListenForMessagesAsync();
                    this.State = BluetoothConnectionState.Connected;
                }
                else
                    OnExceptionOccuredEvent(this, new Exception("Unable to create service.\nMake sure that the 'bluetooth.rfcomm' capability is declared with a function of type 'name:serialPort' in Package.appxmanifest."));
            }
            catch (TaskCanceledException)
            {
                this.State = BluetoothConnectionState.Disconnected;
            }
            catch (Exception ex)
            {
                this.State = BluetoothConnectionState.Disconnected;
                OnExceptionOccuredEvent(this, ex);
            }
        }

        /// <summary>
        /// Abort the connection attempt.
        /// </summary>
        public void AbortConnection()
        {
            if (connectService != null && connectService.Status == AsyncStatus.Started)
                connectService.Cancel();
            if (connectAction != null && connectAction.Status == AsyncStatus.Started)
                connectAction.Cancel();
        }
        /// <summary>
        /// Terminate an connection.
        /// </summary>
        public void Disconnect()
        {
            if (reader != null)
                reader = null;
            if (writer != null)
            {
                writer.DetachStream();
                writer = null;
            }
            if (socket != null)
            {
                socket.Dispose();
                socket = null;
            }
            if (rfcommService != null)
                rfcommService = null;
            this.State = BluetoothConnectionState.Disconnected;
        }
        #endregion

        #region Send & Receive
        /// <summary>
        /// Send a string message.
        /// </summary>
        /// <param name="message">The string to send.</param>
        /// <returns></returns>
        public async Task<uint> SendMessageAsync(string message)
        {
            uint sentMessageSize = 0;
            if (writer != null)
            {
                uint messageSize = writer.MeasureString(message);
                writer.WriteByte((byte)messageSize);
                sentMessageSize = writer.WriteString(message);
                await writer.StoreAsync();
            }
            return sentMessageSize;
        }
        private async Task ListenForMessagesAsync()
        {
            while (reader != null)
            {
                try
                {
                    // Read first byte (length of the subsequent message, 255 or less). 
                    uint sizeFieldCount = await reader.LoadAsync(1);
                    if (sizeFieldCount != 1)
                    {
                        // The underlying socket was closed before we were able to read the whole data. 
                        return;
                    }

                    // Read the message. 
                    uint messageLength = reader.ReadByte();
                    uint actualMessageLength = await reader.LoadAsync(messageLength);
                    if (messageLength != actualMessageLength)
                    {
                        // The underlying socket was closed before we were able to read the whole data. 
                        return;
                    }
                    // Read the message and process it.
                    string message = reader.ReadString(actualMessageLength);
                    OnMessageReceivedEvent(this, message);
                }
                catch (Exception ex)
                {
                    if (reader != null)
                        OnExceptionOccuredEvent(this, ex);
                }
            }
        }
        #endregion
    }
    public enum BluetoothConnectionState
    {
        Disconnected,
        Connected,
        Enumerating,
        Connecting
    }
}