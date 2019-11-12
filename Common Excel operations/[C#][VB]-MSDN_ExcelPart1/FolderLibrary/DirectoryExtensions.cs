using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FolderLibrary
{
    public static class DirectoryExtensions
    {
        public static string UpperFolder(this string pFolderName, decimal pLevel)
        {
            return UpperFolder(pFolderName, Convert.ToInt32(pLevel));
        }
        public static string UpperFolder(this string pFolderName, Int32 pLevel)
        {
            List<string> theList = new List<string>();

            while (!string.IsNullOrEmpty(pFolderName))
            {

                var temp = Directory.GetParent(pFolderName);

                if (temp == null)
                {
                    break;
                }

                pFolderName = Directory.GetParent(pFolderName).FullName;
                theList.Add(pFolderName);

            }

            if (theList.Count > 0 && pLevel > 0)
            {
                if (pLevel - 1 <= theList.Count - 1)
                {
                    return theList[pLevel - 1];
                }
                else
                {
                    return pFolderName;
                }
            }
            else
            {
                return pFolderName;
            }
        }
        public static string CurrentProjectFolder(this string pFolderName)
        {
            return pFolderName.UpperFolder(3);
        }
        public static string GetProjectBaseFolder(this string sender)
        {
            List<string> folders = UpperFolderList(AppDomain.CurrentDomain.BaseDirectory, true);

            var result = (from @this in folders.Select((item, index) =>
                new { Name = item, Index = index })
                          where @this.Name.ToLower().EndsWith("bin")
                          select @this).FirstOrDefault();

            return folders[result.Index - 1];
        }
        public static List<string> UpperFolderList(this string pFolderName, bool pSort)
        {
            List<string> theList = new List<string>();

            while (!string.IsNullOrEmpty(pFolderName))
            {
                var temp = Directory.GetParent(pFolderName);
                if (temp == null)
                {
                    break;
                }

                pFolderName = Directory.GetParent(pFolderName).FullName;
                theList.Add(pFolderName);

            }

            if (pSort)
            {
                theList.Sort();
            }

            return theList;
        }

    }
}
