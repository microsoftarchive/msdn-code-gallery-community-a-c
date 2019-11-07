using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI;
using Windows.UI.Xaml.Media;
using TCD.Arduino.Bluetooth;
using TCD.Controls;

namespace BluetoothCommunicationSampleController
{
    public class UIConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            switch (parameter as string)//parameter tells us who's calling
            {
                //BluetoothConnectionState
                case "BluetoothConnect": return ((BluetoothConnectionState)value == BluetoothConnectionState.Disconnected);
                case "BluetoothInProgress":
                case "BluetoothConnecting": return ((BluetoothConnectionState)value == BluetoothConnectionState.Connecting);
                case "BluetoothDisconnect": return ((BluetoothConnectionState)value == BluetoothConnectionState.Connected);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            return null;
        }
    }
}
