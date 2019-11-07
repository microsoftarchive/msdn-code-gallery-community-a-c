using System;
using System.IO;
using System.Text;

namespace NtierMvc.Common
{
    /// <summary>
    /// Purpose: Cross-cutting helper component for for creating and handling files and folders.
    /// </summary>
    public static class FileHandler
    {
        public static void WriteFile(string folderPath, string fileName, string fileText)
        {
            WriteFile(folderPath, fileName, fileText, false);
        }

        public static void WriteFile(string folderPath, string fileName, string fileText, bool bOverwrite)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                //use current path
                throw new ArgumentNullException("strFolderPath" + " The FolderPath cannot be null or empty. ");
            }
            if (string.IsNullOrEmpty(fileName))
            {
                //use current path
                throw new ArgumentNullException("strFileName" + " The FileName cannot be null or empty. ");
            }
            if (string.IsNullOrEmpty(fileText))
            {
                //use current path
                throw new ArgumentNullException("strFileText" + " The FileText cannot be null or empty. ");
            }

            // Check Folder, if doesn't exist then create it
            CreateFolder(folderPath);

            //make sure filename not like @"..\System\MyFile.txt" i.e. get pure file name
            fileName = Path.GetFileName(fileName);

            // instead of using Path.DirectorySeparatorChar
            string filePathAndName = Path.Combine(folderPath, fileName);

            if (File.Exists(filePathAndName))
            {
                if (bOverwrite)
                {
                    File.Delete(filePathAndName);
                }
                else
                {
                    return;
                }
            }

            using (var fs = new FileStream(filePathAndName, FileMode.Create))
            {
                using (var sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.Write(fileText);
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        public static string CreateFolder(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                //use current path
                throw new ArgumentNullException("strFolderPath" + " The FolderPath cannot be null or empty. ");
            }

            //If directory exists, the delete it with all of its sub-folders
            if (!Directory.Exists(folderPath))
            {
                //Directory.Delete(strFolderPath, true);
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }

        public static string CreateFolder(string parentFolderPath, string folderName)
        {
            if (string.IsNullOrEmpty(parentFolderPath))
            {
                //use current path
                throw new ArgumentNullException("parentFolderPath" + " The Parent Folder Path cannot be null or empty. ");
            }
            if (string.IsNullOrEmpty(folderName))
            {
                //use current path
                throw new ArgumentNullException("folderName" + " The Folder Name cannot be null or empty. ");
            }

            folderName = Path.GetDirectoryName(folderName);

            if (folderName != null)
            {
                string strFolderPath = Path.Combine(parentFolderPath, folderName);
                if (!Directory.Exists(strFolderPath))
                {
                    Directory.CreateDirectory(strFolderPath);
                }

                return strFolderPath;
            }

            return string.Empty;
        }
    }
}
