using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AzureIotHubConsole
{
    class Program
    {
        private const string DeviceConnectionString = "HostName=NOME_DO_SERVICO.azure-devices.net;SharedAccessKeyName=iothubowner;DeviceId=NOME_DO_DEVICE;SharedAccessKey=SHARED_ACCESS_KEY";
        static ServiceClient serviceClient;

        static void Main(string[] args)
        {
            serviceClient =  ServiceClient.CreateFromConnectionString(DeviceConnectionString);
            Program program = new Program();
        }

        public Program()
        {
            DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(DeviceConnectionString);
            SendEvent().Wait();

            ReceiveCommands(deviceClient).Wait();
        }

        static async Task SendEvent()
        {
            string dataBuffer;
            dataBuffer = "HelloWorld";
            Microsoft.Azure.Devices.Message eventMessage = new Microsoft.Azure.Devices.Message(Encoding.ASCII.GetBytes(dataBuffer));
            await serviceClient.SendAsync("NOME_DO_DEVICE", eventMessage);
        }

        async Task ReceiveCommands(DeviceClient deviceClient)
        {
            Console.WriteLine("\nDevice aguardando comandos do IoTHub...\n");
            Microsoft.Azure.Devices.Client.Message receivedMessage;
            string messageData;
            while (true)
            {
                receivedMessage = await deviceClient.ReceiveAsync(TimeSpan.FromSeconds(1));
                if (receivedMessage != null)
                {
                    messageData = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                    Console.WriteLine("\t{0}> Mensagem recebida: {1}", DateTime.Now.ToLocalTime(), messageData);
                    await deviceClient.CompleteAsync(receivedMessage);
                }
            }
        }
    }
}
