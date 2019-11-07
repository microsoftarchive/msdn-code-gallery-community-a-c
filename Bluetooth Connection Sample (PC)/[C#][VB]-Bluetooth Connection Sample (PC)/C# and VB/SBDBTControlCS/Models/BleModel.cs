using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Enumeration;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace SBDBTControlCS.Models
{
    public class BleModel : INotifyPropertyChanged
    {
        private RfcommDeviceService DeviceService;
        private StreamSocket BtSocket;
        private DataWriter Writer;

        public BleModel()
        {
        }

        private int? _Power = null;
        public int? Power
        {
            get
            {
                return _Power;
            }
            set
            {
                if (_Power != value)
                {
                    _Power = value;
                    OnPropertyChanged();
                }
            }
        }

        private String _Message = null;
        public String Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                if (this._Message != value)
                {
                    this._Message = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task Connect()
        {
            var name = Common.Settings.DeviceName;
            if (name != null)
            {
                //保存されたBluetoothデバイス名と一致するデバイス情報を取得しデータを送信する
                var serviceInfos = await DeviceInformation.FindAllAsync(RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort));
                foreach (var serviceInfo in serviceInfos)
                {
                    if (serviceInfo.Name == name)
                    {
                        await Connect(serviceInfo);
                        break;
                    }
                }
            }
        }

        private async Task Connect(DeviceInformation serviceInfo)
        {
            try
            {
                //指定されたデバイス情報で接続を行う
                if (DeviceService == null)
                {
                    DeviceService = await RfcommDeviceService.FromIdAsync(serviceInfo.Id);
                    BtSocket = new StreamSocket();
                    await BtSocket.ConnectAsync(
                        this.DeviceService.ConnectionHostName,
                        this.DeviceService.ConnectionServiceName,
                        SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);
                    Writer = new DataWriter(BtSocket.OutputStream);
                    this.Message = "Connected " + DeviceService.ConnectionHostName.DisplayName;
                }
                //接続されたBluetoothデバイスにデータを送信する
                SetPower(this.Power);
            }
            catch (Exception ex)
            {
                this.Message = ex.Message;
                DeviceService = null;
            }
        }

        private async void SetPower(int? power)
        {
            try
            {
                if (DeviceService != null)
                {
                    //0 - 200の値を送信する
                    var moterPower = (power <= 200 ? power : 200);
                    byte[] byteArray = new byte[] { (byte)moterPower };
                    Writer.WriteBytes(byteArray);
                    var sendResult = await Writer.StoreAsync();
                }
            }
            catch (Exception ex)
            {
                this.Message = ex.Message;
                DeviceService = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}