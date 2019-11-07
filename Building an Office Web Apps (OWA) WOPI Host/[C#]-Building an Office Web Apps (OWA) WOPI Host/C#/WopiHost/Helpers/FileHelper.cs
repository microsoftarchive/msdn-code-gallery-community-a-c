using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Hosting;

namespace MainWeb.Helpers
{

    public interface IFileHelper
    {
        CheckFileInfo GetFileInfo(string name);
    }

    public class FileHelper : IFileHelper
    {
        public CheckFileInfo GetFileInfo(string name)
        {
            var fileName = GetFileName(name);
            FileInfo info = new FileInfo(fileName);
            string sha256 = "";

            using (FileStream stream = File.OpenRead(fileName))
            using (var sha = SHA256.Create())
            {
                byte[] checksum = sha.ComputeHash(stream);
                sha256 = Convert.ToBase64String(checksum);
            }

            var rv = new CheckFileInfo
            {
                BaseFileName = info.Name,
                OwnerId = "admin",
                Size = info.Length,
                SHA256 = sha256,
                Version = info.LastWriteTimeUtc.ToString("s")
            };

            return rv;
        }


        internal string GetFileName(string name)
        {
            var file = HostingEnvironment.MapPath("~/App_Data/" + name);
            return file;
        }
    }
}