using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using IMail;
using System.IO;
using System.Threading;

namespace MailClient
{
    class Program
    {
        public static Object lockObj;
        public static string mensagens;
        public static ISend remoteObject;

        static void Main(string[] args)
        {
            lockObj = new object();
            ArquiteturaBaseadaEmObjetos();
            
        }


        private static void ArquiteturaBaseadaEmObjetos()
        {
            string message = "Entrei na conversa";
            int id;
            TcpChannel tcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(tcpChannel, false);

            Type requiredType = typeof(ISend);

            remoteObject = (ISend)Activator.GetObject(requiredType,
            "tcp://localhost:9998/MailServer");

            id = remoteObject.Register();

            new Thread(refreshMessages).Start();

            while (true)
            {
                lock (lockObj)
                {
                    mensagens = remoteObject.SendMessage(id, message);
                    Console.WriteLine(mensagens);
                }

                message = System.Console.ReadLine();
                Console.Clear();
            }
        }

        static void refreshMessages()
        {
            while (true)
            {
                lock (lockObj)
                {
                    if (!mensagens.Equals(remoteObject.getMessages()))
                    {
                        mensagens = remoteObject.getMessages();
                        Console.Clear();
                        Console.WriteLine(mensagens);
                    }
                }
                Thread.Sleep(500);
            }
        }
    }
}
