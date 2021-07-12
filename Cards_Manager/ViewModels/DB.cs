using System;
using MySqlConnector;
namespace Cards_Manager.ViewModels
{
    public class DB
    {
        MySqlConnection Connection = new MySqlConnection
            ("server=localhost;port = 8889;username =root;password=root;database=CARDS");
        public void OpenConnection()
        {
            if(Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
        public MySqlConnection GetConnection()
        {
            return Connection;
        }
       
    }
}
