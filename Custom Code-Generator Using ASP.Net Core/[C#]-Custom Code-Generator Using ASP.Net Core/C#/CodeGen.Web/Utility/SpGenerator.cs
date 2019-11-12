using Microsoft.AspNetCore.Hosting;
using CodeGen.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Web.Utility
{
    public class SpGenerator
    {
        //CREATE
        public static dynamic GenerateSetSP(List<vmColumn> tblColumns, string contentRootPath)
        {
            StringBuilder builderPrm = new StringBuilder();
            StringBuilder builderBody = new StringBuilder();
            builderPrm.Clear(); builderBody.Clear();

            string path = @"" + contentRootPath + "\\template\\StoredProcedure\\InsertSP.txt";
            string fileContent = string.Empty; string fileld = string.Empty; string fileldPrm = string.Empty; string queryPrm = string.Empty;
            string tableName = tblColumns[0].Tablename; string tableSchema = tblColumns[0].TableSchema;

            string spName = ("[" + tableSchema + "].[Set_" + tableName + "]").ToString();
            foreach (var item in tblColumns)
            {
                fileld = fileld + item.ColumnName + ",";
                fileldPrm = fileldPrm + "@" + item.ColumnName + ",";

                //parameter
                builderPrm.AppendLine();
                if ((item.DataType.ToString() == "nvarchar") || (item.DataType.ToString() == "varchar"))
                    builderPrm.Append("  @" + item.ColumnName + " " + item.DataType + "(" + item.MaxLength + "),");
                else
                    builderPrm.Append("  @" + item.ColumnName + " " + item.DataType + ",");
            }

            queryPrm = builderPrm.Remove((builderPrm.Length - 1), 1).AppendLine().ToString();
            //queryPrm = builderPrm.ToString().TrimEnd(',');

            //Body
            builderBody.Append("INSERT INTO [" + tableSchema + "].[" + tableName + "](");
            builderBody.Append(fileld.TrimEnd(',') + ") ");
            //builderBody.AppendLine();
            builderBody.Append("VALUES (" + fileldPrm.TrimEnd(',') + ")");

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                fileContent = sr.ReadToEnd().Replace("#Name", spName.ToString()).Replace("#Param", queryPrm.ToString()).Replace("#Body", builderBody.ToString());
            }

            return fileContent.ToString();
        }

        //READ
        public static dynamic GenerateGetSP(List<vmColumn> tblColumns, string contentRootPath)
        {
            StringBuilder builderPrm = new StringBuilder();
            StringBuilder builderBody = new StringBuilder();
            builderPrm.Clear(); builderBody.Clear();

            string path = @"" + contentRootPath + "\\template\\StoredProcedure\\ReadSP.txt";
            string fileContent = string.Empty; string fileld = string.Empty; string fileldPrm = string.Empty; string queryPrm = string.Empty;
            string tableName = tblColumns[0].Tablename; string tableSchema = tblColumns[0].TableSchema;

            string spName = ("[" + tableSchema + "].[Get_" + tableName + "]").ToString();
            foreach (var item in tblColumns)
            {
                fileld = fileld + item.ColumnName + ",";
                fileldPrm = fileldPrm + "@" + item.ColumnName + ",";
            }


            //Body
            builderBody.Append("SELECT " + fileldPrm.TrimEnd(',') + " FROM [" + tableSchema + "].[" + tableName + "]");

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                fileContent = sr.ReadToEnd().Replace("#Name", spName.ToString()).Replace("#Body", builderBody.ToString()).Replace("#OrdPrm", fileldPrm.TrimEnd(',').ToString());
            }

            return fileContent.ToString();
        }

        //UPDATE
        public static dynamic GeneratePutSP(List<vmColumn> tblColumns, string contentRootPath)
        {
            StringBuilder builderPrm = new StringBuilder();
            StringBuilder builderBody = new StringBuilder();
            builderPrm.Clear(); builderBody.Clear();

            string path = @"" + contentRootPath + "\\template\\StoredProcedure\\UpdateSP.txt";
            string fileContent = string.Empty; string fileld = string.Empty; string fileldPrm = string.Empty; string queryPrm = string.Empty;
            string tableName = tblColumns[0].Tablename; string tableSchema = tblColumns[0].TableSchema;

            string spName = ("[" + tableSchema + "].[Get_" + tableName + "]").ToString();
            foreach (var item in tblColumns)
            {
                fileld = fileld + item.ColumnName + ",";
                fileldPrm = fileldPrm + item.ColumnName + " = @" + item.ColumnName + ",";

                //parameter
                builderPrm.AppendLine();
                if ((item.DataType.ToString() == "nvarchar") || (item.DataType.ToString() == "varchar"))
                    builderPrm.Append("  @" + item.ColumnName + " " + item.DataType + "(" + item.MaxLength + "),");
                else
                    builderPrm.Append("  @" + item.ColumnName + " " + item.DataType + ",");
            }

            queryPrm = builderPrm.Remove((builderPrm.Length - 1), 1).AppendLine().ToString();

            //Body
            builderBody.Append("UPDATE [" + tableSchema + "].[" + tableName + "] SET " + fileldPrm.TrimEnd(',') + " WHERE [CONDITIONS]");

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                fileContent = sr.ReadToEnd().Replace("#Name", spName.ToString()).Replace("#Param", queryPrm.ToString()).Replace("#Body", builderBody.ToString()).Replace("#OrdPrm", fileldPrm.ToString());
            }

            return fileContent.ToString();
        }

        //DELETE
        public static dynamic GenerateDeleteSP(List<vmColumn> tblColumns, string contentRootPath)
        {
            StringBuilder builderPrm = new StringBuilder();
            StringBuilder builderBody = new StringBuilder();
            builderPrm.Clear(); builderBody.Clear();

            string path = @"" + contentRootPath + "\\template\\StoredProcedure\\DeleteSP.txt";
            string fileContent = string.Empty; string fileld = string.Empty; string fileldPrm = string.Empty; string queryPrm = string.Empty;
            string tableName = tblColumns[0].Tablename; string tableSchema = tblColumns[0].TableSchema;

            string spName = ("[" + tableSchema + "].[Delete_" + tableName + "]").ToString();
            foreach (var item in tblColumns)
            {
                fileld = fileld + item.ColumnName + ",";
                fileldPrm = fileldPrm + "@" + item.ColumnName + ",";

                //parameter
                builderPrm.AppendLine();
                if ((item.DataType.ToString() == "nvarchar") || (item.DataType.ToString() == "varchar"))
                    builderPrm.Append("  @" + item.ColumnName + " " + item.DataType + "(" + item.MaxLength + "),");
                else
                    builderPrm.Append("  @" + item.ColumnName + " " + item.DataType + ",");
            }

            queryPrm = builderPrm.Remove((builderPrm.Length - 1), 1).AppendLine().ToString();

            //Body
            builderBody.Append("DELETE FROM [" + tableSchema + "].[" + tableName + "] WHERE [CONDITIONS]");

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                fileContent = sr.ReadToEnd().Replace("#Name", spName.ToString()).Replace("#Param", queryPrm.ToString()).Replace("#Body", builderBody.ToString()).Replace("#OrdPrm", fileldPrm.ToString());
            }

            return fileContent.ToString();
        }
    }
}
