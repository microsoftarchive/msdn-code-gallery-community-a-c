using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Domain;
using System.Data;

namespace Session
{
    public class Broker
    {
        // connection declaration using oledb
        OleDbConnection connection;
        OleDbCommand command;
        // declaring database source and path
        private void connectTo()

        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\Users\mdjul\Desktop\Management\DataBase.accdb;Persist Security Info=False");
            command = connection.CreateCommand();
        }
        public Broker()
        {
            connectTo();
        }
        // inserting values in the database table
        public void insert(Inventory i)
        {
            try
            {
                command.CommandText = "INSERT INTO InvetoryManagement(ItemName,SerialNum,ItemCompany,ClientCom,OrderId,DateOrder,DateShip,ModelNum,Type,MaitenDate,Price) VALUES('" + i.Item + "','" + i.Serial + "','" + i.Company + "','" + i.ClientCom + "','" + i.Order + "','" + i.DOrder + "','" + i.DShip + "','" + i.Model + "','" + i.Type + "','" + i.DMan + "','"+i.Price+"')";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        // refreshing the search list for updating. I have mentioned here the SELECT all from Table so that I can change the search menu later according to further changes
        public List<Inventory> edit()
        {
            List<Inventory> inventoryList = new List<Inventory>();

            try
            {
                command.CommandText = "SELECT * FROM InvetoryManagement";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Inventory i = new Inventory();
                    i.Item = reader["ItemName"].ToString();
                    i.Serial = reader["SerialNum"].ToString();
              //    i.Company = reader["ItemCompany"].ToString();
              //    i.Model = reader["ModelNum"].ToString();
                    i.Type = reader["Type"].ToString();
             //     i.ClientCom = reader["ClientCom"].ToString();
            //      i.Order = reader["OrderId"].ToString();
            //      i.DOrder = reader["DateOrder"].ToString();
                    i.DShip = reader["DateShip"].ToString();
            //      i.DMan = reader["MaitenDate"].ToString();
                    inventoryList.Add(i);
                }

                return inventoryList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        //here i am updating the information in the access database
        public void NewData(Inventory oldInventory, Inventory newInventory)
        {
            try
            {
                command.CommandText = "UPDATE InvetoryManagement SET ItemName='" + newInventory.Item + "',ItemCompany='" + newInventory.Company + "',Type='" + newInventory.Type + "',ModelNum='" + newInventory.Model + "',DateShip='" + newInventory.DShip + "' WHERE SerialNum='" + oldInventory.Serial + "';";
                command.CommandType = CommandType.Text;
                connection.Open();
               
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        //Delete the Inventory
        public void delete(Inventory i)
        {
            try
            {
                command.CommandText = "DELETE FROM InvetoryManagement WHERE SerialNum='"+i.Serial+"'";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        

      
    }
}




