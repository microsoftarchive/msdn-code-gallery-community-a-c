using CodeGen.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Web.Utility
{
    public class VmGenerator
    {
        public static dynamic GenerateVm(List<vmColumn> tblColumns, string contentRootPath)
        {
            StringBuilder builderPrm = new StringBuilder();
            StringBuilder builderBody = new StringBuilder();
            builderPrm.Clear(); builderBody.Clear();
            string fileContent = string.Empty; string queryPrm = string.Empty;

            string tableName = tblColumns[0].Tablename; string tableSchema = tblColumns[0].TableSchema;
            string path = @"" + contentRootPath + "\\template\\ViewModel\\vmModel.txt";
            string className = "vm" + tableName.ToString();
            foreach (var item in tblColumns)
            {
                //parameter
                builderPrm.AppendLine();
                builderPrm.Append("  public " + TypeMap.GetClrType(item.DataType) + " " + item.ColumnName + " { get; set; }");
            }

            queryPrm = builderPrm.AppendLine().ToString();

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                fileContent = sr.ReadToEnd().Replace("#ClassName", className.ToString()).Replace("#Properties", queryPrm.ToString());
            }

            return fileContent.ToString();
        }
    }
}
