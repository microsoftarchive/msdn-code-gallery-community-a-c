using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.UI;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace CSV2Json
{
    /// <summary>
    /// Summary description for CSV2JSON
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class CSV2JSON : System.Web.Services.WebService
    {

        static int[] colIndex;
        static int[] rowIndex;
        StringBuilder sb = new StringBuilder();
        [WebMethod]
        public  string csvtojson()
        {
            try
            {
                List<int> indx = new List<int>();
                string[] cols;
                string[] rows;
                List<string> tempCol = new List<string>();
                List<int> tempRow = new List<int>();
                DataTable table = new DataTable();
                string path = Server.MapPath("~/App_LocalResources/religions.csv");
                StreamWriter sw = new StreamWriter(Server.MapPath("~/App_LocalResources/religions.json"));
                if (File.Exists(path))
                {
                    StreamReader sr = new StreamReader(path);
                    string line = sr.ReadLine();

                    line = line.Replace("\"", "").Trim();
                    cols = Regex.Split(line, ",");
                    string[] Column = { "year", "cat", "pop" };

                    for (int j = 0; j < cols.Length; j++)
                    {
                        switch (cols[j])
                        {
                            case "year":
                                tempCol.Add(cols[j]);
                                indx.Add(j);
                                break;
                            case "cat":
                                tempCol.Add(cols[j]);
                                indx.Add(j);
                                break;
                            case "pop":
                                tempCol.Add(cols[j]);
                                indx.Add(j);
                                break;

                        }
                        //  colIndex = indx.ToArray();
                    }

                    for (int i = 0; i < Column.Count(); i++)
                    {
                        for (int j = 0; j < tempCol.Count; j++)
                        {
                            if (Column[i] == tempCol[j])
                            {
                                table.Columns.Add(Column[i], typeof(string));
                                tempRow.Add(j);
                            }
                        }
                    }
                    colIndex = indx.ToArray();
                    rowIndex = tempRow.ToArray();
                   
                    string[] columnNames = table.Columns.Cast<DataColumn>().
                                                      Select(column => column.ColumnName).
                                                      ToArray();
                    sb.AppendLine(string.Join(",", columnNames));
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Replace("\"", "").Trim();

                        table.Rows.Clear();

                        int i;
                        string row = string.Empty;
                        rows = Regex.Split(line, ",");
                        DataRow dr = table.NewRow();
                        DataRow tempDr = table.NewRow();
                        for (i = 0; i < colIndex.Length; i++)
                        {
                            tempDr[i] = rows[colIndex[i]];
                            if (i == colIndex.Length)
                                break;
                        }

                        for (int k = 0; k < rowIndex.Length; k++)
                        {
                            dr[k] = tempDr[rowIndex[k]];
                        }

                        table.Rows.Add(dr);

                        foreach (DataRow rws in table.Rows)
                        {
                            string[] fields = rws.ItemArray.Select(field => field.ToString()).
                                                            ToArray();
                            sb.AppendLine(string.Join(",", fields));
                        }

                        File.WriteAllText(Server.MapPath("~/App_LocalResources/my.csv"), sb.ToString());
                        string json = JsonConvert.SerializeObject(table, Formatting.Indented);
                        sw.Write(json);
                    }
                    sr.Close();
                    sw.Close();
                }
                else
                {
                    MessageBox.Show("File Not Found.");
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
