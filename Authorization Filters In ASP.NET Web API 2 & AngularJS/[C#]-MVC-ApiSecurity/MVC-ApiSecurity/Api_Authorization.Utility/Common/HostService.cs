using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Api_Authorization.Utility.Common
{
    public class HostService
    {
        public static string GetIP()
        {
            IPHostEntry host;
            string localIp = "?";
            string hostName = Dns.GetHostName();
            host = Dns.GetHostEntry(hostName);
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIp = ip.ToString();
                }
            }
            return localIp;
        }
    }
}
