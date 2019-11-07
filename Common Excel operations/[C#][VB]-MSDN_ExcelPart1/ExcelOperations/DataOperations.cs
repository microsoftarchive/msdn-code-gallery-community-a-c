using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ConcreteLibrary;

namespace ExcelOperations
{
    public class DataOperations : BaseSqlServerConnection
    {
        public DataTable GetCustomers()
        {
            mHasException = false;
            var dtCustomers = new DataTable();

            try
            {
                using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                    {
                        cmd.CommandText = "SELECT CustomerIdentifier,CompanyName,ContactName,ContactTitle,[Address],City,PostalCode,Country " + 
                                          "FROM dbo.Customers";

                        try
                        {
                            cn.Open();
                            dtCustomers.Load(cmd.ExecuteReader());

                        }
                        catch (SqlException sqlException)
                        {
                            mHasException = true;
                            mLastException = sqlException;
                        }
                        catch (Exception generalException)
                        {
                            mHasException = true;
                            mLastException = generalException;
                        }
                    }
                }
            }
            catch (Exception generalException)
            {
                mHasException = true;
                mLastException = generalException;
            }

            return dtCustomers;
        }

        public List<Person> GetPeople()
        {
            mHasException = false;

            var personList = new List<Person>();

            using (SqlConnection cn = new SqlConnection() {ConnectionString = ConnectionString})
            {
                using (SqlCommand cmd = new SqlCommand() {Connection = cn})
                {
                    cmd.CommandText = "SELECT P.Id, P.FirstName, P.LastName, P.Gender, P.BirthDay, Gender.Role " +
                                      "FROM People AS P INNER JOIN Gender ON P.Gender = Gender.id";
                    try
                    {
                        cn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            personList.Add(new Person()
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Gender = reader.GetInt32(3),
                                BirthDay = reader.GetDateTime(4),
                                Role = reader.GetString(5)
                            });
                        }
                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }
                }
                
                return personList;
            }
        }
    }
}
