using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBAccess
{
  public  class DALStudentDetails
  {
      #region "Variable Declaration"

      string str_SqlQuery = string.Empty;

      #endregion

      #region "Get Details"

      public string GetDetais()
      {
          try
          {
              str_SqlQuery = "select pk_id,StudName,StudTotal from student";

              return str_SqlQuery;
          }
          catch (Exception)
          {

              throw;
          }
      }
      #endregion

      #region "Add Details"
      public string AddDetails(string SName,int STotal )
      {
          try
          {
              str_SqlQuery = "insert into student (StudName,StudTotal) values ('" + SName + "','" + STotal + "') ";

              return str_SqlQuery;
          }
          catch (Exception)
          {

              throw;
          }
      }
      #endregion

      #region "Update Details"
      public string UpdateDetails(string SName, int STotal, int SPk_id)
      {
          try
          {
              str_SqlQuery = "update student set StudName='" + SName + "',StudTotal='" + STotal + "'  where  Pk_id='" + SPk_id + "' ";

              return str_SqlQuery;
          }
          catch (Exception)
          {

              throw;
          }
      }
      #endregion

      #region "Delete Details"
      public string DeleteDetails(int SPk_id)
      {
          try
          {
              str_SqlQuery = "delete from  student  where Pk_id='" + SPk_id + "'";

              return str_SqlQuery;
          }
          catch (Exception)
          {

              throw;
          }
      }
      #endregion
  }
}
