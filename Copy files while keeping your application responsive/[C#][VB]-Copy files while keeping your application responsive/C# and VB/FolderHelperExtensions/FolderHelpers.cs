using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
    /// <summary>
    /// System folder extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Returns the project folder name
        /// </summary>
        /// <returns>Current project folder path</returns>
        /// <example>
        /// <code source="CodeExamples\FolderDemos.vb" language="vbnet" title="VB.NET Examples"/>
        /// </example>
        public static string GetProjectBaseFolder()
        {
            List<string> Folders = UpperFolderList(AppDomain.CurrentDomain.BaseDirectory, true);
            var Result = (
                from @this in Folders.Select((item, index) => new { Name = item, Index = index })
                where @this.Name.ToLower().EndsWith("bin")
                select @this).FirstOrDefault();

            return Folders[Result.Index - 1];
        }

        /// <summary>
        /// Given a folder name return all parents according to level
        /// </summary>
        /// <param name="FolderName">Sub-folder name</param>
        /// <param name="level">Level to move up the folder chain</param>
        /// <returns>A physical folder path</returns>
        /// <example>
        /// <code source="CodeExamples\FolderDemos.vb" language="vbnet" title="VB.NET Examples"/>
        /// </example>
        public static string UpperFolder(string FolderName, decimal level)
        {
            return UpperFolder(FolderName, Convert.ToInt32(level));
        }

        /// <summary>
        /// Given a folder name return all parents according to level
        /// </summary>
        /// <param name="FolderName">Sub-folder name</param>
        /// <param name="level">Level to move up the folder chain</param>
        /// <returns>List of folders dependent on level parameter</returns>
        /// <example>
        /// <code source="CodeExamples\FolderDemos.vb" language="vbnet" title="VB.NET Examples"/>
        /// </example>
        public static string UpperFolder(string FolderName, Int32 level)
        {
            List<string> TheList = new List<string>();

            while (!string.IsNullOrEmpty(FolderName))
            {
                var temp = Directory.GetParent(FolderName);
                if (temp == null)
                {
                    break;
                }
                FolderName = Directory.GetParent(FolderName).FullName;
                TheList.Add(FolderName);
            }

            if (TheList.Count > 0 && level > 0)
            {
                if (level - 1 <= TheList.Count - 1)
                {
                    return TheList[level - 1];
                }
                else
                {
                    return FolderName;
                }
            }
            else
            {
                return FolderName;
            }
        }
        /// <summary>
        /// Get a list of all folders above 'FolderName'
        /// </summary>
        /// <param name="FolderName">Folder to start at</param>
        /// <param name="Sort">True/False</param>
        /// <returns>List of folder names</returns>
        /// <example>
        /// <code source="CodeExamples\FolderDemos.vb" language="vbnet" title="VB.NET Examples"/>
        /// </example>
        public static List<string> UpperFolderList(string FolderName, bool Sort)
        {
            List<string> TheList = new List<string>();

            while (!string.IsNullOrEmpty(FolderName))
            {
                var temp = Directory.GetParent(FolderName);
                if (temp == null)
                {
                    break;
                }
                FolderName = Directory.GetParent(FolderName).FullName;
                TheList.Add(FolderName);
            }

            if (Sort)
            {
                TheList.Sort();
            }

            return TheList;
        }
    }

