using SBDBTControlCS.Common;
using SBDBTControlCS.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SBDBTControlCS.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private SynchronizationContext Context = SynchronizationContext.Current;
        private BleModel Ble = new BleModel();

        public MainViewModel()
        {
            this.Ble.PropertyChanged += Ble_PropertyChanged;
        }

        public String Message
        {
            get { return this.Ble.Message; }
            set
            {
                this.Ble.Message = value;
            }
        }

        public string DeviceName
        {
            get { return Common.Settings.DeviceName; }
            set
            {
                Common.Settings.DeviceName = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand<string> _ConnectBleCommand;
        public RelayCommand<string> ConnectBleCommand
        {
            get
            {
                if (_ConnectBleCommand == null)
                {
                    _ConnectBleCommand = new RelayCommand<string>(
                            async (a) =>
                            {
                                var power = int.Parse(a) * 2;
                                this.Ble.Power = power;
                                await this.Ble.Connect();
                            }
                        );
                }
                return _ConnectBleCommand;
            }
            set
            {
                _ConnectBleCommand = value;
            }
        }

        private void Ble_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.Context.Post((o) =>
            {
                OnPropertyChanged(e.PropertyName);
            },
                null);
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
