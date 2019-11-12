using CodeGen.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Web.Utility
{
    public class ViewGenerator
    {
        public static dynamic GenerateForm(List<vmColumn> tblColumns, string contentRootPath)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            StringBuilder builderPrm = new StringBuilder();
            StringBuilder builderSub = new StringBuilder();
            builderPrm.Clear(); builderSub.Clear();
            string fileContent = string.Empty; string queryPrm = string.Empty; string submitPrm = string.Empty;

            string tableName = tblColumns[0].Tablename; string tableSchema = tblColumns[0].TableSchema;
            string path = @"" + contentRootPath + "\\template\\HtmlForm\\Form.txt";

            //Form Name
            string frmName = "name='frm" + tableName.ToString() + "' novalidate";

            //Form Fields
            foreach (var item in tblColumns)
            {
                //parameter
                builderPrm.AppendLine();
                builderPrm.Append(" <div class='form-group'>");
                builderPrm.AppendLine();
                if (item.ColumnName.Contains("email") || item.ColumnName.Contains("Email"))
                {
                    builderPrm.Append("  <label for='" + item.ColumnName + "' class='control-label'>" + textInfo.ToTitleCase(Conversion.RemoveSpecialCharacters(item.ColumnName)) + "</label>");
                    builderPrm.AppendLine();
                    builderPrm.Append("  <input type='email' class='form-control' ng-model='vmfrm." + item.ColumnName + "' name='" + item.ColumnName + "' required />");
                }
                else if (item.ColumnName.Contains("password") || item.ColumnName.Contains("Password"))
                {
                    builderPrm.Append("  <label for='" + item.ColumnName + "' class='control-label'>" + textInfo.ToTitleCase(Conversion.RemoveSpecialCharacters(item.ColumnName)) + "</label>");
                    builderPrm.AppendLine();
                    builderPrm.Append("  <input type='password' class='form-control' ng-model='vmfrm." + item.ColumnName + "' name='" + item.ColumnName + "' required />");
                }
                else
                {
                    builderPrm.Append("  <label for='" + item.ColumnName + "' class='control-label'>" + textInfo.ToTitleCase(Conversion.RemoveSpecialCharacters(item.ColumnName)) + "</label>");
                    builderPrm.AppendLine();
                    builderPrm.Append("  <input type='text' class='form-control' ng-model='vmfrm." + item.ColumnName + "' name='" + item.ColumnName + "' required />");
                }
                builderPrm.AppendLine();
                builderPrm.Append(" </div>");
            }
            queryPrm = builderPrm.AppendLine().ToString();

            //Form Submit
            builderSub.Append(" <div class='form-group'>");
            builderSub.AppendLine();
            builderSub.Append("  <input type='submit' name='reset' value='Reset' ng-click='Reset()' />");
            builderSub.AppendLine();
            builderSub.Append("  <input type='submit' name='update' value='Update' ng-click='Update()' />");
            builderSub.AppendLine();
            builderSub.Append("  <input type='submit' name='submit' value='Save' ng-click='Save()' />");
            builderSub.AppendLine();
            builderSub.Append(" </div>");

            submitPrm = builderSub.AppendLine().ToString();

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                fileContent = sr.ReadToEnd().Replace("#frmName", frmName.ToString()).Replace("#frmGroup", queryPrm.ToString()).Replace("#frmSubmit", submitPrm.ToString());
            }

            return fileContent.ToString();
        }
    }
}
