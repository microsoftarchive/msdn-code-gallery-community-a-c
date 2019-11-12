using System.IO.Ports;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.Threading;
using System;

namespace SBDBTMotorCS
{
    public class Program
    {
        private static uint MotorPower = 0;
        public static void Main()
        {
            var serial = new SerialPort("COM1", 9800, Parity.None, 8, StopBits.One);
            var power = new PWM(Pins.GPIO_PIN_D9);
            var motorIn8 = new OutputPort(Pins.GPIO_PIN_D8, false);

            serial.DataReceived += Serial_DataReceived;
            motorIn8.Write(true);
            while (true)
            {
                try
                {
                    var value = MotorPower;
                    if (!serial.IsOpen)
                    {
                        serial.Open();
                    }
                    power.SetPulse(20000, value);
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    var mes = ex.Message;
                }
            }
        }

        private static void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var serial = (SerialPort)sender;
                var data = new byte[10];
                var cmd = serial.Read(data, 0, data.Length);

                MotorPower = (uint)((uint)data[0] * 100);
                if (MotorPower > 20000)
                {
                    MotorPower = 20000;
                }
            }
            catch (Exception ex)
            {
                var mes = ex.Message;
            }
        }
    }
}