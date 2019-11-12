using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using ConcreteLibrary;
using ExceptionsLibrary;
using DataTable = System.Data.DataTable;


namespace ExcelOperations.OleDbWork
{
    public class Operations : BaseExceptionsHandler
    {
        /// <summary>
        /// Creates a new WorkSheet, populates the WorkSheet
        /// with data from a DataTable. What is not covered here
        /// is when a column name has spaces in a name. If that is
        /// the case then those columns need to be wrapped in []
        /// where the simple method would be to wrap each and every
        /// column with brackets rather than trying to single out
        /// column names with spaces.
        /// </summary>
        /// <param name="pFileName">Existing Excel file</param>
        /// <param name="pDataTable">DataTable used to populate a new WorkSheet</param>
        /// <remarks>
        /// The intent here was to make everything very dynamic so that this method can
        /// be used for any file. As stated above this does not handle column names
        /// with spaces or column names that are reserve words for OleDb or Excel
        /// </remarks>
        public void ExportDataTableToExcel(string pFileName, DataTable pDataTable)
        {

            mHasException = false;

            /*
             * Create field names for the create table (worksheet)
             */
            var columnsPartsForCreateSheet = pDataTable.Columns.OfType<DataColumn>()
                .Select(col => $"{col.ColumnName.Replace("Column", "")} CHAR(255)")
                .ToArray();

            /*
             * Turn column name and type into a delimited string for the actual create statement
             * below.
             */
            var columnsForCreateSheet = string.Join(",", columnsPartsForCreateSheet);

            /*
             * Full SQL INSERT statement
             */
            var createStatement = $"CREATE TABLE {pDataTable.TableName} ({columnsForCreateSheet})";

            /*
             * Column names for the INSERT SQL staetment.
             */
            var columnsPartsForInsert = pDataTable.Columns.OfType<DataColumn>()
                .Select(col => col.ColumnName.Replace("Column",""))
                .ToArray();

            /*
             * Create named parameters for the insert statement. Note that OleDb
             * does not 'use' named parameters so we could had used a question mark
             * for each parameter name as OleDb parameters are done in ordinal position
             * which the parameters are anyways. The idea is for developers to get
             * use to named parameters as when moving to SQL-Server named parameters
             * allow parameters to be set out of order
             */
            var paramsForInsert = pDataTable.Columns.OfType<DataColumn>()
                .Select(col => "@" + col.ColumnName.Replace("Column",""))
                .ToArray();

            /*
             * Insert statement for populating rows in the WorkSheet.
             */
            var insertStatement =
                $"INSERT INTO {pDataTable.TableName} ({string.Join(",", columnsPartsForInsert)}) VALUES ({string.Join(",", paramsForInsert)})";

            try
            {
                var con = new SmartConnection();
                /*
                 * IMPORTANT: In the connection string, second parameter must be IMEX = 0 for this to work.
                 */
                using (var cn = new OleDbConnection(con.ConnectionString(pFileName,0, ExcelHeader.Yes)))
                {
                    using (var cmd = new OleDbCommand { Connection = cn })
                    {
                        cmd.CommandText = createStatement;

                        cn.Open();
                        /*
                         * Create the WorkSheet
                         */
                        cmd.ExecuteNonQuery();

                        /*
                         * Change our commandText for the INSERT
                         */
                        cmd.CommandText = insertStatement;

                        /*
                         * Create parameters once rather than creating them for each
                         * iteration of an insert, clearing or re-creating the parameters.
                         */
                        foreach (var pName in paramsForInsert)
                        {
                            cmd.Parameters.Add(pName, OleDbType.VarWChar);
                        }

                        /*
                         * Insert row into the WorkSheet.
                         */
                        for (int rowIndex = 0; rowIndex < pDataTable.Rows.Count ; rowIndex++)
                        {
                            for (int colIndex = 0; colIndex < pDataTable.Columns.Count ; colIndex++)
                            {
                                /*
                                 * Set each parameter's value
                                 */
                                cmd.Parameters[colIndex].Value = pDataTable.Rows[rowIndex].Field<string>(pDataTable.Columns.IndexOf(pDataTable.Columns[colIndex]));
                            }

                            cmd.ExecuteNonQuery();
                        }

                    }
                }
            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }

        }

        /// <summary>
        /// Get WorkSheet names for a specific Excel file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public List<string> SheetNames(string pFileName)
        {
            mHasException = false;
            var names = new List<string>();
            var con = new SmartConnection();

            try
            {
                using (var cn = new OleDbConnection(con.ConnectionString(pFileName)))
                {

                    cn.Open();

                    var dt = cn.GetSchema("Tables", new string[] { null, null, null, "Table" });

                    foreach (DataRow row in dt.Rows)
                    {
                        names.Add(row.Field<string>("Table_Name").Replace("$", ""));
                    }

                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }
           
            return names.Distinct().ToList(); 

        }

        public DataTable ReaDataTable(string pFileName)
        {
            var dt = new DataTable();
            var selectStatement = "SELECT * FROM [Customers$]";
            var con = new SmartConnection();

            try
            {
                using (var cn = new OleDbConnection {ConnectionString = con.ConnectionString(pFileName, 1, ExcelHeader.Yes)})
                {
                    using (var cmd = new OleDbCommand {Connection = cn, CommandText = selectStatement})
                    {
                        cn.Open();
                        dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection) ?? throw new InvalidOperationException());
                    }
                }
            }
            catch (OleDbException oe)
            {
                // isolate specific exception and record to log
            }
            catch (Exception e)
            {
                // record exception to log of some sort
            }

