using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.IDAL;
using Test.Model;
using System.Data.SqlClient;
using Test.Helper;
using Microsoft.ApplicationBlocks.Data;

namespace Test.SQLServerDAL
{
    public class Emp : IEmp
    {
        public List<EmpInfo> GetEmps()
        {
            List<EmpInfo> items = new List<EmpInfo>();

            using (SqlDataReader dr = SqlHelper.ExecuteReader(Global.EmpConnectionString, "[dbo].[spGetEmps]"))
            {
                while (dr.Read())
                {
                    EmpInfo item = new EmpInfo();

                    getItem(dr, item);
                    items.Add(item);

                }

                return items;
            }
        }

        private EmpInfo getItem(SqlDataReader dr, EmpInfo item)
        {
            item.Id = (int)dr["Id"];
            item.Name = dr["Name"].ToString();

            return item;
        }
    }
}
