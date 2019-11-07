using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace cSharpChat
{
    public class OSCoreServer
    {
        const string DEFAULT_SERVER = "localhost";
        const int DEFAULT_PORT = 804;

        //Server socket stuff
        System.Net.Sockets.Socket serverSocket;
        System.Net.Sockets.SocketInformation serverSocketInfo;

        //Client socket stuff
        System.Net.Sockets.Socket clientSocket;
        System.Net.Sockets.SocketInformation clientSocketInfo;


        public bool SendData(string textdata)
        {
            if (string.IsNullOrEmpty(textdata))
            {
                return false; 
            }

            if (textdata.Trim().ToLower() == "exit")
            {
                return true;
            }

            // The chat client always starts up on the localhost, using the default port
            IPHostEntry hostInfo = Dns.GetHostByName(DEFAULT_SERVER);
            IPAddress serverAddr = hostInfo.AddressList[0];
            var clientEndPoint = new IPEndPoint(serverAddr, DEFAULT_PORT);

            // Create a listener socket and bind it to the endpoint
            clientSocket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
            clientSocket.Connect(clientEndPoint);

            byte[] byData = System.Text.Encoding.ASCII.GetBytes(textdata);   
            clientSocket.Send(byData);
            clientSocket.Close();

            return false;
        }


        public string ReceiveData()
        {
            System.Net.Sockets.Socket receiveSocket;
            byte[] buffer = new byte[256];

            receiveSocket = serverSocket.Accept();
            
            var bytesrecd = receiveSocket.Receive(buffer);

            receiveSocket.Close();

            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(buffer);
        }


        //public string ParseArgs(string[] cmdline)
        //{
        //    // Test if input arguments were supplied: 
        //    if (cmdline.Length == 0)
        //    {
        //        return DEFAULT_SERVER;
        //    }

        //    string arg1 = cmdline[0];
        //    if (string.IsNullOrEmpty(arg1))
        //    {
        //        return DEFAULT_SERVER;
        //    }
        //    else
        //    {
        //        return arg1;
        //    }
        //}


        public string Startup()
        {
            // The chat server always starts up on the localhost, using the default port
            IPHostEntry hostInfo = Dns.GetHostByName(DEFAULT_SERVER);
            IPAddress serverAddr = hostInfo.AddressList[0];
            var serverEndPoint = new IPEndPoint(serverAddr, DEFAULT_PORT);
            
            // Create a listener socket and bind it to the endpoint
            serverSocket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
            serverSocket.Bind(serverEndPoint);

            return serverSocket.LocalEndPoint.ToString();
        }


        public string Listen()
        {
            int backlog = 0;
            try
            {
                serverSocket.Listen(backlog);
                return "Server listening";
            }
            catch(Exception ex)
            {
                return "Failed to listen" + ex.ToString();
            }
        }


    }


    class Program
    {
        static OSCoreServer server = new OSCoreServer();

        static void Main(string[] args)
        {
            //string remoteServerName = server.ParseArgs(args);


            string serverInfo = server.Startup();
            Console.WriteLine("Server started at:" + serverInfo);

            serverInfo = server.Listen();
            Console.WriteLine(serverInfo);

            string datatosend = Console.ReadLine();
            server.SendData(datatosend);

            serverInfo = server.ReceiveData();
            Console.WriteLine(serverInfo);

            Console.ReadLine();
            //exit
        }  
    }
}