            return dt;
        }

        public (DataTable Table, bool Success) ReaDataTable(string pFileName, string pValue)
        {
            mHasException = false;
            var dt = new DataTable();
            var selectStatement = "SELECT * FROM [Customers$] WHERE ContactTitle = @ContactTitle";
            
            var con = new SmartConnection();

            try
            {
                using (var cn = new OleDbConnection { ConnectionString = con.ConnectionString(pFileName, 1, ExcelHeader.Yes) })
                {
                    using (var cmd = new OleDbCommand { Connection = cn, CommandText = selectStatement })
                    {
                        cmd.Parameters.AddWithValue("ContactName", pValue);
                        cn.Open();
                        dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection) ?? throw new InvalidOperationException());
                    }
                }
            }
            catch (Exception e)
            {
                mHasException = true;
            }

            return (dt, IsSuccessFul);
        }

        /// <summary>
        /// Uses a DataReader to create a List of Customer
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public List<Customer> ReadCustomers(string pFileName)
        {
            mHasException = false;

            var selectStatement = "SELECT CompanyName, ContactName,ContactTitle FROM [Customers$]";

            List<Customer> customers = new List<Customer>();
            var con = new SmartConnection();

            try
            {
                using (var cn = new OleDbConnection { ConnectionString = con.ConnectionString(pFileName,1, ExcelHeader.Yes) })
                {
                    using (var cmd = new OleDbCommand { Connection = cn, CommandText = selectStatement })
                    {
                        cn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader != null && reader.Read())
                        {
                            customers.Add(new Customer()
                            {
                                CompanyName = reader.GetString(0),
                                ContactName = reader.GetString(1),
                                ContactTitle = reader.GetString(2)
                            });
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }

            return customers;
        }
        /// <summary>
        /// This is an exercise in reading data via a data reader where we have 
        /// the following columns, id known to be int, next two columns strings, 
        /// next column int and finally a date. We attempt to read the cells 
        /// using those data types but fail with runtime exceptions on invalid 
        /// data types on conversion but are not told which ones failed yet easy 
        /// to figure it’s the numeric cells. Rather than attempt to try different 
        /// cast we load data into a DataTable and query the column data types via 
        /// console write line. Once we know that we can properly cast the cells.
        /// 
        /// From here we remove the code for the DataTable and are good to go.
        /// 
        /// CAVEAT
        /// The sheet read has data for the first row, not column names. When
        /// this is done each column begins with "F" followed by a numeric. So
        /// Column 1 is F1, Column 2 is F3 etc. If we wanted to use a DataTable
        /// to display the data that is not appealing so as shown below we can
        /// alias the Fn names.
        /// 
        /// 
        /// 
        /// var ops = new OledbCode.Operations();
        /// var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PeopleNoHeader.xlsx");
        /// var sheetName = "People";
        /// ops.ReadPeopleNoHeaderRow(fileName,sheetName);
        /// 
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pSheetName"></param>
        public void ReadPeopleNoHeaderRow(string pFileName, string pSheetName) 
        {
            mHasException = false;

            List<Person> peopleList = new List<Person>();
            var con = new SmartConnection();
            var dt = new DataTable();
            try
            {
                using (var cn = new OleDbConnection { ConnectionString = con.ConnectionString(pFileName, 1, ExcelHeader.No) })
                {
                    var selectStatement = "SELECT F1 AS Identifer, F2 AS FirstName, F3 As LastName, " + 
                                                    "F4 AS Gender, F5 As BirthDate " +
                                            $"FROM [{pSheetName}$]";

                    using (var cmd = new OleDbCommand { Connection = cn, CommandText = selectStatement })
                    {
                        cn.Open();
                        
                        var reader = cmd.ExecuteReader();
                        dt.Load(reader);
                        reader.Close();

                        reader = cmd.ExecuteReader();

                        while (reader != null && reader.Read())
                        {
                            peopleList.Add(new Person()
                            {

                                Id = Convert.ToInt32(reader.GetDouble(0)),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Gender = Convert.ToInt32(reader.GetDouble(3)),
                                BirthDay = Convert.ToDateTime(reader.GetString(4))
                            });
                        }

                        if (reader != null) reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }


            foreach (DataColumn col in dt.Columns)
            {
                Console.WriteLine(col.DataType.ToString());
            }

        }
        /// <summary>
        /// Simple example for importing a comma delimited text file
        /// </summary>
        /// <param name="pExcelFileName">Existing Excel file to import into</param>
        /// <param name="pTextFile">Source comma delimited text file</param>
        /// <param name="pSheetName">Worksheet to create and import text into</param>
        /// <returns></returns>
        /// <remarks>
        /// The database in this case is the directory
        /// </remarks>
        public bool ImportFromTextFile(string pExcelFileName, string pTextFile, string pSheetName)
        {
            mHasException = false;
            var result = true;

            var con = new SmartConnection();
            using (var cn = new OleDbConnection()
            {
                ConnectionString = con.ConnectionStringExporter(pExcelFileName, 0)
            })

            {
                var fileName = Path.GetFileName(pTextFile);

                var sql = $"SELECT * INTO [{pSheetName}] FROM [Text;" +
                          $"DATABASE={Path.Combine(AppDomain.CurrentDomain.BaseDirectory)}].[{fileName}]";

                using (var cmd = new OleDbCommand(sql, cn))
                {
                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        mHasException = true;
                        mLastException = ex;
                        result = false;
                    }

                }
            }

            return result;
        }
    }
}
