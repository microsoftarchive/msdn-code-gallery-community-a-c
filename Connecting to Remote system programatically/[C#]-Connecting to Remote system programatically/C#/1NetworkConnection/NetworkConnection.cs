using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace _1NetworkConnection
{
    public class NetworkConnection : IDisposable
    {
        string _networkName;

        const int CONNECT_UPDATE_PROFILE = 0x1;
        const int CONNECT_INTERACTIVE = 0x8;
        const int CONNECT_PROMPT = 0x10;
        const int CONNECT_REDIRECT = 0x80;
        const int CONNECT_COMMANDLINE = 0x800;
        const int CONNECT_CMD_SAVECRED = 0x1000;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int GetLastError();

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(NetResource netResource,
            string password, string username, int flags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string name, int flags,
            bool force);

        public NetworkConnection()
        {
        }

        public NetworkConnection(string localName, string networkName,
            NetworkCredential credentials)
        {
            _networkName = networkName;

            var netResource = new NetResource()
            {
                Scope = ResourceScope.GlobalNetwork,
                ResourceType = ResourceType.Disk,
                LocalName = localName,
                DisplayType = ResourceDisplaytype.Share,
                RemoteName = networkName
            };

            int flags = CONNECT_UPDATE_PROFILE;

            var result = WNetAddConnection2(
                netResource,
                credentials.Password,
                credentials.UserName,
                flags);

           
            if (result != 0)
            {                
                Win32Exception winex = new Win32Exception(result);
                throw new IOException("Error connecting to remote share",
                    winex);
            }
        }

        ~NetworkConnection()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            //WNetCancelConnection2(_networkName, 0, true);
        }

        
    }

    [StructLayout(LayoutKind.Sequential)]
    public class NetResource
    {
        public ResourceScope Scope;
        public ResourceType ResourceType;
        public ResourceDisplaytype DisplayType;
        public int Usage;
        public string LocalName;
        public string RemoteName;
        public string Comment;
        public string Provider;
    }

    public enum ResourceScope : int
    {
        Connected = 1,
        GlobalNetwork,
        Remembered,
        Recent,
        Context
    };

    public enum ResourceType : int
    {
        Any = 0,
        Disk = 1,
        Print = 2,
        Reserved = 8,
    }

    public enum ResourceDisplaytype : int
    {
        Generic = 0x0,
        Domain = 0x01,
        Server = 0x02,
        Share = 0x03,
        File = 0x04,
        Group = 0x05,
        Network = 0x06,
        Root = 0x07,
        Shareadmin = 0x08,
        Directory = 0x09,
        Tree = 0x0a,
        Ndscontainer = 0x0b
    }

}
