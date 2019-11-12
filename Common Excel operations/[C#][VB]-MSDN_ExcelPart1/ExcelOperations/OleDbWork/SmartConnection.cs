using System.Data.OleDb;

namespace ExcelOperations.OleDbWork
{
    public enum ExcelHeader
    {
        Yes,
        No
    }

    public class SmartConnection
    {
        public string ConnectionString(string pFileName, int pImex = 1, ExcelHeader pHeader = ExcelHeader.No)
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
            if (System.IO.Path.GetExtension(pFileName)?.ToUpper() == ".XLS")
            {
                builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                builder.Add("Extended Properties", $"Excel 8.0;IMEX={pImex};HDR={pHeader.ToString()};");
            }
            else
            {
                builder.Provider = "Microsoft.ACE.OLEDB.12.0";
                builder.Add("Extended Properties", $"Excel 12.0;IMEX={pImex};HDR={pHeader.ToString()};");
            }

            builder.DataSource = pFileName;

            return builder.ConnectionString;
        }

        public string ConnectionStringExporter(string pFileName, int pImex = 1, ExcelHeader pHeader = ExcelHeader.No)
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
            builder.Provider = "Microsoft.ACE.OLEDB.12.0";
            builder.Add("Extended Properties", $"Excel 12.0 Xml;IMEX={pImex};HDR={pHeader.ToString()};");

            builder.DataSource = pFileName;

            return builder.ConnectionString;
        }

    }
}
