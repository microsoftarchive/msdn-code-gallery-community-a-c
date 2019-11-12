using System;
using System.IO;
using System.Linq;
using ExceptionsLibrary;

namespace FolderLibrary
{
    public class CleanCopyOperations : BaseExceptionsHandler
    {
        public void CopyExcelFiles()
        {
            mHasException = false;
            string[] fileNames = new String[]
            {
                "Customers.xlsx",
                "Blank.xlsx",
                "Demo.xlsx",
                "People.xlsx",
                "PeopleNoHeader.xlsx",
                "PeopleOleDbImport.xlsx",
                "ImportFromTextFile.xlsx"
            };

            var currentPath = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                foreach (var file in fileNames)
                {
                    File.Copy(Path.Combine(currentPath.UpperFolder(4), "ExcelFiles", file), 
                        Path.Combine(currentPath, file));
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }
        }

        public void RemoveExcelFiles()
        {
            mHasException = false;

            try
            {
                Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xlsx")
                    .ToList().ForEach(File.Delete);
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }
        }

        public void RemoveOtherExcelFiles(string[] pFileNames)
        {

            mHasException = false;
            var fullPath = "";

            try
            {
                foreach (var file in pFileNames)
                {
                    fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }
        }
    }
}
