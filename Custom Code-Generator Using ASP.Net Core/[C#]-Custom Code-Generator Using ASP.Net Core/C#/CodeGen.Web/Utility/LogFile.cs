using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGen.Web.Utility
{
    public class LogFile
    {
        private static IHostingEnvironment _hostingEnvironment;
        private const string FILE_NAME = "LogTextFile.txt";

        //public static string backupDir = HostingEnvironment.MapPath("~/DatabaseBackup/");
        public LogFile()
        {
        }

        public LogFile(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public static string ConfigFilePath
        {
            get { return _hostingEnvironment.ContentRootPath + FILE_NAME; }
        }

        //string path = @"" + contentRootPath + "\\Models\\Template\\StoredProcedure\\InsertSP.txt";

        public static void WriteLogFile(string fileName, string methodName, string message)
        {
            FileStream fs = null;
            if (!File.Exists(ConfigFilePath))
            {
                using (fs = File.Create(ConfigFilePath))
                {
                }
            }

            try
            {
                if (!string.IsNullOrEmpty(message))
                {
                    StreamWriter streamWriter = new StreamWriter(ConfigFilePath, true);
                    streamWriter.WriteLine((((System.DateTime.Now + " ~ ") + fileName + " ~ ") + methodName + " ~ ") + message + "\r");
                    streamWriter.Close();
                }
            }
            catch
            {

            }
        }
        public static void WriteLogFile(string message)
        {
            FileStream fs = null;
            if (!File.Exists(ConfigFilePath))
            {
                using (fs = File.Create(ConfigFilePath))
                {
                }
            }

            try
            {
                if (!string.IsNullOrEmpty(message))
                {
                    StreamWriter streamWriter = new StreamWriter(ConfigFilePath, true);
                    streamWriter.WriteLine((DateTime.Now + " - ") + message + ",");
                    streamWriter.Close();
                }
            }
            catch
            {

            }
        }
    }
}
