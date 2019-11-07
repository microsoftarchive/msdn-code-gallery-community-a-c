using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GroupDocsViewerWebFormsSample
{
    public static class FileRepository
    {
        public static String RootStorage
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + @"App_Data\";
            }
        }

        public static String[] GetAllDocuments()
        {
            String[] all_files = Directory.GetFiles(RootStorage);
            String[] output = all_files.Select(Path.GetFileName).Where(one_file => one_file != "vs.bin").ToArray();
            return output;
        }

        public static Boolean IsPresent(String Filename)
        {
            return GetAllDocuments().Contains(Filename);
        }
    }
}