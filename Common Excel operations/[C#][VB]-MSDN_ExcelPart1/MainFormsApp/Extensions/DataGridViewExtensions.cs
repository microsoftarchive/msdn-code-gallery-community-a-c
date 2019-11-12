using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConcreteLibrary;
using System.Data;

namespace MainForm.Extensions
{
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Expand all columns and suitable for working with
        /// Entity Framework
        /// </summary>
        /// <param name="sender"></param>
        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                // ensure we are not attempting to do this on a Entity
                if (col.ValueType.Name != "ICollection`1")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        public static List<Person> GetPeopleList(this System.Data.DataTable pDataTable)
        {
            var peopleList = new List<Person>();

            foreach (DataRow row in pDataTable.Rows)
            {
                peopleList.Add(new Person()
                {
                    Id = Convert.ToInt32(row.Field<string>("idColumn")),
                    FirstName = row.Field<string>("FirstNameColumn"),
                    LastName = row.Field<string>("LastNameColumn"),
                    BirthDay = Convert.ToDateTime(row.Field<string>("BirthDayColumn")),
                    Role = row.Field<string>("RoleColumn"), Gender = Convert.ToInt32(row.Field<string>("GenderValueColumn"))
                });
            }
            return peopleList;
        }
    }
}
