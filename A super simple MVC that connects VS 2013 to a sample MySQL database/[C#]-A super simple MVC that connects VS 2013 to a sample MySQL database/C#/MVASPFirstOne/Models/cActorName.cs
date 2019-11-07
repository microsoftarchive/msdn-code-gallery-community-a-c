//********Copy Code Starting Here ********
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MVCASPFirstOne.Models
{
    public class cActorName
    {
        public int actor_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string last_update { get; set; }

        //private bool connection_open;
        private MySqlConnection connection;

        public cActorName()
        {    
        } 
        public cActorName(int arg_id)
        {
            Get_Connection();
            actor_id = arg_id;
	        try
	        {
                MySqlCommand cmd = new MySqlCommand();
		        cmd.Connection = connection;
                cmd.CommandText = string.Format("SELECT first_name, last_name FROM actor WHERE (actor_id = 1)");
        
		        MySqlDataReader reader = cmd.ExecuteReader();    
		    try
		    {
			    reader.Read();

			    if (reader.IsDBNull(0) == false)
				    first_name = reader.GetString(0); 
			    else
				    first_name = null;

                if (reader.IsDBNull(1) == false)
                    last_name = reader.GetString(1);
                else
                    last_name = null;           
                reader.Close();
		    }
		    catch (MySqlException e)
		    {
			    string  MessageString = "Read error occurred " + e.ErrorCode + " - " + e.Message + ";";
			    reader.Close();
		    }
	        }
	        catch (MySqlException e)
	        {
			    string  MessageString = "The following error occurred "
				    + e.ErrorCode + " - " + e.Message;
                first_name = "Marvelous Gentleman";//MessageString;
                last_name = last_update = null;
		     }
        }     
        private void Get_Connection()
        {
            connection = new MySqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn_sakila"].ConnectionString;
            Open_Local_Connection();  
        }

        private bool Open_Local_Connection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
//********Stop Copying Code Here ********