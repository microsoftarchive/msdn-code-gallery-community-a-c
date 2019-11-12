using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class CheckFileInfo
    {
        public CheckFileInfo()
        {
            this.SupportsUpdate = false;
            this.UserCanWrite = false;
        }

        public string BaseFileName { get; set; }
        public string OwnerId { get; set; }
        public long Size { get; set; } //in bytes
        public string SHA256 { get; set; } //SHA256: A 256 bit SHA-2-encoded [FIPS180-2] hash of the file contents
        ////http://msdn.microsoft.com/en-us/library/system.security.cryptography.sha256managed.aspx
        public string Version { get; set; }  //changes when file changes.
        public bool SupportsUpdate { get; set;  }
        public bool UserCanWrite { get; set;  }

        public bool SupportsLocks { get; set;  }
    }
}